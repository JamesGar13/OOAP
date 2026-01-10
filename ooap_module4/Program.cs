using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace module4
{


    public abstract class AI
    {
        public void Run()
        {
            GatherResources();
            BuildStructures();
            TrainUnits();
            Attack();
            Defend();
        }

        protected abstract void GatherResources();
        protected abstract void BuildStructures();
        protected abstract void TrainUnits();
        protected abstract void Attack();
        protected abstract void Defend();
    }


    public class HumanAI : AI
    {
        protected override void GatherResources()
        {
            Console.WriteLine("Humans gather resources themself.");
        }

        protected override void BuildStructures()
        {
            Console.WriteLine("Humans build defensive structures.");
        }

        protected override void TrainUnits()
        {
            Console.WriteLine("Humans train archers and knights.");
        }

        protected override void Attack()
        {
            Console.WriteLine("Humans prefer tactical attacks.");
        }

        protected override void Defend()
        {
            Console.WriteLine("Humans focus on defense.");
        }
    }

    public class OrcAI : AI
    {
        protected override void GatherResources()
        {
            Console.WriteLine("Orcs raid for resources.");
        }

        protected override void BuildStructures()
        {
            Console.WriteLine("Orcs build simple strong structures.");
        }

        protected override void TrainUnits()
        {
            Console.WriteLine("Orcs train brutes and berserkers.");
        }

        protected override void Attack()
        {
            Console.WriteLine("Orcs charge aggressively into battle!");
        }

        protected override void Defend()
        {
            Console.WriteLine("Orcs defend when absolutely necessary.");
        }
    }

    public class MonsterAI : AI
    {
        protected override void GatherResources()
        {
            Console.WriteLine("Wild monsters hunt for survival.");
        }

        protected override void BuildStructures()
        {
            Console.WriteLine("Wild monsters do not build structures.");
        }

        protected override void TrainUnits()
        {
            Console.WriteLine("Wild monsters multiply instinctively.");
        }

        protected override void Attack()
        {
            Console.WriteLine("Wild monsters ambush intruders!");
        }

        protected override void Defend()
        {
            Console.WriteLine("Wild monsters defend their territory viciously.");
        }
    }



    class Program
    {

        static void Main()
        {
            AI human = new HumanAI();
            AI orc = new OrcAI();
            AI monster = new MonsterAI();

            Console.WriteLine("Human AI");
            human.Run();

            Console.WriteLine("\nOrc AI");
            orc.Run();

            Console.WriteLine("\nMonster AI");
            monster.Run();
        }

       

    }


}
