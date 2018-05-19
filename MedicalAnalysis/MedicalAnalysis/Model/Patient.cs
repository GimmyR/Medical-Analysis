using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalAnalysis.Model {

    public class Patient : BaseModel {

        private String id;
        private DateTime dateDiag;
        private String nom;
        private int sexe;
        private int age;

        public Patient() { }

        public Patient(String id, DateTime dateDiag, String nom, int sexe, int age) {

            this.Id = id;
            this.DateDiag = dateDiag;
            this.Nom = nom;
            this.Sexe = sexe;
            this.Age = age;

        }

        public String Id {

            get { return this.id; }
            set { this.id = value; }

        }

        public DateTime DateDiag {

            get { return this.dateDiag; }
            set { this.dateDiag = value; }

        }

        public String Nom {

            get { return this.nom; }
            set { this.nom = value; }

        }

        public int Sexe {

            get { return this.sexe; }
            set {
                if (value == 0 || value == 1)
                    this.sexe = value;
                else
                    throw new ModelException("Votre sexe est incorrect !");
            }

        }

        public int Age {

            get { return this.age; }
            set {
                if (value >= 0)
                    this.age = value;
                else
                    throw new ModelException("Votre age est incorrect !");
            }

        }

    }

}
