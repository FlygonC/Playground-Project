using UnityEngine;
using System.Collections;

[System.Serializable]
public class Item
{
    public Sprite sprite;
    public virtual void Consume() { }
}
