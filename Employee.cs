public class Employee {
    public string firstName { get; init; }
    public string lastName { get; init; }
    public int age { get; init; }
    public int yearsOfXP { get; init; }
    public int desiredSalary { get; set; }
    public Skill[] skills { get; set; }
    public ProgrammingLanguage[] programmingLanguages { get; set; }
    public Project[] pastProjects { get; set; }
    public Course[] courses;

    public Employee(string employeeFirstName,
                    string employeeLastName,
                    int employeeAge,
                    int employeeYearsOfXP,
                    int employeeDesiredSalary,
                    string[] skillNames = null,
                    int[] skillRarities = null,
                    bool[] skillIsHard = null,
                    string[] plNames = null,
                    string[][] plDomains = null,
                    string[] projectNames = null,
                    string[] projectLanguages = null,
                    string[] projectDomains = null,
                    string[] courseNames = null,
                    string[][] courseDomains = null) {

        firstName = employeeFirstName;
        lastName = employeeLastName;
        age = employeeAge;
        yearsOfXP = employeeYearsOfXP;
        desiredSalary = employeeDesiredSalary;

        if (skillNames != null && skillNames.Length > 0 &&
           skillRarities != null && skillRarities.Length > 0 &&
           skillIsHard != null && skillIsHard.Length > 0)

            skills = Skill.createListOfSkills(skillNames, skillRarities, skillIsHard);

        if (plNames != null && plNames.Length > 0 &&
            plDomains != null && plDomains.Length > 0)

            programmingLanguages = ProgrammingLanguage.createListOfLanguages(plNames, plDomains);

        if (projectNames != null && projectNames.Length > 0 &&
            projectLanguages != null && projectLanguages.Length > 0 &&
            projectDomains != null && projectDomains.Length > 0)

                pastProjects = Project.createListOfProjects(projectNames, projectLanguages, projectDomains);
        
        if (courseNames != null && courseNames.Length > 0 &&
            courseDomains != null && courseDomains.Length > 0 &&)

                courses = Course.createListOfCourses(courseNames, courseDomains);
    }

    private bool _checkAge() {
        return this.age + 18 > this.yearsOfXP;
    }
}