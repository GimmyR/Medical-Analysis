using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace MedicalAnalysis.Model {

    public class UtilsModel {
    
        // STATIC METHODS :

        public static float AdaptAngle(float angle) {

            if (angle > 360)
                return angle - 360;
            else
                return angle + 360;

        }

        public static PointF ConvertToGraph(PointF value, float graphWH, float marge) {

            float origin = (graphWH / 2) + marge;
            PointF result = new PointF(value.X - origin, origin - value.Y);

            return result;

        }

        public static PointF InvertFromGraph(PointF value, float graphWH, float marge) {

            float origin = (graphWH / 2) + marge;
            return new PointF(value.X + origin, value.Y + origin);

        }

        public static Line FindSegment(Axe axe, Rectangle rectLimit) {

            PointF[] squareSeg = new PointF[2], segTmp = new PointF[2];
            float angle = axe.Angle;

            if (angle >= 0 && angle <= 45 || angle >= 315 && angle <= 360) {

                squareSeg[0] = ConvertToGraph(new PointF(rectLimit.Location.X + rectLimit.Width, rectLimit.Location.Y), rectLimit.Width, rectLimit.Location.X);
                squareSeg[1] = ConvertToGraph(new PointF(rectLimit.Location.X + rectLimit.Width, rectLimit.Location.Y + rectLimit.Height), rectLimit.Width, rectLimit.Location.X);

            } else if (angle > 45 && angle < 135) {

                squareSeg[0] = ConvertToGraph(new PointF(rectLimit.Location.X, rectLimit.Location.Y), rectLimit.Width, rectLimit.Location.X);
                squareSeg[1] = ConvertToGraph(new PointF(rectLimit.Location.X + rectLimit.Width, rectLimit.Location.Y), rectLimit.Width, rectLimit.Location.X);

            } else if (angle >= 135 && angle <= 225) {

                squareSeg[0] = ConvertToGraph(new PointF(rectLimit.Location.X, rectLimit.Location.Y), rectLimit.Width, rectLimit.Location.X);
                squareSeg[1] = ConvertToGraph(new PointF(rectLimit.Location.X, rectLimit.Location.Y + rectLimit.Height), rectLimit.Width, rectLimit.Location.X);

            } else {

                squareSeg[0] = ConvertToGraph(new PointF(rectLimit.Location.X, rectLimit.Location.Y + rectLimit.Height), rectLimit.Width, rectLimit.Location.X);
                squareSeg[1] = ConvertToGraph(new PointF(rectLimit.Location.X + rectLimit.Width, rectLimit.Location.Y + rectLimit.Height), rectLimit.Width, rectLimit.Location.X);

            }

            segTmp[0] = new PointF(0, 0);
            segTmp[1] = Line.GetLine(squareSeg[0], squareSeg[1]).CutWith(Line.GetLine(segTmp[0], angle));

            PointF a = InvertFromGraph(segTmp[0], rectLimit.Width, rectLimit.Location.X);
            PointF b = InvertFromGraph(segTmp[1], rectLimit.Width, rectLimit.Location.X);

            return Line.GetLine(a, b);

        }

        public static float RuleOfThree(float a, float b, float c) { return c * b / a; }

        public static float LineLength(PointF a, PointF b) {

            return (float)Math.Sqrt((b.X - a.X)*(b.X - a.X) + (b.Y - a.Y)*(b.Y - a.Y));

        }

        public static float AngleFromHorizontal(float angle, int direction) {

            if (direction == 1)
                return 180 - angle;
            else if (direction == 2)
                return angle - 180;
            else if (direction == 3)
                return 360 - angle;
            else
                return angle;

        }

        public static PointF GetPointFromHypothenuse(float length, float angle) {

            return new PointF((float)(length * Math.Cos(Math.PI * angle / 180)), (float)(length * Math.Sin(Math.PI * angle / 180)));

        }

        public static PointF CalculateCurrPoint(float length, float angle, float graphWH, float marge) {

            //throw new Exception("length=" + length + ";angle=" + angle);

            PointF result = default(PointF); float angle_tmp = -1;

            if(angle >= 0 && angle < 90) {

                angle_tmp = AngleFromHorizontal(angle, 0);
                result = GetPointFromHypothenuse(length, angle_tmp);

            } else if (angle >= 90 && angle < 180) {

                angle_tmp = AngleFromHorizontal(angle, 1);
                result = GetPointFromHypothenuse(length, angle_tmp);
                result.X *= -1;

            } else if (angle >= 180 && angle < 270) {

                angle_tmp = AngleFromHorizontal(angle, 2);
                result = GetPointFromHypothenuse(length, angle_tmp);
                result.X *= -1;
                result.Y *= -1;

            } else if (angle >= 270 && angle < 360) {

                angle_tmp = AngleFromHorizontal(angle, 3);
                result = GetPointFromHypothenuse(length, angle_tmp);
                result.Y *= -1;

            } return InvertFromGraph(result, graphWH, marge);

        }
    
    }

}
