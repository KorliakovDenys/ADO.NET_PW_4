using System;
using System.Collections.Generic;

namespace ADO.NET_PW_4.Models;

public sealed class CustomerInterest {
    public int? CustomerId { get; set; }

    public int? InterestId { get; set; }

    public Customer? Customer { get; set; }

    public Interest? Interest { get; set; }

    public override string ToString() {
        return $"{CustomerId} {InterestId} {Customer?.FullName} {Interest?.InterestName}";
    }
}