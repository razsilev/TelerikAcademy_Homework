namespace ComputerBuildingSystem.Motherboardd
{
    /// <summary>
    /// Motherboard – It can load values from the RAM, save values to the RAM and draw on the video card.
    /// </summary>
    public interface IMotherboard
    {
        /// <summary>
        /// Load value from the ram memory.
        /// </summary>
        /// <returns>Return integer value stored in ram memory.</returns>
        int LoadRamValue();

        /// <summary>
        /// Save integer value to ram memory.
        /// </summary>
        /// <param name="value">32 bit integer value for saveing.</param>
        void SaveRamValue(int value);

        /// <summary>
        /// Draw data string on video card.
        /// </summary>
        /// <param name="data">String for drawing on the video card.</param>
        void DrawOnVideoCard(string data);
    }
}
