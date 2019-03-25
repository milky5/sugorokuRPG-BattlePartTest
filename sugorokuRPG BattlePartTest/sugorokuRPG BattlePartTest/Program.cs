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
            player.playerName = "テスターちゃん";
            Enemy enemy = new Enemy();

            int playerLevel = 10;
            int enemyLevel = 30;
            int enemySyuzokuchi = 40;

            //Playerのステータスを取得
            (int playerhp, int playerabcds) = statuscalc.PlayerCalcStatus(playerLevel);
            player.hp = playerhp;
            player.attackPoint = playerabcds;
            player.defencePoint = playerabcds;
            player.magicAttackPoint = playerabcds;
            player.magicDefencePoint = playerabcds;
            player.speed = playerabcds;
            //Enemyを生成、ステータスを渡す
            (int enemyhp, int enemyabcds) = statuscalc.EnemyCalcStatus(enemyLevel,enemySyuzokuchi);
            enemy.hp = enemyhp;
            enemy.attackPoint = enemyabcds;
            enemy.defencePoint = enemyabcds;
            enemy.magicAttackPoint = enemyabcds;
            enemy.magicDefencePoint = enemyabcds;
            enemy.speed = enemyabcds;

            //素早さを判定し、早い順にリストに入れる
            List<Charactor> charactors = new List<Charactor>();
            charactors.Add(player);
            charactors.Add(enemy);

            /* 独自クラスのソート */
            charactors.Sort((a, b) => b.speed - a.speed);
            foreach (var c in charactors)
            {
                Console.WriteLine(c.speed);
            }

            //リスト内をループ
            while (true)
            {
                /*ループ
                playerが敵に攻撃
                敵が防御
                →ダメージ計算

                敵がplayerに攻撃
                playerが防御
                →ダメージ計算

                もし誰かのHPが0になったら、
                0になった人の負け、

                ループ終了*/

                error;
            }

            Console.ReadLine();

        }



    }
}
