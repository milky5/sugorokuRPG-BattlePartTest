using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sugorokuRPG_BattlePartTest
{
    public class Enemy : Charactor, IAttackable, IDamageable
    {
        public void Attack()
        {
            Console.WriteLine("敵の攻撃！");
        }

        public void BeDamaged()
        {
            Console.WriteLine($"敵のHPが{hp}になった");
        }
    }
}
