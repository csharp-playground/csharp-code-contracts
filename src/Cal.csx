using System.Diagnostics.Contracts;

class Calculators {
    public int Division(int i, int j) {
        Contract.Requires( i > j, "i should be greater then j");
        return i / j;
    }
}

class Validation {
    public string GetCustomerPassword(string customerId) {
        Contract.Requires(!string.IsNullOrEmpty(customerId), "Customer ID cannot be null");
        Contract.Requires<ArgumentNullException>(!string.IsNullOrEmpty(customerId));
        Contract.Ensures(Contract.Result<string>() != null);

        var password = "AAA@1234";
        if (customerId != null) return password;
        else return null;
    }
}

var cal = new Calculators();
cal.Division(1,2);