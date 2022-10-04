using UnityEngine;

namespace _Scripts.Extensions
{
    public static class VectorExtensions
    {
        public static Vector2 Vector2(this Vector3 vector3)
        {
            return new Vector2(vector3.x, vector3.y);
        }
    }
}