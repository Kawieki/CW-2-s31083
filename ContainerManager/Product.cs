namespace ContainerManager;

public class Product(string name, string type, bool hazardous)
{
    public string Name { get; init; } = name;
    public string Type { get; init; } = type;
    public bool Hazardous { get; init; } = hazardous;
    public double Weight { get; set; }

    public Product(Product other) : this(other.Name, other.Type, other.Hazardous) { }
}
