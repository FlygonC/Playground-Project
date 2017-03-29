using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

    public static Player _Player;

    public int heartContainers = 3;
    public int healthMax
    {
        get
        {
            return heartContainers * 4;
        }
    }
    public int health;

    public int rupees = 0;

    public int magic = 10;

    public SwordProperties baseSword = new SwordProperties(1, 10, 110, 3);
    public int attackDamage = 3;

    void Start ()
    {
        if (_Player != null)
        {
            Destroy(gameObject);
        }
        else
        {
            _Player = this;
            DontDestroyOnLoad(gameObject);
        }
        
	}
	
    void Update()
    {
        
    }
    

}

