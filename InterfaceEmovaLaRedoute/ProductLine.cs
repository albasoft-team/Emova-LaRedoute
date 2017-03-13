using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace safeprojectname
{
    class ProductLine
    {
        private string v;
        private string EAN;
        private string ClassificationValue;
        private string ProductId;
        private string ProductTilte;
        private string ProductDescription;
        private string BrandCode;
        private string ComColor;
        private string ComColorCode;
        private string VendorID;
        private string Medias;
        
        private string AttributeCode;
        private string AttributeValueLabel;


        private KeyValuePair<string, string> GenericColor = new KeyValuePair<string, string>();

        /*


    */


        private struct MediaElt
        {
            internal string MediaURL;
            internal string MediaType;
            internal string MediaEncoding;
            internal string PublicationRank;
            internal string Checksum;
            internal string ChecksumType;
        };

        private List<MediaElt> listMedias = new List<MediaElt>();
        private string SapEspCode;
        private string SapEspCodeValue;
        private string prodHeightCode;
        private string prodHeightCodeValue;

        public ProductLine(string v)
        {
            this.v = v;
            string[] arrCols = v.Split('|');
            this.EAN = arrCols[27];
            this.ProductId = arrCols[27];
            this.ProductTilte = arrCols[1];
            this.ProductDescription = arrCols[3];
            this.Medias = arrCols[5];
     
            this.ClassificationValue = Program.Globals.classificationValue;
            this.VendorID = Program.Globals.vendorId;
            this.ComColor = arrCols[14].Trim();
            this.ComColorCode = (arrCols[14].IndexOf("fonc") > 0) ? "V087505" : "V087506";
            this.SapEspCodeValue = arrCols[13].Trim();
            this.SapEspCode= GenericColors.find(this.SapEspCodeValue);
            this.prodHeightCodeValue= arrCols[15].Trim();
            this.prodHeightCode = GenericColors.find(this.prodHeightCodeValue);
            this.BrandCode = Program.Globals.productCode;
            //Attributs media
            string[] arrMedia = Medias.Split(' ');
            for (int i = 0; i < arrMedia.Length; i++) {
                var mElt = new MediaElt();
                mElt.MediaURL = arrMedia[i];
                string image = mElt.MediaURL.Split('/')[mElt.MediaURL.Split('/').Length - 1];
                mElt.MediaEncoding = image.Substring(image.IndexOf('.')+1);
                mElt.ChecksumType = "MD5";
                mElt.MediaType = "Photo";
                mElt.Checksum = MD5Hash(mElt.MediaURL);
                mElt.PublicationRank = (i + 1).ToString();
                listMedias.Add(mElt);
            }
           
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
            return "<ns:VendorItem>\n" +
                        "<ns:EAN>" +this.EAN+ "</ns:EAN>\n" +
                       "<ns:Classification><ns:ClassificationValue>" +this.ClassificationValue+ "</ns:ClassificationValue></ns:Classification>\n" +
                        "<ns:Product>\n" +
                        "<ns:ProductId><![CDATA["+this.ProductId+ "]]></ns:ProductId>\n" +
                        @"<ns:ProductTitles><ns:ProductTitle language = ""fr""><![CDATA["+this.ProductTilte+ "]]></ns:ProductTitle></ns:ProductTitles>\n" +
                        @"<ns:ProductDescriptions><ns:ProductDescription language = ""fr""><![CDATA["+this.ProductDescription+ "]]></ns:ProductDescription></ns:ProductDescriptions>\n" +
                        "<ns:ProductBrand><ns:BrandCode>" +this.BrandCode+ "</ns:BrandCode></ns:ProductBrand>\n" +
                         getMedia()+
                         "</ns:Product>\n" +
                         "<ns:Vendor><ns:VendorId>"+this.VendorID+ "</ns:VendorId></ns:Vendor>\n" +
                         getAttributes() +
                         "</ns:VendorItem>\n";
        }

        private string getAttributes()
        {
            string retString = "<ns:Attributes>\n";
            //Coloris générique
            retString += "<ns:Attribute>";
            retString += "<ns:AttributeCode>A0485</ns:AttributeCode>\n";
            retString += "<ns:IsDeclinable>true</ns:IsDeclinable>\n";
            retString += "<ns:AttributeValues>\n";
            retString += "<ns:AttributeValueCode>" + GenericColors.find(this.ComColor.Split(' ')[0].ToUpper()) + "</ns:AttributeValueCode>\n";
            retString += @"<ns:AttributeValueLabel language = ""fr"">" + this.ComColor.Split(' ')[0] + "</ns:AttributeValueLabel>";
            retString += "\n</ns:AttributeValues>\n";
            retString += "</ns:Attribute>\n";
       

            //Coloris commercial
            retString += "<ns:Attribute>";
            retString += "<ns:AttributeCode>A1303</ns:AttributeCode>\n";
            retString += "<ns:IsDeclinable>true</ns:IsDeclinable>\n";
            retString += "<ns:AttributeValues>\n";
            retString += "<ns:AttributeValueCode>"+this.ComColorCode+"</ns:AttributeValueCode>\n";
            retString += @"<ns:AttributeValueLabel language = ""fr"">" + this.ComColor+ "</ns:AttributeValueLabel>";
            retString += "\n</ns:AttributeValues>\n";
            retString += "</ns:Attribute>\n";

            //Attributs code A767
            retString += "<ns:Attribute>";
            retString += "<ns:AttributeCode>A767</ns:AttributeCode>\n";
            retString += "<ns:IsDeclinable>false</ns:IsDeclinable>\n";
            retString += "<ns:AttributeValues>\n";
            retString += "<ns:AttributeValueCode> V19638 </ns:AttributeValueCode>\n";
            retString += @"<ns:AttributeValueLabel language = ""fr""> Sapin de Noel</ns:AttributeValueLabel>";
            retString += "\n</ns:AttributeValues>\n";
            retString += "</ns:Attribute>\n";
       
            //Attribut code A0078
            retString += "<ns:Attribute>";
            retString += "<ns:AttributeCode>A0078</ns:AttributeCode>\n";
            retString += "<ns:IsDeclinable>false</ns:IsDeclinable>\n";
            retString += "<ns:AttributeValues>\n";
            retString += "<ns:AttributeValueCode> V000376 </ns:AttributeValueCode>\n";
            retString += @"<ns:AttributeValueLabel language = ""fr"">Bois clair</ns:AttributeValueLabel>";
            retString += "\n</ns:AttributeValues>\n";
            retString += "</ns:Attribute>\n";
           
            //Attribut code A0082
            retString += "<ns:Attribute>";
            retString += "<ns:AttributeCode>A0082</ns:AttributeCode>\n";
            retString += "<ns:IsDeclinable>false</ns:IsDeclinable>\n";
            retString += "<ns:AttributeValues>\n";
            retString += "<ns:AttributeValueCode>V000466</ns:AttributeValueCode>\n";
            retString += @"<ns:AttributeValueLabel language = ""fr"">Pour tous</ns:AttributeValueLabel>";
            retString += "\n</ns:AttributeValues>\n";
            retString += "</ns:Attribute>\n";

            //Attribut code A0278
            retString += "<ns:Attribute>";
            retString += "<ns:AttributeCode>A0278</ns:AttributeCode>\n";
            retString += "<ns:IsDeclinable>false</ns:IsDeclinable>\n";
            retString += "<ns:AttributeValues>\n";
            retString += "<ns:AttributeValueCode>V001313</ns:AttributeValueCode>\n";
            retString += @"<ns:AttributeValueLabel language = ""fr"">Indoor</ns:AttributeValueLabel>";
            retString += "\n</ns:AttributeValues>\n";
            retString += "</ns:Attribute>\n";
            
            //Attribut code A1305
            retString += "<ns:Attribute>";
            retString += "<ns:AttributeCode>A1305</ns:AttributeCode>\n";
            retString += "<ns:IsDeclinable>false</ns:IsDeclinable>\n";
            retString += "<ns:AttributeValues>\n";
            retString += "<ns:AttributeValueCode>V087516</ns:AttributeValueCode>\n";
            retString += @"<ns:AttributeValueLabel language = ""fr"">Natural</ns:AttributeValueLabel>";
            retString += "\n</ns:AttributeValues>\n";
            retString += "</ns:Attribute>\n";

            //Attribut code A1306
            retString += "<ns:Attribute>";
            retString += "<ns:AttributeCode>A1306</ns:AttributeCode>\n";
            retString += "<ns:IsDeclinable>false</ns:IsDeclinable>\n";
            retString += "<ns:AttributeValues>\n";
            retString += "<ns:AttributeValueCode>"+this.prodHeightCode+"</ns:AttributeValueCode>\n";
            retString += @"<ns:AttributeValueLabel language = ""fr"">"+ this.prodHeightCodeValue + "</ns:AttributeValueLabel>";
            retString += "\n</ns:AttributeValues>\n";
            retString += "</ns:Attribute>\n";

            //Attribut code A1307
            retString += "<ns:Attribute>";
            retString += "<ns:AttributeCode>A1307</ns:AttributeCode>\n";
            retString += "<ns:IsDeclinable>false</ns:IsDeclinable>\n";
            retString += "<ns:AttributeValues>\n";
            retString += "<ns:AttributeValueCode>V087507</ns:AttributeValueCode>\n";
            retString += @"<ns:AttributeValueLabel language = ""fr"">Intérieur</ns:AttributeValueLabel>";
            retString += "\n</ns:AttributeValues>\n";
            retString += "</ns:Attribute>\n";

            //Attribut code A1304
            retString += "<ns:Attribute>";
            retString += "<ns:AttributeCode>A1304</ns:AttributeCode>\n";
            retString += "<ns:IsDeclinable>false</ns:IsDeclinable>\n";
            retString += "<ns:AttributeValues>\n";
            retString += "<ns:AttributeValueCode>"+this.SapEspCode+"</ns:AttributeValueCode>\n";
            retString += @"<ns:AttributeValueLabel language = ""fr"">"+ this.SapEspCodeValue + "</ns:AttributeValueLabel>";
            retString += "\n</ns:AttributeValues>\n";
            retString += "</ns:Attribute>\n";


            retString += "</ns:Attributes>\n";

            return retString;
        }

        private string getMedia()
        {
            string retString = "<ns:Medias>\n";
            int i = 1;
            foreach (MediaElt elt in listMedias)
            {
                retString += "<ns:Media>\n";
                retString += "<ns:MediaType>"+elt.MediaType+"</ns:MediaType>\n";
                retString += "<ns:MediaURL><![CDATA[" + elt.MediaURL + "]]></ns:MediaURL>\n";
                retString += "<ns:MediaEncoding>" + elt.MediaEncoding + "</ns:MediaEncoding>\n";
                retString += "<ns:Checksum>" + elt.Checksum + "</ns:Checksum>\n";
                retString += "<ns:ChecksumType>" + elt.ChecksumType + "</ns:ChecksumType>\n";
                retString += "<ns:PublicationRank>" + elt.PublicationRank + "</ns:PublicationRank>\n";
                retString += "</ns:Media>\n";
            }
            retString += "</ns:Medias>\n";
            return retString;
        }
    }
}
