public class Project {
    public string name { get; init; }
    public string language { get; init; }
    public string domain { get; set; }

    Project(string Pname, string Planguage, string Pdomain) {
        name = Pname;
        language = Planguage;
        domain = Pdomain;
    }

    public static List<Project> createListOfProjects(string[] names, string[] languages, string[] domains) {
        int len = names.Length;
        List<Project> Projects = new List<Project>();

        for (int i = 0; i < len; i++)
            Projects.Add(new Project(names[i], languages[i], domains[i]));
        
        return Projects;
    }

    // get domains of multiple projects in order to make comparisons 
    public static string[] collectDomains(List<Project> projects) {
        string[] domains = {};

        foreach(Project project in projects)
            domains.Append(project.domain);

        return domains;
    }
}