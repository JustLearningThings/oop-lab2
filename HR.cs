class HR {
    public string name { get; init; }
    public string company { get; set; }
    public Project[] projects { get; set; }
    private int threshold { get; set; }

    HR(string HRname, string HRcompany, Project[] HRprojects) {
        name = HRname;
        company = HRcompany;
        projects = HRprojects;

        threshold = 5; // 5 points or more to hire
    }

    // evaluate an employee (hire or not hire)
    public bool evaluate() {
        int points = 0;

        points += evaluateSkills() + evaluateLanguages();

        return points >= this.threshold;
    }

    // evaluate emplyee skills, return nr of points
    private int evaluateSkills() {
        return 0;
    }

    // evaluate emplyee programming language knowledge, return nr of points
    private int evaluateLanguages() {
        return 0;
    }
}