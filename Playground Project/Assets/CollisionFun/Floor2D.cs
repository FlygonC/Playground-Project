using UnityEngine;
using System.Collections;

public class Floor2D : MonoBehaviour
{

    public Vector2 left = new Vector2();
    public Vector2 right = new Vector2();
    //public bool bottomFloor = false;

    public float floorWidth
    {
        get
        {
            return right.x - left.x;
        }
    }
    
    /// <summary>
    /// Returns true if the given Vector position is aligned with the floor.
    /// </summary>
    public bool ActorPositionCheck(Vector2 _pos, float _actorHeight = 0, bool notUnder = false)
    {
        if (notUnder)
        {
            return _pos.x > left.x && _pos.x < right.x && _pos.y > Mathf.Lerp(left.y, right.y, (_pos.x - left.x) / floorWidth) - _actorHeight;
        }
        return _pos.x > left.x && _pos.x < right.x;
    }
    /// <summary>
    /// Returns the Height of the floor at X. (For slopes.) Returns -Infinity if x is not over the floor.
    /// </summary>
    /// <param name="_x"></param>
    /// <returns></returns>
    public float HeightAtPosition(float _x)
    {
        if (_x > left.x && _x < right.x)
        {
            // Get were over/under the actor is on the floor
            float actorLerp = (_x - left.x) / floorWidth;
            // Get final floor height
            return Mathf.Lerp(left.y, right.y, actorLerp);
        }
        return -Mathf.Infinity;
    }
    
}
