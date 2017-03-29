using UnityEngine;
using System.Collections;


public class Pickup : Entity
{
    
    private void Update()
    {
        if (PlayerActor._PlayerActor.hitbox.Collision(hitbox))
        {
            PickupEffect();
            Destroy(gameObject);
            //Debug.Log("Pickup!");
        }
    }

    protected virtual void PickupEffect()
    {

    }

}
