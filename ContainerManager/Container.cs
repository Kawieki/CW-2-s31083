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
            throw new OverfillExepction("The weight is too large for this container.");
        }
        CargoWeight+=weight;
    }

    public virtual Product DeloadContainer()
    {
        Product deloadProduct = new Product(product);
        deloadProduct.Weight = CargoWeight;
        product = null;
        CargoWeight = 0;
        return deloadProduct;
    }

    public override string ToString()
    {
        return $"Container: {SerialNumber}\n" +
               $"Cargo Weight: {CargoWeight}\n" +
               $"Height: {Height}\n" +
               $"Container Weight: {ContainerWeight}\n" +
               $"Depth: {Depth}\n" +
               $"Product Type: {product.Type[0]}\n" +
               $"Max Load: {MaxLoad}";
    }
}

public class OverfillExepction(string message) : Exception(message);
