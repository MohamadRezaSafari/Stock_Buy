
namespace WebApi.Factory;

public interface IBikeFactory
{
    bool CreateSeat();
    bool CreateWheel();
    bool CreatePedal();
    bool CreateBreak();
    int Build();
}