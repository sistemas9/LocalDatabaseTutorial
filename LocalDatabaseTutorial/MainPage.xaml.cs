using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Internals;
using Xamarin.Forms.Xaml;

namespace LocalDatabaseTutorial
{
  public partial class MainPage : ContentPage
  {
    public static String PrecioTemp;
    public MainPage()
    {
      InitializeComponent();
    }

    protected override async void OnAppearing()
    {
      base.OnAppearing();
      collectionView.ItemsSource = await App.Database.GetPeopleAsync();
      TipoGuiso.ItemsSource = ListaTipos.TipoGuisos.ToList();
    }

    async void OnButtonClicked(object sender, EventArgs e)
    {
      if (!string.IsNullOrWhiteSpace(GuisoEntry.Text) && !string.IsNullOrWhiteSpace(PrecioEntry.Text))
      {
        await App.Database.SavePersonAsync(new Guisos
        {
          Guiso = GuisoEntry.Text,
          Precio = double.Parse(PrecioEntry.Text),
          Tipo = TipoGuiso.SelectedItem.ToString()
        });
        
        GuisoEntry.Text = PrecioEntry.Text = string.Empty;
        collectionView.ItemsSource = await App.Database.GetPeopleAsync();
      }
    }
    async void UpdateGuiso(object sender, EventArgs e)
    {
      if (collectionView.SelectedItem != null)
      {
        Guisos g = (Guisos)collectionView.SelectedItem;
        await App.Database.UpdateGuisoAsync(g);
        collectionView.ItemsSource = await App.Database.GetPeopleAsync();
      }
      else
      {
        Android.Widget.Toast.MakeText(Android.App.Application.Context, "Debe seleccionar al menos un Guiso", ToastLength.Long).Show();
      }
    }

    async void DeleteGuiso(object sender, EventArgs e)
    {
      if (collectionView.SelectedItem != null)
      {
        Guisos g = (Guisos)collectionView.SelectedItem;
        await App.Database.DeleteGuisoAsync(g);
        collectionView.ItemsSource = await App.Database.GetPeopleAsync();
      }
      else
      {
        Android.Widget.Toast.MakeText(Android.App.Application.Context, "Debe seleccionar al menos un Guiso", ToastLength.Long).Show();
      }
    }
  }
}
