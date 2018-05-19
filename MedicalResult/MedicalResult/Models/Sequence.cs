using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalAnalysis.Model {

    public class Sequence {

        public String nom;
        public String prefixe;
        public int longueur;
        public int valeur;

        public Sequence() { }

        public Sequence(String nom, String prefixe, int longueur, int valeur) {

            this.nom = nom;
            this.prefixe = prefixe;
            this.longueur = longueur;
            this.valeur = valeur;

        }

        public String GetId() {

            String result = prefixe;

            String tmp = valeur + "";
            while (tmp.Length < longueur)
                tmp = "0" + tmp;

            return (result + tmp);

        }

        public void Next() { valeur++; }

    }

}
