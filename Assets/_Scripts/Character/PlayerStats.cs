using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour
{
    public Vector3 locationSave;
    public float insanityAmount;

    [SerializeField] Image insanityBar;
    [SerializeField] GameObject player;
    

    // Start is called before the first frame update
    void Start()
    {
        locationSave = player.transform.position;

    }

    // Update is called once per frame
    void Update()
    {
        insanityAmount = insanityBar.fillAmount;
    }
}
