using System;
using System.Collections.Generic;

namespace DAL.Models;

public partial class SalesOrderHeader
{
    public int SalesOrderId { get; set; }

    public DateTime OrderDate { get; set; }

    public DateTime DueDate { get; set; }

    public DateTime? ShipDate { get; set; }

    public int CustomerId { get; set; }

    public decimal SubTotal { get; set; }

    public decimal TaxAmt { get; set; }

    public decimal Freight { get; set; }

    public decimal? TotalDue { get; set; }

    public DateTime ModifiedDate { get; set; }

    public virtual Customer Customer { get; set; } = null!;

    public virtual ICollection<SalesOrderDetail> SalesOrderDetails { get; set; } = new List<SalesOrderDetail>();
}
