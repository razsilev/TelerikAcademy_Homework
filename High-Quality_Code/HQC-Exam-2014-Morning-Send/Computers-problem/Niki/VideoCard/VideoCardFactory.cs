namespace ComputerBuildingSystem.VideoCard
{
    public static class VideoCardFactory
    {
        public static IVideoCard CrateVideoCard(VideoCardType type)
        {
            switch (type)
            {
                case VideoCardType.COLORFUL:
                    return new Colorful();
                case VideoCardType.MONOCHROME:
                    return new MonochromeVideoCard();
                default:
                    throw new InvalidArgumentException("Invalid video card type");
            }
        }
    }
}
