public class Controller {
    Model model {get; init;} = new Model();
    View view {get; init;} = new View();

    public int successes {get; set;} = 0;
    public int fails {get; set;} = 0;

    Random rnd {get; init;} = new Random();

    private void postStep() {
        model.createOffers();
        model.postOffers();
    }

    private Offer chooseOffer(JobSite site) {
        return site.offers[rnd.Next(0, site.offers.Count - 1)];
    }

    private bool applyToJob(Employee employee, JobSite site) {
        bool isHired;
        Offer offer = chooseOffer(site);
        HR? offerHR = offer.findHR(model.hrs);

        if (offerHR == null)
            return false;
        
        isHired = offerHR.evaluate(employee);

        if (isHired) {
            model.removeOffer(site, offerHR, offer);
            model.levelUpEmployee(employee);
        }

        return isHired;
    }

    private void jobSearchStep() {
        foreach (Employee employee in model.employees)
            if (applyToJob(employee, model.sites[rnd.Next(0, model.sites.Count - 1)]))
                successes++;
            else
                fails++;
    }

    private void simulationStep() {
        postStep();
        jobSearchStep();

        view.writeIterationStatistics(successes, fails);
    }

    public void simulate(int n = -1) {
        view.simulationStart();
        model.initSimulationState();
        view.renderSimulation(n, ConsoleKey.Q, simulationStep);
        view.simulationEnd();
    }

    public void setHRNum(int n) { model.hrNum = n; }
    public void setEmployeeNum(int n) { model.employeeNum = n; }
    public void setOffersPerHR(int n) { model.offersPerHR = n; }
    public void setSitesNum(int n) { model.sitesNum = n; }
}