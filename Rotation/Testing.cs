using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Rotation
{
    public static class Testing
    {
        // Pre-calculated value of PI / 180.
        const float kPI180 = 0.017453f;
        // Pre-calculated value of 180 / PI.
        const float k180PI = 57.295780f;

        // Converts degrees to radians.
        static float degreesToRadians(float x)
        {
            return (x * kPI180);
        }

        // Converts radians to degrees.
        static float radiansToDegrees(float x)
        {
            return (x * k180PI);
        }

        // Routine to multiply two quaternions.
        public static Quaternion multiplyQuaternions(Quaternion q1, Quaternion q2)
        {
            float w1, x1, y1, z1, w2, x2, y2, z2, w3, x3, y3, z3;

            w1 = q1.getW(); x1 = q1.getX(); y1 = q1.getY(); z1 = q1.getZ();
            w2 = q2.getW(); x2 = q2.getX(); y2 = q2.getY(); z2 = q2.getZ();

            w3 = w1 * w2 - x1 * x2 - y1 * y2 - z1 * z2;
            x3 = w1 * x2 + x1 * w2 + y1 * z2 - z1 * y2;
            y3 = w1 * y2 + y1 * w2 + z1 * x2 - x1 * z2;
            z3 = w1 * z2 + z1 * w2 + x1 * y2 - y1 * x2;

            Quaternion res = new Quaternion(w3, x3, y3, z3);

            return res;
        }

        // Routine to convert the Euler angle specifying a rotation to a quaternion.
        static Quaternion eulerAnglesToQuaternion(float a, float b, float g)
        {
            float alpha = a;
            float beta = b;
            float gamma = g;
            Quaternion q1, q2, q3;

            //alpha = e.getAlpha(); beta = e.getBeta(); gamma = e.getGamma();

            q1 = new Quaternion((float)Math.Cos(((float)Math.PI / 180.0f) * (alpha / 2.0f)), (float)Math.Sin((Math.PI / 180.0f) * (alpha / 2.0f)), 0.0f, 0.0f);
            q2 = new Quaternion((float)Math.Cos(((float)Math.PI / 180.0f) * (beta / 2.0f)), 0.0f, (float)Math.Sin((Math.PI / 180.0f) * (beta / 2.0f)), 0.0f);
            q3 = new Quaternion((float)Math.Cos(((float)Math.PI / 180.0f) * (gamma / 2.0f)), 0.0f, 0.0f, (float)Math.Sin((Math.PI / 180.0f) * (gamma / 2.0f)));

            return multiplyQuaternions(q1, multiplyQuaternions(q2, q3));
        }

        // Routine to convert a quaternion specifying a rotation to a 4x4 rotation matrix in column-major order.
        static RotationMatrix quaternionToRotationMatrix(Quaternion q)
        {
            float w, x, y, z;
            float[] m = new float[16];

            w = q.getW(); x = q.getX(); y = q.getY(); z = q.getZ();

            m[0] = w * w + x * x - y * y - z * z;
            m[1] = 2.0f * x * y + 2.0f * w * z;
            m[2] = 2.0f * x * z - 2.0f * y * w;
            m[3] = 0.0f;
            m[4] = 2.0f * x * y - 2.0f * w * z;
            m[5] = w * w - x * x + y * y - z * z;
            m[6] = 2.0f * y * z + 2.0f * w * x;
            m[7] = 0.0f;
            m[8] = 2.0f * x * z + 2.0f * w * y;
            m[9] = 2.0f * y * z - 2.0f * w * x;
            m[10] = w * w - x * x - y * y + z * z;
            m[11] = 0.0f;
            m[12] = 0.0f;
            m[13] = 0.0f;
            m[14] = 0.0f;
            m[15] = 1.0f;

            return new RotationMatrix(m);
        }
        public static Quaternion AngleAxis(float aAngle, float aX, float aY, float aZ)
        {
            float s = (float)Math.Sin(aAngle / 2f);
            return new Quaternion((float)Math.Cos(aAngle / 2f), aX * s, aY * s, aZ * s);
        }


        // Write RotationMatrix object r values to global matrixData.
        static void writeMatrixData(RotationMatrix r, float[] matrixData)
        {
            for (int i = 0; i < 16; i++) matrixData[i] = r.getMatrixData(i);
        }

        static float[] mTranspose(float[] A, int m, int n)
        {
            var B = new float[16];

            B[0] = A[0];
            B[1] = A[4];
            B[2] = A[8];
            B[3] = A[12];

            B[4] = A[1];
            B[5] = A[5];
            B[6] = A[9];
            B[7] = A[13];

            B[8] = A[2];
            B[9] = A[6];
            B[10] = A[10];
            B[11] = A[14];

            B[12] = A[3];
            B[13] = A[7];
            B[14] = A[11];
            B[15] = A[15];

            return B;
        }


        // Spherical linear interpolation between unit quaternions q1 and q2 with interpolation parameter t.
        static Quaternion slerp(Quaternion q1, Quaternion q2, float t)
        {
            float w1, x1, y1, z1, w2, x2, y2, z2, w3, x3, y3, z3;
            float theta, mult1, mult2;

            w1 = q1.getW(); x1 = q1.getX(); y1 = q1.getY(); z1 = q1.getZ();
            w2 = q2.getW(); x2 = q2.getX(); y2 = q2.getY(); z2 = q2.getZ();

            // Reverse the sign of q2 if q1.q2 < 0.
            if (w1 * w2 + x1 * x2 + y1 * y2 + z1 * z2 < 0)
            {
                w2 = -w2; x2 = -x2; y2 = -y2; z2 = -z2;
            }

            theta = (float)Math.Acos(w1 * w2 + x1 * x2 + y1 * y2 + z1 * z2);

            if (theta > 0.000001)
            {
                mult1 = (float)Math.Asin((1 - t) * theta) / (float)Math.Asin(theta);
                mult2 = (float)Math.Asin(t * theta) / (float)Math.Asin(theta);
            }

            // To avoid division by 0 and by very small numbers the approximation of sin(angle)
            // by angle is used when theta is small (0.000001 is chosen arbitrarily).
            else
            {
                mult1 = 1 - t;
                mult2 = t;
            }

            w3 = mult1 * w1 + mult2 * w2;
            x3 = mult1 * x1 + mult2 * x2;
            y3 = mult1 * y1 + mult2 * y2;
            z3 = mult1 * z1 + mult2 * z2;

            return new Quaternion(w3, x3, y3, z3);
        }

        static float[] mTranspose4x4(float[] A)
        {
            var B = new float[16];

            B[0] = A[0];
            B[1] = A[4];
            B[2] = A[8];
            B[3] = A[12];

            B[4] = A[1];
            B[5] = A[5];
            B[6] = A[9];
            B[7] = A[13];

            B[8] = A[2];
            B[9] = A[6];
            B[10] = A[10];
            B[11] = A[14];

            B[12] = A[3];
            B[13] = A[7];
            B[14] = A[11];
            B[15] = A[15];

            return B;
        }

        static void mIdentity(float[] matrix, int rows, int cols)
        {
            int size = rows * cols;

            for (int i = 0; i < size; i++)
            {
                matrix[i] = 0.0f;
            }

            rows++;
            for (int i = 0; i < size;)
            {
                matrix[i] = 1.0f;
                i += rows;
            }
        }

        static void euler2rm(double angle_x, double angle_y, double angle_z, double[] mat)
        {
            double A, B, C, D, E, F, AD, BD = 0d;
            A = Math.Cos(angle_x);
            B = Math.Sin(angle_x);
            C = Math.Cos(angle_y);
            D = Math.Sin(angle_y);
            E = Math.Cos(angle_z);
            F = Math.Sin(angle_z);
            AD = A * D;
            BD = B * D;
            mat[0] = C * E;
            mat[1] = -C * F;
            mat[2] = D;
            mat[4] = BD * E + A * F;
            mat[5] = -BD * F + A * E;
            mat[6] = -B * C;
            mat[8] = -AD * E + B * F;
            mat[9] = AD * F + B * E;
            mat[10] = A * C;
            mat[3] = mat[7] = mat[11] = mat[12] = mat[13] = mat[14] = 0;
            mat[15] = 1;
        }

        /** this conversion uses NASA standard aeroplane conventions as described on page:
        *   https://www.euclideanspace.com/maths/geometry/rotations/euler/index.htm
        *   Coordinate System: right hand
        *   Positive angle: right hand
        *   Order of euler angles: heading first, then attitude, then bank
        *   matrix row column ordering:
        *   [m00 m01 m02]
        *   [m10 m11 m12]
        *   [m20 m21 m22]
        */
        public static void NASArotate(float yaw, float pitch, float roll, float[] RM)
        {
            // Assuming the angles are in radians.
            float ch = (float)Math.Cos(yaw);
            float sh = (float)Math.Sin(yaw);
            float ca = (float)Math.Cos(pitch);
            float sa = (float)Math.Sin(pitch);
            float cb = (float)Math.Cos(roll);
            float sb = (float)Math.Sin(roll);

            RM[0] = ch * ca;
            RM[1] = sh * sb - ch * sa * cb;
            RM[2] = ch * sa * sb + sh * cb;
            RM[3] = 0;

            RM[4] = sa;
            RM[5] = ca * cb;
            RM[6] = -ca * sb;
            RM[7] = 0;

            RM[8] = -sh * ca;
            RM[9] = sh * sa * cb + ch * sb;
            RM[10] = -sh * sa * sb + ch * cb;
            RM[11] = 0;
            RM[12] = RM[13] = RM[14] = 0;
            RM[15] = 1;
        }

        public static bool gluInvertMatrix(float[] m, float[] invOut)
        {
            float[] inv = new float[16];
            float det = 0;
            int i;

            inv[0] = m[5] * m[10] * m[15] -
                 m[5] * m[11] * m[14] -
                 m[9] * m[6] * m[15] +
                 m[9] * m[7] * m[14] +
                 m[13] * m[6] * m[11] -
                 m[13] * m[7] * m[10];

            inv[4] = -m[4] * m[10] * m[15] +
                      m[4] * m[11] * m[14] +
                      m[8] * m[6] * m[15] -
                      m[8] * m[7] * m[14] -
                      m[12] * m[6] * m[11] +
                      m[12] * m[7] * m[10];

            inv[8] = m[4] * m[9] * m[15] -
                     m[4] * m[11] * m[13] -
                     m[8] * m[5] * m[15] +
                     m[8] * m[7] * m[13] +
                     m[12] * m[5] * m[11] -
                     m[12] * m[7] * m[9];

            inv[12] = -m[4] * m[9] * m[14] +
                       m[4] * m[10] * m[13] +
                       m[8] * m[5] * m[14] -
                       m[8] * m[6] * m[13] -
                       m[12] * m[5] * m[10] +
                       m[12] * m[6] * m[9];

            inv[1] = -m[1] * m[10] * m[15] +
                      m[1] * m[11] * m[14] +
                      m[9] * m[2] * m[15] -
                      m[9] * m[3] * m[14] -
                      m[13] * m[2] * m[11] +
                      m[13] * m[3] * m[10];

            inv[5] = m[0] * m[10] * m[15] -
                     m[0] * m[11] * m[14] -
                     m[8] * m[2] * m[15] +
                     m[8] * m[3] * m[14] +
                     m[12] * m[2] * m[11] -
                     m[12] * m[3] * m[10];

            inv[9] = -m[0] * m[9] * m[15] +
                      m[0] * m[11] * m[13] +
                      m[8] * m[1] * m[15] -
                      m[8] * m[3] * m[13] -
                      m[12] * m[1] * m[11] +
                      m[12] * m[3] * m[9];

            inv[13] = m[0] * m[9] * m[14] -
                      m[0] * m[10] * m[13] -
                      m[8] * m[1] * m[14] +
                      m[8] * m[2] * m[13] +
                      m[12] * m[1] * m[10] -
                      m[12] * m[2] * m[9];

            inv[2] = m[1] * m[6] * m[15] -
                     m[1] * m[7] * m[14] -
                     m[5] * m[2] * m[15] +
                     m[5] * m[3] * m[14] +
                     m[13] * m[2] * m[7] -
                     m[13] * m[3] * m[6];

            inv[6] = -m[0] * m[6] * m[15] +
                      m[0] * m[7] * m[14] +
                      m[4] * m[2] * m[15] -
                      m[4] * m[3] * m[14] -
                      m[12] * m[2] * m[7] +
                      m[12] * m[3] * m[6];

            inv[10] = m[0] * m[5] * m[15] -
                      m[0] * m[7] * m[13] -
                      m[4] * m[1] * m[15] +
                      m[4] * m[3] * m[13] +
                      m[12] * m[1] * m[7] -
                      m[12] * m[3] * m[5];

            inv[14] = -m[0] * m[5] * m[14] +
                       m[0] * m[6] * m[13] +
                       m[4] * m[1] * m[14] -
                       m[4] * m[2] * m[13] -
                       m[12] * m[1] * m[6] +
                       m[12] * m[2] * m[5];

            inv[3] = -m[1] * m[6] * m[11] +
                      m[1] * m[7] * m[10] +
                      m[5] * m[2] * m[11] -
                      m[5] * m[3] * m[10] -
                      m[9] * m[2] * m[7] +
                      m[9] * m[3] * m[6];

            inv[7] = m[0] * m[6] * m[11] -
                     m[0] * m[7] * m[10] -
                     m[4] * m[2] * m[11] +
                     m[4] * m[3] * m[10] +
                     m[8] * m[2] * m[7] -
                     m[8] * m[3] * m[6];

            inv[11] = -m[0] * m[5] * m[11] +
                       m[0] * m[7] * m[9] +
                       m[4] * m[1] * m[11] -
                       m[4] * m[3] * m[9] -
                       m[8] * m[1] * m[7] +
                       m[8] * m[3] * m[5];

            inv[15] = m[0] * m[5] * m[10] -
                      m[0] * m[6] * m[9] -
                      m[4] * m[1] * m[10] +
                      m[4] * m[2] * m[9] +
                      m[8] * m[1] * m[6] -
                      m[8] * m[2] * m[5];

            det = m[0] * inv[0] + m[1] * inv[4] + m[2] * inv[8] + m[3] * inv[12];

            if (det == 0)
                return false;

            det = 1.0f / det;

            for (i = 0; i < 16; i++)
                invOut[i] = inv[i] * det;

            return true;
        }

        static void mMultiply4x4(float[] A, float[] B, float[] C) // C = A* B
        {
            C[0] = A[0] * B[0] + A[4] * B[1] + A[8] * B[2] + A[12] * B[3];
            C[1] = A[1] * B[0] + A[5] * B[1] + A[9] * B[2] + A[13] * B[3];
            C[2] = A[2] * B[0] + A[6] * B[1] + A[10] * B[2] + A[14] * B[3];
            C[3] = A[3] * B[0] + A[7] * B[1] + A[11] * B[2] + A[15] * B[3];

            C[4] = A[0] * B[4] + A[4] * B[5] + A[8] * B[6] + A[12] * B[7];
            C[5] = A[1] * B[4] + A[5] * B[5] + A[9] * B[6] + A[13] * B[7];
            C[6] = A[2] * B[4] + A[6] * B[5] + A[10] * B[6] + A[14] * B[7];
            C[7] = A[3] * B[4] + A[7] * B[5] + A[11] * B[6] + A[15] * B[7];

            C[8] = A[0] * B[8] + A[4] * B[9] + A[8] * B[10] + A[12] * B[11];
            C[9] = A[1] * B[8] + A[5] * B[9] + A[9] * B[10] + A[13] * B[11];
            C[10] = A[2] * B[8] + A[6] * B[9] + A[10] * B[10] + A[14] * B[11];
            C[11] = A[3] * B[8] + A[7] * B[9] + A[11] * B[10] + A[15] * B[11];

            C[12] = A[0] * B[12] + A[4] * B[13] + A[8] * B[14] + A[12] * B[15];
            C[13] = A[1] * B[12] + A[5] * B[13] + A[9] * B[14] + A[13] * B[15];
            C[14] = A[2] * B[12] + A[6] * B[13] + A[10] * B[14] + A[14] * B[15];
            C[15] = A[3] * B[12] + A[7] * B[13] + A[11] * B[14] + A[15] * B[15];
        }

        public static void matrixIdentity(float[] m)
        {
            m[0] = m[5] = m[10] = m[15] = 1.0f;
            m[1] = m[2] = m[3] = m[4] = 0.0f;
            m[6] = m[7] = m[8] = m[9] = 0.0f;
            m[11] = m[12] = m[13] = m[14] = 0.0f;
        }

        public static void matrixTranslate(float x, float y, float z, float[] matrix)
        {
            matrixIdentity(matrix);

            // Translate slots.
            matrix[12] = x;
            matrix[13] = y;
            matrix[14] = z;
        }

        public static void matrixScale(float sx, float sy, float sz, float[] matrix)
        {
            matrixIdentity(matrix);

            // Scale slots.
            matrix[0] = sx;
            matrix[5] = sy;
            matrix[10] = sz;
        }

        public static void matrixRotateX(float degrees, float[] matrix)
        {
            float radians = degreesToRadians(degrees);

            matrixIdentity(matrix);

            // Rotate X formula.
            matrix[5] = (float)Math.Cos(radians);
            matrix[6] = (float)-Math.Sin(radians);
            matrix[9] = -matrix[6];
            matrix[10] = matrix[5];
        }

        public static void matrixRotateY(float degrees, float[] matrix)
        {
            float radians = degreesToRadians(degrees);

            matrixIdentity(matrix);

            // Rotate Y formula.
            matrix[0] = (float)Math.Cos(radians);
            matrix[2] = (float)Math.Sin(radians);
            matrix[8] = -matrix[2];
            matrix[10] = matrix[0];
        }

        public static void matrixRotateZ(float degrees, float[] matrix)
        {
            float radians = degreesToRadians(degrees);

            matrixIdentity(matrix);

            // Rotate Z formula.
            matrix[0] = (float)Math.Cos(radians);
            matrix[1] = (float)Math.Sin(radians);
            matrix[4] = -matrix[1];
            matrix[5] = matrix[0];
        }

        public static void matrixMultiply(float[] m1, float[] m2, float[] result)
        {
            // Fisrt Column
            result[0] = m1[0] * m2[0] + m1[4] * m2[1] + m1[8] * m2[2] + m1[12] * m2[3];
            result[1] = m1[1] * m2[0] + m1[5] * m2[1] + m1[9] * m2[2] + m1[13] * m2[3];
            result[2] = m1[2] * m2[0] + m1[6] * m2[1] + m1[10] * m2[2] + m1[14] * m2[3];
            result[3] = m1[3] * m2[0] + m1[7] * m2[1] + m1[11] * m2[2] + m1[15] * m2[3];

            // Second Column
            result[4] = m1[0] * m2[4] + m1[4] * m2[5] + m1[8] * m2[6] + m1[12] * m2[7];
            result[5] = m1[1] * m2[4] + m1[5] * m2[5] + m1[9] * m2[6] + m1[13] * m2[7];
            result[6] = m1[2] * m2[4] + m1[6] * m2[5] + m1[10] * m2[6] + m1[14] * m2[7];
            result[7] = m1[3] * m2[4] + m1[7] * m2[5] + m1[11] * m2[6] + m1[15] * m2[7];

            // Third Column
            result[8] = m1[0] * m2[8] + m1[4] * m2[9] + m1[8] * m2[10] + m1[12] * m2[11];
            result[9] = m1[1] * m2[8] + m1[5] * m2[9] + m1[9] * m2[10] + m1[13] * m2[11];
            result[10] = m1[2] * m2[8] + m1[6] * m2[9] + m1[10] * m2[10] + m1[14] * m2[11];
            result[11] = m1[3] * m2[8] + m1[7] * m2[9] + m1[11] * m2[10] + m1[15] * m2[11];

            // Fourth Column
            result[12] = m1[0] * m2[12] + m1[4] * m2[13] + m1[8] * m2[14] + m1[12] * m2[15];
            result[13] = m1[1] * m2[12] + m1[5] * m2[13] + m1[9] * m2[14] + m1[13] * m2[15];
            result[14] = m1[2] * m2[12] + m1[6] * m2[13] + m1[10] * m2[14] + m1[14] * m2[15];
            result[15] = m1[3] * m2[12] + m1[7] * m2[13] + m1[11] * m2[14] + m1[15] * m2[15];
        }
    }
}
