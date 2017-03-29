using UnityEngine;
using System.Collections;

[System.Serializable]
public class RedHeart : Item
{
    
    public override void Consume()
    {
        Player._Player.health += Mathf.Min(4, Player._Player.healthMax - Player._Player.health);
    }
}
