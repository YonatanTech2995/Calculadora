using NCalc;
namespace Calculadora

{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            var boton = sender as Button;
            if (boton == null) return;
            if (boton.Text == "0" && string.IsNullOrEmpty(lblOperacion.Text)) return;
            if (boton.Text == "+" || boton.Text == "-" || boton.Text == "/" || boton.Text == "X")
            {
                if (lblOperacion.Text == null || lblOperacion.Text == "") return;
                char ultimo = lblOperacion.Text[lblOperacion.Text.Length - 1];
                if (ultimo == '/' || ultimo == '-' || ultimo == '+' || ultimo == '*')
                {
                    return;
                }
                else
                {
                    if (boton.Text == "X")
                    {
                        lblOperacion.Text += "*";
                    }
                    else
                    {
                        lblOperacion.Text += boton.Text;
                    }
                    return;

                }
            }
            int numero = 0;
            bool r = int.TryParse(boton.Text, out numero);
            if (r)
            {
                lblOperacion.Text += numero.ToString();
                return;
            }
            else if (boton.Text == "C")
            {
                lblOperacion.Text = lblResultado.Text = string.Empty;
                return;
            }
            else if (boton.Text == "=" && !string.IsNullOrEmpty(lblOperacion.Text))
            {
                string operacion = lblOperacion.Text;
                var exp = new Expression(operacion);
                lblResultado.Text = exp.Evaluate().ToString();
            }
            else if (boton.Text == "CE")
            {
                if (lblOperacion.Text.Length > 0)
                {
                    lblOperacion.Text = lblOperacion.Text.Substring(0, lblOperacion.Text.Length - 1);
                }
                if (lblOperacion.Text.Length == 0)
                {
                    lblResultado.Text = string.Empty;
                }
            }
        }
    }
}
