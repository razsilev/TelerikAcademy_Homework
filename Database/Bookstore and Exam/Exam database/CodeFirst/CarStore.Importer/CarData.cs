namespace CarStore.Importer
{
    using CarStore.Models;

    public class CarData
    {
        public int Year { get; set; }

        public TransmitionType TransmissionType { get; set; }

        public string ManufacturerName { get; set; }

        public string Model { get; set; }

        public decimal Price { get; set; }

        public MyDealer Dealer { get; set; }
    }
}
