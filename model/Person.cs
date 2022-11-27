public class Person : SimulationEntity {
    public string firstName { get; init; }
    public string lastName { get; init; }
    public int age { get; init; }
    public int yearsOfXP { get; init; }

    public List<Project> projects { get; set; } = new List<Project>();
    
    protected Person(string personFirstName,
                    string personLastName,
                    int personAge,
                    int personYearsOfXP) {
                        
        firstName = personFirstName;
        lastName = personLastName;
        age = personAge;
        yearsOfXP = personYearsOfXP;

        projects = new List<Project>();
    }

    private bool _checkAge() {
        return this.age + 18 > this.yearsOfXP;
    }

    public string getFullName() {
        return this.firstName + " " + this.lastName;
    }
}