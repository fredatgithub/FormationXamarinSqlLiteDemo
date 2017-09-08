using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using SQLite;
using System.IO;
using Xamarin.Forms;


[assembly: Dependency(typeof(SqlLiteDemo.Droid.MainActivity))]
namespace SqlLiteDemo.Droid
{
  [Activity(Label = "SqlLiteDemo", Icon = "@drawable/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
  public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
  {
    protected override void OnCreate(Bundle bundle)
    {
      TabLayoutResource = Resource.Layout.Tabbar;
      ToolbarResource = Resource.Layout.Toolbar;

      base.OnCreate(bundle);

      global::Xamarin.Forms.Forms.Init(this, bundle);
      LoadApplication(new App());
    }

    public SQLiteConnection GetConnection()
    {
      var sqliteFilename = "StageXTraining.db";
      string documentPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
      var path = Path.Combine(documentPath, sqliteFilename);
      var conn = new SQLite.SQLiteConnection(path);
      return conn;
    }
  }
}