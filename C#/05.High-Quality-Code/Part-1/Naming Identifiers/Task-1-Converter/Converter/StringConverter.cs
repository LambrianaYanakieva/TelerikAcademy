namespace Converter
{
    using System;
    
    public class StringConverter
    {
        public void ConvertBooleanToString(bool inputValue)
        {
            string parsedInputValue = inputValue.ToString();

            Console.WriteLine(parsedInputValue);
        }
    }
}
