using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace acc_hotlab_private_run_compare
{
    /// <summary>
    /// This class contains formatters for the time which are being used at different points in the program. 
    /// </summary>
    public static class TimeFormatter
    {
        /// <summary>
        /// Turns an integer describing the time in miliseconds into a string representation.
        /// 
        /// Examples:
        /// -:-1:42.555 (102555 ms)
        /// -:20:42.555 (1242555 ms)
        /// 1:01:42.555 (3702555 ms)
        /// 
        /// In the code it will be represented as H:MM:SS:mmm
        /// </summary>
        /// <param name="timeInMs">The run lenght in miliseconds.</param>
        /// <returns>A string with a human readable representation for the run length.</returns>
        public static string FormatMilisecondsToHourString(int timeInMs)
        {
            int HInt = timeInMs / (1000 * 60 * 60); // H = hours (1 digit), run cannot be longer than 1 hour and a few minutes because of game logic
            int MMSSmmmRemaining = timeInMs % (1000 * 60 * 60);
            int MMInt = MMSSmmmRemaining / (1000 * 60); // MM = minutes (2 digits), always between 00 and 59 (inclusive)
            int SSmmmRemaining = timeInMs % (1000 * 60);
            int SSInt = SSmmmRemaining / 1000; //SS = seconds (2 digits), always between 00 and 59 (inclusive)
            int mmmInt = SSmmmRemaining % 1000; //mmm = miliseconds (3 digits), always between 000 and 999 (inclusive)

            //Prepare string representation
            string HString = HInt.ToString();
            string HStringFinal;

            string MMString = MMInt.ToString(); //might be only one digit
            string MMStringFinal;

            string SSString = SSInt.ToString(); //might be only one digit
            string SSStringFinal;

            string mmmString = mmmInt.ToString(); //might be only one digit
            string mmmStringFinal;


            // 0h:04m -> -:-4
            // 0h:24m -> -:24
            // 1h:04m -> 1:04
            // 1h:24m -> 1:24
            //For readability less displayed zeros
            if (HString.Equals("0"))
            {
                HStringFinal = "-";

                if (MMString.Length == 1)
                {
                    MMStringFinal = "-" + MMString;
                }
                else
                {
                    MMStringFinal = MMString;
                }
            }
            else
            {
                HStringFinal = HString;

                if (MMString.Length == 1)
                {
                    MMStringFinal = "0" + MMString;
                }
                else
                {
                    MMStringFinal = MMString;
                }
            }

            //Turn 6 seconds into 06 seconds
            if (SSString.Length == 1)
            {
                SSStringFinal = "0" + SSString;
            }
            else
            {
                SSStringFinal = SSString;
            }


            //Turn 5 miliseconds into 005 milliseconds/ turn 19 miliseconds into 019 miliseconds
            if (mmmString.Length == 1)
            {
                mmmStringFinal = "00" + mmmString;
            }
            else if (mmmString.Length == 2)
            {
                mmmStringFinal = "0" + mmmString;
            }
            else
            {
                mmmStringFinal = mmmString;
            }


            return (HStringFinal + ":" + MMStringFinal + ":" + SSStringFinal + "." + mmmStringFinal);
        }

        /// <summary>
        /// Takes an integer and turns it into the following format:
        /// m:ss:MMM
        /// Example: 1:40:412 (101412)
        /// 0:01:987 (1987)
        /// </summary>
        /// <param name="timeInMs">The time in miliseconds</param>
        /// <returns>A string displaying the time in the following format: m:ss:MMM</returns>
        public static string FormatMilisecondsToMinutesString(int timeInMs)
        {
            int minutes = timeInMs / (1000 * 60);
            int totalTimeAfterMinuteCutoff = timeInMs % (1000 * 60);
            int secondsAsInt = totalTimeAfterMinuteCutoff / 1000;
            int remainingMiliseconds = totalTimeAfterMinuteCutoff % 1000;

            //Prepare string representation
            string secondsAsRawString = secondsAsInt.ToString();
            string secondsCorrectRepresentation;

            string milisecondsAsRawString = remainingMiliseconds.ToString();
            string milisecondsCorrectRepresentation;

            //Turn 4 seconds into 04 seconds
            if (secondsAsRawString.Length == 1)
            {
                secondsCorrectRepresentation = "0" + secondsAsRawString;
            }
            else
            {
                secondsCorrectRepresentation = secondsAsRawString;
            }

            //Turn 5 miliseconds into 005 milliseconds/ turn 19 miliseconds into 019 miliseconds
            if (milisecondsAsRawString.Length == 1)
            {
                milisecondsCorrectRepresentation = "00" + milisecondsAsRawString;
            }
            else if (milisecondsAsRawString.Length == 2)
            {
                milisecondsCorrectRepresentation = "0" + milisecondsAsRawString;
            }
            else
            {
                milisecondsCorrectRepresentation = milisecondsAsRawString;
            }


            return (minutes + ":" + secondsCorrectRepresentation + "." + milisecondsCorrectRepresentation);
        }

        /// <summary>
        /// Takes an integer of the time in miliseconds and turns it into a string of the following format:
        /// m:ss:MMM
        /// m = minutes, variable length
        /// ss = seconds, alsways two digits
        /// MMM = miliseconds, always three digits
        /// </summary>
        /// <param name="timeInMs">The time in miliseconds as an integer</param>
        /// <returns></returns>
        public static string ConvertMilisecondsToMinutesString(int timeInMs)
        {
            int minutes = timeInMs / (1000 * 60);
            int totalTimeAfterMinuteCutoff = timeInMs % (1000 * 60);
            int secondsAsInt = totalTimeAfterMinuteCutoff / 1000;
            int remainingMiliseconds = totalTimeAfterMinuteCutoff % 1000;

            //Prepare string representation
            string secondsAsRawString = secondsAsInt.ToString();
            string secondsCorrectRepresentation;

            string milisecondsAsRawString = remainingMiliseconds.ToString();
            string milisecondsCorrectRepresentation;

            //Turn 4 seconds into 04 seconds
            if (secondsAsRawString.Length == 1)
            {
                secondsCorrectRepresentation = "0" + secondsAsRawString;
            }
            else
            {
                secondsCorrectRepresentation = secondsAsRawString;
            }

            //Turn 5 miliseconds into 005 milliseconds/ turn 19 miliseconds into 019 miliseconds
            if (milisecondsAsRawString.Length == 1)
            {
                milisecondsCorrectRepresentation = "00" + milisecondsAsRawString;
            }
            else if (milisecondsAsRawString.Length == 2)
            {
                milisecondsCorrectRepresentation = "0" + milisecondsAsRawString;
            }
            else
            {
                milisecondsCorrectRepresentation = milisecondsAsRawString;
            }


            return (minutes + ":" + secondsCorrectRepresentation + "." + milisecondsCorrectRepresentation);
        }


        /// <summary>
        /// Returns a string to display a time in the format of seconds.miliseconds. 
        /// Both seconds and miliseconds will always be 3 characters long.
        /// Seconds will be filled up with a whitespace character.
        /// Examples:
        /// 123456ms = "123.456"
        /// 7890ms   = "  7.890"
        /// 1001ms   = "  1.001"
        /// 
        /// </summary>
        /// <param name="timeInMS"></param>
        /// <returns></returns>
        public static string ConvertMilisecondsToThreeFixedDigitsSecondsString (int timeInMS)
        {
            int SSSInt = timeInMS / 1000;
            int MMMInt = timeInMS % 1000;

            string SSSString;
            string MMMString;

            //prepare miliseconds part
            if (MMMInt <= 999 && MMMInt >= 100)
                MMMString = MMMInt.ToString();
            else if (MMMInt <= 99 && MMMInt >= 10)
                MMMString = "0" + MMMInt.ToString(); //one whitespace
            else 
                MMMString = "00" + MMMInt.ToString(); //two whitespaces

            //Only display times up to 999.999 seconds
            if (SSSInt > 999)
                return "XXX.XXX";

            //prepare seconds part
            if (SSSInt <= 999 && SSSInt >= 100)
                SSSString = SSSInt.ToString();
            else if (SSSInt <= 99 && SSSInt >= 10)
                SSSString = " " + SSSInt.ToString(); //one whitespace
            else 
                SSSString = "  " + SSSInt.ToString(); //two whitespaces


            return SSSString + "." + MMMString;
        }
    }
}
