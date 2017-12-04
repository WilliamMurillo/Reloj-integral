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
    [Activity(Label = "Traductor")]
    public class ActivityTraductor : Activity
    {
        string[] arrayEspañol = new string[] {"abaratar","balcón","consagración","delincuencia","fumar","historiador","jalar","materialidad","lactancia","zoología"};
        string[] arrayIngles = new string[] {"cheapen", "balcony","consecration","delinquency","smoke","historian","pull","materiality","nursing","zoology"};
        EditText etPalabra;
        Button btnTraducir;
        string inputPalabra;
        TextView txtPalabras, txtTraduccion, txtPalabrasIngles;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.layoutTraductor);
            // Create your application here

            //Relación de componentes
            //-----------------------------

            //EditText con la palabra a traducir 
            etPalabra = FindViewById<EditText>(Resource.Id.etPalabra);

            //btn para traducir y evento click
            btnTraducir = FindViewById<Button>(Resource.Id.btnTraducir);
            btnTraducir.Click += BtnTraducir_Click;

            //txt dónde para mostrar traducción
            txtTraduccion = FindViewById<TextView>(Resource.Id.txtTraduccion);

            //txt para mostrar palabra a traducir de inglés
            txtPalabrasIngles = FindViewById<TextView>(Resource.Id.txtPalabrasIngles);
            txtPalabrasIngles.Text = "" +
                "Palabras a traducir:" +
                "\ncheapen" +
                "\nbalcony" +
                "\nconsecration" +
                "\ndelinquency" +
                "\nsmoke" +
                "\nhistorian" +
                "\npull" +
                "\nmateriality" +
                "\nnursing" +
                "\nzoology";
            //txt para mostrar palabras a traducir del español
            txtPalabras = FindViewById<TextView>(Resource.Id.txtPalabras);
            txtPalabras.Text = "" +
                "Palabras a traducir:" +
                "\nabaratar" +
                "\nbalcón" +
                "\nconsagración" +
                "\ndelincuancia" +
                "\nfumar" +
                "\nhistoriador" +
                "\njalar" +
                "\nmaterialidad" +
                "\nlactancia" +
                "\nzoología";

        
        }

        private void BtnTraducir_Click(object sender, EventArgs e)
        {
            try
            {
                inputPalabra = etPalabra.Text.ToString();
                etPalabra.Text = string.Empty;

                //condicionales para traducción de español - inglés
                if (inputPalabra == "abaratar")
                {
                    txtTraduccion.Text = arrayIngles[0];
                }
                else if (inputPalabra == "balcón")
                {
                    txtTraduccion.Text = arrayIngles[1];
                }
                else if (inputPalabra == "consagración")
                {
                    txtTraduccion.Text = arrayIngles[2];
                }
                else if (inputPalabra == "delincuencia")
                {
                    txtTraduccion.Text = arrayIngles[3];
                }
                else if (inputPalabra == "fumar")
                {
                    txtTraduccion.Text = arrayIngles[4];
                }
                else if (inputPalabra == "historiador")
                {
                    txtTraduccion.Text = arrayIngles[5];
                }
                else if (inputPalabra == "jalar")
                {
                    txtTraduccion.Text = arrayIngles[6];
                }
                else if (inputPalabra == "materialidad")
                {
                    txtTraduccion.Text = arrayIngles[7];
                }
                else if (inputPalabra == "lactancia")
                {
                    txtTraduccion.Text = arrayIngles[8];
                }
                else if (inputPalabra == "zoología")
                {
                    txtTraduccion.Text = arrayIngles[9];
                }

                //condicionales para traducción de inglés - español  
                else if (inputPalabra == "cheapen")
                {
                    txtTraduccion.Text = arrayEspañol[0];
                }
                else if (inputPalabra == "balcony")
                {
                    txtTraduccion.Text = arrayEspañol[1];
                }
                else if (inputPalabra == "consecration")
                {
                    txtTraduccion.Text = arrayEspañol[2];
                }
                else if (inputPalabra == "delinquency")
                {
                    txtTraduccion.Text = arrayEspañol[3];
                }
                else if (inputPalabra == "smoke")
                {
                    txtTraduccion.Text = arrayEspañol[4];
                }
                else if (inputPalabra == "historian")
                {
                    txtTraduccion.Text = arrayEspañol[5];
                }
                else if (inputPalabra == "pull")
                {
                    txtTraduccion.Text = arrayEspañol[6];
                }
                else if (inputPalabra == "materiality")
                {
                    txtTraduccion.Text = arrayEspañol[7];
                }
                else if (inputPalabra == "nursing")
                {
                    txtTraduccion.Text = arrayEspañol[8];
                }
                else if (inputPalabra == "zoology")
                {
                    txtTraduccion.Text = arrayEspañol[9];
                }
                else
                {
                    Toast.MakeText(this, "Palabra no soportada - word not supported", ToastLength.Short).Show();
                }
            }
            catch (Exception ex)
            {
                Toast.MakeText(this,"Palabra no soportada",ToastLength.Short).Show();
            }
        }
        
    }
}