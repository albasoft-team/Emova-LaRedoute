using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace safeprojectname
{
    class OfferLine
    {
        private string v;
        private string ItemStandardId;
        private string ItemConditions;
        private string StockQuantity;
        private string Site;
        private string CountryCode;
        private string SellerOfferId;
        private string OfferNature;
        private string CustomerTarget;
        private string StartDate;
        
        private string EndDate;
        private string CurrencyCode;

        private string Pricetype;
        private string Amount;
        private string VATRAte;
        private string BlockedPrice;

        private string DeliveryType;
        private string DeliveryMode;
        private string DeliveryFee;
        private string ShipmentDelay;

        private string DeliveryDeaysRangeMin;
        private string DeliveryDeaysRangeMax;


        private KeyValuePair<string, string> GenericColor = new KeyValuePair<string, string>();


        public OfferLine(string v)
        {
            this.v = v;
            string[] arrCols = v.Split('|');
            this.ItemStandardId = arrCols[0];
            this.StockQuantity = arrCols[9];
            Decimal Amt = Decimal.Parse(arrCols[3]) * (1+ Decimal.Parse(Program.Globals.tvaActuel));
            this.Amount = Amt.ToString("#.##");
            this.StartDate = formatDate(arrCols[4], arrCols[5]);
            this.EndDate = formatDate(arrCols[6], arrCols[7]);
            this.ItemConditions = "New";
            this.Site = "www.laredoute.fr";
            this.CountryCode = "FR";
            this.OfferNature = "Standard";
            this.CustomerTarget = "All";
            this.CurrencyCode = "EUR";
            this.Pricetype = "SellingPrice";
            this.SellerOfferId = "Monceau Fleurs";
            this.VATRAte = Program.Globals.tvaActuel;
            this.BlockedPrice= this.Amount;
            this.DeliveryType = "Regular";
            this.DeliveryMode = "Home";
            this.DeliveryFee = Program.Offers.DeliveryFee;
            this.ShipmentDelay = Program.Offers.ShipmentDelay;
            this.DeliveryDeaysRangeMin = Program.Offers.DeliveryDeaysRangeMin;
            this.DeliveryDeaysRangeMax = Program.Offers.DeliveryDeaysRangeMax;

        }

        private string formatDate(string v1, string v2)
        {
            string[] arrDat = v1.Split('/');
            string[] arrHeur = v2.Split(':');
            return arrDat[2]+"-"+ arrDat[1]+"-"+ arrDat[0]+ "T"+ arrHeur[0]+ ":" +arrHeur[1]+":00.000Z";
        }

        public static string MD5Hash(string text)
        {
            MD5 md5 = new MD5CryptoServiceProvider();

            //compute hash from the bytes of text
            md5.ComputeHash(ASCIIEncoding.ASCII.GetBytes(text));

            //get hash result after compute it
            byte[] result = md5.Hash;

            StringBuilder strBuilder = new StringBuilder();
            for (int i = 0; i < result.Length; i++)
            {
                //change it into 2 hexadecimal digits
                //for each byte
                strBuilder.Append(result[i].ToString("x2"));
            }

            return strBuilder.ToString();
        }
        public string toXML() {
            string cr = "\n"; 
            return @"<Item>" + cr + "<ItemIdentification>" + cr + @"<ItemStandardID Qualifier = ""EN"">" +
                        this.ItemStandardId +
                        @"</ItemStandardID>" + cr + "</ItemIdentification>" + cr + "<ItemConditions>" + cr + @"<ItemCondition Condition=""" + this.ItemConditions + @""">" + cr +

                "<Availability>" + cr + "<StockQuantity>" + this.StockQuantity + "</StockQuantity></Availability>" + cr +

                @"<SellerOffers>" + cr + @"<SellerOffer Site = """ + this.Site + @""" CountryCode = """ + this.CountryCode + @""" >" +

                "<SellerOfferPrices>" + cr + 

                            @"<SellerOfferPrice SellerOfferID = """ + this.SellerOfferId + @""" OfferNature = """ + this.OfferNature + @""" CustomerTarget = """ + this.CustomerTarget + @""">" + cr +
                                     "<OfferPeriod>" + cr + 
                                        "<StartDate>" + this.StartDate + "</StartDate>" + cr + 
                                            "<EndDate>" + this.EndDate + "</EndDate>" + cr +
                                     "</OfferPeriod>" + cr + 

                                @"<SellingPrice CurrencyCode = """ + this.CurrencyCode + @""" PriceType = """ + this.Pricetype + @""">" + cr + 
                                "<Amount>" + this.Amount.Replace(",",".") + "</Amount>" + cr + 

                                       "<VATRate>" + this.VATRAte.Replace(",", ".") + "</VATRate>" +

                                   "</SellingPrice>" + cr + 
                                "<BlockedPrice>" + this.BlockedPrice.Replace(",", ".") + "</BlockedPrice>" + cr +
                                "</SellerOfferPrice>" + cr + "</SellerOfferPrices>" +

                                @"<Deliveries><Delivery DeliveryType = """ + this.DeliveryType + @""" DeliveryMode = """ + this.DeliveryMode + @""">" + cr + 
                                @"<DeliveryFee CurrencyCode = """ + this.CurrencyCode + @""">" + this.DeliveryFee + "</DeliveryFee>" + cr + 

                                 "<ShipmentDelay>" + this.ShipmentDelay + "</ShipmentDelay>" + cr +
                                 "<DeliveryDaysRange>" + cr + 

                                    "<Min>" + this.DeliveryDeaysRangeMin + "</Min> " + cr + 

                                    "<Max>" + this.DeliveryDeaysRangeMax + "</Max>" + cr +

                                "</DeliveryDaysRange>" + cr +
                                "</Delivery>" + cr + "</Deliveries>" + cr + "</SellerOffer>" + cr + "</SellerOffers>" + cr + "</ItemCondition>" + cr + "</ItemConditions>" + cr + "</Item>" + cr;
        }

       

       
    }
}
