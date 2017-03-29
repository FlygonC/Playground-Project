using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Player))]
public class PlayerActor : ActorB
{

    public static PlayerActor _PlayerActor;

    //public int heartContainers = 3;
    //public int rupees = 0;

    public float movementSpeed = 4;
    private float attackDelay = 0;
    
    public SwingingSword swordPrefab;

    public Projectile testProjectile;

    private SpriteAnimator anim;
    public CharacterAnimation idle;
    public CharacterAnimation walk;

    private Vector2 inputVector = new Vector2();
    private bool attackButton = false;
    private bool attackButton2 = false;

    void Start()
    {
        if (_PlayerActor != null)
        {
            Destroy(gameObject);
        }
        else
        {
            _PlayerActor = this;
            DontDestroyOnLoad(gameObject);
        }

        anim = GetComponent<SpriteAnimator>();
    }

    void Update()
    {
        //healthMax = heartContainers * 4;

        // Movement Input
        inputVector.x = Input.GetAxisRaw("Horizontal");
        inputVector.y = Input.GetAxisRaw("Vertical");
        inputVector = (inputVector.normalized * movementSpeed) / 60;
        // Action Input
        if (Input.GetButtonDown("Fire1") && attackDelay <= 0)
        {
            attackButton = true;
        }
        if (Input.GetButtonDown("Fire2") && attackDelay <= 0)
        {
            attackButton2 = true;
        }
    }

    protected override void FixedUpdate()
    {
        base.FixedUpdate();

        //Vector2 inputVector = new Vector2();

        if (inputVector.x == 0 && inputVector.y == 0)
        {
            anim.Play(idle.GetDirection(facing));
        }
        else
        {
            anim.Play(walk.GetDirection(facing));
        }


        if (attackDelay > 0)
        {
            inputVector *= 0;
            attackDelay -= 1;
        }
        else
        {
            if (inputVector.y > 0)
            {
                facing = Direction.North;
            }
            if (inputVector.y < 0)
            {
                facing = Direction.South;
            }
            if (inputVector.x > 0)
            {
                facing = Direction.East;
            }
            if (inputVector.x < 0)
            {
                facing = Direction.West;
            }
        }
        EntityPosition += inputVector;

        if (attackButton)
        {
            Attack();
            attackButton = false;
        }
        if (attackButton2)
        {
            //Attack();
            Projectile newShot = Instantiate(testProjectile);
            newShot.alliance = alliance;
            newShot.EntityPosition = EntityPosition;
            newShot.direction = Utility.DirectionToVector(facing);

            attackDelay = 15;

            attackButton2 = false;
        }
    }

    void Attack()
    {
        Player._Player.baseSword.damage = Player._Player.attackDamage;

        SwingingSword makeSword = Instantiate(swordPrefab);
        makeSword.properties = Player._Player.baseSword;
        makeSword.swinger = this;

        makeSword.angleDeg = ((int)facing * 90) - 90;

        //attackDelay = (sword.swingLength / 45) / sword.speed;
        attackDelay = (60 / Player._Player.baseSword.speed);
    }

    public override void TakeDamage(int amount)
    {
        //base.TakeDamage(amount);
        Player._Player.health -= amount;
    }

}