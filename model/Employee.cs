public class Employee : Person {
    public int desiredSalary { get; set; }
    public List<Skill> skills { get; set; } = new List<Skill>();
    public List<ProgrammingLanguage> programmingLanguages { get; set; } = new List<ProgrammingLanguage>();
    public List<Course> courses { get; set; } = new List<Course>();
    public List<Contest> contests { get; set; } = new List<Contest>();
    public string? type { get; set; }

    public Employee (
        string employeeFirstName,
        string employeeLastName,
        int employeeAge,
        int employeeYearsOfXP
    ) : base (employeeFirstName, employeeLastName, employeeAge, employeeYearsOfXP) {}
}


public interface EmployeeBuilder {
    void buildPersonalData(string employeeFirstName, string employeeLastName);
    void buildSkillsData();
    void buildProgrammingLanguagesData();
    void buildProjectsData();
    void buildCoursesData();
    void buildContestsData();
    Employee getResult();
}

public class WebDeveloperBuilder: EmployeeBuilder {
    private Employee _employee;
    Random rnd = new Random();

    public void buildPersonalData(
        string employeeFirstName,
        string employeeLastName
    ) {
        int employeeAge = rnd.Next(18, 65);
        int employeeYearsOfXP = rnd.Next(0, 47);
        int employeeDesiredSalary = rnd.Next(500, 1_000_000);

        _employee = new Employee(employeeFirstName, employeeLastName, employeeAge, employeeYearsOfXP);
        _employee.desiredSalary = employeeDesiredSalary;
        _employee.type = "Web Dev";
    }

    public void buildSkillsData() {
        string[] skillNames = new string[] {"teamwork", "punctual", "fast learner"};
        string[] skillDomains = new string[] {"frontend", "backend", "full stack"};
        bool[] flag = new bool[] {true, false};

        _employee.skills.Add(new Skill(
            skillNames[rnd.Next(0, skillNames.Length - 1)],
            rnd.Next(1, 5),
            flag[rnd.Next(0, 1)],
            skillDomains[rnd.Next(0, skillDomains.Length - 1)]
        ));
    }

    public void buildProgrammingLanguagesData() {
        string[] languages = new string[] {"c#", "javascript", "python", "java", "kotlin", "ruby"};
        string[][] languagesDomains = new string[][] {
            new string[] {"web", "game dev", "windows"},
            new string[] {"web"},
            new string[] {"ml", "web"},
            new string[] {"windows", "mobile"},
            new string[] {"mobile"},
            new string[] {"web"}
        };
        int idx = rnd.Next(0, languages.Length - 1);

        _employee.programmingLanguages.Add(new ProgrammingLanguage(
            languages[idx],
            languagesDomains[idx]
        ));
    }

    public void buildProjectsData() {
        string language = _employee.programmingLanguages[0].name;
        string domain = _employee.programmingLanguages[0].domain;

        _employee.projects.Add(new Project(
            "Project" + rnd.Next(0, 100),
            language,
            domain
        ));
    }

    public void buildCoursesData() {
        string domain = _employee.programmingLanguages[0].domain;

        _employee.courses.Add(new Course(
            "Web Dev Course" + rnd.Next(0, 100),
            domain
        ));
    }

    public void buildContestsData() {
        _employee.contests.Add(new Contest(
            "Contest" + rnd.Next(0, 100),
            DateTime.Now,
            _employee.programmingLanguages[0].domain
        ));
    }

    public Employee getResult() {
        return _employee;
    }
}

public class MLEngineerBuilder: EmployeeBuilder {
    private Employee _employee;
    Random rnd = new Random();

    public void buildPersonalData(
        string employeeFirstName,
        string employeeLastName
    ) {
        int employeeAge = rnd.Next(18, 65);
        int employeeYearsOfXP = rnd.Next(0, 47);
        int employeeDesiredSalary = rnd.Next(500, 1_000_000);

        _employee = new Employee(employeeFirstName, employeeLastName, employeeAge, employeeYearsOfXP);
        _employee.desiredSalary = employeeDesiredSalary;
        _employee.type = "ML";
    }

    public void buildSkillsData() {
        string[] skillNames = new string[] {"teamwork", "punctual", "fast learner"};
        string[] skillDomains = new string[] {"math", "ml", "data", "analysis"};
        bool[] flag = new bool[] {true, false};

        _employee.skills.Add(new Skill(
            skillNames[rnd.Next(0, skillNames.Length - 1)],
            rnd.Next(1, 5),
            flag[rnd.Next(0, 1)],
            skillDomains[rnd.Next(0, skillDomains.Length - 1)]
        ));
    }

    public void buildProgrammingLanguagesData() {
        string[] languages = new string[] {"c#", "javascript", "python", "java", "kotlin", "ruby"};
        string[][] languagesDomains = new string[][] {
            new string[] {"web", "game dev", "windows"},
            new string[] {"web"},
            new string[] {"ml", "web"},
            new string[] {"windows", "mobile"},
            new string[] {"mobile"},
            new string[] {"web"}
        };
        int idx = rnd.Next(0, languages.Length - 1);

        _employee.programmingLanguages.Add(new ProgrammingLanguage(
            languages[idx],
            languagesDomains[idx]
        ));
    }

    public void buildProjectsData() {
        string language = _employee.programmingLanguages[0].name;
        string domain = _employee.programmingLanguages[0].domain;

        _employee.projects.Add(new Project(
            "Project" + rnd.Next(0, 100),
            language,
            domain
        ));
    }

    public void buildCoursesData() {
        string domain = _employee.programmingLanguages[0].domain;

        _employee.courses.Add(new Course(
            "ML Course" + rnd.Next(0, 100),
            domain
        ));
    }

    public void buildContestsData() {
        _employee.contests.Add(new Contest(
            "Contest" + rnd.Next(0, 100),
            DateTime.Now,
            _employee.programmingLanguages[0].domain
        ));
    }

    public Employee getResult() {
        return _employee;
    }
}

public class EmployeeDirector  {
    public void populateListOfEmployees(EmployeeBuilder builder, List<Employee> employees, int n = 5, string type = "Web Dev") {
        for (int i = 0; i < n; i++) {
            builder.buildPersonalData(type + " Employee", (employees.Count + 1).ToString());
            builder.buildSkillsData();
            builder.buildProgrammingLanguagesData();
            builder.buildProjectsData();
            builder.buildCoursesData();
            builder.buildContestsData();

            employees.Add(builder.getResult());
        }
    }
}