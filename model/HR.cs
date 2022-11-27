public class HR : Person {
    public string? company { get; set; }
    public List<Offer> offers { get; set; } = new List<Offer>();
    public string[] desiredSkills { get; set; } = new string[] {};
    public int threshold { get; set; } = 2; // points or more to hire

    public HR(
        string HRFirstName,
        string HRLastName,
        int HRAge,
        int HRYearsOfXP) : base (HRFirstName,
                                HRLastName,
                                HRAge,
                                HRYearsOfXP) {}

    // evaluate an employee (hire or not hire)
    public bool evaluate(Employee employee) {
        int points = 0;

        points += _evaluateSkills(employee) + _evaluateProjects(employee);

        numInteractions++;
        employee.numInteractions++;

        return points >= this.threshold;
    }

    public bool evaluate(HR employee) {
        int points = 0;

        // evaluate hrs based on number of offers and number of projects
        points += offers.Count + projects.Count;

        this.increment();
        employee.numInteractions++;

        return points >= this.threshold;
    }

    // evaluate emplyee skills, return nr of points
    private int _evaluateSkills(Employee employee) {
        int points = 0;

        foreach (Skill skill in employee.skills) {
            if (desiredSkills.Contains(skill.name))
                points += skill.rarity + Skill.evaluateHardness(skill.isHardSkill);

            skill.numInteractions++;
            this.increment();
        }

        return points;
    }

    private int _evaluateProjects(Employee employee) {
        int points = 0;

        foreach(Project project in projects) {
            // evaluate programming language
            foreach(ProgrammingLanguage language in employee.programmingLanguages)
                if (language.name.Equals(project.language)) {
                    points++;

                    this.increment();
                    language.numInteractions++;

                    break;
                }
            
            // evaluate domain
            string[] emplyeeDomains = Project.collectDomains(employee.projects);
            string[] hrDomains = Project.collectDomains(projects);

            points += hrDomains.Count(emplyeeDomains.Contains);
        }

        return points;
    }

    public void createOffer(string title, int salary) {        
        offers.Add(new Offer(title, salary, "/" + title));
    }

    public void postOffer(string offerName, JobSite site) {
        // find offer first
        Offer? offer = null;

        foreach(Offer o in offers)
            if (o.title == offerName) {
                offer = o;

                break;
            }
        
        if (offer == null)
            return;

        offer.url = site.url + offer.url;
        site.addOffers(new List<Offer> {offer});
    }
}



public interface HRBuilder {
    void buildPersonalData(string firstName, string lastName);
    void buildHRData(string company);
    HR getResult();
}

public class CommonHRBuilder: HRBuilder {
    private HR _hr;
    Random rnd = new Random();

    public void buildPersonalData(string firstName, string lastName) {
        int HRAge = rnd.Next(18, 65);
        int HRYearsOfXP = rnd.Next(0, 47);

        _hr = new HR(firstName, lastName, HRAge, HRYearsOfXP);
    }

    public void buildHRData(string company) {
        string[] skillNames = new string[] {"teamwork", "punctual", "fast learner"};

        _hr.company = company;
        // _hr.desiredSkills.Append(skillNames[rnd.Next(0, skillNames.Length - 1)]);
        _hr.desiredSkills = new string[] {skillNames[rnd.Next(0, skillNames.Length - 1)]};
    }
    public HR getResult() {
        return _hr;
    }
}

public class HRDirector {
    public void populateListOfHRs(HRBuilder builder, List<HR> hrs, int n = 5) {
        for (int i = 0; i < n; i++) {
            builder.buildPersonalData("HR", (hrs.Count + 1).ToString());
            builder.buildHRData("Company" + (hrs.Count + 1).ToString());

            hrs.Add(builder.getResult());
        }
    }
}