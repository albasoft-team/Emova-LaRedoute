using System.Collections.Generic;
using System.Text;
using System.IO;
namespace safeprojectname
{
    internal class OfferFile
    {
        private string filename;
        List<OfferLine> offerList = new List<OfferLine>();

        public OfferFile(string filename)
        {
            string[] filelines = File.ReadAllLines(filename, Encoding.GetEncoding(28591));
            for (int i = 1; i < filelines.Length; i++)
            {
                offerList.Add(new OfferLine(filelines[i]));
            }
        }

        public string getXMLString()
        {
            string xmlString = Program.Offers.xmlHeader + "\n";
            xmlString += Program.Offers.xmlNS + "\n";
            foreach (OfferLine offer in offerList)
            {
                xmlString += offer.toXML();
            }
            xmlString += Program.Offers.xmlENS;
            return xmlString;
        }
    }
}