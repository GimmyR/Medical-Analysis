using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace MedicalAnalysis.Model {

    public class Line {

        // ATTRIBUTES :

        private bool vertical;
        private float a, b, x;

        private PointF p1, p2;

        // CONSTRUCTS :

        public Line(float a, float b) {

            this.A = a;
            this.B = b;

        }

        public Line(float x) {

            this.X = x;

        }

        // PROPERTIES :

        public float A {

            get { return a; }
            set { this.vertical = false; this.a = value; }

        }

        public float B {

            get { return b; }
            set { this.vertical = false; this.b = value; }

        }

        public float X {

            get { return x; }
            set { this.vertical = true; this.x = value; }

        }

        public PointF P1 {

            get { return this.p1; }
            set { this.p1 = value; }

        }

        public PointF P2 {

            get { return this.p2; }
            set { this.p2 = value; }

        }

        // METHODS :

        public bool IsVertical() { return vertical; }

        public PointF CutWith(Line line) {

            PointF result = new PointF();

            if (this.IsVertical() && !line.IsVertical()) {

                result.X = this.X;
                result.Y = result.X * line.A + line.B;

            } else if (!this.IsVertical() && line.IsVertical()) {

                result.X = line.X;
                result.Y = result.X * this.A + this.B;

            } else {

                result.X = (line.B - this.B) / (this.A - line.A);
                result.Y = result.X * this.A + this.B;

            } return result;

        }

        // STATIC METHODS :

        public static Line GetLine(PointF p1, PointF p2) {

            Line result = null;

            if (p1.X == p2.X)
                result = new Line(p1.X);
            else {

                float a = (p2.Y - p1.Y) / (p2.X - p1.X);
                float b = p1.Y - a * p1.X;

                result = new Line(a, b);

            } result.P1 = p1; result.P2 = p2;
            
            return result;

        }

        public static Line GetLine(PointF p1, float angle) {

            float a = (float)Math.Tan(Math.PI * angle / 180);
            float b = p1.Y - a * p1.X;

            return new Line(a, b);

        }

    }

}
