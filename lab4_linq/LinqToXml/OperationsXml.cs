using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace LinqToXml
{
    class OperationsXml
    {
        public void CreateXml(XDocument document)
        {
            XElement TeamElement = new XElement("teams");
            XElement TeamElement1 = new XElement("team");
            XElement TeamElement2 = new XElement("team");
            XElement PlayerElement1 = new XElement("player");
            XElement PlayerElement2 = new XElement("player");
            XElement PlayerElement3 = new XElement("player");
            XElement PlayerElement4 = new XElement("player");
            XElement PlayerElement5 = new XElement("player");

            XAttribute TeamAttribute = new XAttribute("team", "Toronto Raptors");

            XAttribute NameAttribute1 = new XAttribute("name", "Kawhi Leonard");
            XAttribute NameAttribute2 = new XAttribute("name", "Kyle Lowry");
            XAttribute NameAttribute3 = new XAttribute("name", "Fred VanVleet");
            XAttribute NameAttribute4 = new XAttribute("name", "Marc Gasol");
            XAttribute NameAttribute5 = new XAttribute("name", "Pascal Siakam");

            PlayerElement1.Add(NameAttribute1);
            PlayerElement2.Add(NameAttribute2);
            PlayerElement3.Add(NameAttribute3);
            PlayerElement4.Add(NameAttribute4);
            PlayerElement5.Add(NameAttribute5);

            XElement PlayerWeight1 = new XElement("weight", "104");
            XElement PlayerWeight2 = new XElement("weight", "89");
            XElement PlayerWeight3 = new XElement("weight", "88");
            XElement PlayerWeight4 = new XElement("weight", "116");
            XElement PlayerWeight5 = new XElement("weight", "91");

            PlayerElement1.Add(PlayerWeight1);
            PlayerElement2.Add(PlayerWeight2);
            PlayerElement3.Add(PlayerWeight3);
            PlayerElement4.Add(PlayerWeight4);
            PlayerElement5.Add(PlayerWeight5);

            XElement PlayerHeight1 = new XElement("height", "201sm");
            XElement PlayerHeight2 = new XElement("height", "185sm");
            XElement PlayerHeight3 = new XElement("height", "183sm");
            XElement PlayerHeight4 = new XElement("height", "216sm");
            XElement PlayerHeight5 = new XElement("height", "206sm");

            PlayerElement1.Add(PlayerHeight1);
            PlayerElement2.Add(PlayerHeight2);
            PlayerElement3.Add(PlayerHeight3);
            PlayerElement4.Add(PlayerHeight4);
            PlayerElement5.Add(PlayerHeight5);

            XElement PlayerWage1 = new XElement("wage", "17,64 millions");
            XElement PlayerWage2 = new XElement("wage", "28,07 millions");
            XElement PlayerWage3 = new XElement("wage", "unknown");
            XElement PlayerWage4 = new XElement("wage", "19,69 millions");
            XElement PlayerWage5 = new XElement("wage", "1,196 millions");

            PlayerElement1.Add(PlayerWage1);
            PlayerElement2.Add(PlayerWage2);
            PlayerElement3.Add(PlayerWage3);
            PlayerElement4.Add(PlayerWage4);
            PlayerElement5.Add(PlayerWage5);

            TeamElement1.Add(TeamAttribute);
            TeamElement1.Add(PlayerElement1);
            TeamElement1.Add(PlayerElement2);
            TeamElement1.Add(PlayerElement3);
            TeamElement1.Add(PlayerElement4);
            TeamElement1.Add(PlayerElement5);

            TeamElement.Add(TeamElement1);
            TeamElement.Add(TeamElement2);

            document.Add(TeamElement);

            document.Save("teams.xml");
        }
        public void OutputXml(XDocument document)
        {
            foreach (XElement ElementTeam in document.Element("teams").Elements("team"))
            {
                XAttribute TeamAttributeOutput = ElementTeam.Attribute("team");
                foreach (XElement AllElements in document.Element("teams").Element("team").Elements("player"))
                {
                    XAttribute PlayerAttributeOutput = AllElements.Attribute("name");
                    XElement WeightElementOutput1 = AllElements.Element("weight");
                    XElement WeightElementOutput2 = AllElements.Element("height");
                    XElement WeightElementOutput3 = AllElements.Element("wage");

                    if (TeamAttributeOutput != null && WeightElementOutput1 != null && WeightElementOutput2 != null && WeightElementOutput3 != null)
                    {
                        Console.WriteLine(new string('-', 100));
                        Console.WriteLine("Команда: {0}", TeamAttributeOutput.Value);
                        Console.WriteLine("Имя игрока: {0}", PlayerAttributeOutput.Value);
                        Console.WriteLine("Вес: {0}", WeightElementOutput1.Value);
                        Console.WriteLine("Рост: {0}", WeightElementOutput2.Value);
                        Console.WriteLine("Зароботная плата: {0}", WeightElementOutput3.Value);
                        Console.WriteLine();
                    }
                }
                Console.WriteLine();
            }
        }
        public void LinqXml(XDocument document)
        {
            Console.WriteLine("Выборка отдельного элемента");
            Console.WriteLine(new string('-', 100));
            var q1 = from file in document.Element("teams").Elements("team")
                         //where file.Element("weight").Value == "104"
                     select file;

            foreach (var item in q1)
                Console.WriteLine(item.Attribute("team"));

            Console.WriteLine("Простая выборка элементов");
            Console.WriteLine(new string('-', 100));
            var q2 = from file in document.Element("teams").Element("team").Elements("player")
                     select file;

            foreach (var item in q2)
                Console.WriteLine("Имя игрока: {0}\nВес: {1}\nРост: {2}\nЗароботная плата: {3}\n", item.Attribute("name").Value, item.Element("weight").Value,
                    item.Element("height").Value, item.Element("wage").Value);

            Console.WriteLine("Условия");
            var q3 = from file in document.Element("teams").Element("team").Elements("player")
                     where file.Element("weight").Value == "104" || file.Element("weight").Value == "89"
                     select file;

            Console.WriteLine(new string('-', 100));
            foreach (var item in q3)
                Console.WriteLine("Имя игрока: {0}\nВес: {1}\nРост: {2}\nЗароботная плата: {3}\n", item.Attribute("name").Value, item.Element("weight").Value,
                    item.Element("height").Value, item.Element("wage").Value);

            Console.WriteLine("Сортировка");
            Console.WriteLine(new string('-', 100));
            var q4 = from file in document.Element("teams").Element("team").Elements("player")
                     orderby file.Element("height").Value
                     select file;

            foreach (var item in q4)
                Console.WriteLine("Имя игрока: {0}\nВес: {1}\nРост: {2}\nЗароботная плата: {3}\n", item.Attribute("name").Value, item.Element("weight").Value,
                    item.Element("height").Value, item.Element("wage").Value);

            Console.WriteLine("Сортировка в обратном порядке");
            Console.WriteLine(new string('-', 100));
            var q5 = from file in document.Element("teams").Element("team").Elements("player")
                     orderby file.Element("height").Value descending
                     select file;

            foreach (var item in q5)
                Console.WriteLine("Имя игрока: {0}\nВес: {1}\nРост: {2}\nЗароботная плата: {3}\n", item.Attribute("name").Value, item.Element("weight").Value,
                    item.Element("height").Value, item.Element("wage").Value);
            document.Save("teams.xml");

            Console.WriteLine("Количество игроков");
            Console.WriteLine(new string('-', 100));
            Console.WriteLine("Количество игроков: {0}", document.Element("teams").Element("team").Elements("player").Count());
        }
        public void UpdateXml(XDocument document, string temp)
        {
            foreach (XElement AllElements in document.Element("teams").Element("team").Elements("player"))
            {
                if (AllElements.Attribute("name").Value == temp)
                {
                    Console.WriteLine("Новое имя игрока: ");
                    temp = Console.ReadLine();
                    AllElements.Attribute("name").Value = temp;
                }
                else if (AllElements.Element("weight").Value == temp)
                {
                    Console.WriteLine("Новый вес игрока: ");
                    temp = Console.ReadLine();
                    AllElements.Element("weight").Value = temp;
                }
                else if (AllElements.Element("height").Value == temp)
                {
                    Console.WriteLine("Новый рост игрока: ");
                    temp = Console.ReadLine();
                    AllElements.Element("height").Value = temp;
                }
                else if (AllElements.Element("wage").Value == temp)
                {
                    Console.WriteLine("Новая зароботная плата игрока: ");
                    temp = Console.ReadLine();
                    AllElements.Element("wage").Value = temp;
                }
            }
            document.Save("teams.xml");
        }
        public void DeleteXml(XDocument document, string temp1)
        {
            foreach (XElement AllElements in document.Element("teams").Element("team").Elements("player"))
            {
                if (AllElements.Attribute("name").Value == temp1)
                {
                    AllElements.Remove();
                }
                else if (AllElements.Element("weight").Value == temp1)
                {
                    AllElements.Remove();
                }
                else if (AllElements.Element("height").Value == temp1)
                {
                    AllElements.Remove();
                }
                else if (AllElements.Element("wage").Value == temp1)
                {
                    AllElements.Remove();
                }
            }
            document.Save("teams.xml");
        }
        public void AddXml(XDocument document, string name, string weight, string height, string wage)
        {
            XElement root = document.Element("teams").Element("team");
            XElement PlayerElement5 = new XElement("player");
            XAttribute NameAttribute5 = new XAttribute("name", name);
            XElement PlayerWeight5 = new XElement("weight", weight);
            XElement PlayerHeight5 = new XElement("height", height);
            XElement PlayerWage5 = new XElement("wage", wage);

            PlayerElement5.Add(NameAttribute5);
            PlayerElement5.Add(PlayerWeight5);
            PlayerElement5.Add(PlayerHeight5);
            PlayerElement5.Add(PlayerWage5);

            root.Add(PlayerElement5);

            document.Save("teams.xml");
        }
        public void AddOutput()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Файл не создан\nЗагружаем существующий");
            Console.ResetColor();
            Console.ReadKey();
        }
    }
}
