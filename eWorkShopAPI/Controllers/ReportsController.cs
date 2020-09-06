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
  public class ReportsController : ApiController
  {
    private readonly eWorkShop123Entities db = new eWorkShop123Entities();

    [HttpGet]
    public IHttpActionResult ReportsStats()
    {
      var productsByMonth = new List<DataPoints>();
      var ordersByMonth = new List<DataPoints>();
      var salesByMonth = new List<DataPoints>();
      var productsByDay = new List<DataPoints>();
      var ordersByDay = new List<DataPoints>();
      var salesByDay = new List<DataPoints>();

      var productsByMonthData = db.sp_TotalProductsByMonth().ToList();
      var ordersByMonthData = db.sp_TotalOrdersByMonth().ToList();
      var salesByMonthData = db.sp_TotalSalesByMonth().ToList();

      var productsByDayData = db.sp_TotalProductsByDay().ToList();
      var ordersByDayData = db.sp_TotalOrdersByDay().ToList();
      var salesByDayData = db.sp_TotalSalesByDay().ToList();

      foreach (var product in productsByMonthData)
      {
        productsByMonth.Add(new DataPoints { y = product.TotalProducts, label = product.Month });
      }

      foreach (var order in ordersByMonthData)
      {
        ordersByMonth.Add(new DataPoints { y = order.TotalOrders, label = order.Month });
      }

      foreach (var sale in salesByMonthData)
      {
        salesByMonth.Add(new DataPoints { y = (int)sale.TotalProfit, label = sale.Month });
      }

      foreach (var product in productsByDayData)
      {
        productsByDay.Add(new DataPoints { y = product.TotalProducts, label = product.Month });
      }

      foreach (var order in ordersByDayData)
      {
        ordersByDay.Add(new DataPoints { y = order.TotalOrders, label = order.Month });
      }

      foreach (var sale in salesByDayData)
      {
        salesByDay.Add(new DataPoints { y = (int)sale.TotalProfit, label = sale.Month });
      }

      var reportsStats = new ReportsModel()
      {
        ProductsByMonth = productsByMonth,
        OrdersByMonth = ordersByMonth,
        SalesByMonth = salesByMonth,
        SalesByDay = salesByDay,
        ProductsByDay = productsByDay,
        OrdersByDay = ordersByDay
      };

      return Ok(reportsStats);
    }
  }
}
