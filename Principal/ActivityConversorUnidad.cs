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
    [Activity(Label = "Conversor unidad")]
    public class ActivityConversorUnidad : Activity
    {
        RadioButton rbMillas, rbKilometros, rbGalones, rbLitros;
        TextView txtResultado;
        EditText etValor;
        Button btnConvertir;
        double inputValor = 0, outputValor = 0;
        string tipoConversion = string.Empty;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.layoutConversorUnidad);
            // Create your application here

            //relacion de componentes

            //radioButtons
            rbGalones = FindViewById<RadioButton>(Resource.Id.rbGalones);
            rbKilometros = FindViewById<RadioButton>(Resource.Id.rbkilometros);
            rbMillas = FindViewById<RadioButton>(Resource.Id.rbMillas);
            rbLitros = FindViewById<RadioButton>(Resource.Id.rbLitros);

            //txt para escribir el resultado
            txtResultado = FindViewById<TextView>(Resource.Id.txtResultado);

            //editText para capturar el valor
            etValor = FindViewById<EditText>(Resource.Id.etValor);
            etValor.Text = "1"; //valor por defecto
            //btn para convertir
            btnConvertir = FindViewById<Button>(Resource.Id.btnConvertir);
            btnConvertir.Click += BtnConvertir_Click;
        }

        private void BtnConvertir_Click(object sender, EventArgs e)
        {
            try
            {
                inputValor = double.Parse(etValor.Text.ToString());
                etValor.Text = string.Empty;

                if (rbGalones.Checked == true)
                {
                    tipoConversion = "Galon";   
                }else if(rbLitros.Checked == true)
                {
                    tipoConversion = "Litro";
                }
                else if(rbMillas.Checked == true)
                {
                    tipoConversion = "Milla";
                }
                else if(rbKilometros.Checked == true)
                {
                    tipoConversion = "Kilometro";
                }

                switch (tipoConversion)
                {
                    case "Galon":
                        outputValor = inputValor/0.264;
                        txtResultado.Text = "" +
                            "\nValor en galones: " + inputValor +
                        "\nValor en litros: " + Math.Round(outputValor,6);

                        break;
                    case "Litro":
                        outputValor =  inputValor/3.785 ;
                        txtResultado.Text = "" +
                            "\nValor en litros: " + inputValor +
                            "\nValor en galones: " + Math.Round(outputValor, 6); ;
                        break;
                    case "Milla":
                        outputValor =  inputValor/ 0.621371;
                        txtResultado.Text = "" +
                            "\nValor en millas: " + inputValor +
                            "\nValor en kilometros: " + Math.Round(outputValor, 6); ;
                        break;
                    case "Kilometro":
                        outputValor = inputValor/1.60934;
                        txtResultado.Text = "" +
                            "\nValor en kilometros: " + inputValor +
                            "\nValor en millas: " + Math.Round(outputValor, 6); ;
                        break;
                }
            }catch(Exception ex)
            {
                Toast.MakeText(this, "Error ingrese valores correctos", ToastLength.Short).Show();
            }

        }
    }
}