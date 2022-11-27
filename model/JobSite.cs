public class JobSite : SelectionEnvironment {
    public string name { get; init; }
    public List<Offer> offers { get; set; }

    public JobSite(string siteName, 
                    List<Offer> initialOffers,
                    string url,
                    string country = "Moldova") : base(country, url) {
        name = siteName;
        offers = initialOffers;
    }

    public void addOffers(List<Offer> newOffers) {
        foreach(Offer offer in newOffers)
            offers.Add(offer);
    }

    // select latest
    public List<Offer> yieldOffers(int n) {
        return (List<Offer>)offers.Take(n);
    }
}