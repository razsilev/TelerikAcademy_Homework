namespace ComputerBuildingSystem.Ram
{
    public class RamMemory : IRamMemory
    {
        private int value;

        public RamMemory(int amount)
        {
            this.Amount = amount;
        }

        public int Amount { get; set; }

        public void SaveValue(int newValue)
        {
            this.value = newValue;
        }

        public int LoadValue()
        {
            return this.value;
        }
    }
}