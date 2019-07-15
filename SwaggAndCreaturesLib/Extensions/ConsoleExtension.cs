using System;

namespace SwaggAndCreaturesLib.Extensions
{
    public static class ConsoleDisplay
    {
        private static readonly int DialogLine = 20;

        public static void DialogMessage(string message)
        {
            try
            {
                Console.SetCursorPosition(0, DialogLine);
                Console.Write(message);
                System.Threading.Thread.Sleep(1250);
            }
            catch (ArgumentOutOfRangeException e)
            {
                Console.Clear();
                Console.WriteLine(e.Message);
            }
        }
    }
}
