using System;
using SQLite;

namespace SqlLiteDemo.Model
{
  public class Stage
  {
    [PrimaryKey, AutoIncrement]
    public int Id { get; set; }
    public string Name { get; set; }
    public DateTime InsertDate { get; set; }
    public string ImgPath { get; set; } 
  }
}