using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interface_QuickSTART_20200418
{
    ////////////////////////////////////////////////////////////////////////////////////////////////
    //// A程序员写的小狗类
    //class Dog
    //{
    //    public void LikeFood()
    //    {
    //        Console.WriteLine("我是小狗，我喜欢吃肉");
    //    }
    //}
    //// B程序员写的小猫类
    //class Cat
    //{
    //    public void LikeFood()
    //    {
    //        Console.WriteLine("我是小猫，我喜欢吃鱼");
    //    }
    //}
    //// C程序员写的小猴子类
    //class Monkey
    //{
    //    public void LikeFood()
    //    {
    //        Console.WriteLine("我是小猴子，我喜欢吃香蕉");
    //    }
    //}
    //// 动物园类
    //class Zoo
    //{
    //    public void Show(Dog dog)
    //    {
    //        dog.LikeFood();
    //    }

    //    public void Show(Cat cat)
    //    {
    //        cat.LikeFood();
    //    }
    //    public void Show(Monkey monkey)
    //    {
    //        monkey.LikeFood();
    //    }
    //}
    ////////////////////////////////////////////////////////////////////////////////////////////////   
    //class Dog:Animal
    //{
    //    public override void LikeFood()//覆盖
    //    {
    //        Console.WriteLine("我是小狗，我喜欢吃肉");
    //    }
    //}
    //class Cat:Animal
    //{
    //    public override void LikeFood()//覆盖
    //    {
    //        Console.WriteLine("我是小猫，我喜欢吃鱼");
    //    }
    //}
    //class Monkey:Animal
    //{
    //    public override void LikeFood()//覆盖
    //    {
    //        Console.WriteLine("我是小猴子，我喜欢吃香蕉");
    //    }
    //}
    //class Rabbit : Animal
    //{
    //    public void FavoriteFood()//“Interface_QuickSTART_20200418.Rabbit.FavoriteFood()”: 没有找到适合的方法来重写
    //    {
    //        Console.WriteLine("我是兔子，我喜欢吃萝卜");
    //    }
    //}
    ////动物类
    //class Animal
    //{
    //    public virtual void LikeFood()//虚拟的
    //    {
    //        Console.WriteLine("我是Animal类，我喜欢吃什么呢");
    //    }
    //}
    ////动物园类
    //class Zoo
    //{
    //    public void Show(Animal animal)
    //    {
    //        animal.LikeFood();
    //    }
    //}
    ////////////////////////////////////////////////////////////////////////////////////////////////
    class Dog:Animal
    {
        public void LikeFood()
        {
            Console.WriteLine("我是小狗，我喜欢吃肉");
        }
    }
    class Cat:Animal
    {
        public void LikeFood()
        {
            Console.WriteLine("我是小猫，我喜欢吃鱼");
        }
    }
    class Monkey:Animal
    {
        public void LikeFood()
        {
            Console.WriteLine("我是小猴子，我喜欢吃香蕉");
        }
    }
    class Rabbit:Animal
    {
        public void LikeFood()
        {
            Console.WriteLine("我是兔子，我喜欢吃萝卜");
        }
    }
    //动物接口
    interface Animal
    {
        void LikeFood();
    }
    //动物园类
    class Zoo
    {
        public void Show(Animal animal)
        {
            animal.LikeFood();
        }
    }
    ////////////////////////////////////////////////////////////////////////////////////////////////
    class Program
    {
        static void Main(string[] args)
        {
            Zoo zoo = new Zoo();
            zoo.Show(new Dog());
            zoo.Show(new Cat());
            zoo.Show(new Monkey());
            zoo.Show(new Rabbit());
            Console.ReadKey();
        }
    }
}
