namespace Events
{
    using System.Text;

    public static class Messages
    {        
        public static void EventAdded()
        {
            Execute.Output.Append("Event added\n");
        }

        public static void EventDeleted(int x)
        {
            if (x == 0)
            {
                NoEventsFound();
            }
            else
            {
                Execute.Output.AppendFormat("{0} events deleted\n", x);
            }
        }

        public static void NoEventsFound()
        {
            Execute.Output.Append("No events found\n");
        }

        public static void PrintEvent(Event eventToPrint)
        {
            if (eventToPrint != null)
            {
                Execute.Output.Append(eventToPrint + "\n");
            }
        }
    }
}
