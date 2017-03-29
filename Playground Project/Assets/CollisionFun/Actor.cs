using UnityEngine;
using System.Collections;
using System.Linq;

public class Actor : MonoBehaviour
{

    public float actorWidth = 1;
    public float actorHeight = 1;

    public Vector2 ActorPosition
    {
        get
        {
            return (Vector2)transform.position;
        }
        set
        {
            transform.position = new Vector3(value.x, value.y, transform.position.z);
        }
    }

    public Vector2 velocity = new Vector2();

    Floor2D[] floors;
    Ceiling2D[] ceilings;
    Wall2D[] walls;

    public int collisionSteps = 4;

	// Use this for initialization
	void Start ()
    {
        floors = FindObjectsOfType<Floor2D>();
        walls = FindObjectsOfType<Wall2D>();
        ceilings = FindObjectsOfType<Ceiling2D>();
	}
	
	// Update is called once per frame
	void Update ()
    {

        if (velocity.y > -0.2f)
        {
            velocity.y -= 0.01f;
        }
        //velocity.y = Input.GetAxis("Vertical") * 4 * Time.deltaTime;
        

        velocity.x = Input.GetAxis("Horizontal") * 4 * Time.deltaTime;
        if (Input.GetButtonDown("Jump"))
        {
            velocity.y = 0.1f;
        }


        Vector2 newPosition = ActorPosition;
        //bool validMove = true;
        for (int i = 0; i < collisionSteps; i++)
        {
            // Move Actor one portion
            //Vector2 newVelocity = velocity;
            newPosition += (velocity / collisionSteps);

            // Get all Posible floor the actor could be colliding with
            Floor2D[] trimFloors = floors.Where(x => x.ActorPositionCheck(newPosition, actorHeight, true)).ToArray();
            // Get all Posible ceilings the actor could be colliding with
            Ceiling2D[] trimCeilings = ceilings.Where(x => x.ActorPositionCheck(newPosition, false)).ToArray();

            //bool overFloor = trimFloors.Any();
            //bool underCeiling = trimCeilings.Any();

            //bool valid = true;
            /*if (!overFloor)
            {
                //No Floors!
                Debug.Log("No Floors!");
                validMove = false;
                break;
            }
            else*///Start Collision
            {
                
                //Collide with Floors And Ceilings

                Floor2D hitFloor = FloorCollision(trimFloors, newPosition);
                if (hitFloor != null)
                {
                    velocity.y = 0;
                    newPosition.y = hitFloor.HeightAtPosition(newPosition.x);
                    /*if (CeilingCollision(trimCeilings, newPosition))
                    {
                        //Squished!
                        Debug.Log("Sqiushed!");
                        validMove = false;
                        break;
                    }*/
                }

                Ceiling2D hitCeiling = CeilingCollision(trimCeilings, newPosition);
                if (hitCeiling != null)
                {
                    velocity.y = Mathf.Min(velocity.y, 0);
                    newPosition.y = hitCeiling.HeightAtPosition(newPosition.x) - actorHeight;
                    /*if (FloorCollision(trimFloors, newPosition) != null)
                    {
                        //Squished!
                        Debug.Log("Sqiushed!");
                        validMove = false;
                        break;
                    }*/
                }
                

                // Collide with Walls

                foreach (Wall2D wall in walls)
                {
                    // If actor is inline with wall on y axis
                    if (newPosition.y > wall.basePosition.y - actorHeight && newPosition.y < wall.top)
                    {
                        if (Mathf.Abs(wall.basePosition.x - newPosition.x) < actorWidth / 2)
                        {
                            velocity.x = 0;
                            switch (wall.direction)
                            {
                                case WallDirection.Left:
                                    newPosition.x = wall.basePosition.x - actorWidth / 2;
                                    break;
                                case WallDirection.Right:
                                    newPosition.x = wall.basePosition.x + actorWidth / 2;
                                    break;
                                default:
                                    break;
                            }
                        }
                    }
                }


                // End Collision
            }
        }
        
        ActorPosition = newPosition;
        
	}

    Floor2D FloorCollision(Floor2D[] floors, Vector2 position)
    {
        foreach (Floor2D floor in floors)
        {
            float floorHeight = floor.HeightAtPosition(position.x);

            if (position.y < floorHeight && position.y > floorHeight - actorHeight)
            {
                return floor;
            }
        }
        return null;
    }
    Ceiling2D CeilingCollision(Ceiling2D[] ceilings, Vector2 position)
    {
        foreach (Ceiling2D ceiling in ceilings)
        {
            float ceilingHeight = ceiling.HeightAtPosition(position.x);

            if (position.y > ceilingHeight - actorHeight && position.y < ceilingHeight)
            {
                return ceiling;
            }
        }
        return null;
    }
}
