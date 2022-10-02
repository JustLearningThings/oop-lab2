public abstract class SelectionEntity : SimulationEntity {
    public string name { get; init; }
    public string domain { get; set; }
    public string[] domains { get; set; }

    protected SelectionEntity(string entityName, string entityDomain) {
        name = entityName;
        domain = entityDomain;
        domains = new string[] {};
    }

    // same constuctor, different signature
    protected SelectionEntity(string entityName, string[] entityDomains) {
        name = entityName;
        domains = entityDomains;
        domain = "";
    }
}