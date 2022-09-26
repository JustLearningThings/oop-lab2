public class Project {
    public string name { get; init; }
    public string language { get; init; }
    public string domain { get; init; }

    Project(string Pname, string Planguage, string Pdomain) {
        name = Pname;
        language = Planguage;
        domain = Pdomain;
    }

    public static Project[] createListOfProjects(string[] names, string[] languages, string[] domains) {
        int len = names.Length;
        Project[] Projects = {};

        for (int i = 0; i < len; i++)
            Projects.Append(new Project(names[i], languages[i], domains[i]));
        
        return Projects;
    }

    // get domains of multiple projects in order to make comparisons 
    public static string[] collectDomains(Project[] projects) {
        string[] domains = {};

        foreach(Project project in projects)
            domains.Append(project.domain);

        return domains;
    }

    // extend domain
}