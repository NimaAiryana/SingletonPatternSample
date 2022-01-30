using SingletonPatternSample;

Console.WriteLine("Hello, Singleton Pattern :D");

Console.WriteLine();

var database1 = Database.SingletonInstance;
var database2 = Database.SingletonInstance;
var database3 = Database.SingletonInstance;
Console.WriteLine($"{nameof(database1)} counted number: {database1.Counted}");
Console.WriteLine($"{nameof(database2)} counted number: {database2.Counted}");
Console.WriteLine($"{nameof(database3)} counted number: {database3.Counted}");
Console.WriteLine("And this is the power of singleton pattern, we created one instace of database class in all project lifecycle");

Console.WriteLine();

Console.WriteLine("Now if we do not use the singleton pattern ...");
var database4 = Database.NotSingletonInstance;
var database5 = Database.NotSingletonInstance;
var database6 = Database.NotSingletonInstance;
Console.WriteLine($"{nameof(database4)} counted number: {database4.Counted}");
Console.WriteLine($"{nameof(database5)} counted number: {database5.Counted}");
Console.WriteLine($"{nameof(database6)} counted number: {database6.Counted}");
Console.WriteLine("everytime we should create a new instance of database class to use it");

namespace SingletonPatternSample
{
    public class Person
    {
        public Person(string fullName)
        {
            FullName = fullName;
        }

        public string FullName { get; set; }
    }

    public class Database
    {
        private Database()
        {
            People = new()
            {
                new Person("Nima Airyana")
            };

            CreatedInstanceCounter++;
            Counted = CreatedInstanceCounter;
        }

        public List<Person> People { get; private set; }
        public int Counted { get; set; }

        public static int CreatedInstanceCounter { get; private set; }


        private static readonly Lazy<Database> _lazyDatabase = new Lazy<Database>(() => new Database());

        public static Database SingletonInstance => _lazyDatabase.Value; // we have ONE instance of database everytime use of this propery

        public static Database NotSingletonInstance => new(); // we create NEW instance of database everytime use of this propery
    }
}
