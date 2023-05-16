using Src.Models;

namespace Src.Services.Interfaces;
public interface IDroneDeliverySolver
{
    void Initialize(List<Drone> drones, List<Location> locations);
    void Solve();
    string Print();
}
