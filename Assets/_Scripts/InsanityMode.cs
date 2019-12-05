using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class InsanityMode : MonoBehaviour
{
    [SerializeField] GameObject normalRoom;
    [SerializeField] GameObject insanityRoom;
    [SerializeField] GameObject pendulum;
    [SerializeField] GameObject insanityBar;

    private InsanityBar insanityBarScript;
    private Renderer pendulumRend;

    // Start is called before the first frame update
    void Start()
    {
        normalRoom.SetActive(true);
        insanityRoom.SetActive(false);
        pendulumRend = pendulum.GetComponent<SpriteRenderer>();
        insanityBarScript = insanityBar.GetComponent<InsanityBar>();
        pendulumRend.enabled = false;
    }

    public InsanityBar getInsanityBarScript()
    {
        return insanityBarScript;
    }

    public void InsanityModeActivated()
    {
        normalRoom.SetActive(false);
        insanityRoom.SetActive(true);
        pendulumRend.enabled = true;
    }

    public void InsanityModeDeactivated()
    {
        normalRoom.SetActive(true);
        insanityRoom.SetActive(false);
        pendulumRend.enabled = false;
    }
}
