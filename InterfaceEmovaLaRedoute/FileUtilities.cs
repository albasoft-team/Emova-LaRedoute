using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.XPath;
using IELRLibraryManager;
using IELRLibraryManager.Mails;
using IELRLibraryManager.Models;
using IELRLibraryManager.XmlFileManager;

namespace safeprojectname
{
    abstract class FileUtilities
    {
        static internal  MainInterface ig = (MainInterface)Application.OpenForms["MainInterface"];
        public static string getNextFileFromFolder(string targetDirectory, string archiveDirectory) {
            string fileToProcess = "";
            
            // Process the list of files found in the directory.
            string[] fileEntries = Directory.GetFiles(targetDirectory);
            foreach (string fileName in fileEntries)
                if (isAcquittement(fileName)){

                    // on cherche le fichier correspondant
                    fileToProcess = fileName;
                    fileToProcess = fileToProcess.Replace("acq", "txt");

                    //on déplace le fichier acquittement dans archive
                    FileUtilities.moveFileToFolder(archiveDirectory, fileName);
                    if (File.Exists(fileToProcess))
                    {
                        ig.setRichTextBox("\nTraitement du fichier "+ fileToProcess, false, Parameters.productId);
                        return fileToProcess;
                    }
                    else
                    {
                        ig.setRichTextBox("\nAvertissement : fichier acquittement trouvé sans fichier txt " + fileName, false, Parameters.productId);
                    }

                }
            return null;
        }

        public static void moveFileToFolder(string archive, string fileName)
        {
            string[] fwords = fileName.Split('\\');
            string pathArchive = archive+ fwords[fwords.Length-1];

            try
            {
                if (!File.Exists(fileName))
                {
                    // This statement ensures that the file is created,
                    // but the handle is not kept.
                    using (FileStream fs = File.Create(fileName)) { }
                }

                // Ensure that the target does not exist.
                if (File.Exists(pathArchive))
                    File.Delete(pathArchive);

                // Move the file.
                File.Move(fileName, pathArchive);

            }
            catch (Exception e)
            {
                ig.setRichTextBox("\nAvertissement : Un problème est survenu lors du déplacement du fichier dans le répertoire archive " + fileName, false, Parameters.productId);
            }

        }

        private static bool isAcquittement(string fileName)
        {
            return fileName.Substring(fileName.IndexOf('.')).Equals(".acq");
        }
        public static string Base64Encode(string plainText)
        {
            var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(plainText);
            return System.Convert.ToBase64String(plainTextBytes);
        }

        internal static bool isTagExists(string fluxCommandCreated, string tag)
        {
            return fluxCommandCreated.Contains(tag);
        }

       /// <summary>
       /// Création du fichier xml des commandes acceptées
       /// </summary>
       /// <param name="filename"></param>
       /// <returns>string</returns>
        internal static string CreateAcceptedCommands(string filename)
        {
            return XmlFileManager.XMLToXML(filename, Program.Commands.ApiKeyMaj); ;
        }

        /// <summary>
        /// Création du fichier xml des commandes envoyées
        /// </summary>
        /// <returns></returns>
        internal static string CreateShippedCommands()
        {
            string filename = Program.Commands.source + "update_orders.txt";
           return XmlFileManager.TXTToXML(filename, Program.Commands.ApiKeyMaj, Program.Commands.archive, FileUtilities.moveFileToFolder);
        }
        /// <summary>
        /// sendBill
        /// </summary>
        /// <param name="filename"></param>
        public static void sendBill(string filename) {


            List<Order> orders =  XmlFileManager.CreateOrderLineModel(filename, Program.Globals.tvaActuel, GenericColors.find);
            //GenerateFacture facture = new GenerateFacture();

            XmlFileManager.SendBillMail(filename, orders, Program.Globals.Host,
                                                          Program.Globals.Port,
                                                          Program.Globals.SSL,
                                                          Program.Globals.Username,
                                                          Program.Globals.Password,
                                                          true,
                                                          Parameters.commandId,
                                                          ig.setRichTextBox
                                                            );
        }
    }
}
