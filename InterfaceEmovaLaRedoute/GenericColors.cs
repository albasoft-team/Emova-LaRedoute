using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace safeprojectname
{
   abstract class GenericColors
    {
        static List<KeyValuePair<string, string>> kvpList = new List<KeyValuePair<string, string>>()
      {
        new KeyValuePair<string, string>("AUTRES", "V002226"),
        new KeyValuePair<string, string>("BLANC", "V002227"),
        new KeyValuePair<string, string>("NOIR", "V002228"),
        new KeyValuePair<string, string>("GRIS", "V002229"),
        new KeyValuePair<string, string>("MARRON", "V002230"),
        new KeyValuePair<string, string>("ROUGE", "V002231"),
        new KeyValuePair<string, string>("BLEU", "V002232"),
        new KeyValuePair<string, string>("ORANGE", "V002233"),
        new KeyValuePair<string, string>("ROSE", "V002234"),
        new KeyValuePair<string, string>("BEIGE", "V002235"),
        new KeyValuePair<string, string>("VIOLET", "V002236"),
        new KeyValuePair<string, string>("BOIS CLAIR", "V002237"),
        new KeyValuePair<string, string>("JAUNE", "V002238"),
        new KeyValuePair<string, string>("VERT", "V002239"),
        new KeyValuePair<string, string>("BOIS FONCE", "V002240"),
        new KeyValuePair<string, string>("OR", "V019843"),
        new KeyValuePair<string, string>("ARGENT", "V019844"),
        new KeyValuePair<string, string>("MULTICOLOR", "V019845"),
        new KeyValuePair<string, string>("TRANSPARENT", "V021707"),

        new KeyValuePair<string, string>("Nordmann", "V087509"),
        new KeyValuePair<string, string>("Epicéa", "V087510"),
        new KeyValuePair<string, string>("Nobilis", "V087511"),

        new KeyValuePair<string, string>("100/125 cm","V087513"),
        new KeyValuePair<string, string>("125/150 cm","V087513"),
        new KeyValuePair<string, string>("150/175 cm","V087514"),
        new KeyValuePair<string, string>("175/200 cm","V087514"),

        //reférence orderline + description
        new KeyValuePair<string, string>("0020130074047","Sapin nordmann + rondelle 50 + sac à sapin"),
        new KeyValuePair<string, string>("0020130074054","Sapin nordmann + bûche 50 + sac à sapin"),
        new KeyValuePair<string, string>("0020130074061","Sapin nordmann + bûche 60 + sac à sapin"),
        new KeyValuePair<string, string>("0020130074078","Sapin nobilis + bûche 50 + sac à sapin"),

    };
    public static void add(string k, string v) { kvpList.Insert(0, new KeyValuePair<string, string>(k, v)); }
    public static string find(string k) {
            foreach (KeyValuePair<string, string> kvp in kvpList)
            {
                if (kvp.Key.ToLower().Equals(k.ToLower())) return kvp.Value;
            }
            return null;
     }
       
        }
}
