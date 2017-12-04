using Android.App;
using Android.Widget;
using Android.OS;
using System;

namespace Principal
{
    [Activity(Label = "Principal", MainLauncher = true)]
    public class MainActivity : Activity
    {
        ImageButton btnCalendario, btnContactos, btnConversorMoneda, btnConversorUnidades, btnPaint, btnTraductor, btnCalculadora;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            //Variable para el manejo de los botones y evento clic
            //---------------------------------------------------------

            //btn para calculadora
            btnCalculadora = FindViewById<ImageButton>(Resource.Id.btnCalculadora);
            btnCalculadora.Click += BtnCalculadora_Click;

            //btn para calendario
            btnCalendario = FindViewById<ImageButton>(Resource.Id.btnCalendario);
            btnCalendario.Click += BtnCalendario_Click;

            //btn para contactos
            btnContactos = FindViewById<ImageButton>(Resource.Id.btnContactos);
            btnContactos.Click += BtnContactos_Click;

            //btn para conversor de moneda
            btnConversorMoneda = FindViewById<ImageButton>(Resource.Id.btnConversorMoneda);
            btnConversorMoneda.Click += BtnConversorMoneda_Click;

            //btn para conversor de unidades
            btnConversorUnidades = FindViewById<ImageButton>(Resource.Id.btnConversorUnidades);
            btnConversorUnidades.Click += BtnConversorUnidades_Click;

            //btn para paint
            btnPaint = FindViewById<ImageButton>(Resource.Id.btnPaint);
            btnPaint.Click += BtnPaint_Click;

            //btn traductor
            btnTraductor = FindViewById<ImageButton>(Resource.Id.btnTraductor);
            btnTraductor.Click += BtnTraductor_Click;

        }

        private void BtnTraductor_Click(object sender, EventArgs e)
        {
            StartActivity(typeof(ActivityTraductor));
        }

        private void BtnPaint_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void BtnConversorUnidades_Click(object sender, EventArgs e)
        {
            StartActivity(typeof(ActivityConversorUnidad));
        }

        private void BtnConversorMoneda_Click(object sender, EventArgs e)
        {
            StartActivity(typeof(ActivityConversorMoneda));
        }

        private void BtnContactos_Click(object sender, EventArgs e)
        {
            StartActivity(typeof(ActivityContactos));
        }

        private void BtnCalendario_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void BtnCalculadora_Click(object sender, EventArgs e)
        {
            StartActivity(typeof(ActivityCalculadora));
        }
    }
}

