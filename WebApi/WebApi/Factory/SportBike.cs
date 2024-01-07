using WebApi.Factory.Components.Implementation;

namespace WebApi.Factory;

public class SportBike : IBikeFactory
{
    public int Build()
    {
        List<bool> bikeFactoryStatus = new();
        int createdBikes = 0;

        while (true)
        {
            var seatStatus = CreateSeat();
            var wheelStatus = CreateWheel();
            var pedalStatus = CreatePedal();
            var breakStatus = CreateBreak();

            bikeFactoryStatus.Add(seatStatus);
            bikeFactoryStatus.Add(wheelStatus);
            bikeFactoryStatus.Add(pedalStatus);
            bikeFactoryStatus.Add(breakStatus);

            if (bikeFactoryStatus.Any(i => !i))
                break;

            createdBikes++;

            bikeFactoryStatus.Clear();
        }

        return createdBikes;
    }

    public bool CreateBreak()
    {
        Break @break = new Break();

        return @break.Build();
    }

    public bool CreatePedal()
    {
        Pedal pedal = new Pedal();

        return pedal.Build();
    }

    public bool CreateSeat()
    {
        Seat seat = new Seat();

        return seat.Build();
    }

    public bool CreateWheel()
    {
        Wheel wheel = new Wheel();

        return wheel.Build();
    }
}
