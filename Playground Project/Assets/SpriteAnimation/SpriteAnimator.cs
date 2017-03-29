using UnityEngine;
using System.Collections;

[RequireComponent(typeof(SpriteRenderer))]
public class SpriteAnimator : MonoBehaviour
{
    //public SpriteAnimation[] animations;
    
    public SpriteAnimation spriteAnimation;
    public float speed = 1;


    private int currentFrame = 0;
    private int currentAnimFrameCount
    {
        get
        {
            return spriteAnimation.Frames.Length;
        }
    }
    private float frameTime = 0;

    private SpriteRenderer sprite;

    void Start()
    {
        /*if (animations.Length > 0)
        {
            currentAnimation = animations[0];
        }*/
        sprite = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (sprite != null)
        {
            if (spriteAnimation != null)
            {
                frameTime += (spriteAnimation.FPS) * speed * Time.deltaTime;
                while (frameTime > 1)
                {
                    currentFrame++;
                    if (currentFrame > currentAnimFrameCount - 1)
                    {
                        currentFrame = 0;
                    }
                    frameTime -= 1;
                }

                sprite.sprite = spriteAnimation.Frames[currentFrame];
            }
        }
    }

    public void Play(SpriteAnimation _animation)
    {
        if (spriteAnimation != _animation)
        {
            currentFrame = 0;
            sprite.sprite = _animation.Frames[0];
            spriteAnimation = _animation;
        }
        //currentAnimation = _animation;
        //sprite.sprite = _animation.Frames[0];
    }

}
