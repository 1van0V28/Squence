using Microsoft.Xna.Framework;

namespace Squence.Core
{
    internal interface ICollidable
    {
        Vector2 Center { get; }
        float Radius { get; }
    }
}
