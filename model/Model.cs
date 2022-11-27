public class Model {
    public List<Employee> employees {get; set;} = new List<Employee>();
    WebDeveloperBuilder webDevBuilder {get; init;} = new WebDeveloperBuilder();
    MLEngineerBuilder mlBuilder {get; init;} = new MLEngineerBuilder();
    EmployeeDirector employeeDirector {get; init;} = new EmployeeDirector();

    public List<HR> hrs {get; set;} = new List<HR>();
    CommonHRBuilder hrBuilder {get; init;} = new CommonHRBuilder();
    HRDirector hrDirector {get; init;} = new HRDirector();

    public List<JobSite> sites {get; set;} = new List<JobSite>();

    // simulation state 
    public int hrNum {get; set;} = 5;
    public int employeeNum {get; set;} = 5;
    public int offersPerHR {get; set;} = 5;
    public int sitesNum {get; set;} = 1;

    private Random rnd = new Random();

    // populates employees and hrs lists with initial values based on the rules
    // described in the respective builders
    public void initSimulationState() {
        // create Emplyees and HRs
        int idx = rnd.Next(0, hrNum); // how many employees of each type

        employeeDirector.populateListOfEmployees(webDevBuilder, employees, idx);
        employeeDirector.populateListOfEmployees(mlBuilder, employees, idx, "ML");
        hrDirector.populateListOfHRs(hrBuilder, hrs, hrNum);

        // create JobSites
        for (int i = 0; i < sitesNum; i++)
            sites.Add(new JobSite(
                "JobSite " + (i + 1).ToString(),
                new List<Offer>(),
                "www.site" + (i + 1).ToString() + ".com"
            ));
    }

    // post state function where each hr creates offers for job sites
    public void createOffers() {
        foreach (HR hr in hrs)
            for (int i = 0; i < offersPerHR; i++)
                hr.createOffer("Offer " + (i + 1).ToString(), rnd.Next(500, 1_000_000));
    }

    // post state function where each hr posts the offers created earlier
    public void postOffers() {
        foreach(HR hr in hrs)
            foreach(JobSite site in sites)
                foreach(Offer offer in hr.offers)
                    if (rnd.Next(1, 10) >= 2) // 80% chance to post on this site
                        hr.postOffer(offer.title, site);
    }

    public void removeOffer(JobSite site, HR hr, Offer offer) {
        site.offers.Remove(offer);
        hr.offers.Remove(offer);
    }

    public void levelUpEmployee(Employee employee) {
        EmployeeBuilder builder = webDevBuilder;

        if (employee.type == "ML")
            builder = mlBuilder;
        
        // add a new skill, a new programming language and a new project
        builder.buildSkillsData();
        builder.buildProgrammingLanguagesData();
        builder.buildProjectsData();
    }
}