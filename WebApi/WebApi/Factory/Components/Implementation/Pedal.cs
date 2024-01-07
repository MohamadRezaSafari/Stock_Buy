namespace WebApi.Factory.Components.Implementation;

public class Pedal : IBaseComponent
{
    public bool Build()
    {
        while (Constants.Data.Pedal_stock > 0)
        {
            Constants.Data.Pedal_stock -= Constants.Data.Pedal_numberOfUnitsNeed;

            if (Constants.Data.Pedal_stock < 0)
                return false;

            return true;
        }

        return false;
    }
}
