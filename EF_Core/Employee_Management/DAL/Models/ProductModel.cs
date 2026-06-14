using System;
using System.Collections.Generic;

namespace DAL.Models;

public partial class ProductModel
{
    public int ProductModelId { get; set; }

    public string Name { get; set; } = null!;

    public DateTime ModifiedDate { get; set; }

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
