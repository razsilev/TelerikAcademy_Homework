namespace ComputerBuildingSystem.Cpuu
{
    using System;
    using ComputerBuildingSystem.Motherboardd;

    public class Cpu : ICpu
    {
        internal static readonly Random Random = new Random();
        
        private const int MaxNumberFor32BitCPU = 500;
        private const int MaxNumberFor64BitCPU = 1000;

        private readonly CpuType cpuType;
        private readonly IMotherboard motherboard;

        public Cpu(byte numberOfCores, CpuType cpuType, IMotherboard motherboard)
        {
            this.cpuType = cpuType;
            this.NumberOfCores = numberOfCores;
            this.motherboard = motherboard;
        }

        public byte NumberOfCores { get; set; }

        public void SquareNumber()
        {
            if (this.cpuType == Cpuu.CpuType.BIT32)
            {
                this.CalculateSquare(MaxNumberFor32BitCPU);
            }

            if (this.cpuType == Cpuu.CpuType.BIT32)
            {
                this.CalculateSquare(MaxNumberFor64BitCPU);
            }
        }

        public void Rand(int min, int max)
        {
            int randomNumber = Random.Next(min, max + 1);
            
            this.motherboard.SaveRamValue(randomNumber);
        }

        private void CalculateSquare(int maxNumber)
        {
            var data = this.motherboard.LoadRamValue();
            if (data < 0)
            {
                this.motherboard.DrawOnVideoCard("Number too low.");
            }
            else if (data > maxNumber)
            {
                this.motherboard.DrawOnVideoCard("Number too high.");
            }
            else
            {
                int value = 0;
                for (int i = 0; i < data; i++)
                {
                    value += data;
                }

                this.motherboard.DrawOnVideoCard(string.Format("Square of {0} is {1}.", data, value));
            }
        }
    }
}
