using System;
using System.Drawing;
using System.Windows.Forms;

namespace PlatonicSolids
{
    public partial class MainForm : Form
    {
        private Polyhedron currentPolyhedron;
        private string projectionType = "Perspective";
        private const double ROTATION_ANGLE_X = 0.5;
        private const double ROTATION_ANGLE_Y = 0.5;

        public MainForm()
        {
            InitializeComponent();
            currentPolyhedron = Polyhedron.CreateTetrahedron();
            this.DoubleBuffered = true;

            var transformationsMenu = new ToolStripMenuItem("Transformations");

            var rotateAxisMenu = new ToolStripMenuItem("Rotate Around Axis (through center)");
            rotateAxisMenu.DropDownItems.Add("Around X-axis", null, (s, e) =>
            {
                currentPolyhedron.RotateAroundAxisThroughCenter('X', 30);
                Invalidate();
            });
            rotateAxisMenu.DropDownItems.Add("Around Y-axis", null, (s, e) =>
            {
                currentPolyhedron.RotateAroundAxisThroughCenter('Y', 30);
                Invalidate();
            });
            rotateAxisMenu.DropDownItems.Add("Around Z-axis", null, (s, e) =>
            {
                currentPolyhedron.RotateAroundAxisThroughCenter('Z', 30);
                Invalidate();
            });
            transformationsMenu.DropDownItems.Add(rotateAxisMenu);

            transformationsMenu.DropDownItems.Add("Rotate Around Arbitrary Line...", null, (s, e) =>
            {
                using (var dlg = new LineRotationForm())
                {
                    if (dlg.ShowDialog(this) == DialogResult.OK)
                    {
                        currentPolyhedron.RotateAroundLine(dlg.P1, dlg.P2, dlg.Angle);
                        Invalidate();
                    }
                }
            });

            transformationsMenu.DropDownItems.Add("Reset", null, (s, e) =>
            {
                currentPolyhedron = Polyhedron.CreateTetrahedron();
                Invalidate();
            });

            var surfaceMenuItem = new ToolStripMenuItem("Generate Surface (f(x,y) = z)");
            surfaceMenuItem.Click += (s, e) =>
            {
                using (var dlg = new SurfaceForm())
                {
                    if (dlg.ShowDialog(this) == DialogResult.OK)
                    {
                        currentPolyhedron = Polyhedron.CreateSurface(
                            dlg.Function, dlg.X0, dlg.X1, dlg.Y0, dlg.Y1, dlg.Steps, dlg.Steps);
                        Invalidate();
                    }
                }
            };

            menuStrip1.Items.Add(transformationsMenu);
            menuStrip1.Items.Add(surfaceMenuItem);
        }

        private void MainForm_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.Clear(Color.Black);
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            if (currentPolyhedron == null) return;

            int width = ClientSize.Width;
            int height = ClientSize.Height;
            double scale = Math.Min(width, height) / 5;

            foreach (var polygon in currentPolyhedron.Polygons)
            {
                PointF[] points = new PointF[polygon.Indices.Length];
                for (int i = 0; i < polygon.Indices.Length; i++)
                {
                    Vector3 v = currentPolyhedron.Vertices[polygon.Indices[i]];

                    v = RotateX(v, ROTATION_ANGLE_X);
                    v = RotateY(v, ROTATION_ANGLE_Y);

                    PointF p;
                    if (projectionType == "Perspective")
                    {
                        p = ProjectPerspective(v, width, height, scale);
                    }
                    else
                    {
                        p = ProjectAxonometric(v, width, height, scale);
                    }
                    points[i] = p;
                }
                g.DrawPolygon(Pens.White, points);
            }
        }

        private Vector3 RotateX(Vector3 v, double angle)
        {
            double cos = Math.Cos(angle);
            double sin = Math.Sin(angle);
            return new Vector3(v.X, v.Y * cos - v.Z * sin, v.Y * sin + v.Z * cos);
        }

        private Vector3 RotateY(Vector3 v, double angle)
        {
            double cos = Math.Cos(angle);
            double sin = Math.Sin(angle);
            return new Vector3(v.X * cos + v.Z * sin, v.Y, -v.X * sin + v.Z * cos);
        }

        private PointF ProjectPerspective(Vector3 v, int width, int height, double scale)
        {
            double distance = 5;
            double f = distance / (distance - v.Z);
            double x = v.X * f * scale + width / 2;
            double y = v.Y * f * scale + height / 2;
            return new PointF((float)x, (float)y);
        }

        private PointF ProjectAxonometric(Vector3 v, int width, int height, double scale)
        {
            double x = v.X * scale + width / 2;
            double y = v.Y * scale + height / 2;
            return new PointF((float)x, (float)y);
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void perspectiveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            projectionType = "Perspective";
            perspectiveToolStripMenuItem.Checked = true;
            axonometricToolStripMenuItem.Checked = false;
            this.Invalidate();
        }

        private void axonometricToolStripMenuItem_Click(object sender, EventArgs e)
        {
            projectionType = "Axonometric";
            perspectiveToolStripMenuItem.Checked = false;
            axonometricToolStripMenuItem.Checked = true;
            this.Invalidate();
        }

        private void tetrahedronToolStripMenuItem_Click(object sender, EventArgs e)
        {
            currentPolyhedron = Polyhedron.CreateTetrahedron();
            this.Invalidate();
        }

        private void hexahedronToolStripMenuItem_Click(object sender, EventArgs e)
        {
            currentPolyhedron = Polyhedron.CreateHexahedron();
            this.Invalidate();
        }

        private void octahedronToolStripMenuItem_Click(object sender, EventArgs e)
        {
            currentPolyhedron = Polyhedron.CreateOctahedron();
            this.Invalidate();
        }

        private void icosahedronToolStripMenuItem_Click(object sender, EventArgs e)
        {
            currentPolyhedron = Polyhedron.CreateIcosahedron();
            this.Invalidate();
        }

        private void dodecahedronToolStripMenuItem_Click(object sender, EventArgs e)
        {
            currentPolyhedron = Polyhedron.CreateDodecahedron();
            this.Invalidate();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "OBJ Files (*.obj)|*.obj|All Files (*.*)|*.*";
                openFileDialog.Title = "Open Polyhedron Model (OBJ)";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        currentPolyhedron = ObjFileHandler.LoadFromObj(openFileDialog.FileName);
                        this.Invalidate();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Ошибка при загрузке модели: " + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (currentPolyhedron == null)
            {
                MessageBox.Show("Нет модели многогранника для сохранения.", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = "OBJ Files (*.obj)|*.obj|All Files (*.*)|*.*";
                saveFileDialog.Title = "Save Polyhedron Model (OBJ)";
                saveFileDialog.FileName = "polyhedron.obj";

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        ObjFileHandler.SaveToObj(currentPolyhedron, saveFileDialog.FileName);
                        MessageBox.Show("Модель успешно сохранена!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Ошибка при сохранении модели: " + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
    }
}