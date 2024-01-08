using WebApi.Generic.Framewok.Dto;

namespace WebApi.Generic.Framewok.Builder;

public interface IGenericComponent<T> where T : VehicleDto
{
    void GenerateComponent(T vehicle);
}
