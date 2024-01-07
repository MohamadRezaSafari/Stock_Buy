namespace WebApi.Factory.Components.Implementation;

public class Seat : IBaseComponent
{
    public bool Build()
    {
        while (Constants.Data.Seat_stock > 0)
        {
            Constants.Data.Seat_stock -= Constants.Data.Seat_numberOfUnitsNeed;

            if (Constants.Data.Seat_stock < 0)
                return false;

            return true;
        }

        return false;
    }
}
