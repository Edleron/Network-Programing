using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.Net.NetworkInformation;
using Collective;

namespace NetWoorkProgramlama
{
    public partial class MainServer : Form
    {
        ServerManagment snc;
        ClientManagment cln;
        public MainServer()
        {
            InitializeComponent();
            CardsList();
            //StartServerButton.Click += StartServerButton_Click;
        }

        private void StartServerButton_Click(object sender, EventArgs e)
        {
            //snc = new ServerManagment(8899);
            snc = new ServerManagment(1733);
            snc.ConnectedClientProviode += Snc_ConnectedProvide;
            snc.StartServer((IPAddress)ComeAdapterCmbBox.SelectedValue);
            this.Text = "Server - " + ((IPAddress)ComeAdapterCmbBox.SelectedValue).ToString();
            GroupServerF1.Enabled = false;
        }

        private void Snc_ConnectedProvide(Socket s)
        {
            if (cln != null)
            {
                s.Close();
                return;
            }
            cln = new ClientManagment(s);
            cln.DisconnetedProvide += Cln_DisconnetedProvide;
            cln.DataTransferCompletedProvide += Cln_DataTransferCompletedProvide;
            cln.AsynchronousTransferStart();
            Invoke((MethodInvoker)delegate
            {
                ServerStatus.Text = "Bağlandı - " + cln.EndPoint.ToString();
            });

        }

        private void Cln_DataTransferCompletedProvide(ClientManagment sender, MemorySave e)
        {
            PackageReader po = new PackageReader(e.ComeDateStream);
            Commad k = (Commad)po.ReadUInt16();
            switch (k)
            {
                case Commad.Message:
                    Invoke((MethodInvoker)delegate
                    {
                        ComeMessageText.Text = po.ReadString();
                    });
                    break;
                case Commad.Obje:
                    Person v = (Person)po.ReaderObje<Person>();
                    Invoke((MethodInvoker)delegate
                    {
                        ComeNameText.Text = v.Name;
                        ComeSurnameText.Text = v.SurName;
                        ComeJobsText.Text = v.Jobs;
                        ComeDateText.Text = v.Date.ToString();
                    });
                    break;
                case Commad.Image:
                    Invoke((MethodInvoker)delegate
                    {
                        ComeImageBox.Image = po.ReaderImage();
                    });
                    break;
                default:
                    break;
            }
        }

        private void Cln_DisconnetedProvide(ClientManagment sender)
        {
            cln.Close();
            cln = null;
        }


        private void CardsList()
        {
            Dictionary<string, IPAddress> cmdSource = new Dictionary<string, IPAddress>();
            foreach (NetworkInterface NI in NetworkInterface.GetAllNetworkInterfaces())
            {
                foreach (UnicastIPAddressInformation IP in NI.GetIPProperties().UnicastAddresses)
                {
                    if (IP.Address.AddressFamily == AddressFamily.InterNetwork)
                    {
                        cmdSource.Add(IP.Address.ToString() + " - " + NI.Description, IP.Address);
                    }
                }
            }
            ComeAdapterCmbBox.DataSource = new BindingSource(cmdSource, null);
            ComeAdapterCmbBox.DisplayMember = "Key";
            ComeAdapterCmbBox.ValueMember = "Value";
        }


    }
}
