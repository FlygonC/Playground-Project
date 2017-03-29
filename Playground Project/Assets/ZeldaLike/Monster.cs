using UnityEngine;
using System.Collections;

public class Monster : ActorB
{
    
    public int damage = 1;

    public bool touchDamage = true;


    public Pickup hpick;
    public Pickup rpick;

    protected override void FixedUpdate()
    {
        if (health <= 0)
        {
            Destroy(this.gameObject);
            // Make monster dying explosion

            // if the player is full hp, drop  a rupee
            if (Player._Player.health >= Player._Player.healthMax)
            {
                Pickup newRupee = Instantiate(rpick);
                newRupee.EntityPosition = EntityPosition;
            }
            else// if the player is not full hp, drop a heart or a rupee
            {
                if (FreeRNG.CoinFlip())
                {
                    Pickup newHeart = Instantiate(hpick);
                    newHeart.EntityPosition = EntityPosition;
                }
                else
                {
                    Pickup newRupee = Instantiate(rpick);
                    newRupee.EntityPosition = EntityPosition;
                }
            }
        }

        base.FixedUpdate();

        if (touchDamage)
        {
            if (hitbox.Collision(PlayerActor._PlayerActor.hitbox))
            {
                PlayerActor._PlayerActor.GetHit(this);
                PlayerActor._PlayerActor.TakeDamage(damage);
            }
        }

    }

}
