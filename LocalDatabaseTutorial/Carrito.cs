using SQLite;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Xamarin.Forms;

namespace LocalDatabaseTutorial
{
  public class Carrito
  {
    [PrimaryKey, AutoIncrement]
    public int IdCarrito { get; set; }
    public String ClaveCarrito { get; set; }
    public String Tipo { get; set; }
    public String Guiso { get; set; }
    public Double Cantidad { get; set; }
    public Double Precio { get; set; }
    public Double Monto { get { return this.Cantidad * this.Precio; } set { } }
    public DateTime FechaCreacion { get; set; }
  }
}
