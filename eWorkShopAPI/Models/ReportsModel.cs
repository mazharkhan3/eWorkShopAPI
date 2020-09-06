using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace eWorkShopAPI.Models
{
  public class ReportsModel
  {
    public List<DataPoints> ProductsByMonth { get; set; }
    public List<DataPoints> OrdersByMonth { get; set; }
    public List<DataPoints> SalesByMonth { get; set; }
    public List<DataPoints> ProductsByDay { get; set; }
    public List<DataPoints> OrdersByDay { get; set; }
    public List<DataPoints> SalesByDay { get; set; }
  }
}