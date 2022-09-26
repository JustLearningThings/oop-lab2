public class Employee {
    public string firstName { get; init; }
    public string lastName { get; init; }
    public int age { get; init; }
    public int yearsOfXP { get; init; }
    public Skill[] skills { get; set; }
    public ProgrammingLanguage[] programmingLanguages { get; set; }
    public Project[] pastProjects { get; set; }

    public Employee(string employeeFirstName,
                    string employeeLastName,
                    int employeeAge,
                    int employeeYearsOfXP,
                    string[] skillNames = null,
                    int[] skillRarities = null,
                    bool[] skillIsHard = null,
                    string[] plNames = null,
                    string[][] plDomains = null,
                    string[] projectNames = null,
                    string[] projectLanguages = null,
                    string[] projectDomains = null) {

        firstName = employeeFirstName;
        lastName = employeeLastName;
        age = employeeAge;
        yearsOfXP = employeeYearsOfXP;

        if (skillNames != null && skillNames.Length > 0 &&
           skillRarities != null && skillRarities.Length > 0 &&
           skillIsHard != null && skillIsHard.Length > 0)

            skills = Skill.createListOfSkills(skillNames, skillRarities, skillIsHard);

        if (plNames != null && plNames.Length > 0 &&
            plDomains != null && plDomains.Length > 0)

            programmingLanguages = ProgrammingLanguage.createListOfLanguages(plNames, plDomains);

        if (projectNames != null && projectDomains.Length > 0 &&
            projectLanguages != null && projectLanguages.Length > 0 &&
            projectDomains != null && projectDomains.Length > 0)

                pastProjects = Project.createListOfProjects(projectNames, projectLanguages, projectDomains);
    }

    private bool _checkAge() {
        return this.age + 18 > this.yearsOfXP;
    }
}