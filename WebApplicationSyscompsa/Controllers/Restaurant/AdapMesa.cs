using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplicationSyscompsa.Controllers.Restaurant
{
    public class AdapMesa
    {
      public int Id              { get; set; }
      public string TagNameMesa  { get; set; }
      public string CodecMesa    { get; set; }
      public string PosX         { get; set; }
      public string PosY         { get; set; }
      public string SizeX        { get; set; }
      public string SizeY        { get; set; }
      public int    NumberMesa   { get; set; }
      public string TexturaMesa  { get; set; }
      public string MeseroName   { get; set; }
      public string TiempoEspera { get; set; }
      public string BorderRadius { get; set; }
    }
}
