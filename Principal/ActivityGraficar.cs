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
using OxyPlot.Xamarin.Android;
using OxyPlot;
using OxyPlot.Series;
using OxyPlot.Axes;

namespace Principal
{
    [Activity(Label = "Grafica")]
    public class ActivityGraficar : Activity
    {
        EditText etA, etB, etC;
        Button btnDibujar;
        int a = 0, b = 0, c = 0;
     
          PlotView view;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.layoutGrafica);
            // Create your application here

            view = FindViewById<PlotView>(Resource.Id.plot_view);
            

            etA = FindViewById<EditText>(Resource.Id.parA);
            etB = FindViewById<EditText>(Resource.Id.parB);
            etC = FindViewById<EditText>(Resource.Id.parC);

            btnDibujar = FindViewById<Button>(Resource.Id.btnGraficarParametro);
            btnDibujar.Click += BtnDibujar_Click;
        }

        private void BtnDibujar_Click(object sender, EventArgs e)
        {
            try
            {
                
                if (etA.Text != "" && etB.Text != "" && etC.Text != "")
                {
                    a = int.Parse(etA.Text);
                    b = int.Parse(etB.Text);
                    c = int.Parse(etC.Text);
                    view.Model = CreatePlotModel();
                }
                else
                {
                    etA.Text = string.Empty;
                    etB.Text = string.Empty;
                    etC.Text = string.Empty;
                    Toast.MakeText(this, "Ingrese parametros correctos", ToastLength.Short).Show();
                }
            }catch(Exception ex)
            {
                Toast.MakeText(this, "Ingrese parametros correctos", ToastLength.Short).Show();
            }
            
        }

        private PlotModel CreatePlotModel()
        {
            var plotModel = new PlotModel { Title = "Grafica" };

            plotModel.Axes.Add(new LinearAxis { Position = AxisPosition.Bottom, Maximum=25, Minimum =-25 });
            plotModel.Axes.Add(new LinearAxis { Position = AxisPosition.Left, Maximum = 25, Minimum = -25 });

            var series1 = new LineSeries
            {
                MarkerType = MarkerType.None,
                MarkerSize = 4,
                MarkerStroke = OxyColors.White
               
            };

            for (double x = -10.0; x < 10.0; x = x+ 0.5) {
                double y = a*double.Parse( Math.Pow(x, 2).ToString()) + b*x + c;

                series1.Points.Add(new DataPoint(x,y)); 
            }
            plotModel.Series.Add(series1); 

            return plotModel;
        }
    }
}