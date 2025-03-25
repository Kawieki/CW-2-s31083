namespace ContainerManager;

public class LiquidContainer : Container, IHazardNotifier
{
    public void Notify(string message)
    {
        Console.WriteLine($"Warning! Dangerous activity detected in container {SerialNumber}: {message}");
    }
}