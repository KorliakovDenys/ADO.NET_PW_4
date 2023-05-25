using System;
using System.Collections.Generic;

namespace ADO.NET_PW_4.Models;

public sealed class Customer {
    public int CustomerId { get; set; }

    public string? FullName { get; set; }

    public DateTime? DateOfBirth { get; set; }

    public string? Gender { get; set; }

    public string? Email { get; set; }

    public int? CityId { get; set; }

    public City? City { get; set; }

    public override string ToString() {
        return
            $"{CustomerId} {FullName} {DateOfBirth} {Gender} {Email} {CityId} {City?.CityName} {City?.Country?.CountryName}";
    }
}