using System.Configuration;

namespace DetectingMemoryProblemsInDotNet
{
    class Program
    {
        static void Main(string[] args)
        {
            System.Console.WriteLine(ConfigurationManager.AppSettings["connectionStrings:cityInfoDBConnectionString"]);
            System.Console.ReadLine();
        }
    }
}
