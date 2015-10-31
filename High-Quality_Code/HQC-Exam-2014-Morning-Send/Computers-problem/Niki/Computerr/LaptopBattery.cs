namespace ComputerBuildingSystem.Computerr
{
    public class LaptopBattery : ILaptopBattery
    {
        private const int InitialBatteryPercentage = 50;

        internal LaptopBattery()
        {
            this.Percentage = InitialBatteryPercentage;
        }

        public int Percentage { get; set; }

        public void Charge(int percentage)
        {
            this.Percentage += percentage;
            if (this.Percentage > 100)
            {
                this.Percentage = 100;
            }

            if (this.Percentage < 0)
            {
                this.Percentage = 0;
            }
        }
    }
}