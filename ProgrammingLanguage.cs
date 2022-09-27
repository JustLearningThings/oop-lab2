public class ProgrammingLanguage {
    public string name { get; init; }
    public string[] domains { get; set; }

    public ProgrammingLanguage(string PLName, string[] PLdomains) {
        name = PLName;
        domains = PLdomains;
    }

    // public static ProgrammingLanguage[] createListOfLanguages(string[] names, string[][] domains) {
        public static List<ProgrammingLanguage> createListOfLanguages(string[] names, string[][] domains) {
        int len = names.Length;
        List<ProgrammingLanguage> PLList = new List<ProgrammingLanguage>();

        for (int i = 0; i < len; i++)
            PLList.Add(new ProgrammingLanguage(names[i], domains[i]));

        return PLList;
    }

    // check if the name matches the hr's desired language
    // and that domains are the same
    public bool isPreffered(string name, string domain) {
        if (this.name == name && this.domains.Contains(domain))
            return true;
        
        return false;
    }

    // extend domain()
}