using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalAnalysis.Model {

    public class Consultation : Axe {

        public Consultation() {}

        public Consultation(String id, String name, float lowerX, float upperX, float lowerNormal, float upperNormal, float marginSimilar, String unit) : 
            base(id, name, lowerX, upperX, lowerNormal, upperNormal, marginSimilar, unit) {}

    }

}
