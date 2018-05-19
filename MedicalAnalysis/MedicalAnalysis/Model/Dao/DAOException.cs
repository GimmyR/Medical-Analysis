using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalAnalysis.Model.Dao {
    public class DAOException : Exception {

        public DAOException(String message) : base(message){}

    }
}
