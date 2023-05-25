using System;
using System.Collections.Generic;

namespace ADO.NET_PW_4.Models;

public sealed class Promotion {
    public int PromotionId { get; set; }

    public string? PromotionName { get; set; }

    public int? CountryId { get; set; }

    public DateTime? StartDate { get; set; }

    public DateTime? EndDate { get; set; }

    public Country? Country { get; set; }

    public override string ToString() {
        return $"{PromotionId} {PromotionName} {CountryId} {StartDate} {EndDate} {Country?.CountryName}";
    }
}