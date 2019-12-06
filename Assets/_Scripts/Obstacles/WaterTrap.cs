using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaterTrap : Obstacle
{
    [SerializeField] GameObject player;
    [SerializeField] GameObject manager;
    [SerializeField] GameObject insanityBar;
    [SerializeField] GameObject breathingBarObject;
    [SerializeField] float drainSpeed = 10f;

    [SerializeField] float swimSpeed = 5f;

    [SerializeField] Image breathingBar;
    private bool isSwimming;
    private Rigidbody2D playerRB;
    private InsanityBar insanityBarScript;
    private bool isInWater;
    private bool movementInWater;
    private CharacterController2D controllerChar;
    private bool RightFacing;
    
    private float translation;

    // Start is called before the first frame update
    void Start()
    {
        isInWater = false;
        isSwimming = false;
        playerRB = player.GetComponent<Rigidbody2D>();
        insanityBarScript = insanityBar.GetComponent<InsanityBar>();
        breathingBarObject.SetActive(false);
        controllerChar = player.GetComponent<CharacterController2D>();

        movementInWater = false;
        RightFacing = true;
    }


    void Update()
    {
        if (movementInWater == true)
        {
            float x = Input.GetAxis("Horizontal");
            float y = Input.GetAxis("Vertical");
            playerRB.velocity = new Vector3(x * swimSpeed, y * swimSpeed, 0);
            if(Input.GetKeyDown(KeyCode.A))
            {
                if(controllerChar.isFacingRight == true)
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

        if (insanityBarScript.isInHallucination == false && isInWater == true)
        {
            if (breathingBar.fillAmount <= 0)
            {
                manager.GetComponent<GameOver>().EndGame();
            }
            DecreaseBreath();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            breathingBarObject.SetActive(true);
            isInWater = true;
            playerRB.gravityScale = 0f;
            player.GetComponent<PlayerMovement>().enabled = false;
            player.GetComponent<CharacterController2D>().enabled = false;
            movementInWater = true;
            RightFacing = controllerChar.isFacingRight;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        isInWater = false;
        breathingBarObject.SetActive(false);
        playerRB.gravityScale = 1f;
        player.GetComponent<PlayerMovement>().enabled = true;
        player.GetComponent<CharacterController2D>().enabled = true;
        movementInWater = false;
        player.GetComponent<SpriteRenderer>().flipX = false;

        while (breathingBar.fillAmount < 1)
        {
            AddBreath();
        }
        
    }

    private void DecreaseBreath()
    {
        breathingBar.fillAmount -= (drainSpeed * Time.deltaTime);
    }

    private void AddBreath()
    {
        breathingBar.fillAmount += (drainSpeed * Time.deltaTime);
    }

    public override void Use()
    {
        throw new System.NotImplementedException();
    }
}
