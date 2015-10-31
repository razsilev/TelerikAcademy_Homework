namespace CarStore.Importer
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.IO;

    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;

    using CarStore.Data;
    using CarStore.Models;

    public class DataImporter
    {
        private static CarStoreDbContext db;

        static void Main()
        {
            db = new CarStoreDbContext();

            db.Cars.Any();

            string path = "../../../../DataJsonFiles/data.0.json";
            List<CarData> carsData1 = ReadJson(path);

            AddToDatabase(carsData1);

            string path1 = "../../../../DataJsonFiles/data.1.json";
            List<CarData> carsData2 = ReadJson(path1);
            AddToDatabase(carsData2);

            string path2 = "../../../../DataJsonFiles/data.2.json";
            List<CarData> carsData3 = ReadJson(path2);
            AddToDatabase(carsData3);

            string path3 = "../../../../DataJsonFiles/data.3.json";
            List<CarData> carsData4 = ReadJson(path3);
            AddToDatabase(carsData4);

            string path4 = "../../../../DataJsonFiles/data.4.json";
            List<CarData> carsData5 = ReadJson(path4);
            AddToDatabase(carsData5);
        }

        private static void AddToDatabase(List<CarData> carsData)
        {
            for (int i = 0; i < carsData.Count; i++)
            {
                var car = new Car()
                            {
                                Model = carsData[i].Model,
                                Price = carsData[i].Price,
                                Year = carsData[i].Year,
                                Transmission = carsData[i].TransmissionType,
                                Dealer = new Dealer()
                                                {
                                                    Name = carsData[i].Dealer.Name
                                                }
                            };

                var city = new City()
                                {
                                    Name = carsData[i].Dealer.City
                                };

                db.Cars.Add(car);
                db.Citys.Add(city);

                db.SaveChanges();
            }

        }

        private static List<CarData> ReadJson(string path)
        {
            List<CarData> cars = new List<CarData>();

            string jsonStr = File.ReadAllText(path);

            var objects = JArray.Parse(jsonStr); // parse as array  
            foreach (JObject root in objects)
            {
                cars.Add(JsonConvert.DeserializeObject<CarData>(root.ToString()));
            }

            return cars;
        }




    }
}
