using System;
using System.Windows.Forms;
using Tao.FreeGlut;
using Tao.OpenGl;

namespace Rotation
{
    /// <summary>
    /// Description of MainForm.
    /// </summary>
    public partial class MainForm : Form
    {
        #region Variables
        // 4x4 transform matrices
        float[] mobj = new float[16];   // object transform matrix
        float[] meye = new float[16];   // camera transform matrix

        float[] BoxTrans = new float[16];

        const float RAD2DEG = 180.0f / (float)Math.PI; //Degrees from Radians
        const float DEG2RAD = (float)Math.PI / 180.0f; //Radians from Degrees

        float[] mat4 = new float[16];

        float positionX = 0.0f;
        float positionY = 0.0f;
        float positionZ = -200.0f;

        double roll = 0;
        double pitch = 0;
        double yaw = 0;
        double roll_old = 0;
        double pitch_old = 0;
        double yaw_old = 0;

        float R = 0.0f;
        float P = 0.0f;
        float Y = 0.0f;

        float t = 0.0f; // Interpolation parameter.
        int matrixLength = 0;

        RotationMatrix myRotationMatrix;
        double[] matrixDouble = new double[16];     // Rotation matrix values.
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
        #endregion

        public MainForm()
        {
            InitializeComponent();
            AnT.InitializeContexts();
        }

        void MainFormLoad(object sender, EventArgs e)
        {
            trckBarPitchZ.Minimum = -90;
            trckBarRollX.Minimum = -180;
            trckBarYawY.Minimum = -180;

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
            Gl.glOrtho(-100, 100, -100, 100, -1, 1000);
            //Glu.gluPerspective(60.0f, (float)AnT.Width / AnT.Height, 1.0f, 1000.0f);

            Gl.glMatrixMode(Gl.GL_MODELVIEW);//break
            Gl.glLoadIdentity();

            // Initialize global matrixData.
            Testing.matrixIdentity(matrixData);
            Testing.matrixIdentity(local_matrix);
            Testing.matrixIdentity(mat);
            matrixDouble[0] = matrixDouble[5] = matrixDouble[10] = matrixDouble[15] = 1d;

            Gl.glGetFloatv(Gl.GL_MODELVIEW_MATRIX, mobj);
            Gl.glGetFloatv(Gl.GL_MODELVIEW_MATRIX, meye);
        }
       
        private void Redraw2(object sender, EventArgs e)
        {
            Gl.glClear(Gl.GL_COLOR_BUFFER_BIT | Gl.GL_DEPTH_BUFFER_BIT | Gl.GL_STENCIL_BUFFER_BIT);
            Gl.glMatrixMode(Gl.GL_MODELVIEW);
            //Gl.glLoadIdentity();
            //Gl.glTranslated(positionX, positionY, positionZ);

            Gl.glPushMatrix();
            Gl.glLoadIdentity();
            //Gl.glMultMatrixf(matrixDouble);     // ->| 
            //                                          |-> Equal result. cuz MV matrix is identity matrix
            Gl.glLoadMatrixd(matrixDouble);       // ->|

            // Rotation X
            if (Math.Abs(roll - roll_old) >= 1)
            {
                Gl.glRotated(roll - roll_old, 1, 0, 0);
                roll_old = roll;
            }
            // Rotation Y
            if (Math.Abs(yaw - yaw_old) >= 1)
            {
                Gl.glRotated(yaw - yaw_old, 0, 1, 0);
                yaw_old = yaw;
            }
            //Rotation Z
            if (Math.Abs(pitch - pitch_old)>= 1)
            {
                Gl.glRotated((pitch - pitch_old), 0, 0, 1);
                pitch_old = pitch;
            }

            Gl.glGetDoublev(Gl.GL_MODELVIEW_MATRIX, matrixDouble);

            Gl.glPushMatrix();
            Gl.glLoadIdentity();
            matrixDouble[14] = positionZ;
            Gl.glMultMatrixd(matrixDouble);

            RefreshLabels(); // Update GUI "ModelView" matrix labels
            DrawModel();

            Gl.glPopMatrix();
            Gl.glFlush();
            AnT.Invalidate();
        }

