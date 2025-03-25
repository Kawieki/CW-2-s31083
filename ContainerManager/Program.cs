namespace ContainerManager;

class Program
{
    static void Main(string[] args)
    {
        //Stworzenie produktow
        Product milk = new Product("Milk", "Liquid", false);
        Product oil = new Product("Oil", "Liquid", true);
        Product helium = new Product("Helium", "Gas", false);
        Product bananas = new Product("Bananas", "Fruit", false);
        Product pineapple = new Product("Chocolate", "Sweet", false);
        
        
       // Stworzenie kontenerow
       Container liquidContainer = new LiquidContainer(5000, 400, 1000, 420, milk);
       Container liquidContainer2 = new LiquidContainer(8000, 600, 1000, 420, oil);
       Container gasContainer = new GasContainer(7000, 500, 2000, 430, 997, helium);
       
       //Stworzenie statku
       ContainerShip ship = new ContainerShip();
       
       liquidContainer.LoadProducts(milk, 4000);
       liquidContainer2.LoadProducts(oil, 3400);
       
       
    }
    
}