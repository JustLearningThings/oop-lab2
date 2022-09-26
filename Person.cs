public class Person {
    public string firstName { get; init; }
    public string lastName { get; init; }
    public int age { get; init; }
    public int yearsOfXP { get; init; }
    
    public Person(string personFirstName, string personLastName, int personAge, int personYearsOfXP) {
        firstName = personFirstName;
        lastName = personLastName;
        age = personAge;
        yearsOfXP = personYearsOfXP;
    }

    private bool _checkAge() {
        return this.age + 18 > this.yearsOfXP;
    }
}