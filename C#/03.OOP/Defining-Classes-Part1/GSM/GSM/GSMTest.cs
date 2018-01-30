using System;

namespace GSM
{
    public static class GSMTest
    {

        public static GSM[] CollectPhones()
        {
            
             Battery samsungBattery = new Battery("zed", 5, 20, BatteryType.LiIon);
             Display samsungDisplay = new Display(5, 200);
             Battery nokiaBattery = new Battery("alpha", 4, 10, BatteryType.NiCd);
             Display nokiaDisplay = new Display(6, 300);
             Battery lenovoBattery = new Battery("beta", 8, 15, BatteryType.NiMH);
             Display lenovoDisplay = new Display(4, 150);

             GSM samsung = new GSM("Galaxy S3", "Samsung", 120, "Pesho", samsungBattery, samsungDisplay);
             GSM nokia = new GSM("Corola", "Nokia", 66, "Ivan", nokiaBattery, nokiaDisplay);
             GSM lenovo = new GSM("Fiesta", "Lenovo", 210, "Pamela", lenovoBattery, lenovoDisplay);

            var phoneArray = new GSM[3]
            {
                samsung,
                nokia,
                lenovo
            };

            return phoneArray;
        }

        public static void DisplayPhoneInformation(GSM[] phoneArray)
        {
            for (int i = 0; i < phoneArray.Length; i++)
            {
                Console.WriteLine(phoneArray[i].ToString());
            }
        }

        public static void DisplayIPhoneInformation(GSM iPhone)
        {
            Console.WriteLine(iPhone.ToString());
        }
    }
}