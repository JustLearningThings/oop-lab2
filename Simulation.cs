public abstract class SimulationEntity {
    public int numInteractions { get; set; } = 0;

    public void increment() {
        this.numInteractions++;
    }
}