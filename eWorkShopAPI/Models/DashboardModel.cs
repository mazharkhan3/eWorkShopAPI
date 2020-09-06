using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace eWorkShopAPI.Models
{
  public class DashboardModel
  {
    public int Users { get; set; }
    public int Orders { get; set; }
    public int Products { get; set; }
    public List<DataPoints> OverallStats { get; set; }
  }
}