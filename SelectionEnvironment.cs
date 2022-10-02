public abstract class SelectionEnvironment {
    public string country { get; init; }
    public string url { get; init; }

    protected SelectionEnvironment(string envCountry, string envUrl) {
        country = envCountry;
        url = envUrl;
    }
}