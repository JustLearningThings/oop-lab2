// LAB 5
// state variables
int hrNum = 5;
int employeeNum = 15;
int offerPerHR = 3;
int sitesNum = 2;

int successes = 0, fails = 0;

// default values
string HRFirstName = "HR";
int HRLastName = 1;

string employeeFirstName = "Employee";
int employeeLastName = 1;
int ageID = 1;

int companyID = 0;
int projectID = 0;
int skillID = 0;
int courseID = 0;
int languageID = 0;
int contestID = 0;

string[] languages = new string[] {"c#", "javascript", "python", "java", "kotlin", "ruby"};
string[][] languagesDomains = new string[][] {
    new string[] {"web", "game dev", "windows"},
    new string[] {"web"},
    new string[] {"ml", "web"},
    new string[] {"windows", "mobile"},
    new string[] {"mobile"},
    new string[] {"web"}
};
string[] domains = new string[] {"web", "ml", "data", "mobile"};
string[] skillNames = new string[] {"teamwork", "punctual", "fast learned"};
string[] courseNames = new string[] {"data analysis course", "web dev course", "mobile dev course"};
string[] courseDomains = new string[] {"data", "web", "mobile"};
string[] contestNames = new string[] {"ai contest", "web dev contest", "mobile dev contest"};
string[] contestDomains = new string[] {"ml", "web", "mobile"};

string[] allDomains = new string[] {"web", "ml", "mobile", "game dev"};

int offerID = 1;
int siteTitleID = 1;

// init state functions
Random rnd = new Random();

List<HR> createHRs(int n, bool notify = true) {
    List<HR> hrList = new List<HR> {};

    for (int i = 0; i < n; i++) {
        hrList.Add(new HR(
            HRFirstName,
            HRLastName.ToString(),
            20,
            2,
            "Company " + companyID.ToString(),
            new string[] {"Project " + projectID.ToString()},
            new string[] {languages[projectID % (languages.Length - 1)]},
            new string[] {domains[projectID % (domains.Length - 1)]},
            skillNames
        ));

        HRLastName++;
        companyID++;
        projectID++;
    }

    if (notify)
        Console.WriteLine("Created " + n + " HRs");

    return hrList;
}

List<Employee> createEmployees(int n,
                                List<Skill> skills,
                                List<ProgrammingLanguage> languages,
                                List<Course> courses,
                                List<Contest> contests,
                                bool notify = true) {
    List<Employee> employeeList = new List<Employee> {};

    for (int i = 0; i < n; i++) {
        int skillIdx = skillID % (skills.Count - 1);
        int plIdx = languageID % (languages.Count - 1);
        int courseIdx = courseID % (courses.Count - 1);
        int contestIdx = contestID % (contests.Count - 1);

        employeeList.Add(new Employee(
            employeeFirstName,
            employeeLastName.ToString(),
            20,
            20 + (ageID % 20),
            rnd.Next(5000, 30000),
            new string[] {skills[skillIdx].name},
            new int[] {skills[skillIdx].rarity},
            new bool[] {skills[skillIdx].isHardSkill},
            new string[] {skills[skillIdx].domain},
            new string[] {languages[plIdx].name},
            new string[][] {new string[] {languages[plIdx].domain}},
            new string[] {"Project " + projectID.ToString()},
            new string[] {languages[plIdx].name},
            new string[] {languages[plIdx].domain},
            new string[] {courses[courseIdx].name},
            new string[] {courses[courseIdx].domain},
            new string[] {contests[contestIdx].name},
            new DateTime[] {contests[contestIdx].receivedAt},
            new string[] {contests[contestIdx].domain}
        ));

        ageID++;
        employeeLastName++;
        skillID++;
        languageID++;
        courseID++;
        contestID++;
    }

    if (notify)
        Console.WriteLine("Created " + n + " Employees");

    return employeeList;
}

// post state functions

List<JobSite> createSites(int n, bool notify = true) {
    List<JobSite> siteList = new List<JobSite> {};

    for (int i = 0; i < n; i++) {
        siteList.Add(new JobSite(
            "JobSite " + siteTitleID,
            new List<Offer> {},
            "site" + siteTitleID + ".com"
        ));

        siteTitleID++;
    }

    if (notify)
        Console.WriteLine("Created " + n + " JobSites");

    return siteList;
}

// let HRs create their offers
void createOffers(List<HR> HRs, bool notify = true) {
    int n = 0;

    foreach(HR hr in HRs) {
        for (int i = 0; i < offerPerHR; i++) {
            hr.createOffer("Offer " + offerID.ToString(), rnd.Next(5000, 30000));

            offerID++;
            n++;
        }
    }

    if (notify)
        Console.WriteLine("Created " + n + " offers.");
}

void postOffers(List<HR> HRs, List<JobSite> sites, bool notify = true) {
    int n = 0;

    foreach(HR hr in HRs) {
        foreach (JobSite site in sites) {
            foreach(Offer o in hr.offers) {
                // 80% chance to post
                if (rnd.Next(1, 10) >= 2) {
                    hr.postOffer(o.title, site);

                    n++;
                }
            }
        }
    }

    if (notify)
        Console.WriteLine("Posted " + n + " offers.");
}

