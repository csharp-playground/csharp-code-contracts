## Code Contracts in `C#`

- http://www.dotnetcurry.com/csharp/1172/code-contracts-csharp-static-runtime-checks

## Example

```csharp
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
```

### Contract.Requires(condition, message)

ใช้เป็น `precondition` ก่อนที่จะ execute คำสั่งใน method เมื่อ condition มีค่าเป็น false จะแสดง message ออกมา

### Contract.Requires<T>(condition, message)

`T` เป็น class Exception จะ `condition` เป็น false โปรแกรมจะ throw T ออกมา แต่ถ้ามีการตั้งค่า Assert on contract โปรแกรมจะแสดง mesasge ออกมาแทน

### Contract.Result<T>()

ใชั `Contract.Result<T>` เพื่อดึงค่าที่จะ return ออกจาก method ใช้สำหรับเช็ค `postcondition` สามารถใช้ร่วมกับ `Contract.Ensures()`

### Contract.Ensures(condition)

ใช้เป็น `postcondition` เพื่อเช็คว่าค่าที่ return ออกไปตรงกับเงื่อนไขหรือไม่

### Contract.Invariants()

...

- https://github.com/Microsoft/CodeContracts/issues/140
- http://stackoverflow.com/questions/1209166/why-is-ccrewrite-exe-not-doing-anything-from-the-command-line