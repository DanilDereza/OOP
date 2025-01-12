using System;

namespace ConsoleApp1
{

    interface IQuackStrategy
    {
        void quack();
    }

    class NormalQuack : IQuackStrategy
    {
        public void quack()
        {
            Console.WriteLine("quack");
        }
    }

    class SqueakQuack : IQuackStrategy
    {
        public void quack()
        {
            Console.WriteLine("squeak");
        }
    }

    class SilentQuack : IQuackStrategy
    {
        public void quack()
        {
            Console.WriteLine("quack");
        }
    }
    interface IDisplayStrategy
    {
        void display();
    }
    class CoolDisplay: IDisplayStrategy
    {
        public void display()
        {
            Console.WriteLine("excellent duck!");
        }
    }
    class BadDisplay: IDisplayStrategy
    {
        public void display()
        {
            Console.WriteLine("brazen duck!");
        }
    }
    interface IFlyStrategy
    {
        void fly();
    }
    class FlyWithWings : IFlyStrategy
    {
        public void fly()
        {
            Console.WriteLine("I am flying duck!");
        }
    }
    class FlyNoWay: IFlyStrategy
    {
        public void fly()
        {
            Console.WriteLine("I am not flying(");
        }
    }

    interface ISwimStrategy
    {
        void swim();
    }

    class NormalSwim : ISwimStrategy
    {
        public void swim()
        {
            Console.WriteLine("angry swimming splashes");
        }
    }

    class CuteSwim : ISwimStrategy
    {
        public void swim()
        {
            Console.WriteLine("cute swimming splashes");
        }
    }

    class NoSwim : ISwimStrategy
    {
        public void swim()
        {
            Console.WriteLine("swimming is not for me");
        }
    }

    class Duck
    {
        private IQuackStrategy quackStrategy;
        private ISwimStrategy swimStrategy;
        private IFlyStrategy flyStrategy;
        private IDisplayStrategy displayStrategy;


        public Duck(IQuackStrategy quackStrategy, ISwimStrategy swimStrategy, IFlyStrategy flyStrategy, IDisplayStrategy displayStrategy)
        {
            this.quackStrategy = quackStrategy;
            this.swimStrategy = swimStrategy;
            this.flyStrategy = flyStrategy;
            this.displayStrategy = displayStrategy;

        }

        public void Quack()
        {
            quackStrategy.quack();
        }

        public void Swim()
        {
            swimStrategy.swim();
        }
        public void Fly()
        {
            flyStrategy.fly();
        }
        public void Display()
        {
            displayStrategy.display();
        }
    }


    class Program
    {
        static void TestDuck(Duck duck)
        {
            duck.Quack();
            duck.Swim();
            duck.Fly();
            duck.Display();
        }

        static void Main(string[] args)
        {
            Duck marlladDuck = new Duck(new NormalQuack(), new NormalSwim(), new FlyNoWay(), new CoolDisplay());
            Duck silentDuck = new Duck(new SilentQuack(), new NormalSwim(), new FlyNoWay(),new CoolDisplay());
            Duck rubberDuck = new Duck(new SqueakQuack(), new NormalSwim(), new FlyNoWay(), new CoolDisplay());
            Duck decuyDuck = new Duck(new NormalQuack(), new NoSwim(), new FlyWithWings(), new BadDisplay());
            Program.TestDuck(marlladDuck);
            Program.TestDuck(silentDuck);
            Program.TestDuck(rubberDuck);
            Program.TestDuck(decuyDuck);
        }
    }
}
