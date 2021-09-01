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
using static Android.App.Usage.UsageEvents;

namespace LocalDatabaseTutorial.Droid
{
  [Activity(Label = "MenuPPal", Theme = "@style/MainTheme", MainLauncher = false)]
  public class MenuPPal : Activity
  {
    protected override void OnCreate(Bundle savedInstanceState)
    {
      SetContentView(Resource.Layout.layout_menuppal);
      base.OnCreate(savedInstanceState);

      // Create your application here
      ImageButton buttonAddGuiso = FindViewById<ImageButton>(Resource.Id.addGuiso);
      buttonAddGuiso.Click += delegate {
        Context context = Application.Context;
        string text = "Agregar Guisos! :)";
        ToastLength duration = ToastLength.Short;
        Android.Widget.Toast.MakeText(Android.App.Application.Context, text, ToastLength.Long).Show();
        var toast = Toast.MakeText(context, text, duration);
        toast.Show();
        StartActivity(new Intent(Application.Context, typeof(MainActivity)));
      };

      ImageButton buttonAddComanda = FindViewById<ImageButton>(Resource.Id.comanda);
      buttonAddComanda.Click += delegate {
        Context context = Application.Context;
        string text = "Empezar Comanda! :)";
        ToastLength duration = ToastLength.Short;
        Android.Widget.Toast.MakeText(Android.App.Application.Context, text, ToastLength.Long).Show();
        var toast = Toast.MakeText(context, text, duration);
        toast.Show();
        StartActivity(new Intent(Application.Context, typeof(Comandas)));
      };
    }
  }
}