using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Rotation
{
    public class Quaternion
    {
        public float w, x, y, z;

        public float getW() { return w; }
        public float getX() { return x; }
        public float getY() { return y; }
        public float getZ() { return z; }

        public Quaternion(float wVal, float xVal, float yVal, float zVal)
        {
            w = wVal; x = xVal; y = yVal; z = zVal;
        }

        public double quaternion_length(Quaternion q)
        {
            return Math.Sqrt(q.w * q.w + q.x * q.x + q.y * q.y + q.z * q.z);
        }

        public Quaternion quaternion_normalize(Quaternion q)
        {
            double L = quaternion_length(q);

            q.w *= (float)L;
            q.x *= (float)L;
            q.y *= (float)L;
            q.z *= (float)L;

            return q;
        }
    }   
}
