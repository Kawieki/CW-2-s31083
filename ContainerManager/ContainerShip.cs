namespace ContainerManager;

public class ContainerShip(double speed, double maxContainers, double maxLoad)
{
    private double _speed = speed;
    private double _maxContainers = maxContainers;
    private double _maxLoad = maxLoad;
    private IList<Container> _containers = new List<Container>();

    public void AddContainer(Container container)
    {
        if (container.CargoWeight + container.ContainerWeight > _maxLoad || _containers.Count > _maxContainers)
        {
            Console.WriteLine("Error: Container is full");
            return;
        }
        _containers.Add(container);
    }
    
    public void AddContainer(List<Container> containers)
    {
        foreach (var container in containers)
        {
            if (container.CargoWeight + container.ContainerWeight > _maxLoad || _containers.Count > _maxContainers)
            {
                Console.WriteLine("Error: Container is full");
                return;
            }
            _containers.Add(container);
        }
    }

    public void RemoveContainer(Container container)
    {
        _containers.Remove(container);
    }


    public void ReplaceContainer(String serialNumber, Container container)
    {
        for(var i = 0; i < _containers.Count; i++)
        {
            if (_containers[i].SerialNumber == serialNumber)
            {
                if (CheckContainerCapacity(container))
                {
                    _containers[i] = container;
                    Console.WriteLine("Replaced container with serial number {0}.", _containers[i].SerialNumber);
                    return;
                }
                Console.WriteLine("Error: Container is full");
                return;
            }
        }
        Console.WriteLine($"Container {serialNumber} has not been found");
    }

    public void MoveContainer(Container container, ContainerShip ship)
    {
        if (CheckContainerCapacity(container))
        {
            ship.AddContainer(container);
            RemoveContainer(container);
        }
        else
        {
            Console.WriteLine("Error: Container is full");
        }
        
    }

    public bool CheckContainerCapacity(Container container)
    {
        return container.CargoWeight + container.ContainerWeight <= _maxLoad && _containers.Count <= _maxContainers;

    }
    
}