using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace acc_hotlab_private_run_compare.GameListener
{
    /// <summary>
    /// Used https://github.com/mdjarv/assettocorsasharedmemory as reference (including variable names)
    /// This class is to interpret the bytes of the ACC shared static memory page
    /// Only implemented variables which are being actively used
    /// </summary>
    internal class SharedMemoryStatic
    {
        private const int SIZE_BYTES_INT = 4;
        private const int LENGTH_STRINGS = 33; //implementation size
        public char[] carModel { get; private set; }
        public char[] track {  get; private set; }
        public int sectorCount { get; private set; }


        public SharedMemoryStatic() 
        {
            carModel = new char[LENGTH_STRINGS];
            track = new char[LENGTH_STRINGS];

        }

        /// <summary>
        /// Main function to interpret the bytes from the ACC static memory page
        /// </summary>
        /// <param name="input">Byte array of the ACC static memory page</param>
        public void updateSMS(byte[] input)
        {
            const int indexCarModel = 15 * 2 + 15 * 2 + 4 + 4; //skip smVersion and acVersion
            for (int i = 0; i < LENGTH_STRINGS; i++)
            {
                carModel[i] = BitConverter.ToChar(input, indexCarModel + i * 2);
            }

            const int indexTrack = indexCarModel + 2 * LENGTH_STRINGS;
            for (int i = 0; i < LENGTH_STRINGS; i++)
            {
                track[i] = BitConverter.ToChar(input, indexTrack + i * 2);
            }

            const int indexSectorCount = indexTrack + 2 * LENGTH_STRINGS * 4 + 2; //skip playerName, playerSurname, playerNick
            sectorCount = BitConverter.ToInt32(input, indexSectorCount);
        }

        /// <summary>
        /// Turns the carModel array into a string
        /// </summary>
        /// <returns>carModel array as a string</returns>
        public String getCarModel()
        {
            StringBuilder sb = new();
            foreach (char c in carModel)
            {
                if (c != 0)
                {
                    sb.Append(c); //Only add real chars
                }
            }
            return sb.ToString();
        }

        /// <summary>
        /// Turns the track array into a string
        /// </summary>
        /// <returns>Array track array as a string</returns>
        public String getTrack()
        {
            StringBuilder sb = new();
            foreach (char c in track)
            {
                if (c != 0)
                { 
                    sb.Append(c); //Only add real chars
                }
            }
            return sb.ToString();
        }
    }
}
