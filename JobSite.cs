public class JobSite : SelectionEnvironment {
    public string name;
    public Offer[] offers;

    public JobSite(string siteName, 
                    Offer[] initialOffers,
                    string url,
                    string country = "Moldova") : base(country, url) {
        name = siteName;
        offers = initialOffers;
    }

    public void addOffers(Offer[] newOffers) {
        foreach(Offer offer in newOffers)
            offers.Append(offer);
    }

    // select latest
    public Offer[] yieldOffers(int n) {
        return (Offer[])offers.Take(n);
    }
}