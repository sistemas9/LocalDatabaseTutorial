using Android.Content;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace LocalDatabaseTutorial
{
  [XamlCompilation(XamlCompilationOptions.Compile)]
  public partial class ComandasPage : ContentPage
  {
    public ComandasPage()
    {
      InitializeComponent();
      //stack1.IsVisible = false;
    }
    protected override async void OnAppearing()
    {
      base.OnAppearing();
      //Boolean truncated = await App.DatabaseCarrito.TruncateCarrito();
      List<Totales> TotalCarroList = new List<Totales>();
      Totales TotalCarro = new Totales();
      List<Guisos> listaGuisos = await App.Database.GetPeopleAsync();
      ListaGuisos.ItemsSource = listaGuisos.Where(guiso => guiso.Tipo == "Gorditas").ToList();
      Carrito.ItemsSource = await App.DatabaseCarrito.GetCarritoAsync("CAR01");
      TotalCarro.Total = await App.DatabaseCarrito.GetTotalComanda("CAR01");
      TotalCarroList.Add(TotalCarro);
      Totales.ItemsSource = TotalCarroList;
      TipoGuiso.ItemsSource = ListaTipos.TipoGuisos.ToList();
    }

    public async void HideListaTipos(object sender, EventArgs e)
    {
      stackListaGuisos.IsVisible = false;
      btnListaGuisos.Source = "@drawable/chevron_right";
      if (stackListaTipos.IsVisible)
      {
        stackListaTipos.IsVisible = false;
        (sender as Xamarin.Forms.ImageButton).Source = "@drawable/chevron_right";
      }
      else
      {
        stackListaTipos.IsVisible = true;
        (sender as Xamarin.Forms.ImageButton).Source = "@drawable/chevron_left";
      }
    }

    public async void HideListaGuisos(object sender, EventArgs e)
    {
      if (stackListaTipos.IsVisible)
      {
        if (stackListaGuisos.IsVisible)
        {
          stackListaGuisos.IsVisible = false;
          (sender as Xamarin.Forms.ImageButton).Source = "@drawable/chevron_right";
        }
        else
        {
          stackListaGuisos.IsVisible = true;
          (sender as Xamarin.Forms.ImageButton).Source = "@drawable/chevron_left";
        }
      }
    }

    public async void OnSelectionListaGuisos(object sender, EventArgs e)
    {
      if (ListaGuisos.SelectedItem != null)
      {
        try
        {
          Guisos g = (Guisos)ListaGuisos.SelectedItem;
          await App.DatabaseCarrito.SaveCarritoAsync(new Carrito
          {
            Guiso = g.Guiso,
            Precio = g.Precio,
            ClaveCarrito = "CAR01",
            Cantidad = Convert.ToDouble(Cantidad.Text),
            FechaCreacion = DateTime.Now
          });

          Carrito.ItemsSource = await App.DatabaseCarrito.GetCarritoAsync("CAR01");
          List<Totales> TotalCarroList = new List<Totales>();
          Totales TotalCarro = new Totales();
          TotalCarro.Total = await App.DatabaseCarrito.GetTotalComanda("CAR01");
          TotalCarroList.Add(TotalCarro);
          Totales.ItemsSource = TotalCarroList;
          Android.Widget.Toast.MakeText(Android.App.Application.Context, "Guiso: " + g.Guiso + " seleccionado.", ToastLength.Short).Show();
          ListaGuisos.SelectedItem = false;
        }catch(Exception ex)
        {
          Console.WriteLine(ex.Message);
        }
      }
    }

    public async void DeleteCarritoLinea(object sender, EventArgs e)
    {
      if (Carrito.SelectedItem != null)
      {
        Carrito carroLine = (Carrito)Carrito.SelectedItem;
        await App.DatabaseCarrito.DeleteCarritoAsync(carroLine);
        Carrito.ItemsSource = await App.DatabaseCarrito.GetCarritoAsync("CAR01");
        List<Totales> TotalCarroList = new List<Totales>();
        Totales TotalCarro = new Totales();
        TotalCarro.Total = await App.DatabaseCarrito.GetTotalComanda("CAR01");
        TotalCarroList.Add(TotalCarro);
        Totales.ItemsSource = TotalCarroList;
      }
      else
      {
        Android.Widget.Toast.MakeText(Android.App.Application.Context, "Debe seleccionar al menos un Guiso", ToastLength.Long).Show();
      }
    }

    public async void LoadGuisos(object sender, EventArgs e)
    {
      var TipoGuiso = (sender as Picker).SelectedItem;
      List<Guisos> listaGuisos = await App.Database.GetPeopleAsync();
      ListaGuisos.ItemsSource = listaGuisos.Where(guiso => guiso.Tipo == TipoGuiso.ToString()).ToList();
    }
  }

  public class Totales
  {
    public Double Total { get; set; }
  }
}