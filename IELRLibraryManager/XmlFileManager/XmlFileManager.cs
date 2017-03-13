using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.XPath;
using IELRLibraryManager.Models;
using IELRLibraryManager.Mails;
using System.Net.Mail;

namespace IELRLibraryManager.XmlFileManager
{
    public class XmlFileManager
    {
        public static string XMLToXML(string inputFilename, string apikey)
        {
            XmlDocument doc = new XmlDocument();
            //doc.Load("D:\\projects\\sanarsoft\\commandesLaRedoute2.xml");
            doc.Load(inputFilename);
            XmlNamespaceManager nsmgr = new XmlNamespaceManager(doc.NameTable);
            nsmgr.AddNamespace("S", "http://schemas.xmlsoap.org/soap/envelope");
            nsmgr.AddNamespace("new", "http://RedouteFrance/seller/order/1.2");
            nsmgr.AddNamespace("ns", "http://Redcats/Order/SellerOrder/2.0/RetrieveSellerOrder/6.0");
            nsmgr.AddNamespace("ns1", "http://Redcats/Order/SellerOrder/2.0/xsdHUB/6.0");
            string entete = @"<soapenv:Envelope xmlns:soapenv=""http://schemas.xmlsoap.org/soap/envelope/""";
            string xmlns = @"xmlns:ns=""http://RedouteFrance/seller/order/1.2"">";
            string enteteFooter = @"</soapenv:Envelope>";
            string content = "";

            string header = @"<soapenv:Header/>";
            string body = @"<soapenv:Body>";
            string bodyFoter = @"</soapenv:Body>";
            string request = @"<ns:UpdateRequest>";
            string reauestFooter = @"</ns:UpdateRequest>";
            content += entete + "\n";
            content += xmlns + "\n";
            content += header + "\n";
            content += body + "\n";
            content += request + "\n";
            content += @"<apikey>" + apikey + "</apikey>" + "\n";
            //content += @"<apikey>" + Program.Commands.ApiKeyMaj + "</apikey>" + "\n";
            XmlNode root = doc.DocumentElement;

            XmlNodeList nodeList = root.SelectNodes(".//OrderLine", nsmgr);
            foreach (XmlNode order in nodeList)
            {
                content += "<accept OrderLineID=\"" + order.Attributes[0].Value + "\"/>" + "\n";
            }

            content += reauestFooter + "\n";
            content += bodyFoter + "\n";
            content += enteteFooter;
            return content;
        }

        public static string TXTToXML(string sourcefile, string apikey,string archive, Action<string, string> movefiletofolder)
        {
            string content = "";
            string filename = sourcefile;
            //string filename = Program.Commands.source + "update_orders.txt";
            try
            {
                string[] comLines = File.ReadAllLines(filename);
                XmlDocument doc = new XmlDocument();

                XmlNamespaceManager nsmgr = new XmlNamespaceManager(doc.NameTable);
                nsmgr.AddNamespace("S", "http://schemas.xmlsoap.org/soap/envelope");
                nsmgr.AddNamespace("new", "http://RedouteFrance/seller/order/1.2");
                nsmgr.AddNamespace("ns", "http://Redcats/Order/SellerOrder/2.0/RetrieveSellerOrder/6.0");
                nsmgr.AddNamespace("ns1", "http://Redcats/Order/SellerOrder/2.0/xsdHUB/6.0");
                string entete = @"<soapenv:Envelope xmlns:soapenv=""http://schemas.xmlsoap.org/soap/envelope/""";
                string xmlns = @"xmlns:ns=""http://RedouteFrance/seller/order/1.2"">";
                string enteteFooter = @"</soapenv:Envelope>";


                string header = @"<soapenv:Header/>";
                string body = @"<soapenv:Body>";
                string bodyFoter = @"</soapenv:Body>";
                string request = @"<ns:UpdateRequest>";
                string reauestFooter = @"</ns:UpdateRequest>";
                content += entete + "\n";
                content += xmlns + "\n";
                content += header + "\n";
                content += body + "\n";
                content += request + "\n";
                content += @"<apikey>" + apikey + "</apikey>" + "\n";
                DateTime localDate = DateTime.Now; var culture = "fr-FR";
                for (int i = 1; i < comLines.Length; i++)
                {
                    string[] arrStat = comLines[i].Split('|');
                    switch (arrStat[1].ToLower())
                    {
                        case "shipped":
                            content += "<ship OrderLineID=\"" + arrStat[0] + "\">" + "\n";
                            content += "<shipDate>" + formatDate(localDate.ToString(culture).Split(' ')[0], localDate.ToString(culture).Split(' ')[1]) + "</shipDate></ship>";


                            break;
                        case "accepted":
                            content += "<accept OrderLineID=\"" + arrStat[0] + "\"/>" + "\n";
                            break;
                        case "refuse":
                            content += "<refuse OrderLineID=\"" + arrStat[0] + "\"/>" + "\n";
                            break;
                        case "outofstock":
                            content += "<outOfStock OrderLineID=\"" + arrStat[0] + "\"/>" + "\n";
                            break;
                        case "refunding":
                            content += "<refunding OrderLineID=\"" + arrStat[0] + "\"/>" + "\n";
                            break;
                    }

                }
                content += reauestFooter + "\n";
                content += bodyFoter + "\n";
                content += enteteFooter;
                movefiletofolder(archive, filename);
                //moveFileToFolder(Program.Commands.archive, filename);
            }
            catch (Exception) { }
            return content;
        }

