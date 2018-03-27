using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;

class Connect_to_gadget
{
    static public string ippp = "192.168.1.5";
 static public  string message = "";
    static public void SendMessageFromSocket(int port)
    {
        byte[] bytes = new byte[1024];
        IPHostEntry ipHost = Dns.GetHostEntry(ippp);
        IPAddress ipAddr = ipHost.AddressList[0];
        IPEndPoint ipEndPoint = new IPEndPoint(ipAddr, port);
        Socket sender = new Socket(ipAddr.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
        sender.Connect(ipEndPoint);
      
        Class_Function.obj_list_presentation.listBox.Items.Add("Сокет соединяется с {0} "+ sender.RemoteEndPoint.ToString());
       // Console.WriteLine("Сокет соединяется с {0} ", sender.RemoteEndPoint.ToString());
        byte[] msg = Encoding.UTF8.GetBytes(message);
        int bytesSent = sender.Send(msg);
        int bytesRec = sender.Receive(bytes);
        Console.WriteLine("\nОтвет от сервера: {0}\n\n", Encoding.UTF8.GetString(bytes, 0, bytesRec));
        if (message.IndexOf("<TheEnd>") == -1)
            SendMessageFromSocket(port);
        sender.Shutdown(SocketShutdown.Both);
        sender.Close();
    }




}

