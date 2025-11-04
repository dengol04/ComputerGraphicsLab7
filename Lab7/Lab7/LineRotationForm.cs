using System;
using System.Windows.Forms;

namespace PlatonicSolids
{
    public partial class LineRotationForm : Form
    {
        public Vector3 P1 { get; private set; }
        public Vector3 P2 { get; private set; }
        public double Angle { get; private set; }

        public LineRotationForm()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.Text = "Вращение вокруг произвольной прямой";
            this.Width = 300;
            this.Height = 250;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.StartPosition = FormStartPosition.CenterParent;

            Label lbl1 = new Label() { Text = "Точка 1 (x1, y1, z1):", Left = 10, Top = 20, Width = 150 };
            TextBox txtP1 = new TextBox() { Left = 160, Top = 20, Width = 100, Text = "0 0 0" };

            Label lbl2 = new Label() { Text = "Точка 2 (x2, y2, z2):", Left = 10, Top = 60, Width = 150 };
            TextBox txtP2 = new TextBox() { Left = 160, Top = 60, Width = 100, Text = "1 1 1" };

            Label lblA = new Label() { Text = "Угол (°):", Left = 10, Top = 100, Width = 150 };
            TextBox txtAngle = new TextBox() { Left = 160, Top = 100, Width = 100, Text = "45" };

            Button btnOk = new Button() { Text = "OK", Left = 60, Top = 150, Width = 70 };
            Button btnCancel = new Button() { Text = "Отмена", Left = 150, Top = 150, Width = 80 };

            btnOk.Click += (s, e) =>
            {
                try
                {
                    string[] p1 = txtP1.Text.Split(' ');
                    string[] p2 = txtP2.Text.Split(' ');
                    if (p1.Length != 3 || p2.Length != 3)
                    {
                        MessageBox.Show("Введите по три координаты через пробел!");
                        return;
                    }

                    P1 = new Vector3(
                        double.Parse(p1[0]),
                        double.Parse(p1[1]),
                        double.Parse(p1[2]));
                    P2 = new Vector3(
                        double.Parse(p2[0]),
                        double.Parse(p2[1]),
                        double.Parse(p2[2]));
                    Angle = double.Parse(txtAngle.Text);

                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                catch
                {
                    MessageBox.Show("Ошибка ввода! Проверьте формат чисел.");
                }
            };

            btnCancel.Click += (s, e) => { this.DialogResult = DialogResult.Cancel; this.Close(); };

            Controls.AddRange(new Control[] { lbl1, txtP1, lbl2, txtP2, lblA, txtAngle, btnOk, btnCancel });
        }
    }
}
