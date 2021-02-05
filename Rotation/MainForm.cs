using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Globalization;

using Tao.OpenGl;
using Tao.FreeGlut;

namespace Rotation
{
    /// <summary>
    /// Description of MainForm.
    /// </summary>
    public partial class MainForm : Form
    {
        // 4x4 transform matrices
        float[] mobj = new float[16];   // object transform matrix
        float[] meye = new float[16];   // camera transform matrix

        float[] BoxTrans = new float[16];

        const float RAD2DEG = 180.0f / (float)Math.PI; //Degrees from Radians
        const float DEG2RAD = (float)Math.PI / 180.0f; //Radians from Degrees

        float[] mat4 = new float[16];
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

        float positionX = 0.0f;
        float positionY = 0.0f;
        float positionZ = -200.0f;

        float roll = 0;
        float pitch = 0;
        float yaw = 0;
        float roll_old = 0;
        float pitch_old = 0;
        float yaw_old = 0;

        float R = 0.0f;
        float P = 0.0f;
        float Y = 0.0f;

        float t = 0.0f; // Interpolation parameter.
        int matrixLength = 0;

        RotationMatrix myRotationMatrix;
        float[] matrixData = new float[16];     // Rotation matrix values.
        float[] matrixDataT = new float[16];    // Rotation matrix values.
        float[] matrix2 = new float[16];        // Rotation matrix values.
        float[] mat = new float[16];
        float[] local_matrix = new float[16];
        float[] matrixX = new float[16];
        float[] matrixY = new float[16];
        float[] matrixZ = new float[16];

        Quaternion myQuat = new Quaternion(1.0f, 0.0f, 0.0f, 0.0f);
        Quaternion identityQuaternion = new Quaternion(1.0f, 0.0f, 0.0f, 0.0f); // Global identity quaternion.
        Quaternion q = new Quaternion(1.0f, 0.0f, 0.0f, 0.0f);

        // Create light components.
        //Gl.glLightfv()
        float[] ambientLight = new float[] { 0.1f, 0.1f, 0.1f, 1.0f };
        float[] diffuseLight = new float[] { 0.5f, 0.50f, 0.5f, 1.0f };
        float[] specularLight = new float[] { 0.5f, 0.5f, 0.5f, 1.0f };
        float[] position = new float[] { 0.0f, 300.0f, 0.0f, 0.1f };

        float[] vAmbientLightBright = new float[] { 0.6f, 0.6f, 0.6f, 1.0f };
        float[] vAmbientLightDark = new float[] { 0.2f, 0.2f, 0.2f, 1.0f };
        private double angleX, angleY, angleZ = 0;
        private double delta = 1;


        // Routine to multiply two quaternions.
        public Quaternion multiplyQuaternions(Quaternion q1, Quaternion q2)
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
        Quaternion eulerAnglesToQuaternion(float a, float b, float g)
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
        RotationMatrix quaternionToRotationMatrix(Quaternion q)
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
        void writeMatrixData(RotationMatrix r)
        {
            for (int i = 0; i < 16; i++) matrixData[i] = r.getMatrixData(i);
        }

        float[] mTranspose(float[] A, int m, int n)
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
        Quaternion slerp(Quaternion q1, Quaternion q2, float t)
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

        public MainForm()
        {
            InitializeComponent();
            AnT.InitializeContexts();
        }

