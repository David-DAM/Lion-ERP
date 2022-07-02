using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace ExampleDB_MVC_WPF.resources
{
    class useful
    {
        /// <summary>
        /// Gets the md5.
        /// </summary>
        /// <param name="str">The string.</param>
        /// <returns></returns>
        public static string GetMD5(string str)
        {
            MD5 md5 = MD5CryptoServiceProvider.Create();
            ASCIIEncoding encoding = new ASCIIEncoding();
            byte[] stream = null;
            StringBuilder sb = new StringBuilder();
            stream = md5.ComputeHash(encoding.GetBytes(str));
            for (int i = 0; i < stream.Length; i++) sb.AppendFormat("{0:x2}", stream[i]);
            return sb.ToString();
        }
        /// <summary>
        /// Computes the sha256 hash.
        /// </summary>
        /// <param name="rawData">The raw data.</param>
        /// <returns></returns>
        public static string ComputeSha256Hash(string rawData)
        {
            // Create a SHA256   
            using (SHA256 sha256Hash = SHA256.Create())
            {
                // ComputeHash - returns byte array  
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(rawData));

                // Convert byte array to a string   
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }
        /// <summary>
        /// Transforms the date.
        /// </summary>
        /// <param name="date">The date.</param>
        /// <returns></returns>
        public static string TransformDate(int date) 
        {
            String year, day, month,fdate;
            int days;
            year =Convert.ToString(date/1000);

            days = (date / 1000) % 2;

            month = Convert.ToString(days / 100);

            day = Convert.ToString( (days / 100) % 2);

            fdate = day+"/"+month+"/"+year;

            return fdate;
        }
    }
}
