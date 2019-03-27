using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sugorokuRPG_BattlePartTest
{
    public class Enemy : Charactor, IBattleable
    {
        public int level { get; set; }
        public int hp { get; set; }
        public int attackPoint { get; set; }
        public int defencePoint { get; set; }
        public int magicAttackPoint { get; set; }
        public int magicDefencePoint { get; set; }
        public int speed { get; set; }

        public void Attack()
        {
            Console.WriteLine("敵の攻撃！");
        }

        public void BeDamaged(int damagePoint)
        {
            Console.WriteLine($"敵に{damagePoint}のダメージ");
            hp -= damagePoint;
            Console.WriteLine($"敵のHPが{hp}になった。");
        }
    }
}