        private void _redrawMatrix(object sender, EventArgs e)
        {
            Gl.glClear(Gl.GL_COLOR_BUFFER_BIT | Gl.GL_DEPTH_BUFFER_BIT | Gl.GL_STENCIL_BUFFER_BIT);
            Gl.glMatrixMode(Gl.GL_MODELVIEW);
            Gl.glGetFloatv(Gl.GL_MODELVIEW_MATRIX, matrixData);

            // Draw Global axis
            Gl.glPushMatrix();
            Gl.glLoadIdentity();
            Gl.glTranslatef(0,0,-200);
            Gl.glRotated(30, 1, 0, 0);
            Gl.glRotated(-30, 0, 1, 0);
            Gl.glBegin(Gl.GL_LINES);
            //X axis - OpenGL X Axis
            Gl.glColor4f(0.9f, 0.9f, 0.9f, 0.3f);
            Gl.glVertex3d(-100, 0, 0);
            Gl.glVertex3d(100, 0, 0);
            Gl.glEnd();
            //Y axis - OpenGL Z Axis
            Gl.glBegin(Gl.GL_LINES);
            Gl.glColor4f(0.9f, 0.9f, 0.9f, 0.3f);
            Gl.glVertex3d(0, 0, -100);
            Gl.glVertex3d(0, 0, 100);
            Gl.glEnd();
            //Z axis - OpenGL Y Axis
            Gl.glBegin(Gl.GL_LINES);
            Gl.glColor4f(0.9f, 0.9f, 0.9f, 0.3f);
            Gl.glVertex3d(0, -100, 0);
            Gl.glVertex3d(0, 100, 0);
            Gl.glEnd();
            Gl.glPopMatrix();

            //================= Matrix Multiplication Rotation Animation =================
            if (cbxAnimate.Checked)
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

            Gl.glPushMatrix();
            Gl.glLoadIdentity();
            
            Testing.matrixIdentity(matrixX);
            Testing.matrixIdentity(matrixY);
            Testing.matrixIdentity(matrixZ);
            Testing.matrixIdentity(mat);
            Testing.matrixIdentity(local_matrix);

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

            Testing.matrixMultiply(matrixZ, matrixY, local_matrix);
            Testing.matrixMultiply(local_matrix, matrixX, mat);
            mat[14] = -200;

            Gl.glLoadMatrixf(mat);
            
            //==================================================================

            DrawModel();
            RefreshLabels(); //GUI "Model View" matrix values		
            Gl.glPopMatrix();
            
            //Gl.glPopMatrix();

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

            yaw = trckBarYawY.Value * DEG2RAD;
            pitch = trckBarPitchZ.Value * DEG2RAD;
            roll = trckBarRollX.Value * DEG2RAD;

            //euler2rm(-roll, -pitch, -yaw,  matrix2);
            //NASArotate(yaw, roll, pitch, matrix2);

            //Gl.glLoadMatrixf(matrix2);

            Gl.glGetFloatv(Gl.GL_MODELVIEW_MATRIX, mat);
            Testing.matrixMultiply(matrix2, mat, matrixData); // <------!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!

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

            yaw = trckBarYawY.Value * DEG2RAD;
            pitch = trckBarPitchZ.Value * DEG2RAD;
            roll = trckBarRollX.Value * DEG2RAD;

            //euler2rm(yaw, pitch, roll, matrix2);
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

        private void redraw3DView(object sender, EventArgs e)
        {
            Quaternion qInterpolated, q0, q1, q2;
            RotationMatrix r;

            // очистка буфера цвета и буфера глубины
            Gl.glClear(Gl.GL_COLOR_BUFFER_BIT | Gl.GL_DEPTH_BUFFER_BIT | Gl.GL_STENCIL_BUFFER_BIT);
            Gl.glLoadIdentity();
            //Gl.glPushMatrix();

            Gl.glTranslated(positionX, positionY, -100);
            /*
            q0 = AngleAxis(yaw * ((float)Math.PI / 180.0f), 0, 1, 0);
            q1 = AngleAxis(roll * ((float)Math.PI / 180.0f), 1, 0, 0);
            q2 = AngleAxis(pitch * ((float)Math.PI / 180.0f), 0, 0, 1);
            q = multiplyQuaternions(q0, multiplyQuaternions(q1, q2));

            //if (t < 1.0) t += 0.04f;
            q = eulerAnglesToQuaternion(roll, pitch, yaw);*/

            /* TODO: Correct later      !~!!!!!!!!!!!!!!!!!!!!!!
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
            */

            Gl.glMultMatrixf(matrix2);

            RefreshLabels();

            DrawModel();

            Gl.glPopMatrix();

            Gl.glFlush();
            AnT.Invalidate();
        }

        private void RefreshLabels()
        {
            Gl.glGetFloatv(Gl.GL_MODELVIEW_MATRIX, matrix2);
            lblM00.Text = matrix2[0].ToString("0.####");
            lblM01.Text = matrix2[1].ToString("0.####");
            lblM02.Text = matrix2[2].ToString("0.####");
            //lblM03.Text = matrix2[3].ToString("0.####");
            lblM04.Text = matrix2[4].ToString("0.####");
            lblM05.Text = matrix2[5].ToString("0.####");
            lblM06.Text = matrix2[6].ToString("0.####");
            //lblM07.Text = matrix2[7].ToString("0.####");
            lblM08.Text = matrix2[8].ToString("0.####");
            lblM09.Text = matrix2[9].ToString("0.####");
            lblM10.Text = matrix2[10].ToString("0.####");
            //lblM11.Text = matrix2[11].ToString("0.####");
            //lblM12.Text = matrix2[12].ToString("0.####");
            //lblM13.Text = matrix2[13].ToString("0.####");
            lblM14.Text = matrix2[14].ToString("0.####");
            lblM15.Text = matrix2[15].ToString("0.####");
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
            Glut.glutWireSphere(30, 16, 16);
            //Glut.glutWireCube(30);
            //Glut.glutSolidTeapot(30);
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
            this.Invoke(new EventHandler(Redraw2));//_redrawMatrix
        }

        #region GUI
        void BtnResetRotationClick(object sender, EventArgs e)
        {
            trckBarRollX.Value = 0;
            trckBarPitchZ.Value = 0;
            trckBarYawY.Value = 0;

            lblRollValue.Text = "0";
            lblYawValue.Text = "0";
            lblPitchValue.Text = "0";

            roll = 0;
            pitch = 0;
            yaw = 0;
            roll_old = 0;
            pitch_old = 0;
            yaw_old = 0;

            t = 0.0f;
            // Initialize global matrixData. 
            for (int i = 0; i < 16; i++) matrixDouble[i] = 0.0f;
            matrixDouble[0] = matrixDouble[5] = matrixDouble[10] = matrixDouble[15] = 1.0f;

            for (int i = 0; i < 16; i++) matrix2[i] = 0.0f;
            matrix2[0] = matrix2[5] = matrix2[10] = matrix2[15] = 1.0f;
        }

        private void btnSetXtoZero_Click(object sender, EventArgs e)
        {
            trckBarRollX.Value = 0;
        }

        private void btnSetYtoZero_Click(object sender, EventArgs e)
        {
            trckBarYawY.Value = 0;
        }

        private void btnSetZtoZero_Click(object sender, EventArgs e)
        {
            trckBarPitchZ.Value = 0;
        }

        private void trckBarRollX_ValueChanged(object sender, EventArgs e)
        {
            lblRollValue.Text = trckBarRollX.Value.ToString();
            roll = trckBarRollX.Value;
        }

        private void trckBarYawY_ValueChanged(object sender, EventArgs e)
        {
            lblPitchValue.Text = trckBarYawY.Value.ToString();
            yaw = trckBarYawY.Value;
        }

        private void trckBarPitchZ_ValueChanged(object sender, EventArgs e)
        {
            lblYawValue.Text = trckBarPitchZ.Value.ToString();
            pitch = trckBarPitchZ.Value;
        }

        private void TbX_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                //trckBarRollX.Value = int.Parse(tbX.Text);
                //lblRollValue.Text = tbX.Text;

                // Enter Sound OFF
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }
        #endregion
    }
}
