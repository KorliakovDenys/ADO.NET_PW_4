using System;
using System.Collections.Generic;

namespace ADO.NET_PW_4.Models;

public sealed class City {
    public int CityId { get; set; }

    public string? CityName { get; set; }

    public int? CountryId { get; set; }

    public Country? Country { get; set; }

    public ICollection<Customer> Customers { get; set; } = new List<Customer>();

    public override string ToString() {
        var customers = Customers.Aggregate(string.Empty, (current, customer) => current + ('\n' + customer.FullName));
        return $"{CityId} {CityName} {CountryId} {Country?.CountryName} {customers}";
    }
}