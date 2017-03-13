using IELRLibraryManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IELRLibraryManager.Models
{
    public class Order
    {
        private List<OrderLine> orderLines;

        public List<OrderLine> OrderLines
        {
            get { return orderLines; }
            set { orderLines = value; }
        }
        private Address addressFacturation;

        public Address AddressFacturation
        {
            get { return addressFacturation; }
            set { addressFacturation = value; }
        }
      
        private decimal total_HT;

        public decimal Total_HT
        {
            get { return total_HT; }
            set { total_HT = value; }
        }
        private decimal total_TVA;

        public decimal Total_TVA
        {
            get { return total_TVA; }
            set { total_TVA = value; }
        }
        private DateTime date_commande;

        public DateTime Date_Commande
        {
            get { return date_commande; }
            set { date_commande = value; }
        }


        private decimal total_TTC;

        public decimal Total_TTC
        {
            get { return total_TTC; }
            set { total_TTC = value; }
        }

        private string orderID;
        public string OrderID
        {
            get { return orderID; }
            set { orderID = value; }
        }

    }
}
