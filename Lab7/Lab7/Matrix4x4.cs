using System;

namespace PlatonicSolids
{
    public class Matrix4x4
    {
        private readonly double[,] _values;

        public Matrix4x4()
        {
            _values = new double[4, 4];
        }

        public static Matrix4x4 CreateIdentity()
        {
            var matrix = new Matrix4x4();
            for (int i = 0; i < 4; i++)
            {
                matrix._values[i, i] = 1;
            }
            return matrix;
        }

        public static Matrix4x4 CreateTranslation(double tx, double ty, double tz)
        {
            var matrix = CreateIdentity();
            matrix._values[0, 3] = tx;
            matrix._values[1, 3] = ty;
            matrix._values[2, 3] = tz;
            return matrix;
        }

        public static Matrix4x4 CreateScale(double sx, double sy, double sz)
        {
            var matrix = CreateIdentity();
            matrix._values[0, 0] = sx;
            matrix._values[1, 1] = sy;
            matrix._values[2, 2] = sz;
            return matrix;
        }

        public static Matrix4x4 CreateRotationX(double angle)
        {
            var matrix = CreateIdentity();
            double cos = Math.Cos(angle);
            double sin = Math.Sin(angle);
            matrix._values[1, 1] = cos;
            matrix._values[1, 2] = -sin;
            matrix._values[2, 1] = sin;
            matrix._values[2, 2] = cos;
            return matrix;
        }

        public static Matrix4x4 CreateRotationY(double angle)
        {
            var matrix = CreateIdentity();
            double cos = Math.Cos(angle);
            double sin = Math.Sin(angle);
            matrix._values[0, 0] = cos;
            matrix._values[0, 2] = sin;
            matrix._values[2, 0] = -sin;
            matrix._values[2, 2] = cos;
            return matrix;
        }

        public static Matrix4x4 CreateRotationZ(double angle)
        {
            var matrix = CreateIdentity();
            double cos = Math.Cos(angle);
            double sin = Math.Sin(angle);
            matrix._values[0, 0] = cos;
            matrix._values[0, 1] = -sin;
            matrix._values[1, 0] = sin;
            matrix._values[1, 1] = cos;
            return matrix;
        }

        public static Matrix4x4 CreateReflection(string plane)
        {
            var matrix = CreateIdentity();
            switch (plane.ToLower())
            {
                case "xy":
                    matrix._values[2, 2] = -1;
                    break;
                case "xz":
                    matrix._values[1, 1] = -1;
                    break;
                case "yz":
                    matrix._values[0, 0] = -1;
                    break;
            }
            return matrix;
        }

        public static Matrix4x4 Multiply(Matrix4x4 m1, Matrix4x4 m2)
        {
            var result = new Matrix4x4();
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    for (int k = 0; k < 4; k++)
                    {
                        result._values[i, j] += m1._values[i, k] * m2._values[k, j];
                    }
                }
            }
            return result;
        }

        public Vector3 Transform(Vector3 v)
        {
            double x = _values[0, 0] * v.X + _values[0, 1] * v.Y + _values[0, 2] * v.Z + _values[0, 3];
            double y = _values[1, 0] * v.X + _values[1, 1] * v.Y + _values[1, 2] * v.Z + _values[1, 3];
            double z = _values[2, 0] * v.X + _values[2, 1] * v.Y + _values[2, 2] * v.Z + _values[2, 3];
            double w = _values[3, 0] * v.X + _values[3, 1] * v.Y + _values[3, 2] * v.Z + _values[3, 3];

            if (w != 0)
            {
                x /= w;
                y /= w;
                z /= w;
            }
            return new Vector3(x, y, z);
        }
    }
}