        void MainFormLoad(object sender, EventArgs e)
        {
            trckBarPitch.Minimum = -90;
            trckBarRoll.Minimum = -180;
            trckBarYaw.Minimum = -180;

            trckBarX.Minimum = -100;
            trckBarY.Minimum = -100;
            trckBarZ.Minimum = -200;
            trckBarZ.Value = -200;

            // инициализация Glut
            Glut.glutInit();
            Glut.glutInitDisplayMode(Glut.GLUT_RGBA | Glut.GLUT_DOUBLE | Glut.GLUT_MULTISAMPLE | Glut.GLUT_DEPTH);
            // установка цвета очистки экрана (RGBA)
            Gl.glClearColor(0.02f, 0.10f, 0.16f, 1);

            //Set blending
            Gl.glEnable(Gl.GL_BLEND);
            Gl.glBlendFunc(Gl.GL_SRC_ALPHA, Gl.GL_ONE_MINUS_SRC_ALPHA);

            Gl.glEnable(Gl.GL_COLOR_MATERIAL);
            Gl.glEnable(Gl.GL_LINE_SMOOTH);
            Gl.glEnable(Gl.GL_POLYGON_SMOOTH); //!!!!!!!!!
            Gl.glEnable(Gl.GL_ALPHA_TEST);
            Gl.glEnable(Gl.GL_MULTISAMPLE); //!!!!!!!!!
            Gl.glEnable(Gl.GL_DEPTH_TEST);
            Gl.glEnable(Gl.GL_NORMALIZE);

            Gl.glLightModelfv(Gl.GL_LIGHT_MODEL_AMBIENT, vAmbientLightBright);

            // Assign created components to GL_LIGHT0.
            Gl.glLightfv(Gl.GL_LIGHT0, Gl.GL_AMBIENT, ambientLight);
            Gl.glLightfv(Gl.GL_LIGHT0, Gl.GL_DIFFUSE, diffuseLight);
            //Gl.glLightfv(Gl.GL_LIGHT0, Gl.GL_SPECULAR, specularLight);
            Gl.glLightfv(Gl.GL_LIGHT0, Gl.GL_POSITION, position);

            //Set antialiasing/ multisampling
            Gl.glHint(Gl.GL_LINE_SMOOTH_HINT, Gl.GL_NICEST);
            Gl.glHint(Gl.GL_POLYGON_SMOOTH_HINT, Gl.GL_NICEST);

            Gl.glEnable(Gl.GL_LIGHTING);
            Gl.glEnable(Gl.GL_LIGHT0);

            // используем матрицу проекции
            Gl.glMatrixMode(Gl.GL_PROJECTION);
            // обнуляем матрицу
            Gl.glLoadIdentity();

            Gl.glViewport(0, 0, AnT.Width, AnT.Height);
            // установить корректную перспективу
            //Gl.glOrtho(-1000, 1000, -1000, 1000, -1, 10000);
            Glu.gluPerspective(60.0f, (float)AnT.Width / AnT.Height, 10.0f, 1000.0f); //1cm - 100m
                                                                                      // вернуться к матрице проекции
            Gl.glMatrixMode(Gl.GL_MODELVIEW);//break
            Gl.glLoadIdentity();

            // Initialize global matrixData.
            matrixIdentity(matrixData);
            matrixIdentity(local_matrix);
            matrixIdentity(mat);

            Gl.glGetFloatv(Gl.GL_MODELVIEW_MATRIX, mobj);
            Gl.glGetFloatv(Gl.GL_MODELVIEW_MATRIX, meye);
        }

        void TrckBarRollScroll(object sender, EventArgs e)
        {
            lblRollValue.Text = trckBarRoll.Value.ToString();
            roll = trckBarRoll.Value;
        }

        void TrckBarPitchScroll(object sender, EventArgs e)
        {
            lblPitchValue.Text = trckBarPitch.Value.ToString();
            pitch = trckBarPitch.Value;
        }

