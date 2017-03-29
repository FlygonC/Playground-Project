using UnityEngine;
using System.Collections;

public class RupeePickup : Pickup
{

    public int amount;

    protected override void PickupEffect()
    {
        Player._Player.rupees += amount;
    }

}
