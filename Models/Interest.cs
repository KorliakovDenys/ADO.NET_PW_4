using System;
using System.Collections.Generic;

namespace ADO.NET_PW_4.Models;

public class Interest {
    public int InterestId { get; set; }

    public string? InterestName { get; set; }

    public override string ToString() {
        return $"{InterestId} {InterestName}";
    }
}