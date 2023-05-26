using ADO.NET_PW_4.Context;
using ADO.NET_PW_4.Models;

var dataContext = new StoreDBContext();

PrintIEnumerable(dataContext.Customers);

PrintIEnumerable(dataContext.Customers.Select(c => c.Email)!);

PrintIEnumerable(dataContext.Interests.Select(i => i.InterestName)!);

PrintIEnumerable(dataContext.PromotionItems.Select(p => p.Interest!.InterestName).Distinct()!);

PrintIEnumerable(dataContext.Cities.Where(c=> c.Customers.Count > 0).Select(c => c.CityName)!);

PrintIEnumerable(dataContext.Cities.Where(c=> c.Customers.Count > 0).Select(c => c.Country!.CountryName).Distinct()!);

PrintIEnumerableIEnumerable(dataContext.Cities.Where(c => c.CityName == "Berlin").Select(c => c.Customers));

PrintIEnumerableIEnumerable(dataContext.Cities.Where(c=> c.Country!.CountryName == "Germany").Select(c => c.Customers));

PrintIEnumerableIEnumerable(dataContext.Cities.Where(c=> c.Country!.CountryName == "Germany").Select(c => c.Country!.Promotions));


var customer = new Customer {
    CityId = 1, DateOfBirth = DateTime.Now, FullName = "name of new customer", Email = "email@gmail.com",
    Gender = "non binary"
};

dataContext.Customers.Add(customer);

dataContext.SaveChanges();

PrintIEnumerable(dataContext.Customers);

customer.FullName = "Customer";

dataContext.SaveChanges();

PrintIEnumerable(dataContext.Customers);

dataContext.Remove(customer);

dataContext.SaveChanges();

PrintIEnumerable(dataContext.Customers);

static void PrintIEnumerable(IEnumerable<object> collection) {
    foreach (var el in collection) {
        Console.WriteLine(el.ToString());
    }

    Console.WriteLine(new string('-', 20));
}

static void PrintIEnumerableIEnumerable(IEnumerable<IEnumerable<object>> collection) {
    foreach (var obj in collection) {
        foreach (var el in obj) {
            Console.WriteLine(el.ToString());
        }
    }

    Console.WriteLine(new string('-', 20));
}