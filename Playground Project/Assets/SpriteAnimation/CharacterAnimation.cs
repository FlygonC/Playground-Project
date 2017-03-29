using UnityEngine;
using System.Collections;

[CreateAssetMenu(fileName = "NewSpriteAnimation", menuName = "SpriteAnim/New Char Animation", order = 1)]
public class CharacterAnimation : ScriptableObject
{
    public SpriteAnimation North;
    public SpriteAnimation East;
    public SpriteAnimation South;
    public SpriteAnimation West;

    public SpriteAnimation GetDirection(Direction dir)
    {
        switch (dir)
        {
            case Direction.North:
                return North;
            case Direction.East:
                return East;
            case Direction.South:
                return South;
            case Direction.West:
                return West;
            default:
                return South;
        }
    }
}
