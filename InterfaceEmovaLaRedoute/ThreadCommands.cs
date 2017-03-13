using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace safeprojectname
{
    public abstract class ThreadCommands
    {

        public static void ThreadLoop()
        {
            Boolean fileExists = false; string filename;
            while (Thread.CurrentThread.IsAlive)
            {
                Thread.Sleep(Program.Commands.execIntDelay);
                MainInterface ig = (MainInterface)Application.OpenForms["MainInterface"];
                ig.setRichTextBox("\nRecherche de nouvelles commandes à réceptionner", false, Parameters.commandId);

                //Lecture répertoire  source pour rechercher les fichiers
                //Pour chaque fichier trouvé appeller WSProducts
                //  filename = FileUtilities.getNextFileFromFolder(Program.Commands.source, Program.Commands.archive);
                //  while (filename != null)
                //  {
                WSCommands.initOdersWorkflow();
                   // FileUtilities.moveFileToFolder(Program.Commands.archive, filename);
                   // filename = FileUtilities.getNextFileFromFolder(Program.Commands.source, Program.Commands.archive);
               // }

                Thread.Sleep(Program.Commands.execInterval);

            }
        }
    }
}
