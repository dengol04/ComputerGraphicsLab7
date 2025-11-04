using System;
using System.Collections.Generic;
using System.Linq;

namespace PlatonicSolids
{
    public class Polyhedron
    {
        public List<Vector3> Vertices { get; }
        public List<Polygon> Polygons { get; }

        public Polyhedron(List<Vector3> vertices, List<Polygon> polygons)
        {
            Vertices = vertices;
            Polygons = polygons;
        }

        public static Polyhedron CreateTetrahedron()
        {
            var vertices = new List<Vector3>
            {
                new Vector3(1, 1, 1),
                new Vector3(-1, -1, 1),
                new Vector3(-1, 1, -1),
                new Vector3(1, -1, -1)
            };

            var polygons = new List<Polygon>
            {
                new Polygon(new[] {0, 2, 1}),
                new Polygon(new[] {0, 3, 2}),
                new Polygon(new[] {0, 1, 3}),
                new Polygon(new[] {1, 2, 3})
            };

            return new Polyhedron(vertices, polygons);
        }

        public static Polyhedron CreateHexahedron()
        {
            var vertices = new List<Vector3>
            {
                new Vector3(-1, -1, -1),
                new Vector3(1, -1, -1),
                new Vector3(1, 1, -1),
                new Vector3(-1, 1, -1),
                new Vector3(-1, -1, 1),
                new Vector3(1, -1, 1),
                new Vector3(1, 1, 1),
                new Vector3(-1, 1, 1)
            };

            var polygons = new List<Polygon>
            {
                new Polygon(new[] {0, 1, 2, 3}),
                new Polygon(new[] {4, 7, 6, 5}),
                new Polygon(new[] {0, 4, 5, 1}),
                new Polygon(new[] {2, 6, 7, 3}),
                new Polygon(new[] {0, 3, 7, 4}),
                new Polygon(new[] {1, 5, 6, 2})
            };

            return new Polyhedron(vertices, polygons);
        }

        public static Polyhedron CreateOctahedron()
        {
            var vertices = new List<Vector3>
            {
                new Vector3(1, 0, 0),
                new Vector3(-1, 0, 0),
                new Vector3(0, 1, 0),
                new Vector3(0, -1, 0),
                new Vector3(0, 0, 1),
                new Vector3(0, 0, -1)
            };

            var polygons = new List<Polygon>
            {
                new Polygon(new[] {4, 0, 2}),
                new Polygon(new[] {4, 2, 1}),
                new Polygon(new[] {4, 1, 3}),
                new Polygon(new[] {4, 3, 0}),
                new Polygon(new[] {5, 2, 0}),
                new Polygon(new[] {5, 0, 3}),
                new Polygon(new[] {5, 3, 1}),
                new Polygon(new[] {5, 1, 2})
            };

            return new Polyhedron(vertices, polygons);
        }

        public static Polyhedron CreateIcosahedron()
        {
            double t = (1.0 + Math.Sqrt(5.0)) / 2.0;

            var vertices = new List<Vector3>
            {
                new Vector3(-1, t, 0), new Vector3(1, t, 0), new Vector3(-1, -t, 0), new Vector3(1, -t, 0),
                new Vector3(0, -1, t), new Vector3(0, 1, t), new Vector3(0, -1, -t), new Vector3(0, 1, -t),
                new Vector3(t, 0, -1), new Vector3(t, 0, 1), new Vector3(-t, 0, -1), new Vector3(-t, 0, 1)
            };

            var polygons = new List<Polygon>
            {
                new Polygon(new[] {0, 11, 5}), new Polygon(new[] {0, 5, 1}), new Polygon(new[] {0, 1, 7}), new Polygon(new[] {0, 7, 10}), new Polygon(new[] {0, 10, 11}),
                new Polygon(new[] {1, 5, 9}), new Polygon(new[] {5, 11, 4}), new Polygon(new[] {11, 10, 2}), new Polygon(new[] {10, 7, 6}), new Polygon(new[] {7, 1, 8}),
                new Polygon(new[] {3, 9, 4}), new Polygon(new[] {3, 4, 2}), new Polygon(new[] {3, 2, 6}), new Polygon(new[] {3, 6, 8}), new Polygon(new[] {3, 8, 9}),
                new Polygon(new[] {4, 9, 5}), new Polygon(new[] {2, 4, 11}), new Polygon(new[] {6, 2, 10}), new Polygon(new[] {8, 6, 7}), new Polygon(new[] {9, 8, 1})
            };

            return new Polyhedron(vertices, polygons);
        }

        public static Polyhedron CreateDodecahedron()
        {
            double t = (1.0 + Math.Sqrt(5.0)) / 2.0;
            double a = 1.0 / t;

            var vertices = new List<Vector3>
            {
                new Vector3(1, 1, 1), new Vector3(1, 1, -1), new Vector3(1, -1, 1), new Vector3(1, -1, -1),
                new Vector3(-1, 1, 1), new Vector3(-1, 1, -1), new Vector3(-1, -1, 1), new Vector3(-1, -1, -1),

                new Vector3(0, a, t), new Vector3(0, a, -t), new Vector3(0, -a, t), new Vector3(0, -a, -t),
                new Vector3(a, t, 0), new Vector3(a, -t, 0), new Vector3(-a, t, 0), new Vector3(-a, -t, 0),

                new Vector3(t, 0, a), new Vector3(t, 0, -a), new Vector3(-t, 0, a), new Vector3(-t, 0, -a)
            };

            var polygons = new List<Polygon>
            {
                new Polygon(new[] {0, 12, 1, 17, 16}),
                new Polygon(new[] {0, 16, 2, 10, 8}),
                new Polygon(new[] {0, 8, 4, 14, 12}),

                new Polygon(new[] {1, 9, 5, 14, 12}),
                new Polygon(new[] {1, 17, 3, 11, 9}),

                new Polygon(new[] {2, 13, 3, 17, 16}),
                new Polygon(new[] {2, 10, 6, 15, 13}),

                new Polygon(new[] {3, 11, 7, 15, 13}),

                new Polygon(new[] {4, 18, 6, 10, 8}),
                new Polygon(new[] {4, 14, 5, 19, 18}),

                new Polygon(new[] {5, 9, 11, 7, 19}),
                new Polygon(new[] {6, 18, 19, 7, 15})
            };

            return new Polyhedron(vertices, polygons);
        }

