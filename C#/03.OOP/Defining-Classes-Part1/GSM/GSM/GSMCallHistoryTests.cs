using System;

namespace GSM
{
    public static class GSMCallHistoryTests
    {
        public static void PerformActions()
        {
            //Create an instance of the GSM class
            var phone = new GSM();
            var call_1 = new Call("0882548853", 240);
            var call_2 = new Call("0882548833", 85);
            var call_3 = new Call("0883348853", 280);

            //add few calls
            phone.AddCall(call_1);
            phone.AddCall(call_2);
            phone.AddCall(call_3);

            //Display the information about calls
            DisplayInformationAboutCalls(phone);

            //Calculate and print the total price in call history
            var totalPrice = phone.CalculateTotalPrice();
            Console.WriteLine("Total price before removing a longest call : " + totalPrice);

            //Remove the Longest call and calculate again
            RemoveLongestCall(phone);
            totalPrice = phone.CalculateTotalPrice();

            //Clear call history and print it
            phone.CallHistory.Clear();
            Console.WriteLine("Total price after removing a longest call : " + totalPrice);
        }

        public static void DisplayInformationAboutCalls(GSM phone)
        {
            for (int i = 0; i < phone.CallHistory.Count; i++)
            {
                Console.WriteLine("Date: " + phone.CallHistory[i].Date);
                Console.WriteLine("Time: " + phone.CallHistory[i].Time);
                Console.WriteLine("Dailed Number: " + phone.CallHistory[i].DailedNumber);
                Console.WriteLine("Duration: " + phone.CallHistory[i].Duration);
                Console.WriteLine("--------------------------------");
            }
        }

        public static void RemoveLongestCall(GSM phone)
        {
            decimal bestTime = 0;
            int index = 0;

            for (int i = 0; i < phone.CallHistory.Count; i++)
            {
                if(phone.CallHistory[i].Duration > bestTime)
                {
                    bestTime = phone.CallHistory[i].Duration;
                    index = i;
                }
            }

            phone.DeleteCallAt(index);
        }
    }
}
