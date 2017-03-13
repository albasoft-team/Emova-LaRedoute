using safeprojectname.ServiceReference2;
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
    abstract class WSOffres
    {
        static MainInterface ig = (MainInterface) Application.OpenForms["MainInterface"];

        static string REQUEST_BODY = @"<?xml version=""1.0"" encoding=""UTF-8""?><SOAP-ENV:Envelope xmlns:SOAP-ENV=""http://schemas.xmlsoap.org/soap/envelope/""><SOAP-ENV:Body><attachment/></SOAP-ENV:Body></SOAP-ENV:Envelope>";
        static string REQUEST_BEGIN = @"<soapenv:Envelope xmlns:soapenv=""http://schemas.xmlsoap.org/soap/envelope/"" xmlns:ns=""http://RedouteFrance/seller/items/1.1""><soapenv:Header/><soapenv:Body><ns:injectItems><api-key>";
        static string REQUEST_END = "</api-key></ns:injectItems></soapenv:Body></soapenv:Envelope>";

        internal static void makeSoapRequest(string filename,string postData) {
            var request = (HttpWebRequest)WebRequest.Create(Program.Offers.wsURL);
            //request.ContentType = "application/soap+xml; charset=utf-8";
            request.Method = "POST";

            //Accept - Encoding: 
            // request.Timeout = 10000;
            //request.Credentials = new NetworkCredential(Program.Products.username, Program.Products.password);
            
            request.Headers.Add("Accept-Encoding", "gzip,deflate");
            request.Headers.Add("SoapAction", "InjectFile_1.0");
            request.Accept = "application/soap+xml";//"text/xml, text/html, image/gif, image/jpeg, *; q=.2, */*; q=.2";
            request.Headers.Add("Authorization", "Basic "+FileUtilities.Base64Encode(Program.Offers.username+":"+Program.Offers.password));

           // request.KeepAlive = true;

            request.Headers.Add("mime-version", "1.0");
            request.Expect=null;
            //préparation de la requête SOAP Attachment

            request.ContentType = @"Multipart/Related;boundary=emova;type=""application/soap+xml""charset=""utf-8"";start=""<main_envelope>""";
            
            var requestData = composeMessage(filename,postData);
            byte[] info = new UTF8Encoding(true).GetBytes(requestData);
            request.ContentLength = info.Length;
            ig.setRichTextBox("\n------- requête d'envoi des offres \n" + requestData, false, Parameters.offerId);
            using (Stream stream = request.GetRequestStream())
            {
                
               /* stream.Write(info, 0, info.Length);
                stream.Close();*/
                using (var writer = new StreamWriter(stream))
                {
                  writer.Write(requestData);
                }
            }

            portTypeClient client = new portTypeClient();
            //string response = client.InjectFileToOverride_10Op(Program.Globals.vendorId, "400", "MKP_SellerOffer", "001", Path.GetFileNameWithoutExtension(filename), Path.GetDirectoryName(filename), 0, true);
            string bacchid = null;
            ErrorType err = null;
            client.Open();
            bool response = client.InjectFile_10Op(Program.Globals.vendorId, "400", "MKP_SellerOffer", "001", Path.GetFileName(filename), "", 1, true, null, true, out bacchid, out err);

            ig.setRichTextBox("\n\n-------Response = " + response, false, Parameters.offerId);
            ig.setRichTextBox("\n\n-------Bacchid = " + bacchid, false, Parameters.offerId);
            ig.setRichTextBox("\n\n-------Erreur = " + err.Message, false, Parameters.offerId);
            
            //InjectFile_10OpRequest req = new InjectFile_10OpRequest(Program.Globals.vendorId, "400", "MKP_SellerOffer", "001", Path.GetFileNameWithoutExtension(filename), Path.GetDirectoryName(filename),0, true,null,true);
            /*InjectFile_10OpResponse resp = req.
            resp.*/
            /*
             try
             {
                 WebResponse response = request.GetResponse();

                 using (Stream stream = response.GetResponseStream())
                 {
                     StreamReader reader = new StreamReader(stream, Encoding.UTF8);
                     String responseString = reader.ReadToEnd();
                     ig.setRichTextBox("\n\n-------Response du web service offres = \n" + responseString, false, Parameters.offerId);
                 }
                 response.Close();
             }
             catch (Exception e)
             {

                 ig.setRichTextBox("\nUne erreur s'est produite : " + e.Message, false, Parameters.offerId);
             }*/


        }
        
        internal static string composeMessage(string filename,string content) {
            string crlf = "\n\n"; //System.Environment.
            string cr = System.Environment.NewLine;

            FileInfo info = new FileInfo(filename);
            


            string soapMsg = cr+"--emova" + cr; 
            soapMsg += "Content-ID:<main_envelope>" + cr;
            //soapMsg += "Content-Transfer-Encoding: 8bit"+cr;
            soapMsg += "Content-Type: application/soap+xml; charset=UTF-8" + crlf;

           // soapMsg += REQUEST_BEGIN + Program.Globals.apiKey + REQUEST_END;
            soapMsg += "<?xml version = '1.0'?>" + cr;
            //
            soapMsg += @"<SOAP-ENV:Envelope xmlns:SOAP-ENV = ""http://www.w3.org/2003/05/soap-envelope"" xmlns:ns = ""http://Redcats/File/ESB-TIBCO/File/1.0/InjectFile/1.0"" > <SOAP-ENV:Header/>";
            soapMsg += @"<SOAPENV:Body> <ns:InjectFileRequest_1.0>" + cr + "<ns:EUserId>" + Program.Globals.vendorId + "</ns:EUserId>";
            soapMsg += @"<ns:ESystem>400</ns:ESystem>"+cr+ "<ns:FlowName>MKP_SellerOffer</ns:FlowName>" + cr;
            soapMsg += @"<ns:FlowVersion >001</ ns:FlowVersion>" + cr;
            soapMsg += @"<ns:FileName>"+ Path.GetFileNameWithoutExtension(filename) + ".xml</ns:FileName>" + cr;
            soapMsg += @"<ns:fileAttachedWithSoapMsg>true</ns:fileAttachedWithSoapMsg>" + cr;
           // soapMsg += @"<ns:FunctionalValidationInformation>" + cr;
           // soapMsg += @"</ns:FunctionalValidationInformation>" + cr;
            soapMsg += @"</ns:InjectFileRequest_1.0> </SOAP-ENV:Body>" + cr;
            soapMsg += @"</SOAP-ENV:Envelope>" + cr;

            soapMsg += "--emova" + cr;
           // soapMsg += "Content-ID: <"+ boundary + ">" + crlf;
            soapMsg += "Content-ID:<attachment>" + cr;
            soapMsg += "Content-Type: text/xml;charset=UTF-8" + cr;
            soapMsg += "Content-Transfer-Encoding:" + cr;
            soapMsg += @"Content-Disposition:attachment;name=""" + Path.GetFileNameWithoutExtension(filename) + @".xml"";filename=""" + Path.GetFileNameWithoutExtension(filename) + @".xml""" +cr;
            soapMsg += @"Disposition-type:inline;" + crlf;
            soapMsg += content;//"@a!+s1dw32w16qw...your - binary - file…s + 61...";
            soapMsg += cr+"--emova--"+ cr;
            return soapMsg;
        }

        private static string getFileName(string filename)
        {
            return Program.Globals.vendorId + "." + filename+".001." + DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss");
        }

        internal static void createXMLFile(string filename) {
            OfferFile Offer = new OfferFile(filename);
            string fileContent = "";
            string fileDest = Program.Offers.destination + getFileName("MKP_SellerOffer") + ".xml";
            //Create the file.
            try
            {
                using (FileStream file = File.Create(fileDest))
                {
                    fileContent = Offer.getXMLString();
                    AddText(file, fileContent);
                    file.Close();
                    makeSoapRequest(fileDest, fileContent);
                }
            }
            catch (Exception e)
            {

                ig.setRichTextBox("\nUne erreur s'est produite : " + e.Message,false,Parameters.offerId);
            }
           
        }

        private static void AddText(FileStream fs, string value)
        {
            byte[] info = new UTF8Encoding(true).GetBytes(value);
            fs.Write(info, 0, info.Length);
        }
    }
}
