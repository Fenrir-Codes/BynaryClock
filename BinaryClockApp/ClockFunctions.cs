using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Media;
using System.Globalization;
using System.Timers;

namespace BinaryClockApp
{
    class ClockFunctions
    {
        public enum exitenums { press, ESC, to, Exit, Application } //enum strings.

        private static DateTime Time = System.DateTime.Now, TimeDifference = System.DateTime.Now; // time and time difference.

        static void drawSquares(int x, int y, int tal)  //Method for draw the circles
        {

            string bitsToString = Convert.ToString(tal, 2); // time converted to binary into a string.

            while (bitsToString.Length < 8) //loops while the length is less than 8 bits
            {
                bitsToString = "0" + bitsToString;  // every 0 is the default value.
            }

            for (int i = 4; i < 8; i++)
            {
                Console.ForegroundColor = bitsToString[i] == '1' ? ConsoleColor.Blue : ConsoleColor.White; // if the bit == 1 then it is blue colored, default white.
                Console.SetCursorPosition(x, 1 + 1 * i);
                Console.Write("\u25cf"); // Unicode black circle.
            }
           /* for (int j = 4; j < bitsToString.Length; j++)
            {
                Console.SetCursorPosition(x, 1 + 1 * j);
                Console.Write(bitsToString[j]); 
            }*/
        }

        public static void TimeUpdate()
        {

            while (true) //until it is true looping.
            {

                TimeDifference = System.DateTime.Now;
                if (TimeDifference.Second - Time.Second == 1 || TimeDifference.Second - Time.Second == -59) // Update the seconds every second. 
                {
                    //----------------------------Hour---------------------------------//
                    drawSquares(Console.WindowWidth / 3, 0, TimeDifference.Hour / 10);
                    drawSquares(Console.WindowWidth / 3 + 3, 0, TimeDifference.Hour % 10);

                    //---------------------------Minute-------------------------------//
                    drawSquares(Console.WindowWidth / 3 + 8, 0, TimeDifference.Minute / 10);
                    drawSquares(Console.WindowWidth / 3 + 11, 0, TimeDifference.Minute % 10);

                    //----------------------------Seconds---------------------------------//
                    drawSquares(Console.WindowWidth / 3 + 16, 0, TimeDifference.Second / 10);
                    drawSquares(Console.WindowWidth / 3 + 19, 0, TimeDifference.Second % 10);




                   /* //----------------------------Hour---------------------------------//
                    drawSquares(10, 0, TimeDifference.Hour / 10);
                    drawSquares(12 + 3, 0, TimeDifference.Hour % 10);

                    //---------------------------Minute-------------------------------//
                    drawSquares(16 + 8, 0, TimeDifference.Minute / 10);
                    drawSquares(18 + 11, 0, TimeDifference.Minute % 10);

                    //----------------------------Seconds---------------------------------//
                    drawSquares(22 + 16, 0, TimeDifference.Second / 10);
                    drawSquares(24 + 19, 0, TimeDifference.Second % 10);*/


                    Time = System.DateTime.Now;  //resets the time.
                }

            }

        }

        public static void tick() // tick soundplayer
        {
            SoundPlayer audio = new SoundPlayer(BinaryClockApp.Properties.Resources.tick); // resource path
            audio.PlayLooping();
        }

        public static void printEnum() //enum
        {
            var press = ClockFunctions.exitenums.press.ToString();
            var button = ClockFunctions.exitenums.ESC.ToString();
            var to = ClockFunctions.exitenums.to.ToString();
            var exitapp = ClockFunctions.exitenums.Exit.ToString();
            var app = ClockFunctions.exitenums.Application.ToString();

            Console.SetCursorPosition(Console.WindowWidth / 3 - 4, 17);
            Console.Write(press);
            Console.SetCursorPosition(Console.WindowWidth / 3 + 2, 17);
            Console.Write(button);
            Console.SetCursorPosition(Console.WindowWidth / 3 + 6, 17);
            Console.Write(to);
            Console.SetCursorPosition(Console.WindowWidth / 3+ 9, 17);
            Console.Write(exitapp);
            Console.SetCursorPosition(Console.WindowWidth / 3 + 14, 17);
            Console.Write(app);

        }


    }
}
