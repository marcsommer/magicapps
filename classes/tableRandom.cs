using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.IO;

 
    public partial class table
    {

        private static Random randomSeed = new Random();

        public static int randomInt(int Minimal, int Maximal)
        {
            return randomSeed.Next(Minimal, Maximal);
        }

        public static double randomDouble(int Minimal, int Maximal)
        {
            double inicial = randomSeed.Next(Minimal, Maximal);
            return inicial + randomSeed.NextDouble();
        }

        public static string randomString()
        {
           //return randomSeed.Next().ToString();
            string path = Path.GetRandomFileName();
            path = path.Replace(".", ""); // Remove period.
            return path;
        }


        public static string RandomString(int size, bool lowerCase)
        {
            // StringBuilder is faster than using strings (+=)
            StringBuilder RandStr = new StringBuilder(size);

            // Ascii start position (65 = A / 97 = a)
            int Start = (lowerCase) ? 97 : 65;

            // Add random chars
            for (int i = 0; i < size; i++)
                RandStr.Append((char)(26 * randomSeed.NextDouble() + Start));

            return RandStr.ToString();
        }
         
        /// <summary>
        /// Returns a random boolean value
        /// </summary>
        /// <returns>Random boolean value</returns>
        public static string randomBool()
        {
            bool sal = randomSeed.NextDouble() > 0.5;
            return (sf.BoolToString(sal));
        }

        /// <summary>
        /// Returns a random color
        /// </summary>
        /// <returns></returns>
        public static System.Drawing.Color randomColor()
        {
            return System.Drawing.Color.FromArgb(
                randomSeed.Next(256),
                randomSeed.Next(256),
                randomSeed.Next(256)
            );
        }


        /// <summary>
        /// Returns DateTime in the range [min, max)
        /// </summary>
        public static DateTime randomDate( )
        {
            DateTime min = DateTime.Parse("1/1/1998");
            DateTime max = DateTime.Parse("6/1/2012");

            if (max <= min)
            {
                string message = "Max must be greater than min.";
                throw new ArgumentException(message);
            }
            long minTicks = min.Ticks;
            long maxTicks = max.Ticks;
            double rn = (Convert.ToDouble(maxTicks)
               - Convert.ToDouble(minTicks)) * randomSeed.NextDouble()
               + Convert.ToDouble(minTicks);
            return new DateTime(Convert.ToInt64(rn));
        }

        /// <summary>
        /// Returns DateTime in the range [min, max)
        /// </summary>
        public static string randomDateMysql()
        {
            DateTime min = DateTime.Parse("1/1/1998");
            DateTime max = DateTime.Parse("6/1/2012");

            if (max <= min)
            {
                string message = "Max must be greater than min.";
                throw new ArgumentException(message);
            }
            long minTicks = min.Ticks;
            long maxTicks = max.Ticks;
            double rn = (Convert.ToDouble(maxTicks)
               - Convert.ToDouble(minTicks)) * randomSeed.NextDouble()
               + Convert.ToDouble(minTicks);
            DateTime dt= new DateTime(Convert.ToInt64(rn));
            return sf.fechaMysql(dt);
        }

        /// <summary>
        /// Returns TimeSpan in the range [min, max)
        /// </summary>
        public static TimeSpan Next( )
        {
            TimeSpan min = new TimeSpan(3, 0, 0);
            TimeSpan max = new TimeSpan(7, 0, 0);
            if (max <= min)
            {
                string message = "Max must be greater than min.";
                throw new ArgumentException(message);
            }

            long minTicks = min.Ticks;
            long maxTicks = max.Ticks;
            double rn = (Convert.ToDouble(maxTicks)
               - Convert.ToDouble(minTicks)) * randomSeed.NextDouble()
               + Convert.ToDouble(minTicks);
            return new TimeSpan(Convert.ToInt64(rn));
        }



    }
 
