using UnityEngine;
using System.Collections;

public enum WallDirection { Left = 0, Right}

public class Wall2D : MonoBehaviour
{

    public Vector2 basePosition = new Vector2();
    public float height = 1;
    public WallDirection direction = WallDirection.Left;

	public float top
    {
        get
        {
            return basePosition.y + height;
        }
    }
}
