using System;
using System.IO;
using System.Net;

namespace DesignPatterns.Command
{
    public class FtpFileOperator : IFileOperator
    {
        private readonly Uri m_ServerUri;

        public FtpFileOperator(Uri serverUri)
        {
            if (serverUri.Scheme != Uri.UriSchemeFtp)
                throw new ArgumentException("The serverUri parameter should use the ftp:// scheme.");
            m_ServerUri = serverUri;
        }

        public void Create(string fileName)
        {
            var fileUri = new Uri(m_ServerUri, fileName);
            var request = (FtpWebRequest) WebRequest.Create(fileUri);
            request.Method = WebRequestMethods.Ftp.UploadFile;
            using (Stream requestStream = request.GetRequestStream())
            using (var writer = new StreamWriter(requestStream))
            {
                writer.WriteLine("Hello world!");
            }
            request.GetResponse().Close();
        }

        public void Rename(string oldName, string newName)
        {
            var oldUri = new Uri(m_ServerUri, oldName);
            var request = (FtpWebRequest) WebRequest.Create(oldUri);
            request.Method = WebRequestMethods.Ftp.Rename;
            request.RenameTo = newName;
            request.GetResponse().Close();
        }

        public void Delete(string fileName)
        {
            var fileUri = new Uri(m_ServerUri, fileName);
            var request = (FtpWebRequest) WebRequest.Create(fileUri);
            request.Method = WebRequestMethods.Ftp.DeleteFile;
            request.GetResponse().Close();
        }
    }
}