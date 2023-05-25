using System;
using System.Collections.Generic;

namespace ADO.NET_PW_4.Models;

public sealed class Country {
    public int CountryId { get; set; }

    public string? CountryName { get; set; }

    public ICollection<City> Cities { get; set; } = new List<City>();

    public ICollection<Promotion> Promotions { get; set; } = new List<Promotion>();

    public override string ToString() {
        var cities = Cities.Aggregate(string.Empty, (current, city) => current + (city.CityName + '\n'));
        var promotions = Promotions.Aggregate(string.Empty,
            (current, promotion) => current + (promotion.PromotionName + '\n'));

        return $"{CountryId} {CountryName} {cities} {promotions}";
    }
}