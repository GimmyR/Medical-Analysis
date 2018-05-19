using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace MedicalAnalysis.Model {

    public class Axe : BaseModel {
    
        // ATTRIBUTES :

        private String id;
        private String name;
        private float lowerX, upperX;
        private float lowerNormal, upperNormal;
        private float marginSimilar;
        private String unit;

        private float angle;
        private float currValue;
        private Line line;

        // CONSTRUCTS :

        public Axe() {}

        public Axe(String id, String name, float lowerX, float upperX, float lowerNormal, float upperNormal, float marginSimilar, String unit) {

            this.Id = id;
            this.Name = name;
            this.lowerX = lowerX;
            this.upperX = upperX;
            this.LowerNormal = lowerNormal;
            this.UpperNormal = upperNormal;
            this.MarginSimilar = marginSimilar;
            this.CurrValue = (this.lowerNormal + this.upperNormal) / 2;
            this.Unit = unit;

        }

        // PROPERTIES :

        public String Id {

            get { return this.id; }

            set { this.id = value; }

        }

        public String Name {

            get { return this.name; }

            set { this.name = value; }

        }

        public float LowerX {

            get { return this.lowerX; }

            set {
                if (value >= 0)
                    this.lowerX = value;
                else
                    throw new ModelException("Lower limit cannot be setted with this value : " + value + " !");
            }

        }

        public float UpperX {

            get { return this.upperX; }

            set {
                if (value >= 0)
                    this.upperX = value;
                else
                    throw new ModelException("Upper limit cannot be setted with this value : " + value + " !");
            }

        }

        public float LowerNormal {

            get { return this.lowerNormal; }

            set {
                if (value >= this.lowerX && value <= this.upperX)
                    this.lowerNormal = value;
                else
                    throw new ModelException("Lower normal cannot be setted with this value : " + value + " (out of limit) !");
            }

        }

        public float UpperNormal {

            get { return this.upperNormal; }

            set {
                if (value >= this.lowerX && value <= this.upperX)
                    this.upperNormal = value;
                else
                    throw new ModelException("Upper normal cannot be setted with this value : " + value + " (out of limit) !");
            }

        }

        public float MarginSimilar {

            get { return this.marginSimilar; }

            set {
                if (value >= 0)
                    this.marginSimilar = value;
                else
                    throw new ModelException("Upper normal cannot be setted with this value : " + value + " (out of limit) !");
            }

        }

        public float CurrValue {

            get { return this.currValue; }

            set {
                if (value >= this.lowerX && value <= this.upperX)
                    this.currValue = value;
                else if (value < this.lowerX)
                    this.currValue = this.lowerX;
                else
                    this.currValue = this.upperX;
            }

        }

        public String Unit {

            get { return this.unit; }

            set { this.unit = value; }

        }

        public float Angle {

            get { return this.angle; }

            set {
                if (value >= 0 && value <= 360)
                    this.angle = value;
                else
                    this.angle = UtilsModel.AdaptAngle(value);
            }

        }

        public Line Line {

            get { return this.line; }
            set { this.line = value; }

        }

        // METHODS :

        public void SetLine(PointF a, PointF b) { this.line = Line.GetLine(a, b); }

        public int GetCode() {

            if (this.CurrValue > this.UpperNormal)
                return 2;
            else if (this.CurrValue < this.LowerNormal)
                return 1;
            else
                return 0;

        }

        // STATIC METHODS :


    
    }

}
