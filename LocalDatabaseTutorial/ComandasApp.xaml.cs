using System;
using System.IO;
using Xamarin.Forms;

namespace LocalDatabaseTutorial
{
  public partial class ComandasApp : Application
  {
    public ComandasApp()
    {
      InitializeComponent();
      MainPage = new ComandasPage();
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