        internal static void CreateEmovaTXTFile(string filename, string filedest)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(@"D:\projects\sanarsoft\commandesLaRedoute2.xml");

            XmlNamespaceManager nsmgr = new XmlNamespaceManager(doc.NameTable);
            nsmgr.AddNamespace("S", "http://schemas.xmlsoap.org/soap/envelope");
            nsmgr.AddNamespace("new", "http://RedouteFrance/seller/order/1.2");
            nsmgr.AddNamespace("ns", "http://Redcats/Order/SellerOrder/2.0/RetrieveSellerOrder/6.0");
            nsmgr.AddNamespace("ns1", "http://Redcats/Order/SellerOrder/2.0/xsdHUB/6.0");

            string contents = "N Commande|N Ligne de commande|Date commande|Date livraison|Civilite (livraison)|Nom (livraison)|Prenom (livraison)|Adresse 1 de livraison|Adresse 2 de livraison|Code postal de livraison|Ville de livraison|Pays de livraison|Téléphone|Portable|Email|CODE ARTICLE PARTENAIRE|DESIGNATION ARTICLE|UC|QTE de l'UC|QTE COMMANDEE|Prix de vente|Frais de livraison|Mode de livraison|Instruction de livraison 1|Instruction de livraison 2|Instruction de livraison 3|Civilite (facturation)|Nom (facturation)|Prenom (facturation)|Adresse 1 de facturation|Adresse 2 de facturation|Code postal de facturation|Ville de facturation|Pays de facturation|Statut de la commande";


            // string contents= entete;

            XmlNode root = doc.DocumentElement;

            XmlNodeList nodeList = root.SelectNodes("//Order");// (".//Order", nsmgr);

