using SQLite;

namespace SqlLiteDemo.Service
{
  public interface IServiceSqLite
  {
    SQLiteConnection GetConnection();
  }
}