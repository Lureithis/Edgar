using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PileOfStones : Obstacle
{
    [SerializeField] GameObject insanityBar;

    private InsanityBar insanityBarScript;
    private PolygonCollider2D transformCollider;

    // Start is called before the first frame update
    void Start()
    {
        insanityBarScript = insanityBar.GetComponent<InsanityBar>();
        transformCollider = GetComponent<PolygonCollider2D>();
    }

    private void Update()
    {
        Use();
    }

    public override void Use()
    {
        if(insanityBarScript.isInHallucination == true)
        {
            transformCollider.isTrigger = true;
        }
        if (insanityBarScript.isInHallucination == false)
        {
            transformCollider.isTrigger = false;
        }
    }

}
