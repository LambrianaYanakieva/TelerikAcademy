namespace Age
{
    using System;

    public class StartUp
    {
        public static void Main()
        {
            
            DateTime birthday = DateTime.Parse(Console.ReadLine());
            DateTime today = DateTime.Now;
            int myAge = today.Year - birthday.Year;
            Console.WriteLine(today.Month);

            if (birthday.Month >= today.Month )
            {
                if(birthday.Day > today.Day)
                {
                    Console.WriteLine(myAge - 1);
                    Console.WriteLine(myAge + 9);
                }
            }
            else
            {
                Console.WriteLine(myAge);
                Console.WriteLine(myAge + 10);
            }
        }
    }
}
