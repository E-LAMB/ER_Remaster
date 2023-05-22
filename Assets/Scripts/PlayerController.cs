using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public int normalspeed = 1;
    public float jumpforce = 1;
    bool isOnGround = false;
    Animator anim;

    public AudioClip music;
    public AudioSource musicPlayer;

    public bool inrush = false;
    public int rushspeed = 1;
    public float rushcooldown = 0f;
    public float maxrushcooldown = 100f; // The cooldown of a rush
    public float rushheat = 0f; // How long until the player is forced out of a rush
    public float rushheatlimit = 100f; // The upper limit to a player's heat
    public float rushlevitation = 0.0f; // The vertical distance a rush gets
    public float lastmovement = 1.0f; // The last direction the player moved in
	public float movesInt = 1.0f;
    public bool rushjump = false; // If the player used their second jump
    public bool rushjumpactive = true; // If the player is even given a rush jump
    public float rushjumpforce = 200.0f; // The force of their second jump

    public float movementValueX;

    int playerspeed = 0;

    public GameObject groundChecker;
    public LayerMask whatIsGround;

    Rigidbody2D playerObject; 

    // Start is called before the first frame update
    void Start()
    {
        playerObject = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

        musicPlayer.clip = music;
        musicPlayer.loop = true;
        musicPlayer.Play();

    }

    // Update is called once per frame 
    void Update()
    {

        movesInt = 0.0f;

        if (Input.GetKeyDown(KeyCode.LeftShift) && rushcooldown < 1)
        {
            inrush = true;
            if (rushjumpactive == true)
            {
                rushjump = true;
            }
        }
        if (Input.GetKeyUp(KeyCode.LeftShift) && inrush == true)
        {
            inrush = false;
            rushcooldown = maxrushcooldown;
            rushheat = 0;
        }

        if (rushcooldown > 0)
        {
            rushcooldown = rushcooldown - Time.deltaTime;
        }
        if (rushheat > rushheatlimit)
        {
            inrush = false;
            rushheat = 0;
            rushcooldown = maxrushcooldown;
        }

        if (inrush == true)
        {
            playerspeed = rushspeed;
            rushheat = rushheat + Time.deltaTime;
            float movementValueX = Input.GetAxis("Horizontal");
            playerObject.velocity = new Vector2 (lastmovement*playerspeed,rushlevitation);
        }   
        if (inrush == false)
        {
            playerspeed = normalspeed;
            float movementValueX = Input.GetAxis("Horizontal");
            if (movementValueX > 0)
            {
                lastmovement = 1;
            }
            if (movementValueX < 0)
            {
                lastmovement = -1;
            }
            playerObject.velocity = new Vector2 (movementValueX*playerspeed, playerObject.velocity.y);
        }

        isOnGround = Physics2D.(groundChecker.transform.position, 0.3f, whatIsGround);

        if (Input.GetKeyDown(KeyCode.Space) && isOnGround == true)
        {

            playerObject.AddForce(new Vector2(0.0f,jumpforce * 100.0f));
            anim.SetTrigger("Jumped");

        }

        if (isOnGround == true && rushjump == true)
        {
            rushjump = false;
        }

        if (Input.GetKeyDown(KeyCode.Space) && isOnGround == false && rushjump == true)
        {

            playerObject.AddForce(new Vector2(0.0f,jumpforce * rushjumpforce));
            rushjump = false;
            anim.SetTrigger("Jumped");
            rushcooldown = maxrushcooldown * 2;

        }

        movementValueX = Input.GetAxis("Horizontal");
        movesInt = movementValueX;

        anim.SetFloat("Moves", Mathf.Abs(movesInt));
        anim.SetBool("IsRushing", inrush);
        anim.SetBool("IsOnGround", isOnGround);



    }
}
