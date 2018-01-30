namespace GSM
{
    public class Battery
    {
        private string model;
        private int hoursIdle;
        private int hoursTalk;
        private BatteryType batteryType;

        public Battery(string model, int hoursIdle, 
            int hoursTalk, BatteryType batteryType)
        {
            this.model = model;
            this.hoursIdle = hoursIdle;
            this.hoursTalk = hoursTalk;
            this.batteryType = batteryType;
        }

        public string Model
        {
            get
            {
                return this.model;
            }
        }

        public int HoursIdle
        {
            get
            {
                return this.hoursIdle;
            }
        }

        public int HoursTalk
        {
            get
            {
                return this.hoursTalk;
            }
        }

        public BatteryType BatteryType
        {
            get
            {
                return this.batteryType;
            }
        }
    }
}
