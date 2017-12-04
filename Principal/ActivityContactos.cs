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
using Principal.Gestor_BD;

namespace Principal
{
    [Activity(Label = "Contactos")]
    public class ActivityContactos : Activity
    {
        Button btnGuardar, btnGestionar;
        EditText etCedula, etNombres, etApellidos, etTelefono, etCorreo;
        RadioButton rbFijo, rbMovil, rbTrabajo;
        string tipo ="Móvil";
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.layoutContactos);


            // Create your application here

            //Relación de componentes

            etCedula = FindViewById<EditText>(Resource.Id.etcedula);
            etNombres = FindViewById<EditText>(Resource.Id.etNombres);
            etApellidos = FindViewById<EditText>(Resource.Id.etApellidos);
            etTelefono = FindViewById<EditText>(Resource.Id.etTelefono);
            etCorreo = FindViewById<EditText>(Resource.Id.etCorreo);
            rbFijo = FindViewById<RadioButton>(Resource.Id.rgFijo);
            rbMovil = FindViewById<RadioButton>(Resource.Id.rgMovil);
            rbTrabajo = FindViewById<RadioButton>(Resource.Id.rgTrabajo);
            btnGuardar = FindViewById<Button>(Resource.Id.btnGuardar);
            btnGestionar = FindViewById<Button>(Resource.Id.btnGestion);

            //evento clic para el botón guardar
            btnGuardar.Click += BtnGuardar_Click;
            btnGestionar.Click += BtnGestionar_Click;

            //crear base datos y tablas si no existen
            ClsAdminBDcs dbr = new ClsAdminBDcs();
            var res = dbr.mtCrearBaseDatos();
            Toast.MakeText(this, res, ToastLength.Short).Show();

             res = dbr.mtCrearTabla();
            Toast.MakeText(this, res, ToastLength.Short).Show();

           
        }

        private void BtnGestionar_Click(object sender, EventArgs e)
        {
            StartActivity(typeof(ActivityGestionContactos));
        }

        private void BtnGuardar_Click(object sender, EventArgs e)
        {

            try
            {
                if (etCedula.Text != "" && etNombres.Text != "" && etTelefono.Text != "")
                {
                    ClsAdminBDcs dbr = new ClsAdminBDcs();
                    //hallar el tipo de numero
                    if (rbFijo.Checked == true)
                    {
                        tipo = "Fijo";
                    }
                    if (rbMovil.Checked == true)
                    {
                        tipo = "Móvil";
                    }
                    if (rbTrabajo.Checked == true)
                    {
                        tipo = "Trabajo";
                    }

                    string var = dbr.mtInsertarDatos(int.Parse(etCedula.Text.ToString()), etNombres.Text.ToString(),
                        etApellidos.Text.ToString(), tipo, etTelefono.Text.ToString(), etCorreo.Text.ToString());
                    etCorreo.Text = string.Empty; etNombres.Text = string.Empty; etApellidos.Text = string.Empty; etCedula.Text = string.Empty;
                    etTelefono.Text = string.Empty;

                    Toast.MakeText(this, "Contacto guardado", ToastLength.Short).Show();
                }
                else
                {
                    Toast.MakeText(this,"Ingrese minimo:" +
                        "\nCedula" +
                        "\nNombres" +
                        "\nTelefono", ToastLength.Short).Show();
                }
            }catch(Exception ex)
            {
                Toast.MakeText(this, "Ingrese los datos correctamente",ToastLength.Short).Show();
            }
        }
    }
}