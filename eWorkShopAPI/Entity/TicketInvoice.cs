//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace eWorkShopAPI.Entity
{
    using System;
    using System.Collections.Generic;
    
    public partial class TicketInvoice
    {
        public long TicketInvoiceID { get; set; }
        public string Item { get; set; }
        public string Description { get; set; }
        public Nullable<double> Unit_Cost { get; set; }
        public Nullable<int> Quantity { get; set; }
        public Nullable<double> Discount { get; set; }
        public Nullable<long> TicketID { get; set; }
    
        public virtual Ticket Ticket { get; set; }
    }
}
