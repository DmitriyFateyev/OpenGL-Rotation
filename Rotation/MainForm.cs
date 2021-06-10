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
        const double RAD2DEG = 180 / Math.PI; //Degrees from Radians
        const double DEG2RAD = Math.PI / 180; //Radians from Degrees
        static double[] RotationMatrix = new double[16];

        float positionZ = -200.0f;

        double roll = 0;
        double pitch = 0;
        double yaw = 0;
        double roll_old = 0;
        double pitch_old = 0;
        double yaw_old = 0;

        double[] matModelView = new double[16];     // Rotation matrix values.
        float[] tmpModelViewMat = new float[16];

        #region Light components
        float[] ambientLight = new float[] { 0.1f, 0.1f, 0.1f, 1.0f };
        float[] diffuseLight = new float[] { 0.5f, 0.50f, 0.5f, 1.0f };
        float[] specularLight = new float[] { 0.5f, 0.5f, 0.5f, 1.0f };
        float[] position = new float[] { 0.0f, 300.0f, 0.0f, 0.1f };
        float[] vAmbientLightBright = new float[] { 0.6f, 0.6f, 0.6f, 1.0f };
        float[] vAmbientLightDark = new float[] { 0.2f, 0.2f, 0.2f, 1.0f };
        private double angleX, angleY, angleZ = 0;
        private double delta = 1;
        #endregion

        #endregion

        #region Functions
        static void euler2rm(double angle_x, double angle_y, double angle_z, double[] mat)
        {
            double A, B, C, D, E, F, AD, BD = 0.0f;

            angle_x = angle_x * DEG2RAD; 	//X
            angle_y = angle_y * DEG2RAD; 	//Y
            angle_z = angle_z * DEG2RAD; 	//Z

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
            InitScene();
        }

        private void Redraw(object sender, EventArgs e)
        {
            Gl.glClear(Gl.GL_COLOR_BUFFER_BIT | Gl.GL_DEPTH_BUFFER_BIT | Gl.GL_STENCIL_BUFFER_BIT);
            Gl.glMatrixMode(Gl.GL_MODELVIEW);
            Gl.glPushMatrix();

            Gl.glLoadMatrixd(matModelView);

            // Rotation around X
            if (Math.Abs(roll - roll_old) >= 1)
            {
                Gl.glRotated(roll - roll_old, 1, 0, 0);
                roll_old = roll;
            }
            // Rotation around Y
            if (Math.Abs(yaw - yaw_old) >= 1)
            {
                Gl.glRotated(yaw - yaw_old, 0, 1, 0);
                yaw_old = yaw;
            }
            //Rotation around Z
            if (Math.Abs(pitch - pitch_old)>= 1)
            {
                Gl.glRotated((pitch - pitch_old), 0, 0, 1);
                pitch_old = pitch;
            }

            Gl.glGetDoublev(Gl.GL_MODELVIEW_MATRIX, matModelView);

            Gl.glPushMatrix();
            Gl.glLoadIdentity();
            matModelView[14] = positionZ;
            Gl.glMultMatrixd(matModelView);

            RefreshLabels(); // Update GUI "ModelView" matrix labels
            DrawModel();

            Gl.glPopMatrix();
            Gl.glFlush();
            AnT.Invalidate();
        }

        private void Redraw2(object sender, EventArgs e)
        {
            Gl.glClear(Gl.GL_COLOR_BUFFER_BIT | Gl.GL_DEPTH_BUFFER_BIT | Gl.GL_STENCIL_BUFFER_BIT);
            Gl.glMatrixMode(Gl.GL_MODELVIEW);
            Gl.glLoadIdentity();

            euler2rm(roll, yaw, pitch, RotationMatrix);

            // X Axis
            matModelView[0] = RotationMatrix[0];
            matModelView[1] = RotationMatrix[4];
            matModelView[2] = RotationMatrix[8];

            // Y Axis
            matModelView[4] = RotationMatrix[1];
            matModelView[5] = RotationMatrix[5];
            matModelView[6] = RotationMatrix[9];

            // Z Axis
            matModelView[8] = RotationMatrix[2];
            matModelView[9] = RotationMatrix[6];
            matModelView[10] = RotationMatrix[10];

            // Position Z
            matModelView[14] = positionZ;

            Gl.glLoadMatrixd(matModelView);

            Gl.glPushMatrix();
            Gl.glLoadIdentity();
            matModelView[14] = positionZ;
            Gl.glMultMatrixd(matModelView);

            RefreshLabels(); // Update GUI "ModelView" matrix labels
            DrawModel();

            Gl.glPopMatrix();
            Gl.glFlush();
            AnT.Invalidate();
        }

        void Timer1Tick(object sender, EventArgs e) => this.Invoke(new EventHandler(Redraw2));

        #region Scene
        private void InitScene()
        {
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
            Gl.glOrtho(-100, 100, -100, 100, -10, 10000);
            //Glu.gluPerspective(60.0f, (float)AnT.Width / AnT.Height, 1.0f, 1000.0f);

            Gl.glMatrixMode(Gl.GL_MODELVIEW);//break
            Gl.glLoadIdentity();

            matModelView[0] = matModelView[5] = matModelView[10] = matModelView[15] = 1d;
        }
        #endregion

        #region Labels
        private void RefreshLabels()
        {
            Gl.glGetFloatv(Gl.GL_MODELVIEW_MATRIX, tmpModelViewMat);
            lblM00.Text = tmpModelViewMat[0].ToString("0.####");
            lblM01.Text = tmpModelViewMat[1].ToString("0.####");
            lblM02.Text = tmpModelViewMat[2].ToString("0.####");
            //lblM03.Text = tmpModelViewMat[3].ToString("0.####");
            lblM04.Text = tmpModelViewMat[4].ToString("0.####");
            lblM05.Text = tmpModelViewMat[5].ToString("0.####");
            lblM06.Text = tmpModelViewMat[6].ToString("0.####");
            //lblM07.Text = tmpModelViewMat[7].ToString("0.####");
            lblM08.Text = tmpModelViewMat[8].ToString("0.####");
            lblM09.Text = tmpModelViewMat[9].ToString("0.####");
            lblM10.Text = tmpModelViewMat[10].ToString("0.####");
            //lblM11.Text = tmpModelViewMat[11].ToString("0.####");
            //lblM12.Text = tmpModelViewMat[12].ToString("0.####");
            //lblM13.Text = tmpModelViewMat[13].ToString("0.####");
            lblM14.Text = tmpModelViewMat[14].ToString("0.####");
            lblM15.Text = tmpModelViewMat[15].ToString("0.####");
        }
        #endregion

        #region MainModel
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
            //Glut.glutWireCube(40);
            Glut.glutSolidTeapot(30);
        }
        #endregion

        #region Form Buttons
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

            // Initialize global matrixData. 
            for (int i = 0; i < 16; i++) matModelView[i] = 0.0f;
            matModelView[0] = matModelView[5] = matModelView[10] = matModelView[15] = 1.0f;
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

                // Sound OFF
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }
        #endregion
    }
}
