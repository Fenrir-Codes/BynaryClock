using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Media;
using System.Timers;

namespace BinaryClockApp
{
    class Program
    {
        static void Main(string[] args)
        {
            
            Console.BufferWidth= Console.WindowWidth = 60; Console.BufferHeight = Console.WindowHeight = 20;
            Console.OutputEncoding = Encoding.Unicode; // sets the output to Unicode, otherwise not the proper character will be printed to screen.
            Console.Title = "BinaryClock";
            Console.CursorVisible = false; // Hide the cursor.
            var value ="";

            do
            {
                Thread Clock = new Thread(new ThreadStart(ClockFunctions.TimeUpdate)); Thread.Sleep(1000); // Multithreading starts here with thread one (clock).
                Thread Tick = new Thread(new ThreadStart(ClockFunctions.tick)); // Second thread called for tick sound(wav file).
                Clock.Start(); // starting the threds.
                Tick.Start();

                ClockFunctions.printEnum();

            } while (value == isPressedEsc());

        }
        private static string isPressedEsc()  // method called ReadLineorESC watching escape key is pressed.
        {

            do // loop ...
            {
                ConsoleKeyInfo KeyResult = Console.ReadKey(true);

                // handling Esc
                if (KeyResult.Key == ConsoleKey.Escape)  // checking if escape pressed if pressed then exiting the application.
                {
                    Environment.Exit(0);  // exiting application
                }
            }
            while (true); // ...until true

        }
    }
}
