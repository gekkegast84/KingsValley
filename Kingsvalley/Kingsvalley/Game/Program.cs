using System;

namespace Kingsvalley
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main(string[] args)
        {
            using (KingsValley game = new KingsValley())
            {
                game.Run();
            }
        }
    }
}

