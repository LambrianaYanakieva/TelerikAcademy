using System;
using System.Globalization;

namespace GSM
{
    public class Call
    {
        private string date;
        private string time;
        private string dailedPhoneNumber;
        private decimal duration;

        public Call(string dailedNumber, decimal duration)
        {
            DateTime dateTime = new DateTime().Date;
            this.date = dateTime.ToString("dd.mm.yyyy");
            this.time = dateTime.ToString("HH:mm");
            this.dailedPhoneNumber = dailedNumber;
            this.duration = duration;
        }

        public string Date
        {
            get
            {
                return this.date;
            }
        }

        public string Time
        {
            get
            {
                return this.time;
            }
        }

        public string DailedNumber
        {
            get
            {
                return this.dailedPhoneNumber;
            }
        }

        public decimal Duration
        {
            get
            {
                return this.duration;
            }
        }
    }
}
