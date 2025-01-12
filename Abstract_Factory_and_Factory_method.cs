using System;

namespace Abstract_Factory_and_Factory_method
{
    public interface PizzaIngredientFactory
    {
        public String createDough();
        public String createSause();
        public String createCheese();
        public String[] createVeggies();
        public String createSausages();
    }

    public class NyPizzaIngredientsFactory : PizzaIngredientFactory
    {
        public String createDough()
        {
            return "ThinCrustDough";
        }

        public String createSause()
        {
            return "MarinaraSause";
        }

        public String createCheese()
        {
            return "NyCheese";
        }

        public String[] createVeggies()
        {
            String[] vegetables = { "Cucumbers", "Peppers" };
            return vegetables;
        }
        public String createSausages()
        {
            return "FreshSausage";
        }
    }

    public class ChicagoPizzaIngredientsFactory : PizzaIngredientFactory
    {
        public String createDough()
        {
            return "ThickDough";
        }

        public String createSause()
        {
            return "TomatoSause";
        }

        public String createCheese()
        {
            return "ChicagoCheese";
        }

        public String[] createVeggies()
        {
            String[] vegetables = { "Tomatoes", "Peppers" };
            return vegetables;
        }
        public String createSausages()
        {
            return "FrozenSausages";
        }
    }


    public abstract class Pizza
    {
        public String name;
        public String dough;
        public String sause;
        public String cheese;
        public String[] vegetables;
        public String sausages;

        public abstract void prepare();

        public void bake()
        {
            name += " baked";
        }

        public void cut()
        {
            name += " cut";
        }

        public void box()
        {
            name += " packed";
        }
        public void print_pizza()
        {
            Console.WriteLine(name);
        }
    }

    public class CheesePizza : Pizza
    {
        private PizzaIngredientFactory ingredientFactory;
        public CheesePizza(PizzaIngredientFactory ingredientFactory)
        {
            this.ingredientFactory = ingredientFactory;
        }

        override public void prepare()
        {
            this.name = "cheese";
            this.dough = ingredientFactory.createDough();
            this.sause = ingredientFactory.createSause();
            this.cheese = ingredientFactory.createCheese();
            this.vegetables = ingredientFactory.createVeggies();
            this.sausages = ingredientFactory.createSausages();
        }
    }

    public class PepperoniPizza : Pizza
    {
        private PizzaIngredientFactory ingredientFactory;

        public PepperoniPizza(PizzaIngredientFactory ingredientFactory)
        {
            this.ingredientFactory = ingredientFactory;
        }

        override public void prepare()
        {
            this.name = "pepperoni";
            this.dough = ingredientFactory.createDough();
            this.sause = ingredientFactory.createSause();
            this.cheese = ingredientFactory.createCheese();
            this.sausages = ingredientFactory.createSausages();
        }
    }

    public class GreekPizza : Pizza
    {
        private PizzaIngredientFactory ingredientFactory;

        public GreekPizza(PizzaIngredientFactory ingredientFactory)
        {
            this.ingredientFactory = ingredientFactory;
        }

        override public void prepare()
        {
            this.name = "greek";
            this.dough = ingredientFactory.createDough();
            this.sause = ingredientFactory.createSause();
            this.cheese = ingredientFactory.createCheese();
            this.sausages = ingredientFactory.createSausages();
        }
    }

    public abstract class PizzaStore
    {
        public Pizza orderPizza(String type)
        {
            Pizza pizza = createPizza(type);
            pizza.prepare();
            pizza.bake();
            pizza.cut();
            pizza.box();
            return pizza;
        }

        public Pizza getPizza(String type, PizzaIngredientFactory ingredientFactory)
        {
            if (type == "cheese")
            {
                return new CheesePizza(ingredientFactory);
            }
            else if (type == "greek")
            {
                return new GreekPizza(ingredientFactory);
            }
            else if (type == "pepperoni")
            {
                return new PepperoniPizza(ingredientFactory);
            }
            return null;
        }

        public abstract Pizza createPizza(String type);
    }

    public class NyPizzaStore : PizzaStore
    {
        public override Pizza createPizza(String type)
        {
            Pizza pizza = null;
            PizzaIngredientFactory ingredientFactory = new NyPizzaIngredientsFactory();
            pizza = getPizza(type, ingredientFactory);
            return pizza;
        }
    }

    public class ChicagoPizzaStore : PizzaStore
    {
        public override Pizza createPizza(String type)
        {
            Pizza pizza = null;
            PizzaIngredientFactory ingredientFactory = new ChicagoPizzaIngredientsFactory();
            pizza = getPizza(type, ingredientFactory);
            return pizza;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var PizzaStore = new NyPizzaStore();
            var newpizza = PizzaStore.orderPizza("cheese");
            newpizza.print_pizza();
        }
    }
}
