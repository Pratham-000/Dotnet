using System;
using System.Collections.Generic;

namespace DAL.Models;

public partial class Product
{
    public int ProductId { get; set; }

    public string Name { get; set; } = null!;

    public string ProductNumber { get; set; } = null!;

    public string? Color { get; set; }

    public decimal ListPrice { get; set; }

    public int? ProductCategoryId { get; set; }

    public int? ProductModelId { get; set; }

    public DateTime ModifiedDate { get; set; }

    public virtual ProductCategory? ProductCategory { get; set; }

    public virtual ProductModel? ProductModel { get; set; }

    public virtual ICollection<SalesOrderDetail> SalesOrderDetails { get; set; } = new List<SalesOrderDetail>();
}
