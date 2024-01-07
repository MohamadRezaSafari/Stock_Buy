namespace WebApi.Data;

// This way is called TPT in ef core

public class Bike
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int NumberOfUnitsNeed { get; set; }
}
