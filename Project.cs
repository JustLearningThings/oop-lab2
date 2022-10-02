public class Project : SelectionEntity {
    public string language { get; init; }

    public Project(string Pname, string Planguage, string Pdomain)
            : base(Pname, Pdomain) {
        language = Planguage;
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