using UnityEngine;
using System.Collections;

public class HeartPickup : Pickup
{

    public int multiplier = 1;

    protected override void PickupEffect()
    {
        Player._Player.health += Mathf.Min(4 * multiplier, Player._Player.healthMax - Player._Player.health);
    }
}
