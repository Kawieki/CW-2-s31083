namespace ContainerManager;

public abstract class Container
{
    private static int _containerID = 1;
    public double MaxLoad {get; }
    protected Product? product;
    public string SerialNumber {get; }
    public double CargoWeight { get; set; } = 0;
    public double Height { get; set; }
    public double ContainerWeight { get; set; }
    public double Depth { get; set; }
    public Container(double maxLoad, double height, double containerWeight, double depth, Product? product)
    {
        SerialNumber = "KON-" + GetType().Name[0] + "-" + _containerID++;
        Height = height;
        ContainerWeight = containerWeight;
        Depth = depth;
        MaxLoad = maxLoad;
        this.product = product;
    }

    public virtual void LoadProducts(Product product, double weight)
    {
        if (product.Type[0] != GetType().Name[0])
        {
            Console.WriteLine("Error: Product name mismatch");
            return;
        }
        
        if (weight > MaxLoad || CargoWeight+weight > MaxLoad)
        {
            throw new OverfillException("The weight is too large for this container.");
        }
        CargoWeight+=weight;
    }

    public virtual Product UnloadContainer()
    {
        Product unloadProduct = new Product(product);
        unloadProduct.Weight = CargoWeight;
        product = null;
        CargoWeight = 0;
        return unloadProduct;
    }

    public override string ToString()
    {
        return $"Container[{SerialNumber}], Cargo Weight: {CargoWeight}, Height: {Height}, Container Weight: {ContainerWeight}, Depth: {Depth}, Product Type: {product?.Type}, Product Name: {product?.Name}, Max Load: {MaxLoad}";
    }
}

public class OverfillException(string message) : Exception(message);
