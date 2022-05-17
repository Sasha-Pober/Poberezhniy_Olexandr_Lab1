using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.IO;
namespace Lab_1
{
    class Program
    {
        static void Main(string[] args)
        {
            string cont = default;
            Console.WriteLine("Please, insert edges of intervals.\nInterval #1: ");
            Interval a = new Interval();
            a.LeftEdge = double.Parse(Console.ReadLine());
            a.RightEdge = double.Parse(Console.ReadLine());

            Console.WriteLine("Interval #2: ");
            Interval b = new Interval();
            b.LeftEdge = double.Parse(Console.ReadLine());
            b.RightEdge = double.Parse(Console.ReadLine());

            while (cont != "end")
            {

                Console.WriteLine("Choose the option:\n1. Shift interval\n2. Deform interval\n3. Compare intervals\n4. Add intervals\n5. Substract intervals\n6. Show Lenght of interval\n7. Serialize interval to JSON\n8. Deserialize interval from JSON");

                int option = int.Parse(Console.ReadLine());
                switch (option)
                {

                    case 1:
                        Console.WriteLine("Which interval do you want to shift?(1 or 2)");
                        int dec = int.Parse(Console.ReadLine());
                        Console.WriteLine("Left or right?");
                        string ans = Console.ReadLine();
                        ans = ans.ToLower();
                        Console.WriteLine("Enter the amount of shifting: ");
                        double num = double.Parse(Console.ReadLine());
                        if (dec == 1)
                        {
                            a.Offset(ans, num);
                            Console.WriteLine($"The current interval is [{a.LeftEdge},{a.RightEdge}]");
                        }
                        else if (dec == 2)
                        {
                            b.Offset(ans, num);
                            Console.WriteLine($"The current interval is [{b.LeftEdge},{b.RightEdge}]");
                        }
                        else { Console.WriteLine("Check entered data"); }
                        break;

                    case 2:
                        Console.WriteLine("Which interval do you want to deform?(1 or 2)");
                        dec = int.Parse(Console.ReadLine());

                        Console.WriteLine("Enter the amount of deforming: ");
                        num = Convert.ToDouble(Console.ReadLine());
                        if (dec == 1)
                        {
                            Console.WriteLine($"Length before: {a.IntervalLength()}");
                            a.Distortion(num);
                            Console.WriteLine($"The current interval is [{a.LeftEdge},{a.RightEdge}]");
                            Console.WriteLine($"Length after: {a.IntervalLength()}");

                        }
                        else if (dec == 2)
                        {
                            Console.WriteLine($"Length before: {b.IntervalLength()}");
                            b.Distortion(num);
                            Console.WriteLine($"The current interval is [{b.LeftEdge},{b.RightEdge}]");
                            Console.WriteLine($"Length after: {b.IntervalLength()}");

                        }
                        else { Console.WriteLine("Check entered data"); }
                        break;

                    case 3:
                        a.Compairing(b);
                        break;

                    case 4:
                        a.Sum(b);
                        break;

                    case 5:
                        Console.WriteLine("Which intervals would you like to substract?\n 1. a - b\n2. b - a");
                        dec = int.Parse(Console.ReadLine());

                        if (dec == 1)
                        {
                            a.Substract(b);
                        }
                        else if (dec == 2)
                        {
                            b.Substract(a);
                        }
                        else { Console.WriteLine("Check entered data"); }
                        break;

                    case 6:
                        Console.WriteLine("Which interval's length would you like to be shown?( 1 or 2)");
                        dec = int.Parse(Console.ReadLine());

                        if (dec == 1)
                        {
                            Console.WriteLine($"Length is: {a.IntervalLength()}");
                        }
                        else if (dec == 2)
                        {
                            Console.WriteLine($"Length is: {b.IntervalLength()}");
                        }
                        else { Console.WriteLine("Check entered data"); }
                        break;

                    case 7:
                        string str = default;
                        Console.WriteLine("Which interval would you like to be serialized?( 1 or 2)");
                        dec = int.Parse(Console.ReadLine());
                        if (dec == 1)
                        {
                            str = JsonConvert.SerializeObject(a);
                        }
                        else if (dec == 2)
                        {
                            str = JsonConvert.SerializeObject(b);
                        }
                        else { Console.WriteLine("Check entered data"); }
                        
                        File.WriteAllText("Data.json", str);
                        break;

                    case 8:
                        string jsonstr = File.ReadAllText("Data.json");
                        Console.WriteLine("Which interval would you like to be deserialized?( 1 or 2)");
                        dec = int.Parse(Console.ReadLine());
                        Interval c = JsonConvert.DeserializeObject<Interval>(jsonstr);
                        if (dec == 1)
                        {
                            a.LeftEdge = c.LeftEdge;
                            a.RightEdge = c.RightEdge;
                            Console.WriteLine($"The current interval is [{a.LeftEdge},{a.RightEdge}]");
                        }
                        else if (dec == 2)
                        {
                            b.LeftEdge = c.LeftEdge;
                            b.RightEdge = c.RightEdge;
                            Console.WriteLine($"The current interval is [{b.LeftEdge},{b.RightEdge}]");
                        }
                        else { Console.WriteLine("Check entered data"); }

                        break;

                    default:
                        Console.WriteLine("Returning to menu...");
                        break;

                }
                Console.WriteLine("Type end for exit");
                cont = Console.ReadLine();
            }
        }
    }
}
