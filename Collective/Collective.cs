using System;
using System.Drawing;
using System.Net;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

namespace Collective
{
    public class Person
    {
        public string Name { get; set; }
        public string SurName { get; set; }
        public string Jobs { get; set; }
        public int Date { get; set; }
        public Person(string newNane, string newSurname, string newJobs, int newDate)
        {
            Name = newNane;
            SurName = newSurname;
            Jobs = newJobs;
            Date = newDate;
        }
    }

    public enum Commad : ushort { Message, Obje, Image }

    public class PackagePrinter : BinaryWriter
    {
        MemoryStream ms;
        BinaryFormatter bf;
        public PackagePrinter() : base()
        {
            ms = new MemoryStream();
            bf = new BinaryFormatter();
            OutStream = ms;
        }
        public byte[] ByteBring()
        {
            Close();
            return ms.ToArray();
        }
        public void SummerImage(byte[] data)
        {
            Write(data.Length);
            Write(data);
        }
        public void SummerObje(object o)
        {
            bf.Serialize(ms, o);
        }
    }

    public class PackageReader : BinaryReader
    {
        BinaryFormatter bf;
        public PackageReader(MemoryStream ms) : base(ms)
        {
            bf = new BinaryFormatter();
        }
        public Image ReaderImage()
        {
            int i = ReadInt32();
            byte[] data = ReadBytes(i);
            MemoryStream m = new MemoryStream(data);
            return Image.FromStream(m);
        }
        public T ReaderObje<T>()
        {
            return (T)bf.Deserialize(BaseStream);
        }
    }

    public struct MemorySave
    {
        public int ComeDateLenght;
        public byte[] ComeData;
        public MemoryStream ComeDateStream;
        public MemorySave(int newComeDateLenght)
        {
            ComeDateLenght = newComeDateLenght;
            ComeData = new byte[1024];
            ComeDateStream = new MemoryStream(ComeDateLenght);

        }
        public void Summer(int newComeData)
        {
            ComeDateStream.Write(ComeData, 0, newComeData);
            Array.Clear(ComeData, 0, ComeData.Length);
            ComeDateLenght -= newComeData;
        }
        public void Dispose()
        {
            ComeDateLenght = 0;
            ComeData = null;
            Close();
            if (ComeDateStream != null)
            {
                ComeDateStream.Dispose();
            }
        }
        public void Close()
        {
            if (ComeDateStream != null && ComeDateStream.CanWrite)
            {
                ComeDateStream.Close();
            }
        }
    }

    public class ClientManagment
    {
        public delegate void DisconnectedH(ClientManagment sender);
        public delegate void DataTransferCompletedH(ClientManagment sender, MemorySave e);
        public event DisconnectedH DisconnetedProvide;
        public event DataTransferCompletedH DataTransferCompletedProvide;

        byte[] comeBYT;
        MemorySave memorySave;
        Socket socket;

        public IPEndPoint EndPoint
        {
            get
            {
                if (socket != null && socket.Connected)
                {
                    return (IPEndPoint)socket.RemoteEndPoint;
                }
                return new IPEndPoint(IPAddress.None, 0);
            }
        }

        public ClientManagment(Socket s)
        {
            socket = s;
            comeBYT = new byte[4];
        }

        public void Close()
        {
            if (socket != null)
            {
                socket.Disconnect(false);
                socket.Close();
            }
            memorySave.Dispose();
            socket = null;
            DisconnetedProvide = null;
            DataTransferCompletedProvide = null;
        }
        public void AsynchronousTransferStart()
        {
            socket.BeginReceive(comeBYT, 0, comeBYT.Length, SocketFlags.None, ComeDataExtent, null);
        }

