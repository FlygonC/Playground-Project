using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public enum ItemEnum : int { RedHeart, GreenRupee, BlueRupee, }

public class ItemData : MonoBehaviour
{

    public static Dictionary<ItemEnum, Item> ItemDict = new Dictionary<ItemEnum, Item>();

    void Start()
    {
        
    }

}
