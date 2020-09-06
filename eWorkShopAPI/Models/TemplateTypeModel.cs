using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace eWorkShopAPI.Models
{
  public class TemplateTypeModel
  {
    public int TemplateTypeID { get; set; }
    public string Front { get; set; }
    public string Rear { get; set; }
    public string Other { get; set; }
  }
}