            for (int k = 0; k < nodeList.Count; k++)
            {

                XmlNode order = nodeList[k];
                XPathNavigator nav = order.CreateNavigator();


                XmlNodeList nodeLineList = order.SelectNodes(".//OrderLine");
                for (int kk = 0; kk < nodeLineList.Count; kk++)
                {
                    XmlNode orderLine = nodeLineList[kk];
                    XPathNavigator navLine = orderLine.CreateNavigator();
                    contents += "¤";
                    IEnumerable<string> lin = contents.Split('¤');
                    for (int i = 1; i <= 35; i++)
                    {
                        switch (i)
                        {
                            case 1:
                                try
                                {
                                    contents += order.Attributes["OrderID"].Value + "|";//SelectSingleNode("//Order/@OrderID", nsmgr).Value  + "|";
                                }
                                catch { contents += "|"; }
                                break;
                            case 2:
                                try
                                {
                                    contents += orderLine.Attributes["OrderLineID"].Value + "|"; // order.SelectSingleNode("//OrderLine/@OrderLineID", nsmgr).Value + "|";
                                }
                                catch { contents += "|"; }
                                break;
                            case 3:
                                try
                                {
                                    contents += order.Attributes["OrderDate"].Value + "|"; //order.SelectSingleNode("//Order/@OrderDate", nsmgr).Value  + "|";
                                }
                                catch { contents += "|"; }
                                break;
                            case 5:
                                try
                                {
                                    // contents += getNodeValue(navLine, ".//DeliveryAddress/Title", kk) + "|"; // order.SelectSingleNode("//DeliveryAddress/Title", nsmgr).InnerXml +  "|";
                                    contents += orderLine.SelectSingleNode(".//DeliveryAddress/Title", nsmgr).InnerXml + "|";
                                }
                                catch { contents += "|"; }
                                break;
                            case 6:
                                try
                                {
                                    //contents += getNodeValue(navLine, ".//DeliveryAddress/Name1", kk).Split(' ')[0] + "|";
                                    contents += orderLine.SelectSingleNode(".//DeliveryAddress/Name1", nsmgr).InnerXml.Split(' ')[0] + "|";
                                }
                                catch { contents += "|"; }
                                break;
                            case 7:
                                try
                                {
                                    string[] arrName = orderLine.SelectSingleNode(".//DeliveryAddress/Name1", nsmgr).InnerXml.Split(' ');
                                    arrName[0] = "";
                                    contents += Join(arrName, ' ') + "|";
                                }
                                catch { contents += "|"; }
                                break;
                            case 8:
                                try
                                {
                                    contents += orderLine.SelectSingleNode(".//DeliveryAddress/Address2", nsmgr).InnerXml + "|";
                                }
                                catch { contents += "|"; }
                                break;
                            // case 9:
                            //contents += order.SelectSingleNode("//DeliveryAddress/Address1", nsmgr).InnerXml + "|";
                            //  break;
                            case 10:
                                try
                                {
                                    contents += orderLine.SelectSingleNode(".//DeliveryAddress/ZIPCode", nsmgr).InnerXml + " | ";
                                }
                                catch { contents += "|"; }
                                break;
                            case 11:
                                try
                                {
                                    // contents += getNodeValue(navLine, ".//DeliveryAddress/City", kk) + "|";
                                    contents += orderLine.SelectSingleNode(".//DeliveryAddress/City", nsmgr).InnerXml + " | ";
                                }
                                catch { contents += "|"; }
                                break;
                            case 12:
                                try
                                {
                                    string country = orderLine.SelectSingleNode(".//DeliveryAddress/CountryCode", nsmgr).InnerXml + " | ";
                                    if (country.ToLower() == "fr") country = "France";
                                    contents += country + "|";
                                }
                                catch { contents += "|"; }
                                break;
                            case 13:
                                try
                                {
                                    string phoneType = orderLine.SelectSingleNode(".//PhoneNumber/@PhoneType", nsmgr).Value;
                                    if (phoneType == "Home")
                                        contents += orderLine.SelectSingleNode(".//Delivery/PhoneNumber", nsmgr).InnerXml + "|";
                                    else
                                        contents += "|";

                                }
                                catch { contents += "|"; }
                                break;
                            case 14:
                                try
                                {
                                    string phoneType = orderLine.SelectSingleNode(".//PhoneNumber/@PhoneType", nsmgr).Value;
                                    if (phoneType == "Mobile")
                                        contents += orderLine.SelectSingleNode(".//Delivery/PhoneNumber", nsmgr).InnerXml + "|";
                                    else
                                        contents += "|";
                                }
                                catch { contents += "|"; }
                                break;
                            case 15:
                                try
                                {
                                    contents += orderLine.SelectSingleNode(".//Delivery/AliasEmail", nsmgr).InnerXml.Replace("\n", "").Replace("\r", "") + "|";
                                }
                                catch { contents += "|"; }
                                break;
                            case 16:
                                try
                                {
                                    contents += orderLine.ChildNodes[0].Attributes["ItemStandardID"].Value + "|";
                                }
                                catch { contents += "|"; }
                                break;
                            case 20:
                                try
                                {
                                    string quant = orderLine.SelectSingleNode("Quantity", nsmgr).InnerXml;
                                    decimal qutite = Decimal.Parse(quant.Replace(".", ","), NumberStyles.Float);
                                    contents += qutite.ToString("#.##") + "|";
                                }
                                catch { contents += "|"; }
                                break;
                            case 21:
                                try
                                {
                                    string prix = orderLine.SelectSingleNode(".//Offer/SellingPrice", nsmgr).InnerXml;
                                    string qut = orderLine.SelectSingleNode("Quantity", nsmgr).InnerXml;
                                    decimal mont = Decimal.Parse(prix.Replace(".", ","), NumberStyles.Float) *
                                    Decimal.Parse(qut.Replace(".", ","), NumberStyles.Float);
                                    contents += mont.ToString("C", CultureInfo.CreateSpecificCulture("fr")).Replace(" €", "") + " |";
                                }
                                catch { contents += "|"; }
                                break;
                            case 22:
                                try
                                {
                                    string frais = orderLine.SelectSingleNode(".//Delivery/DeliveryFee", nsmgr).InnerXml;
                                    contents += Decimal.Parse(frais.Replace(".", ","), NumberStyles.Float) + "|";
                                }
                                catch { contents += "|"; }
                                break;
                            case 23:
                                contents += "Home|";

                                break;
                            case 24:
                                try
                                {
                                    if (orderLine.SelectSingleNode(".//Delivery/DeliveryInstruction", nsmgr).InnerXml.Length > 70)
                                        contents += orderLine.SelectSingleNode(".//Delivery/DeliveryInstruction", nsmgr).InnerXml.Substring(70);
                                    else
                                        contents += orderLine.SelectSingleNode(".//Delivery/DeliveryInstruction", nsmgr).InnerXml + "|";
                                }
                                catch { contents += "|"; }
                                break;
                            case 25:
                                try
                                {
                                    int instLength = orderLine.SelectSingleNode(".//Delivery/DeliveryInstruction", nsmgr).InnerXml.Length;
                                    if (instLength > 70)
                                        contents += orderLine.SelectSingleNode(".//Delivery/DeliveryInstruction", nsmgr).InnerXml.Substring(70, instLength);
                                    contents += "|";
                                }
                                catch { contents += "|"; }
                                break;
                            case 26:
                                contents += "|";
                                break;
                            case 27:
                                try
                                {
                                    contents += order.SelectSingleNode(".//BillingAddress/Title", nsmgr).InnerXml + "|";
                                }
                                catch { contents += "|"; }
                                break;
                            case 28:
                                try
                                {
                                    contents += order.SelectSingleNode(".//BillingAddress/Name1", nsmgr).InnerXml.Split(' ')[0] + "|";
                                }
                                catch { contents += "|"; }
                                break;
                            case 29:
                                try
                                {
                                    string[] arrName = order.SelectSingleNode(".//BillingAddress/Name1", nsmgr).InnerXml.Split(' ');
                                    arrName[0] = "";
                                    contents += Join(arrName, ' ') + "|";
                                }
                                catch { contents += "|"; }
                                break;
                            case 30:
                                try
                                {
                                    contents += order.SelectSingleNode(".//BillingAddress/Address2", nsmgr).InnerXml + "|";
                                }
                                catch { contents += "|"; }
                                break;
                            //case 31:
                            //contents += order.SelectSingleNode("//BillingAddress/Address1", nsmgr).InnerXml + "|";
                            //   break;

                            case 32:
                                try
                                {
                                    contents += order.SelectSingleNode(".//BillingAddress/ZIPCode", nsmgr).InnerXml + "|";
                                }
                                catch { contents += "|"; }
                                break;
                            case 33:
                                try
                                {
                                    contents += order.SelectSingleNode(".//BillingAddress/City", nsmgr).InnerXml + "|";
                                }
                                catch { contents += "|"; }
                                break;
                            case 34:
                                try
                                {
                                    string country = order.SelectSingleNode(".//BillingAddress/CountryCode", nsmgr).InnerXml;
                                    if (country.ToLower() == "fr") country = "France";
                                    contents += country + "|";
                                }
                                catch { contents += "|"; }
                                break;
                            case 35:
                                try
                                {
                                    if (orderLine.Attributes["StatusCode"].Value.ToLower().Equals("created"))
                                        contents += "Accepted";
                                    else
                                        contents += orderLine.Attributes["StatusCode"].Value;
                                }
                                catch { contents += "|"; }
                                break;
                            default:
                                contents += "|";
                                break;
                        }

                    }//contents += "|";

                }
            }
            IEnumerable<string> lines = contents.Split('¤');
            System.IO.File.AppendAllLines(filedest, lines);
        }
        public static List<Order> CreateOrderLineModel(string fileName,string tvaactuel, Func<string,string> generatecolor)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(fileName);

