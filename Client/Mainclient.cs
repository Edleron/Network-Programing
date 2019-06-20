using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Collective;
using System.IO;
using System.Windows.Forms;

namespace Client
{
    public partial class MainClient : Form
    {
        Terminal trm;
        public MainClient()
        {
            InitializeComponent();


            SendMesaj.Click += SendMesaj_Click;
            SendObje.Click += SendObje_Click;
            SendImages.Click += SendImages_Click;
            ServerConnected.Click += ServerConnected_Click;


            trm = new Terminal();


            trm.DisconnectProvide += Trm_DisconnectProvide;
            trm.ConnectProvide += Trm_ConnectProvide;
            trm.SenderDataProvide += Trm_SenderDataProvide;
        }




        private void Trm_SenderDataProvide(Terminal sender, int sent)
        {
            Invoke((MethodInvoker)delegate
            {
                Status.Text = "Data İletildi - " + sent.ToString();
            });
        }

        private void Trm_ConnectProvide(Terminal sender, bool connectCase)
        {
            Invoke((MethodInvoker)delegate
            {
                if (trm.ConnectCase)
                {
                    Status.Text = "Bağlantı Sağlandı";
                }
                
            });
        }
        private void Trm_DisconnectProvide(Terminal sender)
        {
            Invoke((MethodInvoker)delegate
            {
                Status.Text = "Bağlantı Koptu";
            });
        }


        private void ServerConnected_Click(object sender, EventArgs e)
        {
            if (!trm.ConnectCase)
            {
                //trm.Connect(IpBox.Text, 8899);
                trm.Connect(IpBox.Text, 1733);
                groupBox1.Enabled = false;
            }
        }


        private void SendImages_Click(object sender, EventArgs e)
        {
            using(OpenFileDialog o = new OpenFileDialog())
            {
                if (o.ShowDialog() == DialogResult.OK)
                {
                    PackagePrinter py = new PackagePrinter();
                    py.Write((ushort)Commad.Image);
                    py.SummerImage(File.ReadAllBytes(o.FileName));
                    byte[] data = py.ByteBring();
                    trm.Send(data, data.Length);
                }
            }
        }
        private void SendObje_Click(object sender, EventArgs e)
        {
            if (Namebox.Text.Length != 0 && SurnameBox.Text.Length != 0 && JobsBox.Text.Length != 0 && DateBox.Text.Length != 0)
            {
                Person v = new Person(Namebox.Text, SurnameBox.Text, JobsBox.Text, int.Parse(DateBox.Text));
                PackagePrinter py = new PackagePrinter();
                py.Write((ushort)Commad.Obje);
                py.SummerObje(v);
                byte[] data = py.ByteBring();
                trm.Send(data, data.Length);
            }
            else
            {
                MessageBox.Show("Boş Data'ları Gönderemessin");
            }
        }

        private void SendMesaj_Click(object sender, EventArgs e)
        {
            if (MessageBoxTxt.Text.Length != 0)
            {
                PackagePrinter py = new PackagePrinter();
                py.Write((ushort)Commad.Message);
                py.Write(MessageBoxTxt.Text);
                byte[] data = py.ByteBring();
                trm.Send(data, data.Length);
            }
            else
            {
                MessageBox.Show("Boş Data'ları Gönderemessin");
            }
        }   
    }
}
