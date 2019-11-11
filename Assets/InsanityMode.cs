using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InsanityMode : MonoBehaviour
{
    [SerializeField] GameObject normalRoom;
    [SerializeField] GameObject insanityRoom;

    // Start is called before the first frame update
    void Start()
    {
        normalRoom.SetActive(true);
        insanityRoom.SetActive(false);
    }

    public void InsanityModeActivated()
    {
        normalRoom.SetActive(false);
        insanityRoom.SetActive(true);
    }

    public void InsanityModeDeactivated()
    {
        normalRoom.SetActive(true);
        insanityRoom.SetActive(false);
    }
}
