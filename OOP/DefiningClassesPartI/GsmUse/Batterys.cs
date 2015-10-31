using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GsmUse
{
    public class Batterys
    {
        public string Model { get; private set; }
        private double idleHours;
        private double talkHours;
        public BatteryType Type { get; private set; }

        public double IdleHours
        {
            get
            {
                return this.idleHours;
            }

            set
            {
                if (value >= 0)
                {
                    this.idleHours = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException("Hours can NOT be negative!");
                }
            }
        }

        public double TalkHours
        {
            get
            {
                return this.talkHours;
            }

            set
            {
                if (value >= 0)
                {
                    this.talkHours = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException("Hours can NOT be negative!");
                }
            }
        }

        public Batterys(string model, BatteryType type)
        {
            this.Model = model;
            this.Type = type;
        }

        public Batterys(string model, double talkHours, BatteryType type)
            : this(model, type)
        {
            this.TalkHours = talkHours;
        }

        public Batterys(string model, double idleHours, double talkHours, BatteryType type)
            : this(model, talkHours, type)
        {
            this.IdleHours = idleHours;
        }

        public Batterys Copy()
        {
            return new Batterys(this.Model, this.idleHours, this.talkHours, this.Type);
        }

        public override string ToString()
        {
            return string.Format("model: {0}; idle hours: {1}; talk hours: {2}; type: {3}", 
                this.Model, this.IdleHours, this.TalkHours, this.Type);
        }
    }
}
