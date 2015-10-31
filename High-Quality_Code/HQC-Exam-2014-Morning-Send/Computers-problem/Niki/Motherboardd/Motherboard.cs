namespace ComputerBuildingSystem.Motherboardd
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    
    using ComputerBuildingSystem.Ram;
    using ComputerBuildingSystem.VideoCard;

    public class Motherboard : IMotherboard
    {
        private IVideoCard videoCard;
        private IRamMemory ram;

        public Motherboard(IVideoCard videocard, IRamMemory ram)
        {
            this.VideoCard = videocard;
            this.Ram = ram;
        }

        public IVideoCard VideoCard
        {
            get { return this.videoCard; }
            set { this.videoCard = value; }
        }

        public IRamMemory Ram
        {
            get { return this.ram; }
            set { this.ram = value; }
        }

        public int LoadRamValue()
        {
            return this.Ram.LoadValue();
        }

        public void SaveRamValue(int value)
        {
            this.Ram.SaveValue(value);
        }

        public void DrawOnVideoCard(string data)
        {
            this.VideoCard.Draw(data);
        }
    }
}
