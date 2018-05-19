using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalAnalysis.Model {

    public class AnalysisResult {

        // ATTRIBUTES :

        private String name;
        private float percentage;

        // CONSTRUCTS :

        public AnalysisResult(String name, float percentage) {

            this.Name = name;
            this.Percentage = percentage;

        }

        // PROPERTIES :

        public String Name {

            get { return this.name; }
            set { this.name = value; }

        }

        public float Percentage {

            get { return this.percentage; }
            set {

                if (value > 0)
                    this.percentage = value;
                else
                    throw new ModelException("Invalid percentage : " + value + " !");

            }

        }

        // METHODS :



        // STATIC METHODS :



    }

}
