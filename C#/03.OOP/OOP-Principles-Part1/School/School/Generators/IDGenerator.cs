namespace School
{
    public static class IDGenerator
    {
        public static int Number { get; set; }

        public static int Generate()
        {
            return Number += 1;
        }
    }
}
