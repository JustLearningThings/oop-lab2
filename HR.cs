class HR {
    public string name { get; init; }
    public string company { get; set; }
    public Project[] projects { get; set; }
    private string[] desiredSkills { get; set; }
    private int threshold { get; set; }

    HR(string HRname, string HRcompany, Project[] HRprojects, string[] HRDesiredSkills = null) {
        name = HRname;
        company = HRcompany;
        projects = HRprojects;

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