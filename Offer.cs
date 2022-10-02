public class Offer : SelectionEnvironment {
    public string title { get; init; }
    public int salary { get; set; }
    public Project project { get; init; }

    public Offer(string offerTitle,
                 int offerSalary,
                 Project offerProject,
                 string url,
                 string country = "Moldova") : base (country, url) {
        title = offerTitle;
        salary = offerSalary;
        project = offerProject;
    }

    public static bool checkEmployeeSalaryMatch(Offer offer, int desiredSalary) {
        return offer.salary >= desiredSalary;
    }
}