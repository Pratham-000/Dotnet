using System;
using System.Collections.Generic;

namespace DAL.Models;

public partial class CustomerAddress
{
    public int CustomerId { get; set; }

    public int AddressId { get; set; }

    public string AddressType { get; set; } = null!;

    public DateTime ModifiedDate { get; set; }

    public virtual Address Address { get; set; } = null!;

    public virtual Customer Customer { get; set; } = null!;
}
