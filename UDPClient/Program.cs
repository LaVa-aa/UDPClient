using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Channels;

namespace UDPClient
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("UDP Client/Sender");

            // initializing the UdpClient
            using (UdpClient socket = new UdpClient())
            {
                //null means "no object." Information about null and its usages in C#
                //include: You cannot use 0 instead of null in your programs even
                //though null is represented by the value 0.
                string message = null;

                //readline is input until the user press enter 
                message = Console.ReadLine();

                //Encoding is the process of transforming a set of Unicode characters
                //into a sequence of bytes. Opposite, decoding is the process of transforming a sequence of encoded bytes into a set of Unicode characters
                IPEndPoint EndPoint = null;

                //4 parameters are:
                //The message as a byte array
                //The length of the byte array
                //The receiver's IP address
                //The port to use
                //convert a string into a byte array
                //The message parameter is the message you want to send
                byte[] data = Encoding.UTF8.GetBytes(message);

                //Calling the send method with the 4 parameters - Client vil gerne sende en besked
                socket.Send(data, data.Length, "127.0.0.1", 5005);

                //recieve
                byte[] dataServer = socket.Receive(ref EndPoint);
                string recivedMessage = Encoding.UTF8.GetString(dataServer);

                Console.WriteLine("Server sent message: " + recivedMessage);
            }
        }
    }
}
