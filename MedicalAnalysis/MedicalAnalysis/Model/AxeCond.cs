using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalAnalysis.Model {

    public class AxeCond {

        // ATTRIBUTES :

        private String id;
        private int code;
        private bool consul;

        // CONSTRUCTS :

        public AxeCond(String id, int code, bool consul) {

            this.Id = id;
            this.Code = code;
            this.Consul = consul;

        }

        // PROPERTIES :

        public String Id {

            get { return this.id; }
            set { this.id = value; }

        }

        public int Code {

            get { return this.code; }
            set {

                if (value == 1 || value == 2 || value == 0)
                    this.code = value;
                else
                    throw new ModelException("Invalid code for axe condition : " + value + " !");

            }

        }

        public bool Consul {
            get { return this.consul; }
            set { this.consul = value; }
        }

        // METHODS :

        public override String ToString() {

            if(!consul)
                return "(dd.axe='" + this.Id + "' AND dd.code=" + this.Code + ")";
            else
                return "(dd.consultation='" + this.Id + "' AND dd.code=" + this.Code + ")";

        }

        // STATIC METHODS :


    
    }

}
