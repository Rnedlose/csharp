using System;
using System.IO;
using System.Text;
using Newtonsoft.Json;
using System.Collections.Generic;
using Newtonsoft.Json.Bson;

namespace Mod05Lab01
{
    class Program
    {
        static void Main(string[] args)
        {
            string personStr = File.ReadAllText("people.json");

            List<Person> PersonList = new List<Person>();

            try
            {            
               PersonList = JsonConvert.DeserializeObject<List<Person>>(personStr);
            }
            catch(Exception e)
            {
                Console.WriteLine(e);
            }

            Encoding ascii = Encoding.ASCII;
            
            Console.WriteLine("{0, -30} {1, -30} {2, -40} {3, -60}\n", "First Name", "Last Name", "Mobile", "Email");
            
            foreach (var p in PersonList)
            {

                Byte[] firstNameBytes = ascii.GetBytes(p.FirstName);
                Byte[] lastNameBytes = ascii.GetBytes(p.LastName);
                Byte[] mobileBytes = ascii.GetBytes(p.Mobile);
                Byte[] emailBytes = ascii.GetBytes(p.Email);
                StringBuilder sb1 = new StringBuilder();
                StringBuilder sb2 = new StringBuilder();               
                StringBuilder sb3 = new StringBuilder();
                StringBuilder sb4 = new StringBuilder();
                string str1;
                string str2;
                string str3;
                string str4;



                foreach (Byte b in firstNameBytes)
                {
                    sb1.AppendFormat("{0}" ,b);
                }

                str1 = sb1.ToString();
                Console.Write(str1.PadRight(30));

                foreach (Byte c in lastNameBytes)
                {
                    sb2.AppendFormat("{0}" ,c);
                }

                str2 = sb2.ToString();
                Console.Write(str2.PadRight(30));

                foreach (Byte d in mobileBytes)
                {
                    sb3.AppendFormat("{0}" ,d);
                }

                str3 = sb3.ToString();
                Console.Write(str3.PadRight(40));
                //Console.Write("          ");

                foreach (Byte e in emailBytes)
                {
                    sb4.AppendFormat("{0}" ,e);
                }

                str4 = sb4.ToString();
                Console.Write(str4.PadRight(60));

                Console.WriteLine();
            }   

        }
    }
}
