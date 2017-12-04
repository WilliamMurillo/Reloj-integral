using System;

using Android.App;
using Android.OS;
using Android.Widget;

namespace Principal
{
    [Activity(Label = "Calculadora")]
    public class ActivityCalculadora : Activity
    {
        Button btnCero, btnUno, btnDos, btnTres, btnCuatro, btnCinco, btnSeis, btnSiete, btnOcho, btnNueve, btnSuma,
            btnResta, btnProducto, btnDivision, btnCos, btnSen, btnTan, btnIgual, btnReiniciar, btnBorrar, btnGraficar;
        Double valorUno = 0, valorDos = 0;
        TextView txtPanel;
        string strOperacion = "suma";
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.layoutCalculadora);
            // Create your application here

            //relacion de componentes
            btnCero = FindViewById<Button>(Resource.Id.btnCero);
            btnUno = FindViewById<Button>(Resource.Id.btnUno);
            btnDos = FindViewById<Button>(Resource.Id.btnDos);
            btnTres = FindViewById<Button>(Resource.Id.btnTres);
            btnCuatro = FindViewById<Button>(Resource.Id.btnCuatro);
            btnCinco = FindViewById<Button>(Resource.Id.btnCinco);
            btnSeis = FindViewById<Button>(Resource.Id.btnSeis);
            btnSiete = FindViewById<Button>(Resource.Id.btnSiete);
            btnOcho = FindViewById<Button>(Resource.Id.btnOcho);
            btnNueve = FindViewById<Button>(Resource.Id.btnNueve);
            btnSuma = FindViewById<Button>(Resource.Id.btnSuma);
            btnResta = FindViewById<Button>(Resource.Id.btnDiferencia);
            btnProducto = FindViewById<Button>(Resource.Id.btnProducto);
            btnDivision = FindViewById<Button>(Resource.Id.btnDivision);
            btnSen = FindViewById<Button>(Resource.Id.btnSen);
            btnCos = FindViewById<Button>(Resource.Id.btnCos);
            btnTan = FindViewById<Button>(Resource.Id.btnTan);
            btnIgual = FindViewById<Button>(Resource.Id.btnIgual);
            btnReiniciar = FindViewById<Button>(Resource.Id.btnReiniciar);
            btnBorrar = FindViewById<Button>(Resource.Id.btnBorrar);
            btnGraficar = FindViewById<Button>(Resource.Id.btnGraficar);
            btnGraficar.Click += BtnGraficar_Click;

            txtPanel = FindViewById<TextView>(Resource.Id.txtResul);

