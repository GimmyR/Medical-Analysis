using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalAnalysis.Model {

    public class Similaire {

        private Axe axe;
        private float min;
        private float max;

        public Similaire() { }

        public Similaire(Axe axe, float min, float max) {

            this.Axe = axe;
            this.Min = min;
            this.Max = max;

        }

        public Axe Axe {
            get { return this.axe; }
            set { this.axe = value; }
        }

        public float Min {
            get { return this.min; }
            set {
                if (value >= axe.LowerX && value <= axe.UpperX)
                    this.min = value;
                else if (value < axe.LowerX)
                    this.min = axe.LowerX;
                else if (value > axe.UpperX)
                    this.min = axe.UpperX;
            }
        }

        public float Max {
            get { return this.max; }
            set {
                if (value >= axe.LowerX && value <= axe.UpperX && value >= this.min)
                    this.max = value;
                else if (value < axe.LowerX)
                    this.min = axe.LowerX;
                else if (value > axe.UpperX)
                    this.min = axe.UpperX;
            }
        }

    }

}
