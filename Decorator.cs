using System;

namespace Decorator
{
    public interface Beverage
    {
        public float Cost();
        public String getDescription();
    }

    public interface CondimentDecorator: Beverage
    {
        public float Cost();
        public String getDescription();
    }


    public class MilkDecorator: CondimentDecorator
    {
        Beverage wrappedObject;

        public MilkDecorator(Beverage wrappedObject)
        {
            this.wrappedObject = wrappedObject;
        }

        public float Cost()
        {
            return wrappedObject.Cost() + 27;
        }
        public String getDescription()
        {
            return wrappedObject.getDescription() + " Milk";
        }
    }

    public class MochaDecorator : CondimentDecorator
    {
        Beverage wrappedObject;

        public MochaDecorator(Beverage wrappedObject)
        {
            this.wrappedObject = wrappedObject;
        }

        public float Cost()
        {
            return wrappedObject.Cost() + 39;
        }
        public String getDescription()
        {
            return wrappedObject.getDescription() + " Mocha";
        }
    }

    public class SoyDecorator : CondimentDecorator
    {
        Beverage wrappedObject;

        public SoyDecorator(Beverage wrappedObject)
        {
            this.wrappedObject = wrappedObject;
        }

        public float Cost()
        {
            return wrappedObject.Cost() + 18;
        }
        public String getDescription()
        {
            return wrappedObject.getDescription() + " Soy";
        }
    }

    public class WhipDecorator : CondimentDecorator
    {
        Beverage wrappedObject;

        public WhipDecorator(Beverage wrappedObject)
        {
            this.wrappedObject = wrappedObject;
        }

        public float Cost()
        {
            return wrappedObject.Cost() + 52;
        }
        public String getDescription()
        {
            return wrappedObject.getDescription() + " Whipped cream";
        }
    }

    public class HouseBlend: Beverage
    {
        public float Cost()
        {
            return 120;
        }
        public String getDescription()
        {
            return "HouseBlend";
        }
    }

    public class DarkRoast : Beverage
    {
        public float Cost()
        {
            return 125;
        }
        public String getDescription()
        {
            return "DarkRoast";
        }
    }
    public class Decaf : Beverage
    {
        public float Cost()
        {
            return 80;
        }
        public String getDescription()
        {
            return "Decaf";
        }
    }
    public class Expresso : Beverage
    {
        public float Cost()
        {
            return 150;
        }
        public String getDescription()
        {
            return "Expresso";
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Beverage order = new HouseBlend();
 
            order = new MilkDecorator(order);
            order = new MochaDecorator(order);

            Console.WriteLine("Описание заказа: " + order.getDescription());
            Console.WriteLine("Стоимость заказа: " + order.Cost());
        }
    }
}
