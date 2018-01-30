using System;
using System.Globalization;

namespace GSM
{
    public class StartUp
    {
        public static void Main()
        {
            //Display information about phone
            var phoneArray = GSMTest.CollectPhones();
            GSMTest.DisplayPhoneInformation(phoneArray);

            //Display information about IPhone
            var iphone = GSM.IPhone4S;
            GSMTest.DisplayIPhoneInformation(iphone);

            //Perform action about calls(add, print info, calculate price, remove call, etc.)
            GSMCallHistoryTests.PerformActions();
        }
    }
}
