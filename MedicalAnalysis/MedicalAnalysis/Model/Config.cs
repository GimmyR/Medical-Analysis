using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalAnalysis.Model {

    public class Config {

        private Patient patient;
        private Axe axe;
        private float valeur;

        public Config() { }

        public Config(Patient patient, Axe axe, float valeur) {

            this.Patient = patient;
            this.Axe = axe;
            this.Valeur = valeur;

        }

        public Patient Patient {
            get { return this.patient; }
            set { this.patient = value; }
        }

        public Axe Axe {
            get { return this.axe; }
            set { this.axe = value; }
        }

        public float Valeur {
            get { return this.valeur; }
            set {
                if (value >= 0)
                    this.valeur = value;
                else
                    throw new ModelException("La valeur du point sur cet axe est invalide !");
            }
        }

        public AxeCond GetAxeCond() {

            axe.CurrValue = valeur;

            if(axe.GetType() == typeof(Consultation))
                return new AxeCond(axe.Id, axe.GetCode(), true);
            else
                return new AxeCond(axe.Id, axe.GetCode(), false);

        }

    }

}
