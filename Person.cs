public class Person {
    public string firstName { get; init; }
    public string lastName { get; init; }
    public int age { get; init; }
    public int yearsOfXP { get; init; }

    public List<Project> projects { get; set; }
    
    public Person(string personFirstName,
                    string personLastName,
                    int personAge,
                    int personYearsOfXP,
                    string[] projectNames,
                    string[] projectLanguages,
                    string[] projectDomains) {
                        
        firstName = personFirstName;
        lastName = personLastName;
        age = personAge;
        yearsOfXP = personYearsOfXP;

        projects = new List<Project>();

        if (projectNames != null && projectNames.Length > 0 &&
            projectLanguages != null && projectLanguages.Length > 0 &&
            projectDomains != null && projectDomains.Length > 0)

                projects = Project.createListOfProjects(projectNames, projectLanguages, projectDomains);
    }

    private bool _checkAge() {
        return this.age + 18 > this.yearsOfXP;
    }
}