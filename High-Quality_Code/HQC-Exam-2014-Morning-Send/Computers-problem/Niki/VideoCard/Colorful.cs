namespace ComputerBuildingSystem.VideoCard
{
    using System;
    
    public class Colorful : IVideoCard
    {
        public void Draw(string text)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(text);
            Console.ResetColor();
        }
    }
}
