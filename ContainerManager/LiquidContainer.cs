namespace ContainerManager;

public class LiquidContainer : Container, IHazardNotifier
{
    public LiquidContainer(double maxLoad, double height, double containerWeight, double depth, Product product) : base(
        maxLoad, height,
        containerWeight, depth, product)
    {
    }

    public void Notify(string message)
    {
        Console.WriteLine($"Warning! Dangerous liquid activity detected in container {SerialNumber}: {message}");
    }

    public override void LoadProducts(Product product, double weight)
    {
        
        if ((product.Hazardous && CargoWeight + weight > MaxLoad*0.5) || CargoWeight + weight > MaxLoad*0.9)
        {
            Console.WriteLine("Warning! This operation is dangerous, please reconsider adding lower weight.");
        }
        else
        {
            /*traktujemy mase cieczy 1:1 i pojemnosc jako masa ladunku (
            w zadaniu nie ma podanego wymagania ze kontener przechowywuje dlugosc, 
            wiec ciezko policzyc objetosc)*/
            base.LoadProducts(product, weight);
        }
    }
    
    
}