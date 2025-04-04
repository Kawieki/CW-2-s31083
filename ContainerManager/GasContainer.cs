namespace ContainerManager;

public class GasContainer: Container, IHazardNotifier
{
    private int _pressure = 0;

    public GasContainer(double maxLoad, double height, double containerWeight, double depth, int pressure, Product product) : base(maxLoad, height,
        containerWeight, depth, product)
    {
        _pressure = pressure;
    }
    public void Notify(string message)
    {
        Console.WriteLine($"Warning! Dangerous activity detected in container {SerialNumber}: {message}");
    }
    
    public override Product UnloadContainer()
    {
        Product unloadedProduct = new Product(product);
        unloadedProduct.Weight = CargoWeight*0.95;
        product = null;
        CargoWeight *= 0.05;
        return unloadedProduct;
    }
    
}