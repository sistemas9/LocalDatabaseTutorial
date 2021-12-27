using System;
using System.IO;
using Xamarin.Forms;

namespace LocalDatabaseTutorial
{
  public partial class App : Application
  {
    static Database database;
    static DatabaseCarrito databaseCarrito;

    public static Database Database
    {
      get
      {
        if (database == null)
        {
          database = new Database(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Guisos.db3"));
        }
        return database;
      }
    }

    public static DatabaseCarrito DatabaseCarrito
    {
      get
      {
        if (databaseCarrito == null)
        {
          databaseCarrito = new DatabaseCarrito(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Carrito.db3"));
        }
        return databaseCarrito;
      }
    }

    public App()
    {
      InitializeComponent();

      MainPage = new MainPage();
    }

    protected override void OnStart()
    {
      // Handle when your app starts
    }

    protected override void OnSleep()
    {
      // Handle when your app sleeps
    }

    protected override void OnResume()
    {
      // Handle when your app resumes
    }
  }
}