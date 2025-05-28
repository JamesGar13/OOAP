using System;
using System.Runtime;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ooap_lab10
{
    
    public interface IArtifact
    {
        bool Obtain(string obstacle);
        string Name { get; }
    }

    public class FlyingBoots : IArtifact
    {
        public string Name => "<Райський Сагайдак>";
        public bool Obtain(string obstacle) => obstacle == "Forest" || obstacle == "Mountain";
    }

    public class WaterAmulet : IArtifact
    {
        public string Name => "<Амулет Води>";
        public bool Obtain(string obstacle) => obstacle == "River" || obstacle == "Desert";
    }

    public class EarthGloves : IArtifact
    {
        public string Name => "<Священний Камінь>";
        public bool Obtain(string obstacle) => obstacle == "River" || obstacle == "Forest";
    }

    public class FirePotion : IArtifact
    {
        public string Name => "<Склянка Вогню>";
        public bool Obtain(string obstacle) => obstacle == "Desert" || obstacle == "Mountain";
    }


    public class Player
    {
        public string Name { get; set; }
        private readonly IArtifact Artifact1;
        private readonly IArtifact Artifact2;

        public Player(string name, IArtifact artifact1, IArtifact artifact2)
        {
            this.Name = name;
            Artifact1 = artifact1;
            Artifact2 = artifact2;
        }

        public bool Pass(string obstacle)
        {
            return Artifact1.Obtain(obstacle) || Artifact2.Obtain(obstacle);
        }

        public void ShowArtifacts()
        {
            Console.WriteLine($"{Name} has {Artifact1.Name} and {Artifact2.Name}");
        }
    }

    public static class Scenario
    {
        private static List<string> scenarios = new List<string>()

        {
            "Forest",
            "River",
            "Mountain",
            "Desert"
        };

        public static List<string> GetScenatio(int index)
        {
            return scenarios[index % scenarios.Count].Split(',').ToList();
        }
    }

        internal class Program
        {

            static void Main(string[] args)
            {
            Random random = new Random();
            Console.OutputEncoding = Encoding.UTF8;

            var char1 = new Player("Knight",new WaterAmulet(), new FirePotion());
            var char2 = new Player("Archer",new FlyingBoots(), new EarthGloves());
            
            char1.ShowArtifacts();
            char2.ShowArtifacts();

            var scenario = Scenario.GetScenatio(random.Next(4)+1);
            Console.WriteLine("Сценарій: " + string.Join("",scenario)  );





            foreach (var obstacle in scenario)
            {
                Console.WriteLine($"\nПерешкода: {obstacle}");

                Console.WriteLine($"{char1.Name} {(char1.Pass(obstacle) ? "пройшов" : "не пройшов")}.");
                Console.WriteLine($"{char2.Name} {(char2.Pass(obstacle) ? "пройшов" : "не пройшов")}.");
            }
        }


        }
    }

