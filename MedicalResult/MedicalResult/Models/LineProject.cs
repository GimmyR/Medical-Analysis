using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalAnalysis.Model {

    public class LineProject {
    
        // ATTRIBUTES :

        private float a, b, c;

        // CONSTRUCTS :

        public LineProject(float a, float b, float c) {

            this.A = a;
            this.B = b;
            this.C = c;

        }

        // PROPERTIES :

        public float A {

            get { return this.a; }
            set { this.a = value; }

        }

        public float B {

            get { return this.b; }
            set { this.b = value; }

        }

        public float C {

            get { return this.c; }
            set { this.c = value; }

        }

        // METHODS :



        // STATIC METHODS :


    
    }

}