        void TrckBarYawScroll(object sender, EventArgs e)
        {
            lblYawValue.Text = trckBarYaw.Value.ToString();
            yaw = trckBarYaw.Value;
        }
        void TrckBarXScroll(object sender, EventArgs e)
        {
            lblXTranslation.Text = trckBarX.Value.ToString();
            positionX = trckBarX.Value;
        }
        void TrckBarYScroll(object sender, EventArgs e)
        {
            lblYTranslation.Text = trckBarY.Value.ToString();
            positionY = trckBarY.Value;
        }
        void TrckBarZScroll(object sender, EventArgs e)
        {
            lblZTranslation.Text = trckBarZ.Value.ToString();
            positionZ = trckBarZ.Value;
        }
        void BtnResetRotationClick(object sender, EventArgs e)
        {
            trckBarRoll.Value = 0;
            trckBarPitch.Value = 0;
            trckBarYaw.Value = 0;

            lblRollValue.Text = "0";
            lblPitchValue.Text = "0";
            lblYawValue.Text = "0";

            roll = 0;
            pitch = 0;
            yaw = 0;
            roll_old = 0;
            pitch_old = 0;
            yaw_old = 0;

            t = 0.0f;
            // Initialize global matrixData. 
            for (int i = 0; i < 16; i++) matrixData[i] = 0.0f;
            matrixData[0] = matrixData[5] = matrixData[10] = matrixData[15] = 1.0f;

            for (int i = 0; i < 16; i++) matrix2[i] = 0.0f;
            matrix2[0] = matrix2[5] = matrix2[10] = matrix2[15] = 1.0f;
        }

        void BtnResetTranslationClick(object sender, EventArgs e)
        {
            trckBarX.Value = 0;
            trckBarY.Value = 0;
            trckBarZ.Value = -200;

            lblXTranslation.Text = "0";
            lblYTranslation.Text = "0";
            lblZTranslation.Text = "-200";

            positionX = 0;
            positionY = 0;
            positionZ = -200;
        }

        float[] mTranspose4x4(float[] A)
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

        void mIdentity(float[] matrix, int rows, int cols)
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

