namespace WebApi.Data;

public class Wheel : Bike
{
    public int Frames { get; set; }
    public int Tubes { get; set; }
    public ICollection<Stock> Stocks { get; set; }
}
