using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HTTPServer
{
    public enum RequestMethod
    {
        GET,
        POST,
        HEAD
    }

    public enum HTTPVersion
    {
        HTTP10,
        HTTP11,
        HTTP09
    }

    class Request
    {
        string[] requestLines;
        RequestMethod method;
        public string relativeURI;
        Dictionary<string, string> headerLines;

        public Dictionary<string, string> HeaderLines
        {
            get { return headerLines; }
        }

        HTTPVersion httpVersion;
        string requestString;
        string[] contentLines;

        public Request(string requestString)
        {
            this.requestString = requestString;
        }
        /// <summary>
        /// Parses the request string and loads the request line, header lines and content, returns false if there is a parsing error
        /// </summary>
        /// <returns>True if parsing succeeds, false otherwise.</returns>
        /// 

        // Mirna
        public bool ParseRequest()
        {
            //throw new NotImplementedException();

            //TODO: parse the receivedRequest using the \r\n delimeter   
            
            // check that there is atleast 3 lines: Request line, Host Header, Blank line (usually 4 lines with the last empty line for empty content)

            // Parse Request line

            // Validate blank line exists

            // Load header lines into HeaderLines dictionary
            return true;
        }

        // Esraa
        private bool ParseRequestLine()
        {
            string[] requestLine_parts = requestString.Split(' ');
            if (requestLine_parts[0] == "GET")
                method = RequestMethod.GET;
            else if (requestLine_parts[0] == "POST")
                method = RequestMethod.POST;
            else if (requestLine_parts[0] == "HEAD")
                method = RequestMethod.HEAD;
            else
                return false;

            if (ValidateIsURI(requestLine_parts[1]))
                relativeURI = requestLine_parts[1];
            else
                return false;

            if (requestLine_parts[2] == "HTTP09")
                httpVersion = HTTPVersion.HTTP09;
            else if (requestLine_parts[2] == "HTTP10")
                httpVersion = HTTPVersion.HTTP10;
            else if (requestLine_parts[2] == "HTTP11")
                httpVersion = HTTPVersion.HTTP11;
            else
                return false;

            return true;
        }

        private bool ValidateIsURI(string uri)
        {
            return Uri.IsWellFormedUriString(uri, UriKind.RelativeOrAbsolute);
        }

        // Mirna
        private bool LoadHeaderLines()
        {
            throw new NotImplementedException();
        }

        // Mohie
        private bool ValidateBlankLine()
        {
            throw new NotImplementedException();
        }

    }
}
