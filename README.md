# Simulating the hiring process in IT
I chose to simulate the hiring process. For this purpose I thought of 9 classes that are related to the hiring process and one class that will perform the simulation.

## Stage 1: the classes
Let's look closer at each of the classes.

### Person
We will have two types of people: the employee and the HR. For the purpose of writing a little bit less code I created a parent class for them that will store general information:

```cs
public class Person {
    public string firstName { get; init; }
    public string lastName { get; init; }
    public int age { get; init; }
    public int yearsOfXP { get; init; }
    
    public Person(string personFirstName, string personLastName, int personAge, int personYearsOfXP) { ... }

    private bool _checkAge() {
        return this.age + 18 > this.yearsOfXP;
    }
}
```

Now, let's explore the children.

### Employee

The employee is a versatile type of person. He or she has many skills, including techincal ones like knowing programming languages. An employee will also have worked on past projects (optionally), have completed courses (optionally), have participated in contests (optionally). All of these will be useful for him in the hiring process and will be discussed with the HR.

```cs
public class Employee : Person {
    public int desiredSalary { get; set; }
    public List<Skill> skills { get; set; }
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

        ...
    }
}
```

### HR
HR has a list of projects the company is interested in. Also he or she has a list of skills they want to see in employees. They have their own methods of evaluating potential employees. For that purpose they watch for a set of things in them and assigns a number of points to them. A threshold helps determine if the candidate is worth hiring.

```cs
class HR : Person {
    public string company { get; set; }
    public List<Project> projects { get; set; }
    public Offer[] offers { get; set; }
    public string[] desiredSkills { get; set; }
    private int threshold { get; set; }

    public HR(
        string HRFirstName,
        string HRLastName,
        int HRAge,
        int HRYearsOfXP,
        string HRcompany,
        List<Project> HRprojects,
        string[] HRDesiredSkills) : base (HRFirstName,
                                                 HRLastName,
                                                 HRAge,
                                                 HRYearsOfXP) {

        company = HRcompany;
        projects = HRprojects;
        
        offers = new Offer[] {};

        threshold = 5; // 5 points or more to hire

        if (HRDesiredSkills != null && HRDesiredSkills.Length > 0)
            desiredSkills = HRDesiredSkills;
        else
            desiredSkills = new string[] {};
    }

    // evaluate an employee (hire or not hire)
    public bool evaluate(Employee employee) {
        int points = 0;

        points += _evaluateSkills(employee) + _evaluateProjects(employee);

        return points >= this.threshold;
    }

    // evaluate emplyee skills, return nr of points
    private int _evaluateSkills(Employee employee) { ... }

    private int _evaluateProjects(Employee employee) { ... }
}
```

### Skill
Skill is one of the ways a candidate is judged by an HR.

``` cs
public class Skill {
    public string name { get; init; }
    public int rarity { get; init; }
    public bool isHardSkill { get; init; }

    public Skill(string skillName, int skillRarity, bool skillIsHardSkill) { ... }

    public static List<Skill> createListOfSkills(string[] names, int[] rarity, bool[] isHard) { ... }

    // used by HR
    public static int evaluateHardness(bool isHard) { ... }
}
```

### Course
Course is another way to judge candidates.

```cs
public class Course {
    string name;
    string domain;

    public Course(string courseName, string courseDomain) { ... }

    public static List<Course> createListOfCourses(string[] names, string[] courseDomain) { ... }

    public static string[] extractDomains(Course[] courses) { ... }
}
```

### Contest
Contest is also one of the judgement points for HRs in candidates.

```cs
public class Contest {
    string name { get; init; }
    DateTime receivedAt { get; init; }
    string domain;
    
    public Contest(string contestName, DateTime contestReceivedAt, string contesetDomain) { ... }

    public static List<Contest> createListOfContests(string[] names, DateTime[] recieveDates, string[] contestDomains) { ... }
}
```

### Project
Project is one of the most important ways to shine for an HR.

```cs
public class Project {
    public string name { get; init; }
    public string language { get; init; }
    public string domain { get; set; }

    Project(string Pname, string Planguage, string Pdomain) { ... }

    public static List<Project> createListOfProjects(string[] names, string[] languages, string[] domains) { ... }

    // get domains of multiple projects in order to make comparisons 
    public static string[] collectDomains(Project[] projects) { ... }
}
```

### ProgrammingLanguage
Programming languages are one of the first things HRs ask for.

```cs
public class ProgrammingLanguage {
    public string name { get; init; }
    public string[] domains { get; set; }

    public ProgrammingLanguage(string PLName, string[] PLdomains) { ... }

    public static List<ProgrammingLanguage> createListOfLanguages(string[] names, string[][] domains) { ... }

    // check if the name matches the hr's desired language
    // and that domains are the same
    public bool isPreffered(string name, string domain) { ... }
}
```

### Offer
It is the connection point between an HR and an employee. HR has a list of offers they seek candidates to respond to.

```cs
public class Offer {
    public string title { get; init; }
    public int salary { get; set; }
    public Project project { get; init; }

    public Offer(string offerTitle, int offerSalary, Project offerProject) { ... }

    public static bool checkEmployeeSalaryMatch(Offer offer, int desiredSalary) {
        return offer.salary >= desiredSalary;
    }
}
```

### JobSite
There are multiple sites where HRs can post offers. This is the use of this class.

```cs
public class JobSite {
    public string name;
    public Offer[] offers;

    public JobSite(string siteName, Offer[] initialOffers) { ... }

    public void addOffers(Offer[] newOffers) { ... }

    // select latest
    public Offer[] yieldOffers(int n) { ... }
}
```

---