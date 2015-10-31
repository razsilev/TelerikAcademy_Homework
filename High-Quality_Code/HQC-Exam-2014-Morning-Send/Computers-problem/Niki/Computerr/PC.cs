namespace ComputerBuildingSystem.Computerr
{
    using ComputerBuildingSystem.Cpuu;
    using ComputerBuildingSystem.Motherboardd;

    public class PC : Computer
    {
        private HardDriver hardDrive;

        public PC(ICpu cpu, IMotherboard motherboard, HardDriver hardDrive)
            : base(cpu, motherboard)
        {
            this.hardDrive = hardDrive;
        }

        public void Play(int guessNumber)
        {
            this.Cpu.Rand(1, 10);
            var number = this.Motherboard.LoadRamValue();
            if (number + 1 != guessNumber + 1)
            {
                this.Motherboard.DrawOnVideoCard(string.Format("You didn't guess the number {0}.", number));
            }
            else
            {
                this.Motherboard.DrawOnVideoCard("You win!");
            }
        }
    }
}
