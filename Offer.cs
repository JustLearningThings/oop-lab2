public class Offer : SelectionEnvironment {
    public string title { get; init; }
    public int salary { get; set; }

    public Offer(string offerTitle,
                 int offerSalary,
                 string url,
                 string country = "Moldova") : base (country, url) {
        title = offerTitle;
        salary = offerSalary;
    }

    public HR? findHR(List<HR> HRs) {
        foreach(HR hr in HRs) {
            foreach(Offer o in hr.offers) {
                if (o.title == this.title)
                    return hr;
            }
        }

        return null;
    }

    public static bool checkEmployeeSalaryMatch(Offer offer, int desiredSalary) {
        return offer.salary >= desiredSalary;
    }
}