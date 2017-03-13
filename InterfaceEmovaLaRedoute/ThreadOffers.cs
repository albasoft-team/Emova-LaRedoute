using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace safeprojectname
{
    public abstract class ThreadOffers
    {
         
        public static void ThreadLoop()
        {
            Boolean fileExists = false; string filename;
            while (Thread.CurrentThread.IsAlive)
            {
                Thread.Sleep(Program.Offers.execIntDelay);
                MainInterface ig = (MainInterface)Application.OpenForms["MainInterface"];
                ig.setRichTextBox("\nRecherche de nouvelles offres à envoyer", false, Parameters.offerId);
             
                //Lecture répertoire  source pour rechercher les fichiers
                //Pour chaque fichier trouvé appeller WSProducts
                filename = FileUtilities.getNextFileFromFolder(Program.Offers.source, Program.Offers.archive);
                while (filename != null)
                {
                    WSOffres.createXMLFile(filename);
                    FileUtilities.moveFileToFolder(Program.Offers.archive, filename);
                    filename = FileUtilities.getNextFileFromFolder(Program.Offers.source, Program.Offers.archive);
                }

                Thread.Sleep(Program.Offers.execInterval);

            }

        }
    }
}
