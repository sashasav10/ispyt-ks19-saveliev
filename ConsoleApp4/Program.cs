using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ConsoleApp4
{
    struct airukraine
    {
        public string reis;
        public string misto;
        public int vylitchas;
        public int vylithvul;
        public int prylitchas;
        public int prylithvul;
        public int vilno;
    }
    class airukraines
    {
        List<airukraine> airukraines1;
        string filename;
        public airukraines(string file)
        {
            if (!File.Exists(file))
            { throw new FileNotFoundException(); }
            filename = file;
            airukraines1 = new List<airukraine>();
            LoadFile();
        }
        private void LoadFile()
        {
            string[] words = File.ReadAllText(@filename).Split(' ');
            for (int i = 0; i < words.Length; i++)
            {
                airukraines1.Add(new airukraine
                {
                    reis = words[i++],
                    misto =words[i++],
                    vylitchas = Convert.ToInt32(words[i++]),
                    vylithvul = Convert.ToInt32(words[i++]),
                    prylitchas = Convert.ToInt32(words[i++]),
                    prylithvul = Convert.ToInt32(words[i++]),
                    vilno = Convert.ToInt32(words[i++])
                });

            }
        }
        public void obrach()
        {
            airukraines1 = airukraines1.ToList();
            Console.WriteLine("Введіть номер рейсу");
            string k = Console.ReadLine();

            foreach (airukraine ai in airukraines1)
            {
                if (ai.reis == k) Console.WriteLine("Час вильоту {0}:{1}", ai.vylitchas, ai.vylithvul);

            }
            Console.WriteLine("Введіть місто призначення");
            string a= Console.ReadLine();
            foreach (airukraine ai in airukraines1)
            {
                if (ai.misto == a) Console.WriteLine("Вільних місць на цей напрямок {0}",ai.vilno);

            }
            Console.WriteLine("Введіть місто призначення");
            string L = Console.ReadLine();
            foreach (airukraine ai in airukraines1)
            {
                if (ai.misto == L&&ai.prylitchas>12) Console.WriteLine("Час прильоту на цьому напрямку{0}:{1}", ai.prylitchas, ai.prylithvul);

            }
            Console.WriteLine("До 10 години вилітають наступні рейси:");
            foreach (airukraine ai in airukraines1)
            {
                if (ai.vylitchas < 10) Console.WriteLine("Рейс {0} місто {1}", ai.reis, ai.misto);

            }
        }
    }
    class Program
    {

        static void Main(string[] args)
        {
            airukraines ai = new airukraines("input.txt");
            ai.obrach();
            Console.ReadKey();
        }
    }
}
