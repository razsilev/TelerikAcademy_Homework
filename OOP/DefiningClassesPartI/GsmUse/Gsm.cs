using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GsmUse
{
    public class Gsm
    {
        public string Model { get; set; }
        public string Manufacturer { get; set; }
        private float price;
        public string Owner { get; set; }

        public Batterys Battery { get; set; }
        public Displays Display { get; set; }

        public List<Call> CallHistory { get; set; }

        private static Gsm iphone4S;

        public static Gsm Iphone4S
        {
            get
            {
                return iphone4S.Copy();
            }
        }

        public float Price
        {
            get
            {
                return this.price;
            }

            set
            {
                if (value >= 0)
                {
                    this.price = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException("Price can NOT be negative!");
                }
            }
        }

        static Gsm()
        {
            iphone4S = new Gsm("Iphone4S", "Apple", 754.30f, 
                new Batterys("Iphone", BatteryType.Li_Ion), new Displays(3.2f, 256));
        }

        public Gsm(string model, string manufacturer, Batterys battery)
        {
            this.Model = model;
            this.Manufacturer = manufacturer;
            this.Battery = battery;
            this.CallHistory = new List<Call>();
        }

        public Gsm(string model, string manufacturer, float price, Batterys battery, Displays display)
            : this(model, manufacturer, price, null, battery, display)
        {

        }

        public Gsm(string model, string manufacturer, float price, string owner,
                                                    Batterys battery, Displays display)
            : this(model, manufacturer, battery)
        {
            this.Price = price;
            this.Owner = owner;

            this.Display = display;
        }

        public Gsm Copy()
        {
            return new Gsm(this.Model, this.Manufacturer, this.Price, this.Owner,
                this.Battery.Copy(),
                this.Display.Copy());
        }

        public void AddCall(Call call)
        {
            this.CallHistory.Add(call);
        }

        public void RemoveCall(Call call)
        {
            this.CallHistory.Remove(call);
        }

        public void ClearCallsHistory()
        {
            this.CallHistory.Clear();
        }

        public decimal CalculateCallsPrice(decimal pricePerMinute)
        {
            decimal price = 0;
            ulong totalSeconds = 0;

            for (int i = 0; i < CallHistory.Count; i++)
            {
                totalSeconds += this.CallHistory[i].Duration;
            }

            price = (totalSeconds / 60) * pricePerMinute;

            return price;
        }

        public override string ToString()
        {
            return string.Format("model: {0} manufacturer: {1} price: {2:C}. owner: {3} Battery: {4} Display: {5}",
                this.Model, this.Manufacturer, this.Price, this.Owner, this.Battery, this.Display);
        }
    }
}
