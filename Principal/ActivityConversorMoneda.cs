using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace Principal
{
    [Activity(Label = "Conversor moneda")]
    public class ActivityConversorMoneda : Activity
    {
        EditText etValor;
        Button btnConvertir;
        RadioButton rbPeso, rbDolar, rbEuro;
        TextView txtInfo;
        Double valorOriginal = 0, valorConvertido = 0, valorDolar = 0, valorEuro = 0, valorPeso = 0;
        string estado = string.Empty;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.layoutConversorMoneda);
            // Create your application here

            //Relación de componentes 
            //_____________________________________
            //EditText para el valor
            etValor = FindViewById<EditText>(Resource.Id.etValor);
            etValor.Text = "1";
            //raddio buttones
            rbDolar = FindViewById<RadioButton>(Resource.Id.rbDolares);
            rbPeso = FindViewById<RadioButton>(Resource.Id.rbPesos);
            rbEuro = FindViewById<RadioButton>(Resource.Id.rbEuros);
            
            //btn para convertir
            btnConvertir = FindViewById<Button>(Resource.Id.btnConvertir);
            btnConvertir.Click += BtnConvertir_Click;

            //txt para la info
            txtInfo = FindViewById<TextView>(Resource.Id.txtInfo);
            txtInfo.Text= "Resultado de la conversión:" +
                "\nValor en dolares: ... "  +
            "\nValor en euros: ..." + 
            "\nValor en pesos: ..." ;

        }

       
        private void BtnConvertir_Click(object sender, EventArgs e)
        {
            try
            {
                valorOriginal = Double.Parse(etValor.Text.ToString());
                etValor.Text = string.Empty;

                if (rbDolar.Checked == true)
                {
                    estado = "Dolar";
                }
                else if (rbEuro.Checked == true)
                {
                    estado = "Euro";
                }
                else if (rbPeso.Checked == true)
                {
                    estado = "Peso";
                }

                switch (estado)
                {
                    case "Dolar":
                        valorDolar = valorOriginal;
                        valorEuro = valorOriginal / 1.16;
                        valorPeso = valorOriginal * 3012.05;
                        break;
                    case "Euro":
                        valorDolar = valorOriginal * 1.16;
                        valorEuro = valorOriginal;
                        valorPeso = valorOriginal * 3513.40;
                        break;
                    case "Peso":
                        valorDolar = valorOriginal / 3012.05;
                        valorEuro = valorOriginal / 3513.40;
                        valorPeso = valorOriginal;
                        break;
                }

                txtInfo.Text = "Resultado de la conversión:" +
                   "\nValor en dolares: " + Math.Round(valorDolar, 7) +
               "\nValor en euros: " + Math.Round(valorEuro, 7) +
               "\nValor en pesos: " + Math.Round(valorPeso, 7);
            }catch(Exception ex)
            {
                Toast.MakeText(this,"ingrese un formato correcto",ToastLength.Short).Show();
            }


        }
        
    }
}