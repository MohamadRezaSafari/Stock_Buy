namespace WebApi.Generic.Framewok.Dto;

public class ComponentDto
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public required int NumberOfUnitsNeed { get; set; }
    public bool HasItems { get; set; } = false;
    public List<KeyValuePair<string, int>> Items { get; set; }
}