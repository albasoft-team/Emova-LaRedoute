using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace safeprojectname
{
    abstract class WSProducts
    {
        static MainInterface ig = (MainInterface) Application.OpenForms["MainInterface"];

        static string REQUEST_BODY = @"<?xml version=""1.0"" encoding=""UTF-8""?><SOAP-ENV:Envelope xmlns:SOAP-ENV=""http://schemas.xmlsoap.org/soap/envelope/""><SOAP-ENV:Body><attachment/></SOAP-ENV:Body></SOAP-ENV:Envelope>";
        static string REQUEST_BEGIN = @"<soapenv:Envelope xmlns:soapenv=""http://schemas.xmlsoap.org/soap/envelope/"" xmlns:ns=""http://RedouteFrance/seller/items/1.1""><soapenv:Header/><soapenv:Body><ns:injectItems><api-key>";
        static string REQUEST_END = "</api-key></ns:injectItems></soapenv:Body></soapenv:Envelope>";



        internal static void makeSoapRequest(string postData) {
            var request = (HttpWebRequest)WebRequest.Create(Program.Products.wsURL);
            request.ContentType = "text/xml; charset=utf-8";
            request.Method = "POST";

            //Accept - Encoding: 
            // request.Timeout = 10000;
            //request.Credentials = new NetworkCredential(Program.Products.username, Program.Products.password);
            
            //request.Headers.Add("Accept-Encoding", "*");
            request.Headers.Add("SoapAction", @"http://RedouteFrance/seller/items/1.1");

            request.Headers.Add("Authorization", "Basic "+FileUtilities.Base64Encode(Program.Products.username+":"+Program.Products.password));

            request.KeepAlive = true;            
            request.Headers.Add("mime-version", "1.0");
            request.Expect=null;
            //préparation de la requête SOAP Attachment

            request.ContentType = @"multipart/related;boundary=emova;type=text/xml;start=""<main_envelope>""";
            
            //Message SOAP
            var requestData = composeMessage(postData);
            byte[] info = new UTF8Encoding(true).GetBytes(requestData);
            request.ContentLength = info.Length;
            ig.setRichTextBox("\n-------Requête d'envoi des produits\n"+requestData, false, Parameters.productId);
            
            using (Stream stream = request.GetRequestStream())
            {
                
               /* stream.Write(info, 0, info.Length);
                stream.Close();*/
                using (var writer = new StreamWriter(stream))
                {
                  writer.Write(requestData);
                }
            }
            

            WebResponse response = request.GetResponse();

         
            using (Stream stream = response.GetResponseStream())
            {
                StreamReader reader = new StreamReader(stream, Encoding.UTF8);
                String responseString = reader.ReadToEnd();
                ig.setRichTextBox("\n\n-------Response du web services produits \n" + responseString, false, Parameters.productId);
            }
            response.Close();
        }

 
        internal static string composeMessage(string content) {
            string crlf = "\n\n"; //System.Environment.
            string cr = System.Environment.NewLine;

            string soapMsg = cr+"--emova" + cr; 
            soapMsg += "Content-ID:<main_envelope>" + cr;
            soapMsg += "Content-Type: text/xml; charset = utf-8" + crlf;
            

           // soapMsg += REQUEST_BEGIN + Program.Globals.apiKey + REQUEST_END;

            soapMsg += "<?xml version = '1.0'?>" + cr;

            soapMsg += @"<soapenv:Envelope xmlns:soapenv = ""http://schemas.xmlsoap.org/soap/envelope/"" xmlns:ns = ""http://RedouteFrance/seller/items/1.1"">" + cr;
            soapMsg += @"<soapenv:Header/>" + cr;
            soapMsg += @" <soapenv:Body><attachment/>" + cr;
            soapMsg += @"<ns:injectItems>" + cr;
            soapMsg += @" <api-key>" + Program.Globals.apiKey + "</api-key>" + cr;
            soapMsg += @"</ns:injectItems>" + cr;
            soapMsg += @" </soapenv:Body>" + cr;
            soapMsg += @"</soapenv:Envelope>" + cr;
            
            soapMsg += "--emova" + cr;
           // soapMsg += "Content-ID: <"+ boundary + ">" + crlf;
            soapMsg += "Content-ID: <attachment>" + cr;
            soapMsg += "Content-Type: application/octet-stream" + cr;
            soapMsg += "Content-Transfer-Encoding:base64" + crlf; 
            soapMsg += FileUtilities.Base64Encode(content);//"@a!+s1dw32w16qw...your - binary - file…s + 61...";
            soapMsg += cr+"--emova--"+ cr;
            return soapMsg;
        }

        internal static void createXMLFile(string filename) {
            ProductFile Product = new ProductFile(filename);
            string fileContent = "";
            string fileDest= Program.Products.destination+Path.GetFileNameWithoutExtension(filename)+ ".xml";
            //Create the file.
            using (FileStream file = File.Create(fileDest))
            {
                fileContent = Product.getXMLString();
                AddText(file, fileContent);
                file.Close();
               makeSoapRequest(fileContent);
            }     
        }

        private static void AddText(FileStream fs, string value)
        {
            byte[] info = new UTF8Encoding(true).GetBytes(value);
            fs.Write(info, 0, info.Length);
        }
    }
}
