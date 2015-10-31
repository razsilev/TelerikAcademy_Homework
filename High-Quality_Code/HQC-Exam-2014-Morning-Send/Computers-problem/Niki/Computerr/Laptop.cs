namespace ComputerBuildingSystem.Computerr
{
    using ComputerBuildingSystem.Cpuu;
    using ComputerBuildingSystem.Motherboardd;

    public class Laptop : Computer
    {
        private ILaptopBattery battery;
        private HardDriver hardDrive;

        public Laptop(ICpu cpu, IMotherboard motherboard, HardDriver hardDrive, ILaptopBattery battery)
            : base(cpu, motherboard)
        {
            this.Battery = battery;
            this.hardDrive = hardDrive;
        }

        public ILaptopBattery Battery
        {
            get { return this.battery; }
            set { this.battery = value; }
        }

        public void ChargeBattery(int percentage)
        {
            this.Battery.Charge(percentage);

            this.Motherboard.DrawOnVideoCard(string.Format("Battery status: {0}", this.Battery.Percentage));
        }
    }
}
