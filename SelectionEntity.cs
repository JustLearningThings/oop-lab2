public abstract class SelectionEntity {
    public string name { get; init; }
    public string domain { get; set; }

    protected SelectionEntity(string entityName, string entityDomain) {
        name = entityName;
        domain = entityDomain;
    }
}