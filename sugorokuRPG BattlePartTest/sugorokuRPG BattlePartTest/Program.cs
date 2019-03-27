using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sugorokuRPG_BattlePartTest
{
    class Program2
    {
        static void Main(string[] args)
        {
            Battle battle = new Battle();
            statuscalc statuscalc = new statuscalc();
            Player player = new Player();
            player.charactorName = "テスターちゃん";
            Enemy enemy = new Enemy();
            enemy.charactorName = "敵";

            player.level = 50;
            enemy.level = 50;
            int enemySyuzokuchi = 50;

            IBattleable battleable = new Player();

            //Playerのステータスを取得
            (int playerhp, int playerabcds) = statuscalc.PlayerCalcStatus(player.level);
            player.hp = playerhp;
            player.attackPoint = playerabcds;
            player.defencePoint = playerabcds;
            player.magicAttackPoint = playerabcds;
            player.magicDefencePoint = playerabcds;
            player.speed = playerabcds;
            //Enemyを生成、ステータスを渡す
            (int enemyhp, int enemyabcds) = statuscalc.EnemyCalcStatus(enemy.level,enemySyuzokuchi);
            enemy.hp = enemyhp;
            enemy.attackPoint = enemyabcds;
            enemy.defencePoint = enemyabcds;
            enemy.magicAttackPoint = enemyabcds;
            enemy.magicDefencePoint = enemyabcds;
            enemy.speed = enemyabcds;

            //リストに追加
            List<Charactor> charactors = new List<Charactor>();
            charactors.Add(player);
            charactors.Add(enemy);

            //素早さを判定し、早い順にリストに入れる
            /* 独自クラスのソート */
            //charactors.Sort((a, b) => b.speed - a.speed);
            //foreach (var c in charactors)
            //{
            //    Console.WriteLine(c.charactorName);
            //}

            //リスト内をループ
            while (true)
            {
                player.Attack();
                int damagePoint = statuscalc.DamagePointCalc(player, enemy);
                enemy.BeDamaged(damagePoint);

                if (enemy.hp <= 0)
                {
                    Console.WriteLine("敵が倒れた");
                    break;
                }

                Console.WriteLine();

                enemy.Attack();
                damagePoint = statuscalc.DamagePointCalc(enemy, player);
                player.BeDamaged(damagePoint);

                if (player.hp <= 0)
                {
                    Console.WriteLine("自分は倒れた");
                    break;
                }

                Console.WriteLine();
                Console.WriteLine();
            }

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
            player.attackPoint = 10;
            player.defencePoint = 10;
            player.magicAttackPoint = 10;
            player.magicDefencePoint = 10;
            player.speed = 10;
            player.charactorName = "ぷれいやー";

            enemy.level = 15;
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

        void Direct(IBattleable attacker,IBattleable defencer)
        {
            attacker.Attack();
            var damagePoint = DamagePointCalc(attacker, defencer);
            defencer.BeDamaged(damagePoint);
        }

        void Test()
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
            int ransu = Random(0, 100);

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
