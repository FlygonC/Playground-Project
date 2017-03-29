using UnityEngine;
using System.Collections;

public class TestEnemy : ActorB {

    public ActorB target;
	// Update is called once per frame
	protected override void FixedUpdate()
    {
        base.FixedUpdate();

        /*Vector2 move = new Vector2();

        float random = (float)FreeRNG.Generate();
        float normal = random / FreeRNG.MaxUInt;
        move.x = (2.0f * normal - 1) * 0.1f;

        random = (float)FreeRNG.Generate();
        normal = random / FreeRNG.MaxUInt;
        move.y = (2.0f * normal - 1) * 0.1f;

        EntityPosition += move;*/


        foreach (ActorB i in FindObjectsOfType<ActorB>())
        {
            if (i != this)
            {
                if (hitbox.Collision(i.hitbox))
                {
                    i.GetHit(this);
                }
            }
        }

        if (target != null)
        {
            facing = Utility.VectorToDirection((target.EntityPosition - EntityPosition));
        }

	}
}
