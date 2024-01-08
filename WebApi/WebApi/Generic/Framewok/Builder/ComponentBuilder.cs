using WebApi.Generic.Framewok.Dto;

namespace WebApi.Generic.Framewok.Builder;

public abstract class ComponentBuilder : IGenericComponent<VehicleDto>
{
    private VehicleDto _vehicle;
    private List<StockDto> _stocks;

    public void GenerateComponent(VehicleDto vehicle)
    {
        _vehicle = new VehicleDto()
        {
            Id = vehicle.Id,
            Type = vehicle.Type,
            Components = vehicle.Components
        };
    }

    public int Build(List<StockDto> stocks)
    {
        if (_vehicle is null) return 0;

        var componenets = _vehicle.Components;
        if (componenets is null) return 0;

        _stocks = stocks;
        if (_stocks is null) return 0;

        List<int> nestedComponents = new();
        List<int> simpleComponents = new();

        foreach (var component in componenets)
        {
            if (component.HasItems)
            {
                var items = component.Items;

                foreach (var item in items)
                {
                    var findStock = _stocks.FirstOrDefault(i => i.Name == item.Key);

                    if (findStock is null)
                        continue;

                    var minimumStock = items.Select(i => i.Value).Min();
                    int createdNestedItem = 0;

                    if (nestedComponents.Any())
                    {
                        for (int i = 0; i <= nestedComponents.Min(); i++)
                        {
                            if (minimumStock < 0) break;

                            minimumStock -= component.NumberOfUnitsNeed;
                            createdNestedItem++;
                        }
                    }
                    else
                    {
                        while (true)
                        {
                            if (minimumStock < 0) break;

                            minimumStock -= component.NumberOfUnitsNeed;
                            createdNestedItem++;
                        }
                    }
                    nestedComponents.Add(createdNestedItem);
                }
            }
            else
            {
                var stock = _stocks
                    .FirstOrDefault(i => i.Name == component.Name)
                    ?.Quantity;

                if (stock is null)
                    continue;

                int createdSimpleItem = 0;

                if (simpleComponents.Any())
                {
                    for (int i = 0; i <= simpleComponents.Min(); i++)
                    {
                        stock -= component.NumberOfUnitsNeed;
                        createdSimpleItem++;

                        if (stock < 0) break;
                    }
                }
                else
                {
                    for (int i = 0; i <= nestedComponents.Min(); i++)
                    {
                        stock -= component.NumberOfUnitsNeed;
                        createdSimpleItem++;

                        if (stock < 0) break;
                    }
                }
                simpleComponents.Add(createdSimpleItem);
            }
        }

        var createdVehicles = nestedComponents.Concat(simpleComponents).Min();

        return createdVehicles;
        //LoopEnd:
        //    Console.WriteLine("Wedding over!");


        // using stocks
    }
}
