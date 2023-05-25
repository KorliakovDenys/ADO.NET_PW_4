using System;
using System.Collections.Generic;

namespace ADO.NET_PW_4.Models;

public sealed class PromotionItem {
    public int? PromotionId { get; set; }

    public int? InterestId { get; set; }

    public Interest? Interest { get; set; }

    public Promotion? Promotion { get; set; }

    public override string ToString() {
        return $"{PromotionId} {InterestId} {Interest?.InterestName} {Promotion?.PromotionName}";
    }
}