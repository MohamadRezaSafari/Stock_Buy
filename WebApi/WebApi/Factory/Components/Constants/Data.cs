namespace WebApi.Factory.Components.Constants;

public class Data
{
    public static int Seat_numberOfUnitsNeed = 1;
    public static int Wheel_numberOfUnitsNeed = 2;
    public static int Pedal_numberOfUnitsNeed = 2;
    public static int Break_numberOfUnitsNeed = 2;
    public static int Seat_stock = 50;
    public static int Pedal_stock = 60;
    public static int Break_stock = int.MaxValue;
    public static int Wheel_frames = 60;
    public static int Wheel_tubes = 35;
    public static int Wheel_minimumOfFramesAndTubes = new List<int> { Wheel_frames, Wheel_tubes }.Min();
}
