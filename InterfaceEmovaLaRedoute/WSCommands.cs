
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
    abstract class WSCommands
    {
        static MainInterface ig = (MainInterface) Application.OpenForms["MainInterface"];

       // static string REQUEST_BODY = @"<?xml version=""1.0"" encoding=""UTF-8""?><SOAP-ENV:Envelope xmlns:SOAP-ENV=""http://schemas.xmlsoap.org/soap/envelope/""><SOAP-ENV:Body><attachment/></SOAP-ENV:Body></SOAP-ENV:Envelope>";
       // static string REQUEST_BEGIN = @"<soapenv:Envelope xmlns:soapenv=""http://schemas.xmlsoap.org/soap/envelope/"" xmlns:ns=""http://RedouteFrance/seller/items/1.1""><soapenv:Header/><soapenv:Body><ns:injectItems><api-key>";
       // static string REQUEST_END = "</api-key></ns:injectItems></soapenv:Body></soapenv:Envelope>";

        internal static string makeSoapRequest(string flux,string SoapAction,int method) {
            var request = (HttpWebRequest)WebRequest.Create(Program.Commands.wsURL);

             request.Method = "POST";

             request.Headers.Add("SoapAction", SoapAction);
             //request.Accept = "text/xml";
             request.Headers.Add("Authorization", "Basic "+FileUtilities.Base64Encode(Program.Commands.username+":"+Program.Commands.password));


            //Message SOAP
            var requestData = "";
            if (method == 0)
            {
                requestData = composeMessageRecup(flux);
                ig.setRichTextBox("\n------- requête de récupération des commandes \n" + requestData, false, Parameters.commandId);
            }
            else if (method == 1)
            {
                requestData = flux;
                ig.setRichTextBox("\n------- requête de mise à jour des commandes\n" + requestData, false, Parameters.commandId);
            }
            /*byte[] info = new UTF8Encoding(true).GetBytes(requestData);
            request.ContentLength = info.Length;*/

            using (Stream stream = request.GetRequestStream())
            {
                
               /* stream.Write(info, 0, info.Length);
                stream.Close();*/
                using (var writer = new StreamWriter(stream))
                {
                  writer.Write(requestData);
                }
            }

            try
            {
                WebResponse response = request.GetResponse();

                using (Stream stream = response.GetResponseStream())
                {
                    StreamReader reader = new StreamReader(stream, Encoding.UTF8);
                    String responseString = reader.ReadToEnd();
                    ig.setRichTextBox("\n\n-------Response du web service \n" + responseString, false, Parameters.commandId);
                    return responseString;
                }
                response.Close();
            }
            catch (Exception e)
            {

                ig.setRichTextBox("\nUne erreur s'est produite : " + e.Message, false, Parameters.commandId);
            }
            return null;
        }
        
        internal static string composeMessageRecup(string statut) {
            string crlf = "\n\n"; //System.Environment.
            string cr = System.Environment.NewLine;

            string soapMsg = @"<?xml version=""1.0"" encoding=""UTF-8""?>";
            // soapMsg += REQUEST_BEGIN + Program.Globals.apiKey + REQUEST_END;
            // soapMsg += " <?xml version = '1.0'?>" + cr;
            soapMsg += @"<soapenv:Envelope xmlns:soapenv = ""http://schemas.xmlsoap.org/soap/envelope/"" xmlns:ns = ""http://RedouteFrance/seller/order/1.2"">" + cr;
            soapMsg += "<soapenv:Header/>" + cr;
            soapMsg += "<soapenv:Body>" + cr;
            soapMsg += "<ns:RetrieveByStatusRequest>" + cr;
            soapMsg += "<apikey>"+Program.Commands.ApiKeyRec+"</apikey>" + cr;
            soapMsg += "<Statuses>" + cr;
            soapMsg += statut + cr;
            soapMsg += "<Period>" + cr;
            soapMsg += "<minDate>"+ DateTime.Now.AddDays(-1).ToString("yyyy-MM-ddT00:00:00") + "</minDate>" + cr;
            soapMsg += "<maxDate>" + DateTime.Now.AddDays(-1).ToString("yyyy-MM-ddT23:59:59") + "</maxDate>" + cr;
            soapMsg += "</Period>" + cr;
            soapMsg += "</Statuses>" + cr;
            soapMsg += "</ns:RetrieveByStatusRequest>" + cr;
            soapMsg += "</soapenv:Body>" + cr;
            soapMsg += "</soapenv:Envelope>" + cr;
            // soapMsg += content;//"@a!+s1dw32w16qw...your - binary - file…s + 61...";
            // soapMsg += cr+"--emova--"+ cr;

            return soapMsg;
        }



        private static string getFileName(string filename)
        {
            return "flux_emove_" + filename + DateTime.Now.ToString("_yyyyMMddHHmmss");
        }


        internal static void initOdersWorkflow()
        {
            FileUtilities.sendBill(@"D:\Projects\SanarSoft\commandesLaRedoute2.xml");
            //1.Le web service récupère toutes les commandes à l’état « CREATED » à La Redoute
            ig.setRichTextBox("\n------- Récupération de toutes les commandes à l’état « CREATED » depuis La Redoute\n", false, Parameters.commandId);
            /*  string result = getOdersByStatus(Program.Statut.Created,"created");
              if (result != "Error") {
                  //'2.Il crée un flux XML où toutes les commandes sont topées « ACCEPTED » et l’envoi à La Redoute
                  ig.setRichTextBox("\n------- Acceptation de toutes les commandes par mise à jour\n", false, Parameters.commandId);
                  string fluxAccept = FileUtilities.CreateAcceptedCommands(result);
                  string resultFlux = makeSoapRequest(fluxAccept, "NewOrdersService.UpdateRequest", 1);
                  //3.	Il créé le fichier TXT attendu par Emova (STATUT ACCEPTED)
                  ig.setRichTextBox("\n------- Création du fichier TXT attendu par Emova (STATUT ACCEPTED)\n", false, Parameters.commandId);
                  FileUtilities.CreateEmovaTXTFile(result, Program.Commands.destination + getFileName("created") + ".txt");
              }
              //4.	Il récupère toutes les commandes des statuts « TOSHIP », « CANCELLED », « PAID », « REFUNDIND », « TO APPOVE », « REFUNDED », « REFUND REFUSED ».
              ig.setRichTextBox("\n------- Récupération de toutes les autres commandes depuis La Redoute\n", false, Parameters.commandId);
              result = getOdersByStatus(Program.Statut.RecupStatuts,"toship");
              if (result != "Error")
              {
                  //5.	Il crée le fichier TXT attendu par Emova avec tous les statuts récupérés.
                  ig.setRichTextBox("\n-------Création du fichier TXT attendu par Emova avec tous les statuts récupérés.\n", false, Parameters.commandId);
                  FileUtilities.CreateEmovaTXTFile(result, Program.Commands.destination + getFileName("shipped") + ".txt");
                  //6.Emova dépose un Fichier avec les demandes aux statuts « SHIPPED »,  « OUTOFSTOCK » et éventuellement « TOREFUND »
                  ig.setRichTextBox("\n-------Mise à jour des status avec le fichier déposé par Emova.\n", false, Parameters.commandId);
                  string fluxShipped = FileUtilities.CreateShippedCommands();
                  string resultFlux = makeSoapRequest(fluxShipped, "NewOrdersService.UpdateRequest",1);                
              }
              result = getOdersByStatus(Program.Statut.Shipped, "shipped");

              if (result != "Error")
              {
                  //gérer la facturation
                  if (Program.Globals.startBilling) { 
                      FileUtilities.sendBill(result);
                  }
              } */
        }

        internal static string getOdersByStatus(string status,string st)
        {
            String fluxCommandCreated;
            string fileDest = Program.Commands.destination + getFileName(st) + ".xml";
            //Create the file.
                fluxCommandCreated = makeSoapRequest(status, "NewOrdersService.RetrieveByStatusRequest",0);

            if (fluxCommandCreated != null && !isFluxError(fluxCommandCreated)) { 
            try
            {
                using (FileStream file = File.Create(fileDest))
                {                  
                    AddText(file, fluxCommandCreated);
                    file.Close();
                    return fileDest;
                }
            }
            catch (Exception e)
            {

                ig.setRichTextBox("\nUne erreur s'est produite : " + e.Message, false, Parameters.commandId);
            }
            }
            return @"Error";// file:///D:/Projects/Emova/La%20redoute/Exemples%20de%20commandes%20La%20Redoute2.xml";
        }

        private static bool isFluxError(string fluxCommandCreated)
        {
            return FileUtilities.isTagExists(fluxCommandCreated, "</ns2:InjectFault>");
        }

        private static void AddText(FileStream fs, string value)
        {
            byte[] info = new UTF8Encoding(true).GetBytes(value);
            fs.Write(info, 0, info.Length);
        }
    }
}
