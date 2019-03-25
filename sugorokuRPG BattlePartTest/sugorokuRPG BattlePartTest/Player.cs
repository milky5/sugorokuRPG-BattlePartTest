using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sugorokuRPG_BattlePartTest
{
    public class Player : Charactor,IAttackable, IDamageable
    {
        public string playerName;
        string haveitem;
        //List<ItemList> items;
        int money;

        public bool isActive;
        public int remainMass { get; set; }
        public bool isMoving { get; set; }
        public bool firstMass { get; set; }
        //public StoryList story { get; set; }

        private void Start()
        {
            isMoving = false;
            //firstMass = true;
            //Roll();
            //Move();
        }

        private void Update()
        {
            if (isMoving)
            {
                //通常用
                //transform.Translate(new Vector3(1f, 0, 0)*Time.deltaTime);
                //イーブイ用
                //transform.Translate(new Vector3(0, 0, 2f) * Time.deltaTime);
            }
        }

        public void Attack()
        {
            //Console.WriteLine($"{name}の攻撃");
        }

        public void BeDamaged()
        {
            //Console.WriteLine($"{name}のHPが{hp}になった。");
        }

        //public void Move()
        //{
        //    //firstMass = true;
        //    isMoving = true;
        //}

        //public void Roll()
        //{
        //    remainMass = Random.Range(1, 7);
        //    Debug.Log($"出目は{remainMass}");
        //}
    }
}
