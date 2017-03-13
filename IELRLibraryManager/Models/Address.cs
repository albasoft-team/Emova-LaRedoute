using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IELRLibraryManager.Models
{
    public class Address
    {
       
        private string title;

        public string Title
        {
            get { return title; }
            set { title = value; }
        }

        
        private string d_Name1;

        public string D_Name1
        {
            get { return d_Name1; }
            set { d_Name1 = value; }
        }
        private string g_Name1;

        public string G_Name1
        {
            get { return g_Name1; }
            set { g_Name1 = value; }
        }
        private string  address2;

        public string Address2
        {
            get { return address2; }
            set { address2 = value; }
        }
        private int zipCode;

        public int ZipCode
        {
            get { return zipCode; }
            set { zipCode = value; }
        }
        private string city;

        public string City
        {
            get { return city; }
            set { city = value; }
        }
    
      
    }
}
