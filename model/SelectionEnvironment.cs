public abstract class SelectionEnvironment : SimulationEntity {
    public string country { get; init; }
    public string url { get; set; }

    protected SelectionEnvironment(string envCountry, string envUrl) {
        country = envCountry;
        url = envUrl;
    }
}