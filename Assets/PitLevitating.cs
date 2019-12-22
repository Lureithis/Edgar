using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PitLevitating : Obstacle
{
    [SerializeField] GameObject player;
    [SerializeField] GameObject manager;
    [SerializeField] GameObject insanityBar;
    [SerializeField] float swimSpeed = 5f;
    [SerializeField] int gravityPull = 10;

    private Animator animator;
    private bool isSwimming;
    private Rigidbody2D playerRB;
    private InsanityBar insanityBarScript;
    private bool isInWater;
    private bool movementInWater;
    private CharacterController2D controllerChar;
    private bool RightFacing;
    private float translation;
    private Animation animationRand;

    private bool isAnimPlaying;
    private bool firstTimeEnter;

    // Start is called before the first frame update
    void Start()
    {
        firstTimeEnter = true;
        isInWater = false;
        isSwimming = false;
        playerRB = player.GetComponent<Rigidbody2D>();
        insanityBarScript = insanityBar.GetComponent<InsanityBar>();
        controllerChar = player.GetComponent<CharacterController2D>();

        animator = player.GetComponent<Animator>();
        movementInWater = false;
        RightFacing = true;
        animationRand = player.GetComponent<Animation>();
    }

    void Update()
    {
        if(insanityBarScript.isInHallucination == true)
        {
            LevitatingMovement();
        }
        
    }

    private void LevitatingMovement()
    {
        if (movementInWater == true)
        {
            float x = Input.GetAxis("Horizontal");
            float y = Input.GetAxis("Vertical");
            playerRB.velocity = new Vector3(x * swimSpeed, y * swimSpeed, 0);
            if (Input.GetKeyDown(KeyCode.A))
            {
                if (controllerChar.isFacingRight == true)
                {
                    player.GetComponent<SpriteRenderer>().flipX = true;
                    RightFacing = !RightFacing;
                }
                else
                {
                    player.GetComponent<SpriteRenderer>().flipX = false;
                    RightFacing = !RightFacing;
                }


            }

            if (Input.GetKeyDown(KeyCode.D))
            {
                if (controllerChar.isFacingRight == true)
                {
                    player.GetComponent<SpriteRenderer>().flipX = false;
                    RightFacing = !RightFacing;
                }
                else
                {
                    player.GetComponent<SpriteRenderer>().flipX = true;
                    RightFacing = !RightFacing;
                }
            }
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            if(insanityBarScript.isInHallucination == true)
            {
                if(firstTimeEnter == true)
                {
                    animator.SetTrigger("Swimming");
                }
                firstTimeEnter = false;
                isInWater = true;
                playerRB.gravityScale = gravityPull;
                player.GetComponent<PlayerMovement>().enabled = false;
                player.GetComponent<CharacterController2D>().enabled = false;
                movementInWater = true;
                RightFacing = controllerChar.isFacingRight;
            }

        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        firstTimeEnter = true;
        animator.ResetTrigger("Swimming");
        animator.Play("Poe_walking");
        isInWater = false;
        playerRB.gravityScale = 1f;
        player.GetComponent<PlayerMovement>().enabled = true;
        player.GetComponent<CharacterController2D>().enabled = true;
        movementInWater = false;
        player.GetComponent<SpriteRenderer>().flipX = false;
    }

    public override void Use()
    {
        throw new System.NotImplementedException();
    }
}

