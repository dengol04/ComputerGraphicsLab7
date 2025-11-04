using System;
using System.Windows.Forms;

namespace PlatonicSolids
{
    public partial class SurfaceForm : Form
    {
        public Func<double, double, double> Function { get; private set; }
        public double X0 { get; private set; }
        public double X1 { get; private set; }
        public double Y0 { get; private set; }
        public double Y1 { get; private set; }
        public int Steps { get; private set; }

        public SurfaceForm()
        {
            Text = "Создание поверхности f(x,y)";
            Width = 400;
            Height = 250;
            StartPosition = FormStartPosition.CenterParent;

            Label lblFunc = new Label() { Text = "Выберите функцию:", Left = 20, Top = 20, Width = 120 };
            ComboBox combo = new ComboBox() { Left = 150, Top = 18, Width = 200 };
            combo.Items.AddRange(new string[]
            {
                "sin(x)*cos(y)",
                "x^2 + y^2",
                "sin(x)*y",
                "x*y",
                "sqrt(x^2+y^2)"
            });
            combo.SelectedIndex = 0;

            Label lblX = new Label() { Text = "X ∈ [", Left = 20, Top = 60, Width = 40 };
            TextBox txtX0 = new TextBox() { Left = 60, Top = 58, Width = 50, Text = "-3" };
            Label lblToX = new Label() { Text = ";", Left = 115, Top = 60, Width = 10 };
            TextBox txtX1 = new TextBox() { Left = 130, Top = 58, Width = 50, Text = "3" };
            Label lblEndX = new Label() { Text = "]", Left = 185, Top = 60, Width = 10 };

            Label lblY = new Label() { Text = "Y ∈ [", Left = 200, Top = 60, Width = 40 };
            TextBox txtY0 = new TextBox() { Left = 240, Top = 58, Width = 50, Text = "-3" };
            Label lblToY = new Label() { Text = ";", Left = 295, Top = 60, Width = 10 };
            TextBox txtY1 = new TextBox() { Left = 310, Top = 58, Width = 50, Text = "3" };
            Label lblEndY = new Label() { Text = "]", Left = 365, Top = 60, Width = 10 };

            Label lblSteps = new Label() { Text = "Разбиений:", Left = 20, Top = 100, Width = 90 };
            TextBox txtSteps = new TextBox() { Left = 110, Top = 98, Width = 60, Text = "30" };

            Button btnOK = new Button() { Text = "Создать", Left = 240, Top = 140, Width = 100 };
            btnOK.Click += (s, e) =>
            {
                try
                {
                    X0 = double.Parse(txtX0.Text);
                    X1 = double.Parse(txtX1.Text);
                    Y0 = double.Parse(txtY0.Text);
                    Y1 = double.Parse(txtY1.Text);
                    Steps = int.Parse(txtSteps.Text);

                    switch (combo.SelectedItem.ToString())
                    {
                        case "sin(x)*cos(y)":
                            Function = (x, y) => Math.Sin(x) * Math.Cos(y);
                            break;
                        case "x^2 + y^2":
                            Function = (x, y) => x * x + y * y;
                            break;
                        case "sin(x)*y":
                            Function = (x, y) => Math.Sin(x) * y;
                            break;
                        case "x*y":
                            Function = (x, y) => x * y;
                            break;
                        case "sqrt(x^2+y^2)":
                            Function = (x, y) => Math.Sqrt(x * x + y * y);
                            break;
                        default:
                            Function = (x, y) => 0;
                            break;
                    }

                    DialogResult = DialogResult.OK;
                }
                catch
                {
                    MessageBox.Show("Ошибка в параметрах.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            };

            Controls.AddRange(new Control[]
            {
                lblFunc, combo, lblX, txtX0, lblToX, txtX1, lblEndX,
                lblY, txtY0, lblToY, txtY1, lblEndY,
                lblSteps, txtSteps, btnOK
            });
        }
    }
}
