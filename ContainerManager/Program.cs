namespace ContainerManager;

class Program
{
    static void Main(string[] args)
    {
        // Stworzenie produktów
        Product milk = new Product("Milk", "L", false);
        Product oil = new Product("Oil", "L", true);
        Product helium = new Product("Helium", "G", false);
        Product bananas = new Product("Bananas", "C", false);

        // Stworzenie kontenerów
        Container liquidContainer = new LiquidContainer(5000, 400, 1000, 420, milk);
        Container liquidContainer2 = new LiquidContainer(8000, 600, 1000, 420, oil);
        Container gasContainer = new GasContainer(7000, 500, 2000, 430, 997, helium);
        Container refrigeratedContainer = new ContainerRefrigerated(6000, 450, 1500, 400, 14, bananas);

        // Załadowanie produktów do kontenerów
        liquidContainer.LoadProducts(milk, 4000);
        liquidContainer2.LoadProducts(oil, 3400);
        gasContainer.LoadProducts(helium, 6000);
        refrigeratedContainer.LoadProducts(bananas, 3000);

        // Stworzenie statków
        ContainerShip ship1 = new ContainerShip(30, 10, 50000);
        ContainerShip ship2 = new ContainerShip(25, 5, 30000);

        // Załadowanie kontenerów na statek
        ship1.AddContainer(liquidContainer);
        ship1.AddContainer(liquidContainer2);
        ship1.AddContainer(gasContainer);
        ship1.AddContainer(refrigeratedContainer);

        // Wypisanie informacji o statku
        Console.WriteLine("Statek 1 po załadowaniu kontenerów:");
        Console.WriteLine(ship1);

        // Usunięcie kontenera ze statku
        ship1.RemoveContainer(gasContainer);
        Console.WriteLine("Statek 1 po usunięciu kontenera na gaz:");
        Console.WriteLine(ship1);

        // Rozładowanie kontenera
        Product unloadedProduct = refrigeratedContainer.UnloadContainer();
        Console.WriteLine($"Rozładowano kontener ({refrigeratedContainer.SerialNumber}) z produktami: {unloadedProduct.Name}, masa: {unloadedProduct.Weight}");
        Console.WriteLine(ship1);

        // Zastąpienie kontenera na statku
        Container newLiquidContainer = new LiquidContainer(5000, 400, 1000, 420, milk);
        newLiquidContainer.LoadProducts(milk, 4000);
        ship1.ReplaceContainer(liquidContainer.SerialNumber, newLiquidContainer);
        Console.WriteLine("Statek 1 po zastąpieniu kontenera:");
        Console.WriteLine(ship1);

        // Przeniesienie kontenera między statkami
        ship1.MoveContainer(newLiquidContainer, ship2);
        Console.WriteLine("Stan statków po przeniesieniu kontenera:");
        Console.WriteLine("Statek 1:");
        Console.WriteLine(ship1);
        Console.WriteLine("Statek 2:");
        Console.WriteLine(ship2);
    }
}