        void euler2rm(float angle_x, float angle_y, float angle_z, float[] mat)
        {
            float A, B, C, D, E, F, AD, BD = 0.0f;
            A = (float)Math.Cos(angle_x);
            B = (float)Math.Sin(angle_x);
            C = (float)Math.Cos(angle_y);
            D = (float)Math.Sin(angle_y);
            E = (float)Math.Cos(angle_z);
            F = (float)Math.Sin(angle_z);
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
        public void NASArotate(float yaw, float pitch, float roll, float[] RM)
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

        private void Redraw2(object sender, EventArgs e)
        {
            Gl.glClear(Gl.GL_COLOR_BUFFER_BIT | Gl.GL_DEPTH_BUFFER_BIT | Gl.GL_STENCIL_BUFFER_BIT);
            Gl.glMatrixMode(Gl.GL_MODELVIEW);
            Gl.glLoadIdentity();
            //Gl.glTranslated(positionX, positionY, positionZ);

            Gl.glPushMatrix();
            Gl.glLoadIdentity();
            Gl.glMultMatrixf(matrixData);

            // Rotation X
            if (roll != roll_old)
            {
                Gl.glRotatef(roll - roll_old, 1, 0, 0);
                roll_old = roll;
            }
            // Rotation Y
            if (pitch != pitch_old)
            {
                Gl.glRotatef(pitch - pitch_old, 0, 1, 0);
                pitch_old = pitch;
            }
            //Rotation Z
            if (yaw != yaw_old)
            {
                Gl.glRotatef((yaw - yaw_old), 0, 0, 1);
                yaw_old = yaw;
            }

            Gl.glGetFloatv(Gl.GL_MODELVIEW_MATRIX, matrixData);

            Gl.glPushMatrix();
            Gl.glLoadIdentity();
            matrixData[14] = positionZ;
            Gl.glMultMatrixf(matrixData);

            RefreshLabels(); //GUI "Model View" matrix values		
            DrawModel();

            Gl.glPopMatrix();

            Gl.glFlush();
            AnT.Invalidate();
        }

        void Timer1Tick(object sender, EventArgs e)
        {
            /*
            Gl.glPushMatrix();
            Gl.glLoadMatrixf(mobj);
            Gl.glRotatef(roll, 1, 0, 0);
            Gl.glRotatef(pitch, 0, 1, 0);
            // obtain mobj from GL
            Gl.glGetFloatv(Gl.GL_MODELVIEW_MATRIX, mobj);
            Gl.glPopMatrix();
            */
            this.Invoke(new EventHandler(_redrawMatrix));//_redrawMatrix
        }

        private void _redrawMatrix(object sender, EventArgs e)
        {
            Gl.glClear(Gl.GL_COLOR_BUFFER_BIT | Gl.GL_DEPTH_BUFFER_BIT | Gl.GL_STENCIL_BUFFER_BIT);
            Gl.glMatrixMode(Gl.GL_MODELVIEW);
            Gl.glGetFloatv(Gl.GL_MODELVIEW_MATRIX, matrixData);
            Gl.glPushMatrix();
            Gl.glLoadIdentity();

            //================= Matrix Multiplication Rotation Animation =================
            if(cbxAnimate.Checked)
            {
                if (angleZ < 45)
                {
                    angleZ += delta;
                }
                else if (angleY < 90)
                {
                    angleY += delta;
                }
                else if (angleX < 90)
                {
                    angleX += delta;
                }
            } 
            else
            {
                angleX = roll;
                angleY = pitch;
                angleZ = yaw;
            }
            
            matrixIdentity(matrixX);
            matrixIdentity(matrixY);
            matrixIdentity(matrixZ);
            matrixIdentity(mat);
            matrixIdentity(local_matrix);

            // Rotate around Z
            matrixZ[0] =  (float)Math.Cos(angleZ * DEG2RAD);
            matrixZ[1] =  (float)Math.Sin(angleZ * DEG2RAD);
            matrixZ[4] = -(float)Math.Sin(angleZ * DEG2RAD);
            matrixZ[5] =  (float)Math.Cos(angleZ * DEG2RAD);

            // Rotate around Y
            matrixY[0] =  (float)Math.Cos(angleY * DEG2RAD);
            matrixY[2] = -(float)Math.Sin(angleY * DEG2RAD);
            matrixY[8] =  (float)Math.Sin(angleY * DEG2RAD);
            matrixY[10] = (float)Math.Cos(angleY * DEG2RAD);

            // Rotate around X
            matrixX[5] =  (float)Math.Cos(angleX * DEG2RAD);
            matrixX[6] =  (float)Math.Sin(angleX * DEG2RAD);
            matrixX[9] = -(float)Math.Sin(angleX * DEG2RAD);
            matrixX[10] = (float)Math.Cos(angleX * DEG2RAD);

            matrixMultiply(matrixZ, matrixY, local_matrix);
            matrixMultiply(local_matrix, matrixX, mat);
            mat[14] = -200;

            Gl.glLoadMatrixf(mat);
            //==================================================================

            DrawModel();
            RefreshLabels(); //GUI "Model View" matrix values		

            Gl.glPopMatrix();
            Gl.glFlush();
            AnT.Invalidate();
        }

        private void Redraw3(object sender, EventArgs e)
        {
            /*
            Here's EXACTLY what you need to do. Create a matrix which is the identity matrix. Then each time you perform a rotation,
            get the modelview matrix with glGetMatrixf(GL_MODELVIEW, mat), where you declared float mat[16];
            Then simply take your created matrix, L and multiply it with mat = L * mat;
            Then store the result back in L.Then clear the modelview matrix with glLoadIdentity and simply call glLoadMatrix(L);
            What this will basically do is concatenate all your rotations and it will enable you to do local rotations no matter what 
            the orientation of the model is. You do the same thing after translating or scaling your model.

            So here's a short example:

            glClear(...);
            glLoadIdentity();
            // perform camera rotations, translations, ect... here

            glPushMatrix();
            glLoadIdentity();

            glRotate(angle, 0, 1, 0); // rotate model around y-axis
            glGetMatrixf(GL_MODELVIEW, mat);
            multiplyMatrices(local_matrix, mat);

            glPopMatrix();
            glMultMatrixf(local_matrix);
            */
            Gl.glClear(Gl.GL_COLOR_BUFFER_BIT | Gl.GL_DEPTH_BUFFER_BIT | Gl.GL_STENCIL_BUFFER_BIT);
            Gl.glMatrixMode(Gl.GL_MODELVIEW);
            Gl.glLoadIdentity();
            Gl.glTranslated(positionX, positionY, positionZ);

            Gl.glPushMatrix();
            Gl.glLoadIdentity();

            yaw = trckBarYaw.Value * DEG2RAD;
            pitch = trckBarPitch.Value * DEG2RAD;
            roll = trckBarRoll.Value * DEG2RAD;

            euler2rm(-roll, -pitch, -yaw,  matrix2);
            //NASArotate(yaw, roll, pitch, matrix2);

            //Gl.glLoadMatrixf(matrix2);

            Gl.glGetFloatv(Gl.GL_MODELVIEW_MATRIX, mat);
            matrixMultiply(matrix2, mat, matrixData); // <------!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!

            Gl.glPopMatrix();

            Gl.glMultTransposeMatrixf(matrixData);
            DrawModel();
            RefreshLabels(); //GUI "Model View" matrix values		

            //Gl.glMultMatrixf(local_matrix);
            Gl.glFlush();
            AnT.Invalidate();
        }

        private void Redraw(object sender, EventArgs e)
        {
            Gl.glClear(Gl.GL_COLOR_BUFFER_BIT | Gl.GL_DEPTH_BUFFER_BIT | Gl.GL_STENCIL_BUFFER_BIT);
            Gl.glMatrixMode(Gl.GL_MODELVIEW);
            Gl.glGetFloatv(Gl.GL_MODELVIEW_MATRIX, matrixData);
            Gl.glPushMatrix();
            Gl.glLoadIdentity();
            Gl.glTranslated(positionX, positionY, positionZ);

            yaw = trckBarYaw.Value * DEG2RAD;
            pitch = trckBarPitch.Value * DEG2RAD;
            roll = trckBarRoll.Value * DEG2RAD;

            euler2rm(yaw, pitch, roll, matrix2);
            Gl.glMultMatrixf(matrix2);
            RefreshLabels(); //GUI "Model View" matrix values		
            DrawModel();

            Gl.glTranslated(positionX, positionY, -positionZ);
            Gl.glPopMatrix();

            //mMultiply4x4(matrix2, matrixData, matrixDataT);
            //Gl.glLoadMatrixf(matrixDataT);

            Gl.glFlush();
            AnT.Invalidate();
        }

        public bool gluInvertMatrix(float[] m, float[] invOut)
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

        void mMultiply4x4(float[] A, float[] B, float[] C) // C = A* B
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

        private void redraw3DView(object sender, EventArgs e)
        {
            Quaternion qInterpolated, q0, q1, q2;
            RotationMatrix r;

            // очистка буфера цвета и буфера глубины
            Gl.glClear(Gl.GL_COLOR_BUFFER_BIT | Gl.GL_DEPTH_BUFFER_BIT | Gl.GL_STENCIL_BUFFER_BIT);
            Gl.glLoadIdentity();
            //Gl.glPushMatrix();

            Gl.glTranslated(positionX, positionY, -100);

            q0 = AngleAxis(yaw * ((float)Math.PI / 180.0f), 0, 1, 0);
            q1 = AngleAxis(roll * ((float)Math.PI / 180.0f), 1, 0, 0);
            q2 = AngleAxis(pitch * ((float)Math.PI / 180.0f), 0, 0, 1);
            q = multiplyQuaternions(q0, multiplyQuaternions(q1, q2));

            //			if (t < 1.0) t += 0.04f;
            q = eulerAnglesToQuaternion(roll, pitch, yaw);
            q = quaternion_normalize(q);
            qInterpolated = slerp(identityQuaternion, q, t);
            qInterpolated = quaternion_normalize(qInterpolated);
            r = quaternionToRotationMatrix(q);
            writeMatrixData(r);

            Gl.glGetFloatv(Gl.GL_MODELVIEW_MATRIX, matrixData);
            for(int i=0; i < 16; i++)
            {
                matrixDataT[i] = r.getMatrixData(i);
            }
            matrixMultiply(matrixData, matrixDataT, matrix2);
            
            Gl.glMultMatrixf(matrix2);

            RefreshLabels();

            DrawModel();

            Gl.glPopMatrix();

            Gl.glFlush();
            AnT.Invalidate();
        }

        void matrixIdentity(float[] m)
        {
            m[0] = m[5] = m[10] = m[15] = 1.0f;
            m[1] = m[2] = m[3] = m[4] = 0.0f;
            m[6] = m[7] = m[8] = m[9] = 0.0f;
            m[11] = m[12] = m[13] = m[14] = 0.0f;
        }

        void matrixTranslate(float x, float y, float z, float[] matrix)
        {
            matrixIdentity(matrix);

            // Translate slots.
            matrix[12] = x;
            matrix[13] = y;
            matrix[14] = z;
        }

        void matrixScale(float sx, float sy, float sz, float[] matrix)
        {
            matrixIdentity(matrix);

            // Scale slots.
            matrix[0] = sx;
            matrix[5] = sy;
            matrix[10] = sz;
        }

        void matrixRotateX(float degrees, float[] matrix)
        {
            float radians = degreesToRadians(degrees);

            matrixIdentity(matrix);

            // Rotate X formula.
            matrix[5] = (float)Math.Cos(radians);
            matrix[6] = (float)-Math.Sin(radians);
            matrix[9] = -matrix[6];
            matrix[10] = matrix[5];
        }

        void matrixRotateY(float degrees, float[] matrix)
        {
            float radians = degreesToRadians(degrees);

            matrixIdentity(matrix);

            // Rotate Y formula.
            matrix[0] = (float)Math.Cos(radians);
            matrix[2] = (float)Math.Sin(radians);
            matrix[8] = -matrix[2];
            matrix[10] = matrix[0];
        }

        void matrixRotateZ(float degrees, float[] matrix)
        {
            float radians = degreesToRadians(degrees);

            matrixIdentity(matrix);

            // Rotate Z formula.
            matrix[0] = (float)Math.Cos(radians);
            matrix[1] = (float)Math.Sin(radians);
            matrix[4] = -matrix[1];
            matrix[5] = matrix[0];
        }

        void matrixMultiply(float[] m1, float[] m2, float[] result)
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

        private void RefreshLabels()
        {
            Gl.glGetFloatv(Gl.GL_MODELVIEW_MATRIX, matrix2);
            lblM00.Text = matrix2[0].ToString();
            lblM01.Text = matrix2[1].ToString();
            lblM02.Text = matrix2[2].ToString();
            lblM03.Text = matrix2[3].ToString();
            lblM04.Text = matrix2[4].ToString();
            lblM05.Text = matrix2[5].ToString();
            lblM06.Text = matrix2[6].ToString();
            lblM07.Text = matrix2[7].ToString();
            lblM08.Text = matrix2[8].ToString();
            lblM09.Text = matrix2[9].ToString();
            lblM10.Text = matrix2[10].ToString();
            lblM11.Text = matrix2[11].ToString();
            lblM12.Text = matrix2[12].ToString();
            lblM13.Text = matrix2[13].ToString();
            lblM14.Text = matrix2[14].ToString();
            lblM15.Text = matrix2[15].ToString();

            lbE2RM0.Text = matrixData[0].ToString();
            lbE2RM1.Text = matrixData[1].ToString();
            lbE2RM2.Text = matrixData[2].ToString();
            lbE2RM3.Text = matrixData[3].ToString();
            lbE2RM4.Text = matrixData[4].ToString();
            lbE2RM5.Text = matrixData[5].ToString();
            lbE2RM6.Text = matrixData[6].ToString();
            lbE2RM7.Text = matrixData[7].ToString();
            lbE2RM8.Text = matrixData[8].ToString();
            lbE2RM9.Text = matrixData[9].ToString();
            lbE2RM10.Text = matrixData[10].ToString();
            lbE2RM11.Text = matrixData[11].ToString();
            lbE2RM12.Text = matrixData[12].ToString();
            lbE2RM13.Text = matrixData[13].ToString();
            lbE2RM14.Text = matrixData[14].ToString();
            lbE2RM15.Text = matrixData[15].ToString();

            lblQuatW.Text = q.w.ToString();
            lblQuatX.Text = q.x.ToString();
            lblQuatY.Text = q.y.ToString();
            lblQuatZ.Text = q.z.ToString();
        }

        private void DrawModel()
        {
            // Local model axis
            Gl.glBegin(Gl.GL_LINES);
            //X axis - OpenGL X Axis
            Gl.glColor4f(0.8f, 0.0f, 0.0f, 0.9f);
            Gl.glVertex3d(-70, 0, 0);
            Gl.glVertex3d(70, 0, 0);
            Gl.glEnd();
            //X Axis red arrow
            Gl.glPushMatrix();
            Gl.glTranslatef(70, 0.0f, 0.0f);
            Gl.glRotatef(90.0f, 0, 1, 0);
            Glut.glutSolidCone(2, 6, 8, 8);
            Gl.glPopMatrix();

            //Y axis - OpenGL Z Axis
            Gl.glBegin(Gl.GL_LINES);
            Gl.glColor4f(0.0f, 0.8f, 0.0f, 0.9f);
            Gl.glVertex3d(0, 0, -70);
            Gl.glVertex3d(0, 0, 70);
            Gl.glEnd();
            //Y Axis green arrow
            Gl.glPushMatrix();
            Gl.glTranslatef(0.0f, 0.0f, 70);
            Glut.glutSolidCone(2, 6, 8, 8);
            Gl.glPopMatrix();

            //Z axis - OpenGL Y Axis
            Gl.glBegin(Gl.GL_LINES);
            Gl.glColor4f(0.20f, 0.20f, 0.98f, 1.0f);
            Gl.glVertex3d(0, -70, 0);
            Gl.glVertex3d(0, 70, 0);
            Gl.glEnd();
            //Z Axis blue arrow
            Gl.glPushMatrix();
            Gl.glTranslatef(0.0f, 70, 0.0f);
            Gl.glRotatef(-90.0f, 1, 0, 0);
            Glut.glutSolidCone(2, 6, 8, 8);
            Gl.glPopMatrix();

            Gl.glColor4f(0.56f, 0.56f, 0.56f, 1.0f);
            //Glut.glutWireSphere(30, 16, 16);
            Glut.glutWireCube(30);
            //Glut.glutSolidTeapot(30);
        }

        double quaternion_length(Quaternion q)
        {
            return Math.Sqrt(q.w * q.w + q.x * q.x + q.y * q.y + q.z * q.z);
        }

        Quaternion quaternion_normalize(Quaternion q)
        {
            double L = quaternion_length(q);

            q.w *= (float)L;
            q.x *= (float)L;
            q.y *= (float)L;
            q.z *= (float)L;

            return q;
        }

        private void TbX_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                trckBarRoll.Value = int.Parse(tbX.Text);
                lblRollValue.Text = tbX.Text;

                // Enter Sound OFF
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }
    }

    // Quaternion class.
    public class Quaternion
    {
        public Quaternion() { }
        public Quaternion(float wVal, float xVal, float yVal, float zVal)
        {
            w = wVal; x = xVal; y = yVal; z = zVal;
        }
        public float getW() { return w; }
        public float getX() { return x; }
        public float getY() { return y; }
        public float getZ() { return z; }

        public float w, x, y, z;
    };


    // Euler angles class.
    class EulerAngles
    {
        public
            EulerAngles()
        { }
        EulerAngles(float alphaVal, float betaVal, float gammaVal)
        {
            alpha = alphaVal; beta = betaVal; gamma = gammaVal;
        }
        public float getAlpha() { return alpha; }
        public float getBeta() { return beta; }
        public float getGamma() { return gamma; }

        private
            float alpha, beta, gamma;
    };

    // Rotation matrix class.
    public class RotationMatrix
    {
        public
            RotationMatrix()
        { }
        public RotationMatrix(float[] matrixDataVal)
        {
            for (int i = 0; i < 16; i++) matrixData[i] = matrixDataVal[i];
        }
        public float getMatrixData(int i) { return matrixData[i]; }

        private float[] matrixData = new float[16];
    };
}
