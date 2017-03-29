using UnityEngine;
using System.Collections;

public class Portal : Entity
{

    public bool exited = false;

    public Portal exit;

	// Update is called once per frame
	void Update ()
    {
	    if (exited)
        {
            if (hitbox.Collision(PlayerActor._PlayerActor.hitbox))
            {
                exited = true;
            }
            else
            {
                exited = false;
            }
        }
        else
        {
            if (PlayerActor._PlayerActor.hitbox.Collision(EntityPosition))
            {
                PlayerActor._PlayerActor.EntityPosition = exit.EntityPosition;
                exit.exited = true;
            }
        }
	}
}
