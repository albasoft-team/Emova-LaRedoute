using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace safeprojectname
{
    public partial class MainInterface : Form
    {
       
        public MainInterface()
        {
            InitializeComponent();
            ThreadController.initThread();
            if (Program.Offers.startOnLaunch) fctToolStartOffers();
            if (Program.Products.startOnLaunch) fctToolStartProducts();
            if (Program.Commands.startOnLaunch) fctToolStartCommands();
        }

        private void toolStartProducts_Click(object sender, EventArgs e)
        {
            fctToolStartProducts();
        }
        public void fctToolStartProducts()
        {
            DateTime date1 = DateTime.Now;
            richConsoleProducts.AppendText("\n**************************************************************");
            richConsoleProducts.AppendText("**************************************************************");
            richConsoleProducts.AppendText("\n[" + date1.ToString("f",
                  CultureInfo.CreateSpecificCulture("fr-FR")) + "] : " + Parameters.startProductText);
            richConsoleProducts.AppendText("\n**************************************************************");
            richConsoleProducts.AppendText("**************************************************************");
            ThreadController.startThreadProduct();
            toolStopProducts.Enabled = true;
            toolStartProducts.Enabled = false;

        }
        delegate void SetTextCallback(string text, bool isErr, int cyble);
        internal void setRichTextBox(string txt, bool isErr, int cyble)
        {
            RichTextBox richConsole = null;
            
            switch (cyble) {
                case 0:
                    richConsole = this.richConsoleProducts;
                    break;
                case 1:
                    richConsole = this.richConsoleOffers;
                    break;
                case 2:
                    richConsole = this.richConsoleCommands;
                    break;
            }


            if (richConsole.InvokeRequired)
            {
                SetTextCallback d = new SetTextCallback(setRichTextBox);
                this.Invoke(d, new object[] { txt,isErr,cyble });
            }
            else
            {
                if (isErr)
                    richConsole.SelectionColor = Color.Red;
                else
                    richConsole.SelectionColor = Color.White;
                richConsole.AppendText(txt);
            }
        }

        private void toolStopProducts_Click(object sender, EventArgs e)
        {
            fctToolStopProducts();
        }
        private void fctToolStopProducts()
        {
            DateTime date1 = DateTime.Now;
            richConsoleProducts.AppendText("\n[" + date1.ToString("f",
                 CultureInfo.CreateSpecificCulture("fr-FR")) + "] : " + Parameters.stopProductText);
            ThreadController.stopThreadProduct();
            toolStartProducts.Enabled = true;
            toolStopProducts.Enabled = false;
        }

        private void toolStartOffers_Click(object sender, EventArgs e)
        {
            fctToolStartOffers();
        }
        public void fctToolStartOffers()
        {
            DateTime date1 = DateTime.Now;
            richConsoleOffers.AppendText("\n**************************************************************");
            richConsoleOffers.AppendText("**************************************************************");
            richConsoleOffers.AppendText("\n[" + date1.ToString("f",
                 CultureInfo.CreateSpecificCulture("fr-FR")) + "] : " + Parameters.startOfferText);
            richConsoleOffers.AppendText("\n**************************************************************");
            richConsoleOffers.AppendText("**************************************************************");
            ThreadController.startThreadOffers();
            toolStopOffers.Enabled = true;
            toolStartOffers.Enabled = false;
        }

        private void toolStopOffers_Click(object sender, EventArgs e)
        {
            fctToolStopOffers();
        }

        private void fctToolStopOffers()
        {
            DateTime date1 = DateTime.Now;
            richConsoleOffers.AppendText("\n[" + date1.ToString("f",
                 CultureInfo.CreateSpecificCulture("fr-FR")) + "] : " + Parameters.stopOfferText);
            ThreadController.stopThreadOffers();
            toolStartOffers.Enabled = true;
            toolStopOffers.Enabled = false;

        }

        private void toolStartCommands_Click(object sender, EventArgs e)
        {
            fctToolStartCommands();
        }
        public void fctToolStartCommands()
        {
            DateTime date1 = DateTime.Now;
            richConsoleCommands.AppendText("\n**************************************************************");
            richConsoleCommands.AppendText("**************************************************************");
            richConsoleCommands.AppendText("\n[" + date1.ToString("f",
                 CultureInfo.CreateSpecificCulture("fr-FR")) + "] : " + Parameters.startCommandText);
            richConsoleCommands.AppendText("\n**************************************************************");
            richConsoleCommands.AppendText("**************************************************************");
            ThreadController.startThreadCommands();
            toolStopCommands.Enabled = true;
            toolStartCommands.Enabled = false;
        }

        private void toolStopCommandes_Click(object sender, EventArgs e)
        {
            fctToolStopCommandes();
        }
        private void fctToolStopCommandes()
        {
            DateTime date1 = DateTime.Now;
            richConsoleCommands.AppendText("\n[" + date1.ToString("f",
                 CultureInfo.CreateSpecificCulture("fr-FR")) + "] : " + Parameters.stopCommandText);
            ThreadController.stopThreadCommands();
            toolStartCommands.Enabled = true;
            toolStopCommands.Enabled = false;
        }


    }
}
