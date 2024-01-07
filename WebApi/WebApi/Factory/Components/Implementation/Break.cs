namespace WebApi.Factory.Components.Implementation;

public class Break : IBaseComponent
{
    public bool Build()
    {
        while (Constants.Data.Break_stock > 0)
        {
            Constants.Data.Break_stock -= Constants.Data.Break_numberOfUnitsNeed;

            if (Constants.Data.Break_stock < 0)
                return false;

            return true;
        }

        return false;
    }
}
