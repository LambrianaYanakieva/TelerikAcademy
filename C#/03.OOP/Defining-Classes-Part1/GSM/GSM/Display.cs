namespace GSM
{
    public class Display
    {
        private int size;
        private int numberOfColors;

        public Display(int size, int numberOfColor)
        {
            this.size = size;
            this.numberOfColors = numberOfColor;
        }

        public int Size
        {
            get
            {
                return this.size;
            }
        }

        public int NumberOfColors
        {
            get
            {
                return this.numberOfColors;
            }
        }
    }
}
