public class Simulation {
    int steps { get; init; } = 0;
    int successes { get; } = 0;
    int fails { get; } = 0;

    // public Simulation(int nSteps) {
        
    // }

    public void run() {
        for (int i = 0; i < steps; i++) {
            Console.WriteLine("Simulation step");
        }
    }

    public void printStats() {
        Console.WriteLine("=========== Simulation ==========");
        Console.WriteLine("Steps done: " + steps);
        Console.WriteLine("Successes: " + successes);
        Console.WriteLine("Fails: " + fails);
        Console.WriteLine("=================================");
    }
}