using System;

namespace EulerToRM
{
    class Program
    {
        const double RAD2DEG = 180 / Math.PI; //Degrees from Radians
        const double DEG2RAD = Math.PI / 180; //Radians from Degrees
        static double[] RotationMatrix = new double[16];

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

        public static void Calculate(double x, double y, double z)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("\t");

            Console.Write("X:");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write($"{x} ");

            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("Y:");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write($"{y} ");

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write("Z:");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write($"{z} ");

            euler2rm(x, y, z, RotationMatrix);

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(Environment.NewLine);
            Console.WriteLine($"\t| {RotationMatrix[0]:F4}  {RotationMatrix[1]:F4}  {RotationMatrix[2]:F4} |");
            Console.WriteLine($"\t| {RotationMatrix[4]:F4}  {RotationMatrix[5]:F4}  {RotationMatrix[6]:F4} |");
            Console.WriteLine($"\t| {RotationMatrix[8]:F4}  {RotationMatrix[9]:F4}  {RotationMatrix[10]:F4} |");
            // calculate det(A) =1
            // A^t*A = I
        }


        static void Main(string[] args)
        {
            //Console.WriteLine($"Euler angles to Rotation matrix converter");
            //Console.WriteLine($"Usage: EulerToRM.exe Xangle, Yangle, Zangle in degrees");
            // X, Y, Z angles
            if (args.Length != 3) return;

            if(double.TryParse(args[0], out double X)
                && double.TryParse(args[1], out double Y) 
                && double.TryParse(args[2], out double Z))
            {
                Calculate(X, Y, Z);
            }

            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
