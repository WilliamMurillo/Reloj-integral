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
    [Activity(Label ="Gestión contactos")]
    public class ActivityGestionContactos : Activity
    {

        Button btnBuscar, btnGestionar;
        EditText etBuscar;
        TextView txtCedula, txtNombres, txtApellidos, txtTelefono, txtCorreo, txtTipo;
  

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.layoutGestionContactos);

            // Create your application here

            //Relación de componentes
            etBuscar = FindViewById<EditText>(Resource.Id.etBuscar);
            txtCedula = FindViewById<TextView>(Resource.Id.txtCedula);
            txtNombres = FindViewById<TextView>(Resource.Id.txtNombres);
            txtApellidos = FindViewById<TextView>(Resource.Id.txtApellidos);
            txtTelefono = FindViewById<TextView>(Resource.Id.txtTelefono);
            txtCorreo = FindViewById<TextView>(Resource.Id.txtCorreo);
            txtTipo = FindViewById<TextView>(Resource.Id.txtTipo);
            btnBuscar = FindViewById<Button>(Resource.Id.btnBuscar);

            // invisibilizar el panel para actualizar
           // linearSection.Visibility = ViewStates.Invisible;
            //evento clic para el botón guardar y actualizar
            btnBuscar.Click += BtnBuscar_Click;
            
        }

        private void BtnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                ClsAdminBDcs bdr = new ClsAdminBDcs();
                //string[] array = new string[] { };

                var item = bdr.mtMostrarDatosTel(int.Parse(etBuscar.Text.ToString()));
                if (item != null)
                {
                    txtCedula.Text = "Cédula: "+item.Id.ToString();
                    txtNombres.Text = "Nombres: "+item.nombres.ToString();
                    txtApellidos.Text = "Apellidos: "+item.apellidos.ToString();
                    txtTelefono.Text = "Telefono: "+item.telefono.ToString();
                    txtTipo.Text = "Tipo: "+ item.tipo.ToString();
                    txtCorreo.Text = "Correo: "+ item.correo.ToString();
                }
                else
                {
                    Toast.MakeText(this, "Ningun usuario con esta cédula",ToastLength.Short).Show();
                }
            }catch(Exception ec)
            {
                Toast.MakeText(this, "Ingrese parametros validos y no existentes", ToastLength.Short).Show();
            }
        }
    }
} 