using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace eWorkShopAPI.Models
{
  public class TicketInvoiceModel
  {
    public int TicketInvoiceID { get; set; }
    public string Item { get; set; }
    public int Unit_Cost { get; set; }
  }
}