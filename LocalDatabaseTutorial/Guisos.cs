using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace LocalDatabaseTutorial
{
  public class Guisos
  {
    [PrimaryKey, AutoIncrement]
    public int idGuiso { get; set; }
    public String Guiso { get; set; }
    public Double Precio { get; set; }
    public int Activo { get; set; }
    public String Tipo { get; set; }
  }
}
