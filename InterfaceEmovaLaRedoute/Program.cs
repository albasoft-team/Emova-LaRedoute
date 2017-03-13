using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace safeprojectname
{
    static class Program
    {
        internal struct Statut {
            public static string Created = "<Status>Created</Status>";
            public static string Shipped = "<Status>Shipped</Status>";
            public static string RecupStatuts = "<Status>Toship</Status>\n<Status>Cancelled</Status>\n"+
                "<Status>Paid</Status>\n<Status>Refunding</Status>\n<Status>Toapprove</Status>\n"+
                "<Status>Refunded</Status>\n<Status>Refund refused</Status>";
            public static string MajStatuts = "<Status>Shipped</Status>\n<Status>OutOfStock</Status>";
        }

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        /// 

        internal struct Products
        {
            public static string wsURL = "";
            public static int execInterval = 10000;
            public static int execIntDelay = 0;
            public static bool startOnLaunch = false;
            public static string username = "";
            public static string password = "";
            public static string source = "";
            public static string destination = "";
            public static string xmlHeader = @"<?xml version=""1.0"" encoding = ""UTF-8"" ?>";
            public static string xmlNS = @"<ns:VendorItems xmlns:ns = ""http://RedouteFrance/CAT-EXT-INTG/Product/VendorItems/1.0"" xmlns:xsi = ""http://www.w3.org/2001/XMLSchema-instance"" xsi:schemaLocation = ""http://RedouteFrance/CAT-EXT-INTG/Product/VendorItems/1.0 file:///G:/Commun/R%c3%a9f%c3%a9rentiel%20Vente/Kit%20Technique_vendeur_direct_xml/VendorItems_1.0.xsd"" >";
            public static string xmlENS = "</ns:VendorItems>";
            public static string archive = "";
            public static string productCode = "";
        };
        internal struct Offers
        {
            public static string wsURL = "";
            public static int execInterval = 10000;
            public static int execIntDelay = 0;
            public static bool startOnLaunch = false;
            public static string username = "";
            public static string password = "";
            public static string source = "";
            public static string destination = "";
            public static string xmlHeader = @"<?xml version=""1.0"" encoding = ""UTF-8"" ?>";
            public static string xmlNS = @"<SellerOfferRequest xmlns = ""http://RedCats/MarketPlace/Partnership/2.0"" MessageRelease=""1.0"" MessageDate="""+DateTime.Now.ToString("yyyy-MM-ddTHH:mm:33.000Z") +@""" SellerID=""12821"" HubID=""400"" xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"" xsi:schemaLocation=""http://RedCats/MarketPlace/Partnership/2.0"">";
            public static string xmlENS = "</SellerOfferRequest>";
            public static string archive = "";
            public static string DeliveryFee = "";
            public static string ShipmentDelay = "";
            public static string DeliveryDeaysRangeMin = "";
            public static string DeliveryDeaysRangeMax = "";


        };
        internal struct Commands
        {
            public static string wsURL = "";
            public static int execInterval = 10000;
            public static int execIntDelay = 0;
            public static bool startOnLaunch = false;
            public static string username = "";
            public static string password = "";
            public static string source = "";
            public static string destination = "";
            public static string xmlHeader = ""; // {<?xml version="1.0" encoding = "UTF - 8" ?> };
            public static string xmlNS = "";
            public static string archive = "";
            public static string ApiKeyRec = "";
            public static string ApiKeyMaj = "";

        };
        internal struct Globals
        {
            public static string vendorId = "";
            public static string classificationValue = "S783";
            public static string apiKey = "";
            public static string tvaActuel;
            public static string productCode;
            public static string Host;
            public static int Port=25;
            public static bool SSL=true;
            public static string Username;
            public static string Password;
            public static bool startBilling=true;
        };

        public static String Justify(String s, Int32 count)
        {
            if (count <= 0)
                return s;

            Int32 middle = s.Length / 2;
            IDictionary<Int32, Int32> spaceOffsetsToParts = new Dictionary<Int32, Int32>();
            String[] parts = s.Split(' ');
            for (Int32 partIndex = 0, offset = 0; partIndex < parts.Length; partIndex++)
            {
                spaceOffsetsToParts.Add(offset, partIndex);
                offset += parts[partIndex].Length + 1; // +1 to count space that was removed by Split
            }
            foreach (var pair in spaceOffsetsToParts.OrderBy(entry => Math.Abs(middle - entry.Key)))
            {
                count--;
                if (count < 0)
                    break;
                parts[pair.Value] += ' ';
            }
            return String.Join(" ", parts);
        }

        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Hashtable productSection = (Hashtable)ConfigurationManager.GetSection("WebServiceSection/Products");
            Hashtable offerSection = (Hashtable)ConfigurationManager.GetSection("WebServiceSection/Offers");
            Hashtable commandSection = (Hashtable)ConfigurationManager.GetSection("WebServiceSection/Commands");

            Hashtable globals = (Hashtable)ConfigurationManager.GetSection("WebServiceSection/Globals");
           
            //Initialisation des paramètres du web service produits
            Products.execInterval = int.Parse(productSection["execInterval"].ToString());
            Products.execIntDelay = int.Parse(productSection["execIntDelay"].ToString()); 
            Products.startOnLaunch = bool.Parse(productSection["startOnLaunch"].ToString());
            Products.wsURL = (string)productSection["wsURL"];
            Products.username = (string)productSection["username"];
            Products.password = (string)productSection["password"];
            Products.source = (string)productSection["source"];
            Products.destination = (string)productSection["destination"];
            Products.archive = (string)productSection["archive"];
            Products.productCode = (string)productSection["productCode"];

            //initialisation des paramètres du web service offres
            Offers.execInterval = int.Parse(offerSection["execInterval"].ToString());
            Offers.execIntDelay = int.Parse(offerSection["execIntDelay"].ToString());
            Offers.startOnLaunch = bool.Parse(offerSection["startOnLaunch"].ToString());
            Offers.wsURL = (string)offerSection["wsURL"];
            Offers.username = (string)offerSection["username"];
            Offers.password = (string)offerSection["password"];
            Offers.source = (string)offerSection["source"];
            Offers.destination = (string)offerSection["destination"];
            Offers.archive = (string)offerSection["archive"];
            Offers.DeliveryFee = (string)offerSection["DeliveryFee"];
            Offers.ShipmentDelay = (string)offerSection["ShipmentDelay"];
            Offers.DeliveryDeaysRangeMin = (string)offerSection["DeliveryDeaysRangeMin"];
            Offers.DeliveryDeaysRangeMax = (string)offerSection["DeliveryDeaysRangeMax"];
        

            //initialisation des paramètres du web service command
            Commands.execInterval = int.Parse(commandSection["execInterval"].ToString());
            Commands.execIntDelay = int.Parse(commandSection["execIntDelay"].ToString());
            Commands.startOnLaunch = bool.Parse(commandSection["startOnLaunch"].ToString());
            Commands.wsURL = (string)commandSection["wsURL"];
            Commands.username = (string)commandSection["username"];
            Commands.password = (string)commandSection["password"];
            Commands.source = (string)commandSection["source"];
            Commands.destination = (string)commandSection["destination"];
            Commands.archive = (string)commandSection["archive"];
            Commands.ApiKeyRec= (string)commandSection["ApiKeyRec"];
            Commands.ApiKeyMaj = (string)commandSection["ApiKeyMaj"];
            // initialisation des paramètres application
            Globals.classificationValue= (string)globals["ClassificationValue"];
            Globals.vendorId = (string)globals["VendorId"];
            Globals.apiKey = (string)globals["ApiKey"];
            Globals.tvaActuel = (string)globals["tvaActuel"];
            Globals.productCode = (string)globals["productCode"];

            Globals.Host= (string)globals["Host"];
            Globals.Port = int.Parse(globals["Port"].ToString());
            Globals.SSL = bool.Parse(globals["SSL"].ToString());
            Globals.Username= (string)globals["Username"];
            Globals.Password = (string)globals["Password"];
            Globals.startBilling = bool.Parse(globals["startBilling"].ToString());

            //liste de commande
            
            Application.Run(new MainInterface());

    }
}

}
