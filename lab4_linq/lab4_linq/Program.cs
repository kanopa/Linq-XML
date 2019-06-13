using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab4_linq
{
    public class Magazine
    {
        public string NameMagazine { get; set; }
        public int InfoPeriodMagazine { get; set; }
        public DateTime RealiseMagazine { get; set; }
        public int CountMagazine { get; set; }

        public Magazine(string NameMagazine, int InfoPeriodMagazine, DateTime RealiseMagazine, int CountMagazine)
        {
            this.NameMagazine = NameMagazine;
            this.InfoPeriodMagazine = InfoPeriodMagazine;
            this.RealiseMagazine = RealiseMagazine;
            this.CountMagazine = CountMagazine;
        }
    }
    public class Article
    {
        public string NameArticle { get; set; }
        public string AutorArticle { get; set; }
        public string NameMagazine { get; set; }
        public DateTime RealiseRedaction { get; set; }
        public Article(string NameArticle, string AutorArticle, string NameMagazine, DateTime RealiseRedaction)
        {
            this.NameArticle = NameArticle;
            this.AutorArticle = AutorArticle;
            this.NameMagazine = NameMagazine;
            this.RealiseRedaction = RealiseRedaction;
        }
    }

    class Program
    {
        public class Autor
        {
            public string PIB { get; set; }
            public string Organisation { get; set; }
            public Autor(string PIB, string Organisation)
            {
                this.PIB = PIB;
                this.Organisation = Organisation;
            }
        }
        static List<Autor> Autors = new List<Autor>()
        {
            new Autor("Konoplyanka D.S.","Red"),
            new Autor("Konopatskiy D.V.","ArtLebedev"),
            new Autor("Turko M.V.", "Apple"),
            new Autor("Zaginaylo E.O.", "Samsung"),
            new Autor("Kashich D.O.","FootballTrue"),
            new Autor("Kashich D.O.","FootballTrue")

        };
        static List<Autor> AutorsForGroup = new List<Autor>()
        {
            new Autor("Duda V.S.","1"),
            new Autor("Kazimir D.V.","2"),
            new Autor("Valakas M.V.", "3"),
            new Autor("Migulya E.O.", "4"),
            new Autor("Void D.O.","5"),
            new Autor("James D.O.","6")

        };
        static List<Article> Articles = new List<Article>()
        {
            new Article("BigData","Konoplyanka D.S.","Design",new DateTime(2019,06,25)),
            new Article("C#Problems","Konopatskiy D.V.","ItSphere",new DateTime(2019,10,01)),
            new Article("FinallNBA","Turko M.V.", "AboutNBA",new DateTime(2019,01,10)),
            new Article("C#Knowledge", "Zaginaylo E.O.","Education", new DateTime(2019,03,19)),
            new Article("FootballScheme","Kashich D.O.","UEFA", new DateTime(2019,08,1) )
        };
        static List<Magazine> Magazines = new List<Magazine>()
        {
            new Magazine("Data",10,new DateTime(2015,01,02),1000),
            new Magazine("C#Today",5,new DateTime(2011,04,06),500),
            new Magazine("Slam",7,new DateTime(2005,01,01),1500),
            new Magazine("C#Git",14,new DateTime(2010,02,02),200),
            new Magazine("Football",7,new DateTime(1980,03,03),3000)
        };
        static void Main(string[] args)
        {
            Console.WriteLine("Простая выборка элементов");
            Console.WriteLine("Выборка Авторов");
            var q1 = from Autor in Autors
                     select Autor;
            foreach(var item in q1)
                Console.WriteLine("PIB: {0},  Organisation:{1}",item.PIB,item.Organisation);
            Console.WriteLine(new string('-', 100));

            Console.WriteLine("Создание нового объекта анонимного типа");
            var q2 = from Autor in Autors
                     select new { PIB = Autor.PIB, Organisation = Autor.Organisation };
            foreach(var item in q2)
                Console.WriteLine("PIB: {0},  Organisation:{1}", item.PIB, item.Organisation);
            Console.WriteLine(new string('-', 100));

            Console.WriteLine("Условия");
            var q3 = from Magazine in Magazines
                     where Magazine.CountMagazine >= 1000
                     select Magazine;
            foreach(var item in q3)
                Console.WriteLine("Name Magazine: {0}, Period Magazine: {1}, Realise Magazine: {2}, Count Magazine: {3}",item.NameMagazine,item.InfoPeriodMagazine,item.RealiseMagazine,item.CountMagazine);
            Console.WriteLine(new string('-', 100));

            Console.WriteLine("Сортировка");
            var q4 = from Magazine in Magazines
                     where Magazine.CountMagazine >= 500
                     orderby Magazine.RealiseMagazine
                     select Magazine;
            foreach(var item in q4)
                Console.WriteLine("Name Magazine: {0}, Period Magazine: {1}, Realise Magazine: {2}, Count Magazine: {3}", item.NameMagazine, item.InfoPeriodMagazine, item.RealiseMagazine, item.CountMagazine);
            Console.WriteLine(new string('-', 100));

            Console.WriteLine("Join");
            var q5 = from x in Autors
                     join y in Articles
                        on x.PIB equals y.AutorArticle
                     orderby x.PIB
                     select new { X = x, Y = y };
            foreach(var x in q5)
                Console.WriteLine(x.X.PIB + "-------" + x.X.Organisation + "-------" + x.Y.NameMagazine + "-------" + x.Y.RealiseRedaction);
            Console.WriteLine(new string('-', 100));

            Console.WriteLine("Декартово произведение");
            var q6 = from x in Magazines
                     from y in Articles
                     select new { X = x, Y = y };
            foreach(var x in q6)
                Console.WriteLine(x.X.NameMagazine + "-------" + x.X.RealiseMagazine + "-------" + x.Y.AutorArticle);
            Console.WriteLine(new string('-', 100));

            Console.WriteLine("Outer join");
            var q7 = from x in Articles
                     join y in Magazines
                     on x.NameMagazine equals y.NameMagazine into temp
                     from z in temp.DefaultIfEmpty()
                     select new { X = x, Y = ((z == null) ? null : z) };
            foreach(var x in q7)
                Console.WriteLine(x.X.AutorArticle + "-------" + x.X.NameMagazine + "-------" + x.Y?.InfoPeriodMagazine);
            Console.WriteLine(new string('-', 100));

            Console.WriteLine("Distinct - неповторяющиеся значения для объектов");
            var q8 = (from x in Autors select x.PIB).Distinct();
            foreach(var x in q8)
                Console.WriteLine(x);
            Console.WriteLine(new string('-', 100));

            Console.WriteLine("Группировка");
            var q9 = from x in Autors.Union(AutorsForGroup)
                     group x by x.PIB
                     into y
                     select new { Key = y.Key, Values = y };
            foreach (var x in q9)
            {
                Console.WriteLine(x.Key);
                foreach(var z in x.Values)
                    Console.WriteLine("     " + z.PIB);
            }
            Console.WriteLine(new string('-', 100));

            Console.WriteLine("Immediate Execution - немедленное выполнение запроса, результат преобразуется в список ");
            var q10 = (from x in Autors select x).ToList();
            Console.WriteLine(q10.GetType().Name);
            Console.WriteLine(new string('-', 100));

            Console.WriteLine("Count - количество элементов");
            Console.WriteLine(Autors.Count());
            Console.WriteLine(new string('-', 100));

            Console.WriteLine("Получение элемента в заданной позиции");
            var q11 = (from x in Magazines select x).ElementAt(3);
            Console.WriteLine(q11.NameMagazine + "-------" + q11.InfoPeriodMagazine + "-------" + q11.RealiseMagazine + "-------" + q11.CountMagazine);
            Console.WriteLine(new string('-', 100));
        }
    }
}
