namespace ContainerManager;

public class ContainerRefrigerated: Container
{
    public double Temperature {get; set;}
    private Dictionary<string, double> _productTemperatures = new()
    {
        { "Bananas", 13.3 },
        { "Chocolate", 18 },
        { "Fish", 2 },
        { "Meat", -15 },
        { "Ice cream", -18 },
        { "Frozen pizza", -30 },
        { "Cheese", 7.2 },
        { "Sausages", 5 },
        { "Butter", 20.5 },
        { "Eggs", 19 }
    };

    
    public ContainerRefrigerated(double maxLoad, double height, double containerWeight, double depth, double temperature, Product product) : base(maxLoad, height, containerWeight, depth, product)
    {
        if (temperature < _productTemperatures[product.Name])
        {
            Temperature = _productTemperatures[product.Name];
        }
        else
        {
            Temperature = temperature;
        }
    }
    
}