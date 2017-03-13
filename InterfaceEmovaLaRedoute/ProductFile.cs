using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace safeprojectname
{

    class ProductFile
    {
        List<ProductLine> productList = new List<ProductLine>();

        public ProductFile(string filename) {
            string[] filelines = System.IO.File.ReadAllLines(filename, Encoding.GetEncoding(28591));
            for (int i = 1;i < filelines.Length;i++)
            {
                productList.Add (new ProductLine(filelines[i]));
            }
        }
        public string getXMLString() {
            string xmlString = Program.Products.xmlHeader+"\n";
            xmlString += Program.Products.xmlNS+"\n";
            foreach (ProductLine product in productList) {
                xmlString += product.toXML();
            }
            xmlString += Program.Products.xmlENS;
            return xmlString;
        }

    }
}
