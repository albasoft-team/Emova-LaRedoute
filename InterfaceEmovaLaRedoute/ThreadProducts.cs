using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace safeprojectname
{
    public abstract class ThreadProducts
    {
        
       
        public static void ThreadLoop()
        {
            Boolean fileExists = false;string filename;
            while (Thread.CurrentThread.IsAlive) {
                Thread.Sleep(Program.Products.execIntDelay);
                MainInterface ig = (MainInterface)Application.OpenForms["MainInterface"];

                ig.setRichTextBox("\nRecherche de nouveaux produits à envoyer", false, Parameters.productId);
                

                //Lecture répertoire  source pour rechercher les fichiers
                //Pour chaque fichier trouvé appeller WSProducts
                filename = FileUtilities.getNextFileFromFolder(Program.Products.source, Program.Products.archive);
                while (filename != null) {
                    WSProducts.createXMLFile(filename);
                    FileUtilities.moveFileToFolder(Program.Products.archive, filename);
                    filename = FileUtilities.getNextFileFromFolder(Program.Products.source, Program.Products.archive);
                }

                Thread.Sleep(Program.Products.execInterval);
             
            }
        }

       
    }
}
