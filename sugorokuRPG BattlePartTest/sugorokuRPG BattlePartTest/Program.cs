using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sugorokuRPG_BattlePartTest
{
    class Program
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
}
