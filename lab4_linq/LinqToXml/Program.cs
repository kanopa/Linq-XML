using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace LinqToXml
{
    class Program
    {
        static void Main(string[] args)
        {
            XDocument document = new XDocument();
            OperationsXml operationsXml = new OperationsXml();
            bool flag = true;
            string key;

            while(flag)
            {
                Console.WriteLine("1. Создать xml документ");
                Console.WriteLine("2. Вывести xml документ на экран");
                Console.WriteLine("3. Linq to xml");
                Console.WriteLine("4. Изменить xml файл");
                Console.WriteLine("5. Удалить элемент");
                Console.WriteLine("6. Добавить элемент в файл");
                Console.WriteLine("7. Выход\n");
                Console.WriteLine("Ввод: ");
                key = Console.ReadLine();
                Console.Clear();
                switch (key)
                {
                    case "1":
                        try
                        {
                            operationsXml.CreateXml(document);
                            Console.WriteLine(document);
                        }
                        catch
                        {
                            Console.WriteLine("Нельзя пересоздать файл, нарушится структура");
                        }
                        Console.ReadKey();
                        break;
                    case "2":
                        try
                        {
                            operationsXml.OutputXml(document);
                        }
                        catch
                        {
                            operationsXml.AddOutput();
                            XDocument xDocument = XDocument.Load("teams.xml");
                            operationsXml.OutputXml(xDocument);
                        }
                        Console.ReadKey();
                        break;
                    case "3":
                        try
                        {
                            operationsXml.LinqXml(document);
                        }
                        catch
                        {
                            operationsXml.AddOutput();
                            XDocument xDocument = XDocument.Load("teams.xml");
                            operationsXml.LinqXml(xDocument);
                        }
                        Console.ReadKey();
                        break;
                    case "4":
                        string temp;
                        Console.WriteLine("Введите значение с файла");
                        temp = Console.ReadLine();
                        try
                        {
                            operationsXml.UpdateXml(document,temp);
                        }
                        catch
                        {
                            operationsXml.AddOutput();
                            XDocument xDocument = XDocument.Load("teams.xml");
                            operationsXml.UpdateXml(xDocument,temp);
                        }
                        Console.ReadKey();
                        break;
                    case "5":
                        string temp1;
                        Console.WriteLine("Введите значение с файла");
                        temp1 = Console.ReadLine();
                        try
                        {
                            operationsXml.DeleteXml(document, temp1);
                        }
                        catch
                        {
                            operationsXml.AddOutput();
                            XDocument xDocument = XDocument.Load("teams.xml");
                            operationsXml.DeleteXml(xDocument, temp1);
                        }
                        Console.ReadKey();
                        break;
                    case "6":
                        string name, weight, height, wage;
                        Console.WriteLine("Введите имя нового игрока");
                        name = Console.ReadLine();
                        Console.WriteLine("Введите вес нового игрока: ");
                        weight = Console.ReadLine();
                        Console.WriteLine("Введите рост нового игрока");
                        height = Console.ReadLine();
                        Console.WriteLine("Введите зароботную плату");
                        wage = Console.ReadLine();
                        try
                        {
                            operationsXml.AddXml(document, name, weight, height, wage);
                        }
                        catch
                        {
                            operationsXml.AddOutput();
                            XDocument xDocument = XDocument.Load("teams.xml");
                            operationsXml.AddXml(xDocument, name, weight, height, wage);
                        }
                        Console.ReadKey();
                        break;
                    case "7":
                        flag = false;
                        break;
                    default :
                        operationsXml.AddOutput();
                        break;
                }
                Console.Clear();
            }
        }
    }
}
