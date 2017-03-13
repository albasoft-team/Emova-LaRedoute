using IELRLibraryManager.Models;
using PdfSharp;
using PdfSharp.Drawing;
using PdfSharp.Drawing.Layout;
using PdfSharp.Pdf;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IELRLibraryManager
{
    abstract public class GenerateFacture
    {
        public static string GeneratePDF(Order orders)
        {
            string factureName = String.Empty;
            try
            {
                PdfDocument pdf = new PdfDocument();
                pdf.Info.Title = "Facture EMOVA";
                PdfPage pdfPage = pdf.AddPage();

                pdfPage.Orientation = PageOrientation.Portrait;
                XFont fontR9 = new XFont("Calibri", 9, XFontStyle.Regular);
                XFont fontR10 = new XFont("Calibri", 10, XFontStyle.Regular);
                XFont fontR11 = new XFont("Calibri", 11, XFontStyle.Regular);
                XFont fontR12 = new XFont("Calibri", 12, XFontStyle.Regular);
                XFont fontR8 = new XFont("Calibri", 8, XFontStyle.Regular);
                XFont fontB11 = new XFont("Calibri", 11, XFontStyle.Bold);
                XFont fontB12 = new XFont("Calibri", 12, XFontStyle.Bold);
                XFont fontB14 = new XFont("Calibri", 14, XFontStyle.Bold);
                XFont fontB10 = new XFont("Calibri", 9, XFontStyle.Bold);
                XFont fontR7 = new XFont("Browallia New", 7, XFontStyle.Italic);

                XSolidBrush brushGray = new XSolidBrush(XColor.FromArgb(0, 242, 242, 242));
                XSolidBrush brushGray1 = new XSolidBrush(XColor.FromArgb(0, 242, 242, 242));
                XSolidBrush brushBlue = new XSolidBrush(XColor.FromArgb(0, 0, 45, 75));

                XGraphics graph = XGraphics.FromPdfPage(pdfPage);
                XColor color = new XColor();
                XColor color0 = new XColor();

                color.R = 0; color.G = 0; color.B = 0;
                color0.R = 255; color0.G = 255; color0.B = 255;

                XPen penBold = new XPen(color);
                penBold.Width = 1;
                XPen penNormal = new XPen(color);
                XPen penIncolor = new XPen(color);

                penNormal.Width = 0.1;
                XColor color1 = new XColor();
                color1.R = 224; color1.G = 224; color1.B = 224;
                XPen penGray = new XPen(color1);
                penGray.Width = 0.5;
                XTextFormatter tf = new XTextFormatter(graph);
                XStringFormat alignRight = new XStringFormat();
                alignRight.Alignment = XStringAlignment.Far;

                // ----------------- LOGO --------------------
                XImage logo = XImage.FromFile(@"D:\projects\sanarsoft\logo.png");
                graph.DrawImage(logo, 35, 20, 80, 80);

              
                ////------------- RECTANGLE GAUCHE ---------------------------

                graph.DrawString("ADRESSE DE FACTURATION", fontB11, XBrushes.Black, new XRect(37, 170, 200, 10), XStringFormats.TopLeft);
                string adrF = String.Concat(orders.AddressFacturation.Title + orders.AddressFacturation.G_Name1 + orders.AddressFacturation.D_Name1, "\n",
                   orders.AddressFacturation.Address2, "\n",
                   orders.AddressFacturation.ZipCode + " " + orders.AddressFacturation.City);
                XRect rect1 = new XRect(37, 185, 200, 80);
                XRect rect5 = new XRect(30, 165, 200, rect1.Height + 10);
                graph.DrawRectangle(penNormal, rect5);
                tf.DrawString(adrF, fontR10, XBrushes.Black, rect1, XStringFormats.TopLeft);
                

                int k = 1;
                var size = orders.OrderLines.Count;
                foreach (var cmd in orders.OrderLines)
                {
                    if(k == 1)
                    {
                        // ------------- PREMIER RECTANGLE --------------------
                        XRect rect = new XRect(30, 110, 540, 35);
                        graph.DrawRectangle(penNormal, new XSolidBrush(XColor.FromCmyk(0, 0, 0, 0.051)), rect);
                        graph.DrawString("Facture N° : " + cmd.Numero_Facture, fontB12, XBrushes.Black, new XRect(40, 120, 100, 10), XStringFormats.TopLeft);
                        graph.DrawString("Commande N° : " + cmd.Numero_Commande, fontR10, XBrushes.Black, new XRect(245, 115, 100, 10), XStringFormats.TopLeft);
                        graph.DrawString("Date Commande : " + orders.Date_Commande, fontR10, XBrushes.Black, new XRect(245, 130, 100, 10), XStringFormats.TopLeft);
                        graph.DrawString("Date de facture : " + cmd.Date_Facturation, fontR10, XBrushes.Black, new XRect(410, 115, 100, 10), XStringFormats.TopLeft);
                        graph.DrawString("Devise : " + cmd.Devise, fontR10, XBrushes.Black, new XRect(410, 130, 100, 20), XStringFormats.TopLeft);

                        //------------- RECTANGLE DROITE ---------------------------

                        graph.DrawString("ADRESSE DE LIVRAISON", fontB11, XBrushes.Black, new XRect(422, 170, 125, 10), XStringFormats.TopLeft);
                        string adrL = String.Concat(cmd.AddressLivraison.Title + cmd.AddressLivraison.G_Name1 + cmd.AddressLivraison.D_Name1, "\n",
                            cmd.AddressLivraison.Address2, "\n",
                             cmd.AddressLivraison.ZipCode + " " + cmd.AddressLivraison.City);
                        XRect rect2 = new XRect(422, 185, 155, 80);
                        XRect rect6 = new XRect(415, 165, 155, rect2.Height + 10);
                        graph.DrawRectangle(penNormal, rect6);
                        tf.DrawString(adrL, fontR10, XBrushes.Black, rect2, XStringFormats.TopLeft);

                        ////------------- T A B L E A U ---------------------------

                        ////------------- ENTETE ---------------------------
                        XRect rect3 = new XRect(30, 300, 540, 15);
                        graph.DrawRectangle(penNormal, new XSolidBrush(XColor.FromCmyk(0, 0, 0, 0.051)), rect3);
                        graph.DrawString("Référence", fontB10, XBrushes.Black, new XRect(35, 302, 110, 10), XStringFormats.TopLeft);

                        graph.DrawRectangle(penNormal, new XRect(115, 300, 0.04, 15));
                        graph.DrawString("Désignation", fontB10, XBrushes.Black, new XRect(117, 302, 280, 10), XStringFormats.TopLeft);

                        graph.DrawRectangle(penNormal, new XRect(280, 300, 0.04, 15));
                        graph.DrawString("Quantité", fontB10, XBrushes.Black, new XRect(282, 302, 60, 10), XStringFormats.TopLeft);

                        graph.DrawRectangle(penNormal, new XRect(342, 300, 0.04, 15));
                        graph.DrawString("Prix Unitaire", fontB10, XBrushes.Black, new XRect(344, 302, 60, 10), XStringFormats.TopLeft);

                        graph.DrawRectangle(penNormal, new XRect(400, 300, 0.04, 15));
                        graph.DrawString("TVA %", fontB10, XBrushes.Black, new XRect(410, 302, 60, 10), XStringFormats.TopLeft);

                        graph.DrawRectangle(penNormal, new XRect(462, 300, 0.04, 15));
                        graph.DrawString("Prix TTC", fontB10, XBrushes.Black, new XRect(474, 302, 100, 10), XStringFormats.TopLeft);

                        XRect recte = new XRect(344, 320 + (size+3) * 25, 225, 20);
                        graph.DrawString("Montant HT ", fontR9, XBrushes.Black, new XRect(344, 320 + size * 25, 100, 10), XStringFormats.TopLeft);
                        graph.DrawString(orders.Total_HT.ToString("#.##"), fontR9, XBrushes.Black, new XRect(525, 320 + size * 25, 33, 10), alignRight);
                        graph.DrawString("€", fontR9, XBrushes.Black, new XRect(560, 320 + size * 25, 10, 10), XStringFormats.TopLeft);

                        graph.DrawString("Frais de port TTC ", fontR9, XBrushes.Black, new XRect(344, 320 + (size+1) * 25, 150, 10), XStringFormats.TopLeft);
                        graph.DrawString(cmd.Frais_Livraison.ToString("#.##"), fontR9, XBrushes.Black, new XRect(525, 320 + (size + 1) * 25, 33, 10), alignRight);
                        graph.DrawString("€", fontR9, XBrushes.Black, new XRect(560, 320 + (size + 1) * 25, 10, 10), XStringFormats.TopLeft);

                        graph.DrawString("TVA ", fontR9, XBrushes.Black, new XRect(344, 320 + (size+2) * 25, 100, 10), XStringFormats.TopLeft);
                        graph.DrawString(orders.Total_TVA.ToString("#.##"), fontR9, XBrushes.Black, new XRect(525, 320 + (size + 2) * 25, 33, 10), alignRight);
                        graph.DrawString("€", fontR9, XBrushes.Black, new XRect(560, 320 + (size + 2) * 25, 10, 10), XStringFormats.TopLeft);

                        graph.DrawRectangle(penGray, new XSolidBrush(XColor.FromCmyk(1, 0.4, 0, 0.706)), recte);
                        graph.DrawString("TOTAL TTC A PAYER ", fontR9, XBrushes.White, new XRect(346, 325 + (size+3) * 25, 150, 10), XStringFormats.TopLeft);
                        graph.DrawString(orders.Total_TTC.ToString("#.##"), fontR9, XBrushes.White, new XRect(525, 325 + (size + 3) * 25, 33, 10), alignRight);
                        graph.DrawString("€", fontR9, XBrushes.White, new XRect(560, 325 + (size + 3) * 25, 10, 10), XStringFormats.TopLeft);
                        graph.DrawString("* Comprend les remises eventuelles sur les frais de port", fontR7, XBrushes.Black, new XRect(352, 325 + (size + 4) * 24, 100, 10), XStringFormats.TopLeft);
 
                        ////--------------------------------- P I E D S  D E  P A G E --------------------------

                        XRect rectPieds = new XRect(30, 765, 540, 50);
                        graph.DrawRectangle(penGray, new XSolidBrush(XColor.FromCmyk(0, 0, 0, 0.051)), rectPieds);
                        graph.DrawString("Merci d'avoir choisi Monceau Fleurs pour votre commande", fontR11, XBrushes.Black, new XRect(35, 770, 300, 10), XStringFormats.TopLeft);
                        graph.DrawString("Pour nous contacter :", fontR11, XBrushes.Black, new XRect(385, 770, 150, 10), XStringFormats.TopLeft);
                        graph.DrawString("01 80 00 20 11", fontR10, XBrushes.Black, new XRect(385, 783, 100, 10), XStringFormats.TopLeft);
                        graph.DrawString("A bientôt sur www.monceaufleurs.com ou sur l'application mobile Monceau Fleurs ! ", fontR10, XBrushes.Black, new XRect(35, 798, 500, 10), XStringFormats.TopLeft);
                        graph.DrawString("service.consommateurs@emova-group.com", fontR10, XBrushes.Blue, new XRect(385, 798, 100, 20), XStringFormats.TopLeft);

                        string pied1 = "FINANET - SARL au capital de 7 500€ - 233, avenue le jour se lève, 92 100 BOULOGNE BILLANCOURT";
                        string pied2 = "RCS NANTERRE 423 725 795 - TVA intracommunautaire FR 60 423 725 795 00045 ";
                        XRect rectPieds1 = new XRect(117, 820, 540, 40);
                        XRect rectPieds2 = new XRect(150, 830, 540, 40);
                        graph.DrawString(pied1, fontR10, XBrushes.Gray, rectPieds1, XStringFormats.TopLeft);
                        graph.DrawString(pied2, fontR10, XBrushes.Gray, rectPieds2, XStringFormats.TopLeft);

                    }
                    cmd.renderToPDF(graph, penNormal, fontR9, k);
                    k++;
                   
                }
                
                string pdfFilename = @"D:\projects\sanarsoft\factures\facture" + "_"+orders.AddressFacturation.D_Name1+"_"+orders.AddressFacturation.G_Name1+".pdf";
                pdf.Save(pdfFilename);
                factureName = pdfFilename;
            }
            catch (Exception e)
            {
                Console.WriteLine("Erreur :" + e.Message);
            }
            return factureName;
        }
    }
}
