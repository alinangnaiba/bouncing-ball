using System.Collections.Generic;

namespace BouncingBall.GameObjects.Contract
{
    public interface IGameObject
    {
        List<Position> GetLocation();
    }
}
