using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pendulum : Obstacle
{
    [SerializeField] float speed = 10f;
    private BoxCollider2D boxCollider;
    private bool isActive;
    private Renderer pendulumLayer;

    // Start is called before the first frame update
    void Start()
    {
        isActive = false;
        isDangerous = true;
        boxCollider = GetComponent<BoxCollider2D>();
        pendulumLayer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if(isActive == false)
        {
            isActive = true;
            Use();
        }
        
    }

    public override void Use()
    {
        StartCoroutine(PendulumMovement());
    }

    IEnumerator PendulumMovement()
    {
        yield return new WaitForSecondsRealtime(speed);
        
        isDangerous = !isDangerous;
        if (isDangerous == true)
        {
            Debug.Log("Dangerous!");
            boxCollider.isTrigger = false;
           // pendulumLayer.renderingLayerMask = 0;
        }
            
        else if(isDangerous == false)
        {
            Debug.Log("Not Dangerous!");
            boxCollider.isTrigger = true;
           // pendulumLayer.renderingLayerMask = 10;
        }
        isActive = false; 
    }
}
