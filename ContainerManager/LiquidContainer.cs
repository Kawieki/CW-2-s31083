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
        Console.WriteLine($"Warning! Dangerous activity detected in container {SerialNumber}: {message}");
    }

    public override void LoadProducts(Product product, double weight)
    {
        
        if ((product.Hazardous && CargoWeight + weight > MaxLoad*0.5) || CargoWeight + weight > MaxLoad*0.9)
        {
          Notify("This operation is not safe for this product weight.");
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