using eWorkShopAPI.Entity;
using eWorkShopAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace eWorkShopAPI.Controllers
{
  public class DashboardController : ApiController
  {
    private readonly eWorkShop123Entities db = new eWorkShop123Entities();

    [HttpGet]
    public DashboardModel DashboardStats()
    {
      var users = db.Users.ToList().Count();
      var products = db.Products.ToList().Count();
      var orders = db.Tickets.ToList().Count();

      var userStatsWeek = new List<DataPoints>();

      userStatsWeek.Add(
        new DataPoints { label = "Users", y = users }
        );

      userStatsWeek.Add(
        new DataPoints { label = "Orders", y = orders }
        );

      userStatsWeek.Add(
        new DataPoints { label = "Products", y = products }
        );

      var dashboardStats = new DashboardModel
      {
        Users = db.Users.Count(),
        Orders = db.Tickets.Count(),
        Products = db.Products.Count(),
        OverallStats = userStatsWeek
      };

      return dashboardStats;
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing)
      {
        db.Dispose();
      }
      base.Dispose(disposing);
    }
  }
}
