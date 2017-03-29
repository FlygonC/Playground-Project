using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class HealthDisplayScript : MonoBehaviour
{

    public Sprite FullHeart
    {
        get
        {
            return HeartImages[4];
        }
    }
    //public Sprite ThreeHeart;
    //public Sprite HalfHeart;
    //public Sprite QuarterHeart;
    //public Sprite EmptyHeart;
    public Sprite[] HeartImages = new Sprite[5];

    public Image ImageObject;
    public Image[] images;

    int lastContainerCount = 0;

	void Start()
    {
        ResetObjects();
	}


    void Update()
    {
        if (Player._Player.heartContainers != lastContainerCount)
        {
            ResetObjects();
        }

        for (int i = 0; i < lastContainerCount; i++)
        {
            //images[i].sprite = HeartImages[Mathf.Clamp(Player._Player.health - (i * 4), 0, 4)];
            if (Player._Player.health >= (i + 1) * 4)
            {
                images[i].sprite = FullHeart;
            }
            else
            {
                images[i].sprite = HeartImages[Mathf.Max(0, Player._Player.health - (i * 4))];
            }
        }
    }

    void ResetObjects()
    {
        Image[] newImages = new Image[Player._Player.heartContainers];
        foreach (Image i in images)
        {
            Destroy(i.gameObject);
        }

        for (int i = 0; i < Player._Player.heartContainers; i++)
        {
            newImages[i] = Instantiate(ImageObject);
            newImages[i].rectTransform.SetParent(transform);
            newImages[i].rectTransform.localPosition = new Vector3(i * 30, 0, 0);
        }
        images = newImages;

        lastContainerCount = Player._Player.heartContainers;
    }
}
