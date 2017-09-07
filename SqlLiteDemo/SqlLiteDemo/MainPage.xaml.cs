using System;
using SqlLiteDemo.Model;
using SqlLiteDemo.Service;
using Xamarin.Forms;
using System.Linq;

namespace SqlLiteDemo
{
  public partial class MainPage : ContentPage
  {
    public MainPage()
    {
      InitializeComponent();
    }

    private static SQLite.SQLiteConnection database;
    static object locker = new object();
    private static int i = 1;

    private void BtnOpen_OnClicked(object sender, EventArgs e)
    {
      try
      {
        database = DependencyService.Get<IServiceSqLite>().GetConnection();
        database.CreateTable<Stage>();
      }
      catch
      {
        // ignored
      }
    }

    private void BtnAddCourse_OnClicked(object sender, EventArgs e)
    {
      if (database != null)
      {
        var stage = new Stage();
        stage.Name = $"jQuery version {i}";
        stage.ImgPath = $"ery_{i}.jpg";
        stage.InsertDate = DateTime.Now.ToLocalTime();
        lock (locker)
        {
          try
          {
            var id = database.Insert(stage);
            var query = from s in database.Table<Stage>()
                        where s.Id == stage.Id
                        select s;
            listStages.ItemsSource = query.ToList();
            i++;
            DisplayAlert("création", "votre db a été créée", "ok");
          }
          catch
          {
            //ignored
          }
        }
      }

    }
  }
}