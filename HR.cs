class HR : Person {
    public string company { get; set; }
    public Project[] projects { get; set; }
    public Offer[] offers { get; set; }
    public string[] desiredSkills { get; set; }
    private int threshold { get; set; }

    public HR(
        string HRFirstName,
        string HRLastName,
        int HRAge,
        int HRYearsOfXP,
        string HRcompany,
        Project[] HRprojects,
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
    private int _evaluateSkills(Employee employee) {
        int points = 0;

        foreach (Skill skill in employee.skills) {
            if (desiredSkills.Contains(skill.name))
                points += skill.rarity + Skill.evaluateHardness(skill.isHardSkill);
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

                    break;
                }
            
            // evaluate domain
            string[] emplyeeDomains = Project.collectDomains(employee.pastProjects);
            string[] hrDomains = Project.collectDomains(projects);

            points += hrDomains.Count(emplyeeDomains.Contains);
        }

        return points;
    }
}