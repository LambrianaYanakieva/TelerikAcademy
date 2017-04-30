namespace Converter
{
    public class StartUp
    {
        public static void Main()
        {
            var stringConverter = new StringConverter();

            stringConverter.ConvertBooleanToString(true);
        }
    }
}
