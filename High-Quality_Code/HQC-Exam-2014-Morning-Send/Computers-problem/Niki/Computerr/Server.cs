namespace ComputerBuildingSystem.Computerr
{
    using System.Collections.Generic;
    using ComputerBuildingSystem.Cpuu;
    using ComputerBuildingSystem.Motherboardd;

    public class Server : Computer
    {
        private IEnumerable<HardDriver> hardDrives;

        public Server(ICpu cpu, IMotherboard motherboard, IEnumerable<HardDriver> hardDrives)
            : base(cpu, motherboard)
        {
            this.hardDrives = hardDrives;
        }

        public void Process(int data)
        {
            this.Motherboard.SaveRamValue(data);

            // TODO: Fix it
            this.Cpu.SquareNumber();
        }
    }
}
