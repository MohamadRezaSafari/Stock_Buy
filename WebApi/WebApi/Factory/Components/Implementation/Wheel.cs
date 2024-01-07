namespace WebApi.Factory.Components.Implementation;

public class Wheel : IBaseComponent
{
    public bool Build()
    {
        while (Constants.Data.Wheel_minimumOfFramesAndTubes > 0)
        {
            Constants.Data.Wheel_minimumOfFramesAndTubes
                -= Constants.Data.Wheel_numberOfUnitsNeed;

            if (Constants.Data.Wheel_minimumOfFramesAndTubes < 0)
                return false;

            return true;
        }

        return false;
    }
}
