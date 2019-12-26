using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PitLevitating : Obstacle
{
    [SerializeField] GameObject player;
    [SerializeField] GameObject manager;
    [SerializeField] GameObject insanityBar;
    [SerializeField] float flyingSpeed = 5f;
    [SerializeField] int gravityPull = 10;

    [SerializeField] GameObject cross01;
    [SerializeField] GameObject cross02;

    private Animator animator;
    private bool isSwimming;
    private Rigidbody2D playerRB;
    private InsanityBar insanityBarScript;
    private bool isInAir;
    private bool movementInAir;
    private CharacterController2D controllerChar;
    private bool RightFacing;
    private float translation;
    private Animation animationRand;

    private Collider2D cross01COL;
    private Collider2D cross02COL;

    private bool isAnimPlaying;
    private BoxCollider2D colliderBOX;
    // Start is called before the first frame update
    void Start()
    {
        isInAir = false;
        isSwimming = false;
        playerRB = player.GetComponent<Rigidbody2D>();
        insanityBarScript = insanityBar.GetComponent<InsanityBar>();
        controllerChar = player.GetComponent<CharacterController2D>();
        colliderBOX = GetComponent<BoxCollider2D>();

        animator = player.GetComponent<Animator>();
        movementInAir = false;
        RightFacing = true;
        animationRand = player.GetComponent<Animation>();

        cross01COL = cross01.GetComponent<Collider2D>();
        cross02COL = cross02.GetComponent<Collider2D>();
    }

    void Update()
    {
        if(insanityBarScript.isInHallucination == true)
        {
            colliderBOX.size = new Vector2(16.3f, colliderBOX.size.y);
            LevitatingMovement();
            if(cross01COL.isTrigger == true && cross02COL.isTrigger == true)
            {
                cross01COL.isTrigger = false;
                cross02COL.isTrigger = false;
            }

        }
        else if (colliderBOX.size.x != 9 && insanityBarScript.isInHallucination == false)
        {
            colliderBOX.size = new Vector2(9f, colliderBOX.size.y);
            if (cross01COL.isTrigger == false && cross02COL.isTrigger == false)
            {
                cross01COL.isTrigger = true;
                cross02COL.isTrigger = true;
            }
        }
        
    }

    private void LevitatingMovement()
    {
        if (movementInAir == true)
        {
            float x = Input.GetAxis("Horizontal");
            float y = Input.GetAxis("Vertical");
            playerRB.velocity = new Vector3(x * flyingSpeed, y * flyingSpeed, 0);
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
                animator.Play("Poe_levitating");
                isInAir = true;
                playerRB.gravityScale = gravityPull;
                player.GetComponent<PlayerMovement>().enabled = false;
                player.GetComponent<CharacterController2D>().enabled = false;
                movementInAir = true;
                RightFacing = controllerChar.isFacingRight;
            }
            else
            {
                if(manager.GetComponent<GameOver>().isPlayerDead == false)
                {
                    playerRB.gravityScale = 1f;
                    animator.Play("Poe_fallingLOOP");
                    player.GetComponent<PlayerMovement>().enabled = true;
                    player.GetComponent<CharacterController2D>().enabled = true;
                }
                
            }

        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        //animator.ResetTrigger("isLevitating");
        animator.Play("Poe_walking");
        isInAir = false;
        playerRB.gravityScale = 1f;
        player.GetComponent<PlayerMovement>().enabled = true;
        player.GetComponent<CharacterController2D>().enabled = true;
        movementInAir = false;
        player.GetComponent<SpriteRenderer>().flipX = false;
    }

    public override void Use()
    {
        throw new System.NotImplementedException();
    }
}

