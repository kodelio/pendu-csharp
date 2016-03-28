using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pendu_GERMAN_TOSON
{
    public class Pendu
    {
        public String mot { get; set; }
        public String motMystere { get; set; }
        public String lettresCherches { get; set; }
        public int coupsRestants { get; set; }

        public Pendu()
        {
            String[] listeMots = { "bateau", "chaise", "film", "taxi", "montagne", "stylo" };
            Random rand = new Random();
            mot = listeMots[rand.Next(listeMots.Length)];
            motMystere = "";
            for (int i = 0; i < mot.Length; i++)
            {
                motMystere += "-";
            }
            lettresCherches = "";
            coupsRestants = 7;
        }

        public void TesteLettre(char lettre)
        {
            lettre = lettre.ToString().ToLower()[0];
            if (!lettresCherches.Contains(lettre))
            {
                lettresCherches = lettresCherches + lettre;
                if (!mot.Contains(lettre))
                {
                    coupsRestants--;
                }

                motMystere = "";
                foreach (char l in mot)
                {
                    if (lettresCherches.Contains(l))
                    {
                        motMystere = motMystere + l;
                    }
                    else
                    {
                        motMystere = motMystere + '-';
                    }
                }
            }
        }
    }
}
