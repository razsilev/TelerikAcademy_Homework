namespace ComputerBuildingSystem.Computerr
{
    using ComputerBuildingSystem.Cpuu;
    using ComputerBuildingSystem.Motherboardd;

    public abstract class Computer
    {
        public Computer(ICpu cpu, IMotherboard motherboard)
        {
            this.Cpu = cpu;
            this.Motherboard = motherboard;
        }

        public ICpu Cpu
        {
            get;

            private set;
        }

        public IMotherboard Motherboard
        {
            get;

            private set;
        }
    }
}
