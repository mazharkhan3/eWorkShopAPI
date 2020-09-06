using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace eWorkShopAPI.Models
{
  public class TicketModel
  {
    public long TicketID { get; set; }
    public string Description { get; set; }
    public string CustomerName { get; set; }
    public double? TotalCost { get; set; }
    public DateTime PickUpTime { get; set; }
    public List<TicketInvoiceModel> TicketInvoiceList { get; set; }
    public List<TemplateTypeModel> TemplateTypeList { get; set; }
  }
}