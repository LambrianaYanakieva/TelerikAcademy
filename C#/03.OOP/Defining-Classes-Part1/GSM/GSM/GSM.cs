using System.Collections.Generic;
using System.Text;

namespace GSM
{
    public class GSM
    {
        private string model;
        private string manufacturer;
        private int price;
        private string owner;
        private Battery battery;
        private Display display;
        private IList<Call> callHystory;
        private static Battery iPhoneBattery = new Battery("iBattery", 23, 56, BatteryType.NiMH);
        private static Display iPhoneDisplay = new Display(7, 225);
        private static GSM iPhone4S = new GSM("IPhone 4S","Apple",1900, "Mariya", iPhoneBattery, iPhoneDisplay);

        public GSM(string model, string manufacturer, int price,
            string owner, Battery battery, Display display)
        {
            this.model = model;
            this.manufacturer = manufacturer;
            this.price = price;
            this.owner = owner;
            this.battery = battery;
            this.display = display;
            this.callHystory = new List<Call>();
        }

        public GSM()
        {
            this.callHystory = new List<Call>();
        }

        public string Model
        {
            get
            {
                return this.model;
            }
        }

        public string Manufacturer
        {
            get
            {
                return this.manufacturer;
            }
        }

        public int Price
        {
            get
            {
                return this.price;
            }
        }

        public string Owner
        {
            get
            {
                return this.owner;
            }
        }

        public Battery Battery
        {
            get
            {
                return this.battery;
            }
            set
            {
                this.battery = value;
            }
        }

        public Display Display
        {
            get
            {
                return this.display;
            }
            set
            {
                this.display = value;
            }
        }

        public static GSM IPhone4S
        {
            get
            {
                return iPhone4S;
            }
        }

        public IList<Call> CallHistory
        {
            get
            {
                return this.callHystory;
            }
            
           
        }

        public void AddCall(Call call)
        {
            this.callHystory.Add(call);
        }

        public void DeleteCall(Call call)
        {
            this.callHystory.Remove(call);
        }

        public void DeleteCallAt(int index)
        {
            this.callHystory.RemoveAt(index);
        }

        public void ClearHistory()
        {
            this.callHystory.Clear();
        }

        public decimal CalculateTotalPrice()
        {
            decimal pricePerMinute = 0.37M;
            decimal totalPrice = 0;

            for (int i = 0; i < callHystory.Count; i++)
            {
                decimal minutes = callHystory[i].Duration / 60;
                totalPrice += (minutes * pricePerMinute);
            }

            return totalPrice;
        }

        public override string ToString()
        {
            var phoneInformation = new StringBuilder();
            phoneInformation.AppendLine("Model: " + Model);
            phoneInformation.AppendLine("Manufacturer: " + Manufacturer);
            phoneInformation.AppendLine("Price: " + Price);
            phoneInformation.AppendLine("Owner: " + Owner);
            phoneInformation.AppendLine("Battery model: " + Battery.Model);
            phoneInformation.AppendLine("Battery hours idle: " + Battery.HoursIdle);
            phoneInformation.AppendLine("Battery hours talk: " + Battery.HoursTalk);
            phoneInformation.AppendLine("Battery type: " + Battery.BatteryType);
            phoneInformation.AppendLine("Display size: " + Display.Size);
            phoneInformation.AppendLine("Display number of colors: " + Display.NumberOfColors);
            return phoneInformation.ToString();
        }
    }
}
