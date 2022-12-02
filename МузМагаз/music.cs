using System;
using System.Collections.Generic;
using System.Runtime.ConstrainedExecution;

namespace P_1
{
    class Program
    {
        public interface Istoreitem
        {
            static double price = 30.0;
            void discountprice(int percent)
            {
                price = price * (percent/100);
            }
        }
        class disk : Istoreitem
        {
            protected string name;
            protected string genre;
            protected int burncount;
            protected int disksize;
            public disk(string n, string g)
            {
                name = n;
                genre = g;
            }
            public virtual int getsize()
            {
                return disksize;
            }
            public virtual void Burn(params string[] values) {}

        }
        class Audio : disk
        {
            protected string artist;
            protected string recordingstudio;
            protected int songnums;
            public Audio (string _artist, string _recordingstudio, int _songnums, string _name, string _genre)
                : base(_name, _genre)
            {
                artist = _artist;
                recordingstudio = _recordingstudio;
                songnums = _songnums;
            }
            public override int getsize()
            {
                return (songnums * 8);
            }
            public override void Burn (params string[] values)
            {
                burncount++;
            }
            public override string ToString()
            {
                string s = name + " " + genre + " " + artist + " " + recordingstudio + " " + songnums + " " + burncount;
                return s;
            }
        }

        class DVD : disk
        {
            protected string produser;
            protected string filmcompany;
            protected int mincount;
            public DVD (string _produser, string _filmcompany, int _mincount, string _name, string _genre)
                : base (_name, _genre)
            {
                produser = _produser;
                filmcompany = _filmcompany;
                mincount = _mincount;
            }
            public override int getsize()
            {
                return (mincount * 32);
            }
            public override void Burn(params string[] values)
            {
                burncount++;
            }
            public override string ToString()
            {
                string s = name + " " + genre + " " + produser + " " + filmcompany + " " + mincount + " " + burncount;
                return s;
            }
        }
         class Store
        {
            protected string storename;
            protected string adress;
            protected List<Audio> audios = new List<Audio>();
            protected List<DVD> dvds = new List<DVD>();

            public Store (string _storename, string _adress)
            {
                storename = _storename;
                adress = _adress;
            }
            public static Store operator +(Store a1, Audio a2)
            {
                a1.audios.Add(a2);
                return a1;
            }
            public static Store operator +(Store _a1, DVD _a2)
            {
                _a1.dvds.Add(_a2);
                return _a1;
            }
            public static Store operator -(Store a1, Audio a2)
            {
                int num = a1.audios.IndexOf(a2);
                a1.audios.RemoveAt(num);
                return a1;
            }
            public static Store operator -(Store a1, DVD a2)
            {
                int num = a1.dvds.IndexOf(a2);
                a1.audios.RemoveAt(num);
                return a1;
            }
            public override string ToString()
            {
                string s = "";
                foreach (var i in audios)
                {
                    Console.WriteLine(i.ToString());
                }
                foreach (var i in dvds)
                {
                    Console.WriteLine(i.ToString());
                }
                return s;
            }

        }

        public static void Main(string[] args)
        {
            Store magaz = new Store("Auchan","Moscow, Komsomolsky prospect, 6");
            Audio moderntalk = new Audio("Thomas Anders", "kosmostars", 7, "hits", "pop");
            Audio maksim = new Audio("Maksim", "Luzhniki", 9, "vdol dnevnikh mostov", "pop");
            Audio sabaton = new Audio("joakhim", "sweden", 16, "war to end all wars", "hard-rock");
            DVD t1 = new DVD("Luke Besson", "Warner bros.", 180, "Taxi_1", "Action");
            DVD t2 = new DVD("Luke Besson", "Warner bros.", 190, "Taxi_2", "Action");
            magaz += moderntalk;
            magaz += maksim;
            magaz += sabaton;
            magaz += t1;
            magaz += t2;
            Console.WriteLine(magaz.ToString());
            t1.Burn();
            Console.WriteLine(t1.getsize());
        }
    }
}
