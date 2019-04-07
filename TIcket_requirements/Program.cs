using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TIcket_requirements
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the number of seats:");
            int n = int.Parse(Console.ReadLine());
            List<Seat> ticketlist = new List<Seat>();
            for(int i=0;i<n;i++)
            {
                string str = Console.ReadLine();
                ticketlist.Add(Seat.CreateSeat(str));
                
            }
            Dictionary<string, int> ticketgenderlist = Seat.GenderWiseCount(ticketlist);
            foreach(var ch in ticketgenderlist)
            {
                Console.WriteLine("{0,-15}{1}", ch.Key, ch.Value);
            }
        }
    }

    class Seat
    {
        string _seatno;
        string _type;
        double _price;
        string _passengername;
        string _gender;

        public string Seatno { get => _seatno; set => _seatno = value; }
        public string Type { get => _type; set => _type = value; }
        public double Price { get => _price; set => _price = value; }
        public string Passengername { get => _passengername; set => _passengername = value; }
        public string Gender { get => _gender; set => _gender = value; }

        public Seat()
        {
            Seatno = null;Type = null; Price = 0;Passengername = null;Gender = null;
        }

        public Seat(string seatno,string type,double price,string passengername,string gender)
        {
            Seatno = seatno;Type = type;Price = price;Passengername = passengername;Gender = gender;
        }

        public static Seat CreateSeat(string detail)
        {
            string[] input = detail.Split(',');
            Seat s = new Seat(input[0], input[1], double.Parse(input[2]), input[3], input[4]);
            return s;
        }

        public static Dictionary<string,int> GenderWiseCount(List<Seat> seatList)
        {
            var GenderCount = from seat in seatList
                              group seat by seat.Gender into Genderwise
                              select new { Key=Genderwise.Key,count=Genderwise.Count()};
            Dictionary<string, int> Count = new Dictionary<string, int>();
            foreach(var ch in GenderCount)
            {
                Count.Add(ch.Key,ch.count);
            }
            return Count;

        }
    }
}
