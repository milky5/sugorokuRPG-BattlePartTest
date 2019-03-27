using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using sugorokuRPG_BattlePartTest;

namespace test
{
    class Program
    {
        static void Main(string[] args)
        {
            Program3 program3 = new Program3();
            program3.Test();

            Console.ReadLine();
        }
    }

    class Program3
    {
        Player player = new Player();
        Enemy enemy = new Enemy();
        List<Charactor> charactors = new List<Charactor>();
        List<IBattleable> battlers = new List<IBattleable>();


        void SetStatus()
        {
            player.level = 20;
            player.hp = 20;
            player.attackPoint = 10;
            player.defencePoint = 10;
            player.magicAttackPoint = 10;
            player.magicDefencePoint = 10;
            player.speed = 10;
            player.charactorName = "ぷれいやー";

            enemy.level = 15;
            enemy.hp = 20;
            enemy.attackPoint = 8;
            enemy.defencePoint = 8;
            enemy.magicAttackPoint = 8;
            enemy.magicDefencePoint = 8;
            enemy.speed = 8;
            enemy.charactorName = "てき";
        }

        void Sort()
        {
            //charactors.Add(player);
            //charactors.Add(enemy);

            battlers.Add(player);
            battlers.Add(enemy);

            battlers.Sort((a, b) => b.speed - a.speed);
        }

        void Lister()
        {
            Direct(battlers[0], battlers[1]);
            Direct(battlers[1], battlers[0]);
        }

        void Direct(IBattleable attacker, IBattleable defencer)
        {
            attacker.Attack();
            var damagePoint = DamagePointCalc(attacker, defencer);
            defencer.BeDamaged(damagePoint);
        }

        public void Test()
        {
            SetStatus();
            Sort();
            Lister();
        }



        public int DamagePointCalc(IBattleable attacker, IBattleable defencer)
        {
            int iryoku = 50;
            float ransu = DamageRatioGenerator();

            var damagePoint = ((attacker.level * 2 / 5 + 2) * (iryoku * attacker.attackPoint / defencer.defencePoint) / 50 + 2) * ransu;

            return (int)damagePoint;
        }

        public float DamageRatioGenerator()
        {
            Random random = new Random();
            int ransu = random.Next(0, 100);

            float ratio = 1.0f;

            if (0 <= ransu && ransu < 8)
            {
                ratio = 1.2f;
            }
            else if (8 <= ransu && ransu < 25)
            {
                ratio = 1.1f;
            }
            else if (25 <= ransu && ransu < 75)
            {
                ratio = 1.0f;
            }
            else if (75 <= ransu && ransu < 92)
            {
                ratio = 0.9f;
            }
            else if (92 <= ransu && ransu < 100)
            {
                ratio = 0.8f;
            }

            return ratio;
        }


    }
}
