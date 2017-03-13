using PdfSharp.Drawing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IELRLibraryManager.Models
{
    public class OrderLine
    {
        private string reference;

        public string Reference
        {
            get { return reference; }
            set { reference = value; }
        }

        private Address addressLivraison;

        public Address AddressLivraison
        {
            get { return addressLivraison; }
            set { addressLivraison = value; }
        }

        private string designation;

        public string Designation
        {
            get { return designation; }
            set { designation = value; }
        }
        private int quantite;

        public int Quantite
        {
            get { return quantite; }
            set { quantite = value; }
        }
        private decimal prix_unitaire;

        public decimal Prix_Unitaire
        {
            get { return prix_unitaire; }
            set { prix_unitaire = value; }
        }
        private decimal tVA;

        public decimal TVA
        {
            get { return tVA; }
            set { tVA = value; }
        }
        private decimal prix_TTC;

        public decimal Prix_TTC
        {
            get { return prix_TTC; }
            set { prix_TTC = value; }
        }
        private decimal frais_livraison;

        public decimal Frais_Livraison
        {
            get { return frais_livraison; }
            set { frais_livraison = value; }
        }
       
        private string numero_commande;

        public string Numero_Commande
        {
            get { return numero_commande; }
            set { numero_commande = value; }
        }
        
        private DateTime date_facturation;

        public DateTime Date_Facturation
        {
            get { return date_facturation; }
            set { date_facturation = value; }
        }
        private string numero_facture;

        public string Numero_Facture
        {
            get { return numero_facture; }
            set { numero_facture = value; }
        }
        private string devide;

        public string Devise
        {
            get { return devide; }
            set { devide = value; }
        }
        private string email;

        public string Email
        {
            get { return email; }
            set { email = value; }
        }

        public void renderToPDF(XGraphics graph, XPen penNormal, XFont fontR9, int i)
        {
  
            graph.DrawString(Reference, fontR9, XBrushes.Black, new XRect(15, 305 + i * 20, 110, 10), XStringFormats.Center);

        
            graph.DrawString(Designation, fontR9, XBrushes.Black, new XRect(117, 305+i*20, 280, 10), XStringFormats.TopLeft);


            graph.DrawString(Quantite.ToString(), fontR9, XBrushes.Black, new XRect(282, 305+i*20, 60, 10), XStringFormats.Center);

            graph.DrawString(Prix_Unitaire.ToString() + " €", fontR9, XBrushes.Black, new XRect(372, 305+i*20, 60, 10), XStringFormats.TopLeft);

            graph.DrawString((TVA*100).ToString("#.") + " %", fontR9, XBrushes.Black, new XRect(442, 305+i*20, 60, 10), XStringFormats.TopLeft);

            graph.DrawString(Prix_TTC.ToString("#.##") + " €", fontR9, XBrushes.Black, new XRect(535, 305+i*20, 100, 10), XStringFormats.TopLeft);
        }

    }
}