// job search state functions

Offer chooseOffer(JobSite site) {
    return site.offers[rnd.Next(0, site.offers.Count - 1)];
}

bool applyToJob(Employee employee, JobSite site, List<HR> HRs) {
    bool isHired = false;
    Offer offer = chooseOffer(site);
    HR? offerHR = offer.findHR(HRs);

    if (offerHR == null)
        return isHired;
    
    isHired = offerHR.evaluate(employee);

    // if hired remove offer and add skills, programming languages and projects to employee
    if (isHired) {
        string languageName = languages[rnd.Next(0, languages.Length - 1)];
        string[] languageDomain = languagesDomains[rnd.Next(0, languagesDomains.Length - 1)];

        site.offers.Remove(offer);
        offerHR.offers.Remove(offer);

        employee.skills.Add(new Skill(
            skillNames[skillID % (skillNames.Length - 1)],
            new int[] {1, 2, 4}[rnd.Next(0, 3)],
            rnd.Next(0, 1) > 0 ? true : false,
            allDomains[rnd.Next(0, allDomains.Length - 1)]
            ));
        
        employee.programmingLanguages.Add(new ProgrammingLanguage(
            languageName,
            languageDomain
        ));

        employee.projects.Add(new Project(
            "Project " + projectID,
            languageName,
            languageDomain[0]
        ));

        projectID++;
    }

    return isHired;
}

// simulation functions
void runSimulationBaseStep(
    int i,
    List<HR> HRs,
    List<Skill> skills,
    List<Course> courses,
    List<Contest> contests,
    List<ProgrammingLanguage> programmingLanguages,
    List<Employee> employees,
    List<JobSite> sites) {
    
    // posting phase
    createOffers(HRs);
    postOffers(HRs, sites);

    // Job search phase
    foreach(Employee e in employees)
        if (applyToJob(e, sites[rnd.Next(0, sitesNum - 1)], HRs))
            successes++;
        else
            fails++;

    Console.Write("There were ");
    Console.ForegroundColor = ConsoleColor.DarkYellow;
    Console.Write("" + (successes + fails));
    Console.ForegroundColor = ConsoleColor.White;
    Console.Write(" jobs applications. Out of them ");
    Console.ForegroundColor = ConsoleColor.Green;
    Console.Write("" + successes);
    Console.ForegroundColor = ConsoleColor.White;
    Console.Write(" employees were hired and ");
    Console.ForegroundColor = ConsoleColor.Red;
    Console.Write("" + fails);
    Console.ForegroundColor = ConsoleColor.White;
    Console.WriteLine(" were not.");
}

void runSimulationStep(
    ref int i,
    List<HR> HRs,
    List<Skill> skills,
    List<Course> courses,
    List<Contest> contests,
    List<ProgrammingLanguage> programmingLanguages,
    List<Employee> employees,
    List<JobSite> sites) {

    Console.WriteLine("===========");
    Console.WriteLine("Iteration " + i);
    Console.WriteLine("===========");

    runSimulationBaseStep(i, HRs, skills, courses, contests, programmingLanguages, employees, sites);

    // intermediary phase (prepare for repetition)
    Console.WriteLine("\nAfter a while a new wave of job applications started. The hired employees earned new skills, but HRs also hightened their expectations.\n");

    foreach(HR h in HRs)
        h.threshold++;
    i++;
}

void simulate(int n = -1) {
    Console.WriteLine("====Simulation started====");
    Console.WriteLine("\tIteration 0");
    Console.WriteLine("==========================");

    // init phase

    List<HR> HRs = createHRs(hrNum);
    List<Skill> skills = Skill.createListOfSkills(
        skillNames,
        new int[] {1, 2, 4},
        new bool[] {false, false, true},
        new string[] {"soft skill", "soft skill", "soft skill"}
    );
    List<Course> courses = Course.createListOfCourses(courseNames, courseDomains);
    List<Contest> contests = Contest.createListOfContests(
        contestNames,
        new DateTime[] {DateTime.Now, DateTime.Now, DateTime.Now},
        contestDomains
    );
    List<ProgrammingLanguage> programmingLanguages = ProgrammingLanguage.createListOfLanguages(languages, languagesDomains);
    List<Employee> employees = createEmployees(
        employeeNum,
        skills,
        programmingLanguages,
        courses,
        contests
        );
    List<JobSite> sites = createSites(sitesNum);
    
    int i = 1;
    Console.WriteLine(n);
    if (n == -1)
        while(Console.ReadKey(true).Key != ConsoleKey.Q)
            runSimulationStep(ref i, HRs, skills, courses, contests, programmingLanguages, employees, sites);
    else
        while (i < n)
            runSimulationStep(ref i, HRs, skills, courses, contests, programmingLanguages, employees, sites);

    Console.WriteLine("\nSimulation ended.");
}

simulate(200);