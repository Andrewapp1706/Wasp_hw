using System;
using System.Runtime.ConstrainedExecution;

namespace P_1
{   
    class Program
    {   
        class car
        {
            protected string label;
            protected int ratata;
            protected int year;
            public car (string l, int r, int y)
            {
                label = l;
                ratata = r;
                year = y;
            }
            public override string ToString()
            {
                string s =(label + ratata + year);
                return s;
            }
        }
        class Pascar : car
        {
            protected int numpas;
            Dictionary <string,int> service = new Dictionary <string, int>();
            public Pascar (string l, int r, int y, int nump)
                : base (l,r,y)
            {
                numpas = nump;
            }

            public void remont(string s, int y)
            {
                service.Add(s,y);
            }
            public override string ToString()
            {
                string s = (label + ratata + year + numpas);
                return s;
            }
            public int zapchast(string s)
            {
                return service[s];
            }
            public void book()
            {
                foreach (var pascar in service)
                {
                    Console.WriteLine($"Название: {pascar.Key} год замены {pascar.Value}");
                }
            }
        }
        class Truck : car
        {
            protected int lift;
            protected string driver;
            Dictionary<string, int> gruz = new Dictionary<string, int>();
            public Truck (string l, int r, int y, int lift_, string driver_)
                : base(l, r, y)
            {
                lift = lift_;
                driver = driver_;
            }
            public void set_driver(string d)
            {
                driver = d;
            }
            public void zagruzka(string n, int g)
            {
                gruz.Add(n, g);
            }
            public void book()
            {
                foreach (var Truck in gruz)
                {
                    Console.WriteLine($"Груз номер {Truck.Key} с весом {Truck.Value}");
                }
            }
            public override string ToString()
            {
                string s = (label + ratata + year + lift + driver);
                return s;
            }
        }
        class Autopark
        {
            string label;
            protected List<car> carpark = new List<car>();
            public Autopark(string label, List <car> carpark)
            {
                this.label = label;
                this.carpark = carpark;
            }
            public override string ToString()
            {
                string s="";
                foreach (var i in carpark)
                {
                    Console.WriteLine(i.ToString() + "\n");
                }
                return s;
            }
        }
        public static void Main(string[] args)
        {
            //car[] spiscars = new car[5];
            //Autopark park1("Тыртыр", spiscars);
            Truck kamaz = new Truck("Kamaz", 560, 2005, 5000, "Mihalich");
            Pascar zhiga = new Pascar("2107", 74, 2011, 5);
            Pascar lancer = new Pascar("Lancer", 118, 2016, 5);
            List<car> carpark = new List<car>(); 
            carpark.Add(kamaz);
            carpark.Add(zhiga);
            carpark.Add(lancer);
            Autopark taxi = new Autopark("bubu", carpark);
            //string s = taxi.ToString();
            Console.Write(taxi);
        }
    }
}
