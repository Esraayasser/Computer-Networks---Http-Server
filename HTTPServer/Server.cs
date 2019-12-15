using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.IO;

namespace HTTPServer
{
    class Server
    {
        Socket serverSocket;

        public Server(int portNumber, string redirectionMatrixPath)
        {
            //TODO: call this.LoadRedirectionRules passing redirectionMatrixPath to it
            this.LoadRedirectionRules("redirectionRules.txt");
            //TODO: initialize this.serverSocket
            serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            serverSocket.Bind(new IPEndPoint(IPAddress.Any, portNumber));
        }

        // Mirna
        public void StartServer()
        {
            // TODO: Listen to connections, with large backlog.

            // TODO: Accept connections in while loop and start a thread for each connection on function "Handle Connection"
            while (true)
            {
                //TODO: accept connections and start thread for each accepted connection.

            }
        }

        // Eman
        public void HandleConnection(object obj) 
        {
            // TODO: Create client socket 
            Socket clientSocket = serverSocket.Accept();

            // set client socket ReceiveTimeout = 0 to indicate an infinite time-out period
            clientSocket.ReceiveTimeout = 0;

            // TODO: receive requests in while true until remote client closes the socket.
            while (true)
            {
                try
                {
                    // TODO: Receive request
                    byte []requestReceived = new byte[5000];
                    int receivedBytesLength = serverSocket.Receive(requestReceived); //check meen elly bey recieve, server socket wala client socket

                    // TODO: break the while loop if receivedLen==0
                    if (receivedBytesLength == 0)
                        break;

                    // TODO: Create a Request object using received request string
                    string requestString = Encoding.ASCII.GetString(requestReceived);
                    Request requestOfClient = new Request(requestString);

                    // TODO: Call HandleRequest Method that returns the response
                    Response responseOfServer = HandleRequest(requestOfClient);

                    // TODO: Send Response back to client
                    byte[] responseByteArray = new byte[responseOfServer.ResponseString.Length];
                    responseByteArray = Encoding.ASCII.GetBytes(responseOfServer.ResponseString);
                    clientSocket.Send(responseByteArray);
                }
                catch (Exception ex)
                {
                    // TODO: log exception using Logger class
                    Logger.LogException(ex);
                }
            }

            // TODO: close client socket
            clientSocket.Close();
        }

        // Awad
        Response HandleRequest(Request request)
        {
            throw new NotImplementedException();
            string content;
            try
            {
                //TODO: check for bad request 
                //TODO: map the relativeURI in request to get the physical path of the resource.
                //TODO: check for redirect

                //TODO: check file exists

                //TODO: read the physical file

                // Create OK response
            }
            catch (Exception ex)
            {
                // TODO: log exception using Logger class
                // TODO: in case of exception, return Internal Server Error. 
            }
        }

        // Eman
        private string GetRedirectionPagePathIFExist(string relativePath)
        {
            // using Configuration.RedirectionRules return the redirected page path if exists else returns empty
            if (Configuration.RedirectionRules.ContainsKey(relativePath))
                return Configuration.RedirectionRules[relativePath];
            return string.Empty;
        }

        // Mohie
        private string LoadDefaultPage(string defaultPageName)
        {
            string filePath = Path.Combine(Configuration.RootPath, defaultPageName);
            // TODO: check if filepath not exist log exception using Logger class and return empty string
            
            // else read file and return its content
            return string.Empty;
        }

        // Esraa
        private void LoadRedirectionRules(string filePath)
        {
            try
            {
                // TODO: using the filepath paramter read the redirection rules from file 
                if (File.Exists(filePath))
                {
                    // then fill Configuration.RedirectionRules dictionary 
                    using (StreamReader sr = File.OpenText(filePath))
                    {
                        string s = "";
                        while ((s = sr.ReadLine()) != null)
                            Configuration.RedirectionRules.Add(s.Split(',')[0], s.Split(',')[1]);
                    }
                }
            }
            catch (Exception ex)
            {
                // TODO: log exception using Logger class
                Logger.LogException(ex);
                Environment.Exit(1);
            }
        }
    }
}
