using System;
using System.Collections.Generic;
using System.Text;

namespace LocalDatabaseTutorial
{
  public class ListaTipos
  {
    public static IList<string> TipoGuisos
    {
      get
      {
        return new List<string> { "Gorditas", "Tortas", "Tamales" };
      }
    }
  }
}
