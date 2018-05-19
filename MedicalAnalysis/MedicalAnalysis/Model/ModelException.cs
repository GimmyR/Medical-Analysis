using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalAnalysis.Model {
    public class ModelException : Exception {

        public ModelException(String message) : base(message) { }

    }
}
