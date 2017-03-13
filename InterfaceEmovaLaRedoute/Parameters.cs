using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace safeprojectname

{
    public abstract class Parameters
    {
        public static string startProductText = @"Démarrage du web service d'envoi des produits";
        public static string stopProductText = @"Arrêt du web service d'envoi des produits";
        public static string startOfferText = @"Démarrage du web service d'envoi des offres";
        public static string stopOfferText = @"Arrêt du web service d'envoi des offres";
        public static string startCommandText = @"Démarrage du web service de réception des commandes";
        public static string stopCommandText = @"Arrêt du web service de réception des commandes";
        public static int productId = 0;
        public static int offerId = 1;
        public static int commandId = 2;
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


    }
}