        //Матричные преобразования

        private static double[,] Multiply(double[,] A, double[,] B)
        {
            var result = new double[4, 4];
            for (int i = 0; i < 4; i++)
                for (int j = 0; j < 4; j++)
                    for (int k = 0; k < 4; k++)
                        result[i, j] += A[i, k] * B[k, j];
            return result;
        }

        private static Vector3 Multiply(double[,] M, Vector3 v)
        {
            double[] p = { v.X, v.Y, v.Z, 1 };
            double[] r = new double[4];
            for (int i = 0; i < 4; i++)
                for (int j = 0; j < 4; j++)
                    r[i] += M[i, j] * p[j];
            return new Vector3(r[0], r[1], r[2]);
        }

        private static double[,] Translation(double dx, double dy, double dz)
        {
            return new double[,]
            {
                {1,0,0,dx},
                {0,1,0,dy},
                {0,0,1,dz},
                {0,0,0,1}
            };
        }

        private static double[,] RotationAxis(char axis, double angle)
        {
            double a = angle * Math.PI / 180.0;
            double c = Math.Cos(a);
            double s = Math.Sin(a);

            if (axis == 'X')
            {
                return new double[,]
                {
                    {1,0,0,0},
                    {0,c,-s,0},
                    {0,s,c,0},
                    {0,0,0,1}
                };
            }
            else if (axis == 'Y')
            {
                return new double[,]
                {
                    {c,0,s,0},
                    {0,1,0,0},
                    {-s,0,c,0},
                    {0,0,0,1}
                };
            }
            else if (axis == 'Z')
            {
                return new double[,]
                {
                    {c,-s,0,0},
                    {s,c,0,0},
                    {0,0,1,0},
                    {0,0,0,1}
                };
            }
            else
            {
                throw new ArgumentException("Ось должна быть 'X', 'Y' или 'Z'.");
            }
        }

        //Вращение многогранника вокруг оси, проходящей через центр.
        public void RotateAroundAxisThroughCenter(char axis, double angle)
        {
            var cx = Vertices.Average(v => v.X);
            var cy = Vertices.Average(v => v.Y);
            var cz = Vertices.Average(v => v.Z);

            var origin = Translation(-cx, -cy, -cz);
            var back = Translation(cx, cy, cz);
            var rot = RotationAxis(axis, angle);
            var M = Multiply(back, Multiply(rot, origin));

            for (int i = 0; i < Vertices.Count; i++)
                Vertices[i] = Multiply(M, Vertices[i]);
        }

        //Вращение многогранника вокруг произвольной прямой.
        public void RotateAroundLine(Vector3 p1, Vector3 p2, double angle)
        {
            double ux = p2.X - p1.X;
            double uy = p2.Y - p1.Y;
            double uz = p2.Z - p1.Z;
            double len = Math.Sqrt(ux * ux + uy * uy + uz * uz);
            ux /= len; uy /= len; uz /= len;

            double a = angle * Math.PI / 180.0;
            double c = Math.Cos(a);
            double s = Math.Sin(a);
            double t = 1 - c;

            double[,] R = {
                {t*ux*ux + c,     t*ux*uy - s*uz, t*ux*uz + s*uy, 0},
                {t*ux*uy + s*uz,  t*uy*uy + c,    t*uy*uz - s*ux, 0},
                {t*ux*uz - s*uy,  t*uy*uz + s*ux, t*uz*uz + c,    0},
                {0,0,0,1}
            };

            var toOrigin = Translation(-p1.X, -p1.Y, -p1.Z);
            var back = Translation(p1.X, p1.Y, p1.Z);
            var M = Multiply(back, Multiply(R, toOrigin));

            for (int i = 0; i < Vertices.Count; i++)
                Vertices[i] = Multiply(M, Vertices[i]);
        }

        public static Polyhedron CreateSurface(Func<double, double, double> f,
            double x0, double x1, double y0, double y1, int nx, int ny)
        {
            if (nx < 1 || ny < 1) throw new ArgumentException("Число разбиений должно быть > 0");

            var vertices = new List<Vector3>();
            var polygons = new List<Polygon>();

            double dx = (x1 - x0) / nx;
            double dy = (y1 - y0) / ny;

            // создаём вершины сетки
            for (int j = 0; j <= ny; j++)
            {
                double y = y0 + j * dy;
                for (int i = 0; i <= nx; i++)
                {
                    double x = x0 + i * dx;
                    double z = f(x, y);
                    vertices.Add(new Vector3(x, y, z));
                }
            }

            // функция индекса
            Func<int, int, int> index = (i, j) => j * (nx + 1) + i;

            // создаём грани (четырёхугольники)
            for (int j = 0; j < ny; j++)
            {
                for (int i = 0; i < nx; i++)
                {
                    int i0 = index(i, j);
                    int i1 = index(i + 1, j);
                    int i2 = index(i + 1, j + 1);
                    int i3 = index(i, j + 1);
                    polygons.Add(new Polygon(new[] { i0, i1, i2, i3 }));
                }
            }

            return new Polyhedron(vertices, polygons);
        }

    }
}