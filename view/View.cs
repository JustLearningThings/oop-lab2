public class View {
    public void simulationStart() {
        Console.Clear();
        Console.WriteLine("====Simulation started====");
        Console.WriteLine("\tIteration 1");
        Console.WriteLine("==========================");
    }

    public void simulationEnd() {
        Console.WriteLine("====Simulation ended====");
    }

    public void writeIterationStatistics(int successes, int fails) {
        Console.Write("There were ");
        Console.ForegroundColor = ConsoleColor.DarkYellow;
        Console.Write("" + (successes + fails));
        Console.ForegroundColor = ConsoleColor.White;
        Console.Write(" jobs applications. Out of them ");
        Console.ForegroundColor = ConsoleColor.Green;
        Console.Write("" + successes);
        Console.ForegroundColor = ConsoleColor.White;
        Console.Write(" employees were hired and ");
        Console.ForegroundColor = ConsoleColor.Red;
        Console.Write("" + fails);
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine(" were not.");
    }

    public void renderSimulation(int iterations, ConsoleKey exitKey, Action runIteration) {
        int i = 0;

        if (iterations == -1)
            while (true) {
                if (Console.KeyAvailable && Console.ReadKey(true).Key == exitKey)
                    break;

                runIteration();

                i++;
            }
        else
            while (i < iterations) {
                runIteration();

                i++;
            }
    }
}