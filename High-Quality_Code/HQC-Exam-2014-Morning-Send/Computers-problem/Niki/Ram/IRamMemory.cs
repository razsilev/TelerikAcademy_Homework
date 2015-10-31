namespace ComputerBuildingSystem.Ram
{
    public interface IRamMemory
    {
        int Amount { get; }

        void SaveValue(int newValue);

        int LoadValue();
    }
}
