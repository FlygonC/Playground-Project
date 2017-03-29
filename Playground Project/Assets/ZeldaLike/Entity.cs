using UnityEngine;
using System.Collections;
using System.Linq;

public class Entity : MonoBehaviour
{

    public float size = 1;

    public CircleCollider hitbox
    {
        get
        {
            return new CircleCollider(new Vector2(transform.position.x, transform.position.y), size / 2);
        }
    }

    public Vector2 EntityPosition
    {
        get
        {
            return new Vector2(transform.position.x, transform.position.y);
        }
        set
        {
            transform.position = new Vector3(value.x, value.y, transform.position.z);
        }
    }

    private SpriteRenderer _ThisSprite;
    protected SpriteRenderer ThisSprite
    {
        get
        {
            if (_ThisSprite != null)
            {
                return _ThisSprite;
            } 
            else
            {
                if (GetComponent<SpriteRenderer>())
                {
                    _ThisSprite = GetComponent<SpriteRenderer>();
                    return _ThisSprite;
                }
                else
                {
                    return null;
                }
            }
        }
    }

    public Vector2 EP = new Vector2();

    void Update()
    {
        EP = EntityPosition;
    }
}
