public class Employee : Person {
    public int desiredSalary { get; set; }
    public List<Skill> skills { get; set; }
    // public ProgrammingLanguage[] programmingLanguages { get; set; }
    public List<ProgrammingLanguage> programmingLanguages { get; set; }
    public List<Project> pastProjects { get; set; }
    public List<Course> courses { get; set; }
    public List<Contest> contests { get; set; }

    public Employee(string employeeFirstName,
                    string employeeLastName,
                    int employeeAge,
                    int employeeYearsOfXP,
                    int employeeDesiredSalary,
                    string[] skillNames,
                    int[] skillRarities,
                    bool[] skillIsHard,
                    string[] plNames,
                    string[][] plDomains,
                    string[] projectNames,
                    string[] projectLanguages,
                    string[] projectDomains,
                    string[] courseNames,
                    string[] courseDomains,
                    string[] contestNames,
                    DateTime[] contestDates,
                    string[] contestDomains) : base (employeeFirstName,
                                                            employeeLastName,
                                                            employeeAge,
                                                            employeeYearsOfXP) {

        desiredSalary = employeeDesiredSalary;

        skills = new List<Skill>();
        programmingLanguages = new List<ProgrammingLanguage>();
        pastProjects = new List<Project>();
        courses = new List<Course>();
        contests = new List<Contest>();

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
            courseDomains != null && courseDomains.Length > 0)

                courses = Course.createListOfCourses(courseNames, courseDomains);
        
        if (contestNames != null && contestNames.Length > 0 &&
            contestDates != null && contestDates.Length > 0 &&
            contestDomains != null && contestDomains.Length > 0)

                contests = Contest.createListOfContests(contestNames, contestDates, contestDomains);
    }
}