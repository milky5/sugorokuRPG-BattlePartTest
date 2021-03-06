﻿using System;
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
        List<IBattleable> battlers = new List<IBattleable>();


        public void Test()
        {
            SetStatus();
            Sort();
            //[攻撃][魔法攻撃]がクリックされたら、どっちがクリックされたのか保持
            /*
            While的な
            OnMouseButtonDown
            攻撃　→　文字表示コルーチン
            防御　→　文字表示コルーチン
            OnMouseButtonDown
            攻撃　→　文字表示コルーチン
            防御　→　文字表示コルーチン
            OnMouseButtonDown
            攻撃　→　文字表示コルーチン
            防御　→　文字表示コルーチン
            break

            if(isEnd)
            いつもの文字表示コルーチン
            break;
            if(!isEnd)
            専用の文字表示コルーチン
            */

            Lister();
        }

        void SetStatus()
        {
            player.money = 1000;
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
            enemy.speed = 20;
            enemy.charactorName = "てき";
        }

        void Sort()
        {
            battlers.Add(player);
            battlers.Add(enemy);

            battlers.Sort((a, b) => b.speed - a.speed);
        }

        void Lister()
        {
            while (true)
            {
                (var battleStr ,var isEnd) = Direct(battlers[0], battlers[1]);
                battleStr.ForEach(n => Console.WriteLine(n));
                Console.ReadLine();
                if (isEnd) break;
                Console.Clear();

                (battleStr,isEnd) = Direct(battlers[1], battlers[0]);
                battleStr.ForEach(n => Console.WriteLine(n));
                Console.ReadLine();
                if (isEnd) break;
                Console.Clear();
            }
        }

        (List<string>, bool) Direct(IBattleable attacker, IBattleable defencer)
        {
            var attackStr = attacker.Attack();
            var damagePoint = DamagePointCalc(attacker, defencer);
            (var damageStr,var isEnd) = defencer.BeDamaged(damagePoint);

            var returnList = new List<string>();
            returnList.Add(attackStr);
            damageStr.ForEach(n => returnList.Add(n));

            if (isEnd && attacker is Player)
            {
                Player winner = attacker as Player;
                returnList.Add($"{winner.charactorName}の勝利！");
                winner.level++;
                returnList.Add($"{winner.charactorName}はレベルが1上がった！");
                Random random = new Random();
                returnList.Add($"{winner.charactorName}は報奨金として{random.Next(1000)}円もらった！");
            }
            if (isEnd && attacker is Enemy)
            {
                Player loser = defencer as Player;
                returnList.Add($"{loser.charactorName}の敗北…");
                loser.money /= 2;
                returnList.Add($"{loser.charactorName}は混乱してお金を落とした");
                returnList.Add($"{loser.charactorName}の所持金が半分の{loser.money}円になった");
            }

            return (returnList, isEnd);
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