            //control del evento clic para cada btn
            btnCero.Click += BtnCero_Click;
            btnUno.Click += BtnUno_Click;
            btnDos.Click += BtnDos_Click;
            btnTres.Click += BtnTres_Click;
            btnCuatro.Click += BtnCuatro_Click;
            btnCinco.Click += BtnCinco_Click;
            btnSeis.Click += BtnSeis_Click;
            btnSiete.Click += BtnSiete_Click;
            btnOcho.Click += BtnOcho_Click;
            btnNueve.Click += BtnNueve_Click;
            btnSuma.Click += BtnSuma_Click;
            btnResta.Click += BtnResta_Click;
            btnProducto.Click += BtnProducto_Click;
            btnDivision.Click += BtnDivision_Click;
            btnSen.Click += BtnSen_Click;
            btnCos.Click += BtnCos_Click;
            btnTan.Click += BtnTan_Click;
            btnIgual.Click += BtnIgual_Click;
            btnReiniciar.Click += BtnReiniciar_Click;
            btnBorrar.Click += BtnBorrar_Click;
                  }

        private void BtnGraficar_Click(object sender, EventArgs e)
        {
            StartActivity(typeof(ActivityGraficar));
        }

        private void BtnBorrar_Click(object sender, EventArgs e)
        {
            if (txtPanel.Text.Length > 1)
            {
                txtPanel.Text = txtPanel.Text.Remove(txtPanel.Text.Length - 1);
            }else if(txtPanel.Text.Length == 1)
            {
                txtPanel.Text = "0";
            }
        }

        private void BtnReiniciar_Click(object sender, EventArgs e)
        {
            
                txtPanel.Text = "0";
            
        }

        private void BtnIgual_Click(object sender, EventArgs e)
        {
            try
            {
                valorDos = double.Parse(txtPanel.Text.ToString());
                txtPanel.Text = "0";

                switch (strOperacion)
                {
                    case "suma":
                        txtPanel.Text = (valorUno + valorDos).ToString();
                        break;
                    case "resta":
                        txtPanel.Text = (valorUno - valorDos).ToString();

                        break;
                    case "producto":
                        txtPanel.Text = (valorUno * valorDos).ToString();
                        break;
                    case "division":
                        if (valorDos != 0)
                        {
                            txtPanel.Text = (valorUno / valorDos).ToString();
                        }
                        else
                        {
                            Toast.MakeText(this, "No se puede dividir entre 0", ToastLength.Short).Show();
                        }
                        break;
                }
            }
            catch(Exception ec) { Toast.MakeText(this,"Error",ToastLength.Short).Show(); }
        }

        private void BtnTan_Click(object sender, EventArgs e)
        {
            txtPanel.Text = (Math.Tan(double.Parse(txtPanel.Text))).ToString();
        }

        private void BtnCos_Click(object sender, EventArgs e)
        {
            txtPanel.Text = (Math.Cos(double.Parse(txtPanel.Text))).ToString();
        }

        private void BtnSen_Click(object sender, EventArgs e)
        {
            txtPanel.Text = (Math.Sin(double.Parse(txtPanel.Text))).ToString();
        }

        private void BtnDivision_Click(object sender, EventArgs e)
        {
            valorUno = Double.Parse(txtPanel.Text);
            txtPanel.Text = "0";
            strOperacion = "division";
        }

        private void BtnProducto_Click(object sender, EventArgs e)
        {
            valorUno = Double.Parse(txtPanel.Text);
            txtPanel.Text = "0";
            strOperacion = "producto";
        }

        private void BtnResta_Click(object sender, EventArgs e)
        {
            valorUno = Double.Parse(txtPanel.Text);
            txtPanel.Text = "0";
            strOperacion = "resta";
        }

        private void BtnSuma_Click(object sender, EventArgs e)
        {
            valorUno = Double.Parse(txtPanel.Text);
            txtPanel.Text = "0";
            strOperacion = "suma";
        }

        private void BtnNueve_Click(object sender, EventArgs e)
        {
            if (txtPanel.Text != "0")
            {
                txtPanel.Text += "9";
            }
            else if (txtPanel.Text == "0")
            {
                txtPanel.Text = "9";
            }
        }

        private void BtnOcho_Click(object sender, EventArgs e)
        {
            if (txtPanel.Text != "0")
            {
                txtPanel.Text += "8";
            }
            else if (txtPanel.Text == "0")
            {
                txtPanel.Text = "8";
            }
        }

        private void BtnSiete_Click(object sender, EventArgs e)
        {
            if (txtPanel.Text != "0")
            {
                txtPanel.Text += "7";
            }
            else if (txtPanel.Text == "0")
            {
                txtPanel.Text = "7";
            }
        }

        private void BtnSeis_Click(object sender, EventArgs e)
        {
            if (txtPanel.Text != "0")
            {
                txtPanel.Text += "6";
            }
            else if (txtPanel.Text == "0")
            {
                txtPanel.Text = "6";
            }
        }

        private void BtnCinco_Click(object sender, EventArgs e)
        {
            if (txtPanel.Text != "0")
            {
                txtPanel.Text += "5";
            }
            else if (txtPanel.Text == "0")
            {
                txtPanel.Text = "5";
            }
        }

        private void BtnCuatro_Click(object sender, EventArgs e)
        {
            if (txtPanel.Text != "0")
            {
                txtPanel.Text += "4";
            }
            else if (txtPanel.Text == "0")
            {
                txtPanel.Text = "4";
            }
        }

        private void BtnTres_Click(object sender, EventArgs e)
        {
            if (txtPanel.Text != "0")
            {
                txtPanel.Text += "3";
            }
            else if (txtPanel.Text == "0")
            {
                txtPanel.Text = "3";
            }
        }

        private void BtnDos_Click(object sender, EventArgs e)
        {
            if (txtPanel.Text != "0")
            {
                txtPanel.Text += "2";
            }
            else if (txtPanel.Text == "0")
            {
                txtPanel.Text = "2";
            }
        }

        private void BtnUno_Click(object sender, EventArgs e)
        {
            if (txtPanel.Text != "0")
            {
                txtPanel.Text += "1";
            }else if(txtPanel.Text == "0")
            {
                txtPanel.Text = "1";
            }
        }

        private void BtnCero_Click(object sender, EventArgs e)
        {
            if(txtPanel.Text != "0")
            {
                txtPanel.Text += "0";
            }
        }
    }
}