        private void ComeDataExtent(IAsyncResult ar)
        {
            try
            {
                int i = socket.EndReceive(ar);
                if (i == 0)
                {
                    if (DisconnetedProvide != null)
                    {
                        DisconnetedProvide(this);
                        return;
                    }
                    if (i == 4)
                    {
                        throw new Exception();
                    }
                }
            }
            catch (Exception)
            {
                if (DisconnetedProvide != null)
                {
                    DisconnetedProvide(this);
                    return;
                }
            }

            memorySave = new MemorySave(BitConverter.ToInt32(comeBYT, 0));
            socket.BeginReceive(memorySave.ComeData, 0, memorySave.ComeData.Length, SocketFlags.None, DataTransfers, null);
        }

        private void DataTransfers(IAsyncResult ar)
        {
            try
            {
                int i = socket.EndReceive(ar);
                if (i <= 0)
                {
                    return;
                }
                memorySave.Summer(i);
                if (memorySave.ComeDateLenght > 0)
                {
                    socket.BeginReceive(memorySave.ComeData, 0, memorySave.ComeData.Length, SocketFlags.None, DataTransfers, null);
                    return;
                }
                if (DataTransferCompletedProvide != null)
                {
                    memorySave.ComeDateStream.Position = 0;
                    DataTransferCompletedProvide(this, memorySave);
                }
                memorySave.Dispose();
                AsynchronousTransferStart();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }

    public class ServerManagment
    {
        public delegate void ConnectedClientH(Socket s);
        public event ConnectedClientH ConnectedClientProviode;
        Socket socket;
        int port;
        public bool ConnectedCase
        {
            get;
            private set;
        }

        public ServerManagment(int newPort)
        {
            port = newPort;
        }

        public void StartServer(IPAddress ip)
        {
            if (ConnectedCase)
            {
                return;
            }
            socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            socket.Bind(new IPEndPoint(ip, port));            
            socket.Listen(0);
            socket.BeginAccept(WhenConnected, null);
        }


        /*
        public string GetLocalIPAddress()
        {
            var host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (var ip in host.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    return ip.ToString();
                }
            }
            throw new System.Exception("No network adapters with an IPv4 address in the system!");
        }
        */

        private void WhenConnected(IAsyncResult ar)
        {
            try
            {
                Socket s = socket.EndAccept(ar);
                if (ConnectedClientProviode != null)
                {
                    ConnectedClientProviode(s);
                }
            }
            catch (Exception)
            {

                throw;
            }
            if (ConnectedCase)
            {
                socket.BeginAccept(WhenConnected, null);
            }
        }

        public void StopServer()
        {
            if (!ConnectedCase)
            {
                return;
            }
            socket.Close();
            ConnectedCase = false;
        }
    }

    public class Terminal
    {
        public delegate void ConnectProvideH(Terminal sender, bool connectCase);
        public delegate void DisconnectProvideH(Terminal sender);
        public delegate void SenderDataH(Terminal sender, int sent);
        public event ConnectProvideH ConnectProvide;
        public event DisconnectProvideH DisconnectProvide;
        public event SenderDataH SenderDataProvide;
        Socket socket;
        public bool ConnectCase
        {
            get
            {
                if (socket != null)
                {
                    return socket.Connected;
                }
                return false;
            }
        }

        public Terminal()
        {
            socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        }

        public void Connect(string newIp, int newPort)
        {
            if (socket == null)
            {
                socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            }
            socket.BeginConnect(newIp, newPort, Connected, null);
        }
        private void Connected(IAsyncResult ar)
        {
            try
            {
                socket.EndConnect(ar);
                if (ConnectProvide != null)
                {
                    ConnectProvide(this, ConnectCase);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Send(byte[] data, int Size)
        {
            socket.BeginSend(BitConverter.GetBytes(Size), 0, 4, SocketFlags.None, SenderingData, null);
            socket.BeginSend(data, 0, data.Length, SocketFlags.None, SenderingData, null);
        }

        private void SenderingData(IAsyncResult ar)
        {
            try
            {
                int senddata = socket.EndSend(ar);
                if (SenderDataProvide != null)
                {
                    SenderDataProvide(this, senddata);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }


        private void Disconnected()
        {
            try
            {
                if (socket.Connected)
                {
                    socket.Close();
                    if (DisconnectProvide != null)
                    {
                        DisconnectProvide(this);
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

    }

}
