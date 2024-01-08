namespace WebApi.Generic.Framewok.Dto;

public class VehicleDto
{
    public int Id { get; set; }
    public required string Type { get; set; }
    public required List<ComponentDto> Components { get; set; }
}
