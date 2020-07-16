using System;
using System.Drawing;
using System.Windows.Forms;

namespace calculadora
{
    public partial class Calculator : Form
    {
        private string _operador;
        private decimal _valor1;
        private decimal _valor2;
        private decimal _resultado;

        public Calculator()
        {
            InitializeComponent();

            this.Text = "Mi Calculadora";
            this.MaximumSize = new Size(334, 180);

            setup();
        }
        private void setup()
        {
            Button buttonSuma = new Button();
            buttonSuma.Location = new Point(10, 80);
            buttonSuma.Size = new Size(50, 20);
            buttonSuma.Text = "+";
            buttonSuma.Click += new EventHandler(operadorButton_Click);

            Button buttonResta = new Button();
            buttonResta.Location = new Point(70, 80);
            buttonResta.Size = new Size(50, 20);
            buttonResta.Text = "-";
            buttonResta.Click += new EventHandler(operadorButton_Click);

            Button buttonMultiplicacion = new Button();
            buttonMultiplicacion.Location = new Point(130, 80);
            buttonMultiplicacion.Size = new Size(50, 20);
            buttonMultiplicacion.Text = "*";
            buttonMultiplicacion.Click += new EventHandler(operadorButton_Click);

            Button buttonDivision = new Button();
            buttonDivision.Location = new Point(190, 80);
            buttonDivision.Size = new Size(50, 20);
            buttonDivision.Text = "/";
            buttonDivision.Click += new EventHandler(operadorButton_Click);

            Button buttonSalir = new Button();
            buttonSalir.Location = new Point(10, 105);
            buttonSalir.Size = new Size(100, 20);
            buttonSalir.Text = "Salir";
            buttonSalir.Click += new EventHandler(cerrarFormulario);

            Label labelValor1 = new Label();
            labelValor1.Text = "Valor 1";
            labelValor1.Size = new Size(93, 20);
            labelValor1.Location = new Point(10, 30);

            TextBox textBoxValor1 = new TextBox();
            textBoxValor1.Location = new Point(10, 50);
            textBoxValor1.Size = new Size(93, 20);
            textBoxValor1.TextChanged += new EventHandler(textBoxValor1_Change);

            Label labelValor2 = new Label();
            labelValor2.Text = "Valor 2";
            labelValor2.Size = new Size(93, 20);
            labelValor2.Location = new Point(113, 30);

            TextBox textBoxValor2 = new TextBox();
            textBoxValor2.Location = new Point(113, 50);
            textBoxValor2.Size = new Size(93, 20);
            textBoxValor2.TextChanged += new EventHandler(textBoxValor2_Change);

            Label labelResultado = new Label();
            labelResultado.Text = "Resultado";
            labelResultado.Size = new Size(93, 20);
            labelResultado.Location = new Point(216, 30);

            TextBox textBoxResultado = new TextBox();
            textBoxResultado.Location = new Point(216, 50);
            textBoxResultado.Size = new Size(93, 20);
            textBoxResultado.ReadOnly = true;
            textBoxResultado.Name = "textBoxResultado";

            this.Controls.AddRange(new Control[] {
                buttonSuma, buttonResta, buttonDivision, 
                buttonMultiplicacion, buttonSalir, labelValor1, 
                labelValor2, labelResultado, textBoxValor1, 
                textBoxValor2, textBoxResultado 
            });
        }
        public void textBoxValor1_Change(object sender, EventArgs e)
        {
            TextBox textBoxValor1 = sender as TextBox;
            this._valor1 = decimal.Parse(textBoxValor1.Text);
        }
        public void textBoxValor2_Change(object sender, EventArgs e)
        {
            TextBox textBoxValor1 = sender as TextBox;
            this._valor2 = decimal.Parse(textBoxValor1.Text);
        }
        private void operadorButton_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            this._operador = btn.Text;
            decimal resultado = this.operar(_valor1, _operador, _valor2);
            this._resultado = resultado;
            Control[] controls = this.Controls.Find("textBoxResultado", false);
            TextBox textBoxResultado = controls[0] as TextBox;
            textBoxResultado.Text = _resultado.ToString();
        }
        private void cerrarFormulario(object sender, EventArgs e)
        {
            this.Close();
        }
        public decimal operar(decimal numero1, string operador, decimal numero2)
        {
            decimal resultado = 0;

            switch (operador)
            {
                case "+":
                    resultado = numero1 + numero2;
                    break;
                case "-":
                    resultado = numero1 - numero2;
                    break;
                case "*":
                    resultado = numero1 * numero2;
                    break;
                case "/":
                    resultado = numero1 / numero2;
                    break;
                default:
                    /* 
                    * TODO: throw error
                    */
                    break;
            }

            return resultado;
        }

    }
}