            XmlNamespaceManager nsmgr = new XmlNamespaceManager(doc.NameTable);
            nsmgr.AddNamespace("S", "http://schemas.xmlsoap.org/soap/envelope");
            nsmgr.AddNamespace("new", "http://RedouteFrance/seller/order/1.2");
            nsmgr.AddNamespace("ns", "http://Redcats/Order/SellerOrder/2.0/RetrieveSellerOrder/6.0");
            nsmgr.AddNamespace("ns1", "http://Redcats/Order/SellerOrder/2.0/xsdHUB/6.0");

            XmlNode root = doc.DocumentElement;

            XmlNodeList nodeList = root.SelectNodes("//Order");

            List<Order> listeOrdre = new List<Order>();
            for (int k = 0; k < nodeList.Count; k++)
            {
                decimal frais = 0;
                XmlNode orderCmd = nodeList[k];
                XPathNavigator navCmd = orderCmd.CreateNavigator();
                Address addressbillling = new Address();
                Order orderEle = new Order();
                List<OrderLine> listeOrdreline = new List<OrderLine>();
                XmlNodeList nodeListOrderLine = orderCmd.SelectNodes(".//OrderLine");
                decimal somme = 0;
                decimal total = 0;
                decimal valeurTVA = 0; string formats = @"MM\/dd\/yyyy";


                for (int j = 0; j < nodeListOrderLine.Count; j++)
                {
                    OrderLine orderline = new OrderLine();
                    Address address = new Address();

                    XmlNode order = nodeListOrderLine[j];
                    XPathNavigator nav = order.CreateNavigator();
                    if (order.Attributes["StatusCode"].Value.ToLower().Equals("shipped"))
                    {
                        try
                        {
                            orderline.Reference = order.ChildNodes[0].Attributes["ItemStandardID"].Value;
                            orderline.Designation = generatecolor(orderline.Reference);
                            orderline.Devise = "EUR";
                            orderline.Numero_Facture = "numero facture";
                            orderline.TVA = Decimal.Parse((tvaactuel).Replace(".", ","), NumberStyles.Float);
                            valeurTVA = orderline.TVA;
                            orderline.Numero_Commande = orderCmd.Attributes["OrderID"].Value;

                            orderline.Date_Facturation = DateTime.Now;
                            //Delivery Address
                            address.Title = getNodeValue(nav, ".//DeliveryAddress/Title", j);
                            address.D_Name1 = getNodeValue(nav, ".//DeliveryAddress/Name1", j).Split(' ')[0];
                            string[] arrName = getNodeValue(nav, ".//DeliveryAddress/Name1", j).Split(' ');
                            arrName[0] = "";
                            orderline.AddressLivraison = new Address();
                            address.G_Name1 = Join(arrName, ' ');
                            address.Address2 = getNodeValue(nav, ".//DeliveryAddress/Address2", j);
                            address.ZipCode = Int32.Parse(getNodeValue(nav, "//DeliveryAddress/ZIPCode", j));
                            address.City = getNodeValue(nav, ".//DeliveryAddress/City", j);
                            orderline.AddressLivraison = address;
                            orderline.Email = getNodeValue(nav, ".//Delivery/AliasEmail", j);
                            //Calcul des montants
                            string quant = getNodeValue(nav, "//OrderLine/Quantity", j);
                            int qutite = Int32.Parse(quant.Replace(".", ","), NumberStyles.Float);
                            orderline.Quantite = qutite;
                            string prix = getNodeValue(nav, "//Offer/SellingPrice", j);
                            string qut = getNodeValue(nav, "//OrderLine/Quantity", j);
                            //calcul du montant HT
                            var mont = Decimal.Parse(prix.Replace(".", ","), NumberStyles.Float) *
                            Int32.Parse(qut.Replace(".", ","), NumberStyles.Float);
                            somme += mont;

                            string wefee = getNodeValue(nav, "//Offer/Delivery/DeliveryFee", j);

                            orderline.Prix_Unitaire = Decimal.Parse(prix.Replace(".", ","), NumberStyles.Float);
                            orderline.Frais_Livraison = Decimal.Parse(wefee.Replace(".", ","), NumberStyles.Float);
                            orderline.Prix_TTC = mont * (1 + orderline.TVA);
                            frais = orderline.Frais_Livraison;
                        }
                        catch (Exception e) { }

                    }
                    listeOrdreline.Add(orderline);
                }
                //Billing addresse
                XmlNodeList nodeBilling = orderCmd.SelectNodes(".//BillingAddress");
                XmlNode ord = nodeBilling[0];
                XPathNavigator navOrd = ord.CreateNavigator();
                orderEle.Date_Commande = DateTime.Parse(orderCmd.Attributes["OrderDate"].Value);
                orderEle.Total_HT = somme;
                orderEle.Total_TTC = somme * (1 + valeurTVA) + frais;
                orderEle.Total_TVA = somme * valeurTVA;
                addressbillling.Title = getNodeValue(navOrd, "//BillingAddress/Title", k);
                orderEle.AddressFacturation = new Address();
                addressbillling.D_Name1 = getNodeValue(navOrd, "//BillingAddress/Name1", k).Split(' ')[0];
                string[] arr2Name = getNodeValue(navOrd, "//BillingAddress/Name1", k).Split(' ');
                arr2Name[0] = "";
                addressbillling.G_Name1 = Join(arr2Name, ' ');
                addressbillling.Address2 = getNodeValue(navOrd, "//BillingAddress/Address2", k);
                addressbillling.ZipCode = Int32.Parse(getNodeValue(navOrd, "//BillingAddress/ZIPCode", k));
                addressbillling.City = getNodeValue(navOrd, "//BillingAddress/City", k);

                orderEle.AddressFacturation = addressbillling;
                orderEle.OrderLines = listeOrdreline;
                listeOrdre.Add(orderEle);

            }
            return listeOrdre;

        }
        public static void SendBillMail(string filename, List<Order> orders,
                                            string host,
                                            int port,
                                            bool ssl,
                                            string username,
                                            string password,
                                            bool isERR,
                                            int commandID,
                                            Action<string,bool,int> setRichTextBox
                                            )
        {


            //List<Order> orders = XmlFileManager.CreateOrderLineModel(filename, Program.Globals.tvaActuel, GenericColors.find);
            //GenerateFacture facture = new GenerateFacture();
            var factureName = String.Empty;
            var num_facture = String.Empty;



            foreach (var order in orders)
            {
                var prenom = String.Empty; var nom = String.Empty;
                var title = String.Empty;
                factureName = GenerateFacture.GeneratePDF(order);
                if (!String.IsNullOrEmpty(factureName))
                {
                    MailSender mailer = new MailSender(host,
                                                       port,
                                                       ssl,
                                                       username,
                                                       password
                                                       );

                    MailSender.facture = new Attachment(factureName);
                    MailSender.cgv = new Attachment(@"D:\projects\sanarsoft\fichierCGV.txt");

                    foreach (var orderline in order.OrderLines)
                    {
                        if (!String.IsNullOrEmpty(orderline.Email))
                        {
                            mailer.ToEmail = orderline.Email;
                        }

                        num_facture = orderline.Numero_Facture;
                        if (!String.IsNullOrEmpty(orderline.AddressLivraison.D_Name1))
                        {
                            prenom = orderline.AddressLivraison.D_Name1;
                        }
                        if (!String.IsNullOrEmpty(orderline.AddressLivraison.G_Name1))
                        {
                            nom = orderline.AddressLivraison.G_Name1;
                        }
                        if (!String.IsNullOrEmpty(orderline.AddressLivraison.Title))
                        {
                            title = orderline.AddressLivraison.Title;
                        }

                    }

                    MailSender.Subject = "Votre facture Monceau Fleurs du " + order.Date_Commande;
                    string body = "Bonjour " + title + " " + nom + " " + prenom + "," + "<br /> <br />" +

                        "Monceau Fleurs vous remercie pour votre achat du " + order.Date_Commande + ". Vous pouvez consulter votre" + "<br/>" +
                        "facture n° " + num_facture + " en pièce jointe, au format PDF." + "<br/>" +
                        "<br/>" +
                        "Merci de votre confiance et à très vite dans nos magasins Monceau Fleurs ou sur" + "<br/>" +
                        "www.monceaufleurs.com." + "<br/>" +
                        "<br/>" +
                        "Pour toute question sur votre achat, n’hésitez pas à nous contacter par email à " + "<br/>" +
                        "service.consommateurs@emova-group.com." + "<br/>" +
                        "<br/>" +
                        "L'équipe Monceau Fleurs";

                    mailer.Body = body;

                    try
                    {
                        mailer.Send();
                    }
                    catch (Exception ex)
                    {

                        setRichTextBox("\nErreur : Une erreur est survenue lors de l'envoi de l'email", isERR, commandID);
                    }
                }
            }

        }
        private static string getNodeValue(XPathNavigator nav, string path, int k)
        {
            XPathNodeIterator iterator = nav.Select(path); int i = 0;
            while (iterator.MoveNext())
            {
                if (i++ == k)
                    return iterator.Current.Value;
            }
            return "";
        }
        private static string Join(string[] arrName, char v)
        {
            string ret = "";
            for (int i = 0; i < arrName.Length; i++)
            {
                ret += arrName[i] + v;
            }
            return ret;
        }
        private static string formatDate(string v1, string v2)
        {
            string[] arrDat = v1.Split('/');
            string[] arrHeur = v2.Split(':');
            return arrDat[2] + "-" + arrDat[1] + "-" + arrDat[0] + "T" + arrHeur[0] + ":" + arrHeur[1];
        }
    }
}
