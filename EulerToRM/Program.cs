using System;

namespace EulerToRM
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine($"Euler angles to Rotation matrix converter");
            Console.WriteLine($"Usage: EulerToRM.exe Xangle, Yangle, Zangle in degrees");
            // X, Y, Z angles
            if (args.Length != 3) return;

            if(double.TryParse(args[0], out double X)
                && double.TryParse(args[1], out double Y) 
                && double.TryParse(args[2], out double Z))
            {
                Console.WriteLine($"X:{X}, Y:{Y}, Z:{Z}");
            }
        }
    }
}
