namespace ComputerBuildingSystem.VideoCard
{
    using System;
    
    public class MonochromeVideoCard : IVideoCard
    {
        public void Draw(string text)
        {
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine(text);
            Console.ResetColor();
        }
    }
}
