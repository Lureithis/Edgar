using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMusicHallucination : MonoBehaviour
{
    [SerializeField] GameObject _InsanityBar;

    private InsanityBar insanityBarScript;
    private bool isPlaying1;
    private bool isPlaying2;
    private bool isPlaying3;

    // Start is called before the first frame update
    void Start()
    {
        isPlaying1 = false;
        isPlaying2 = false;
        isPlaying3 = false;
        insanityBarScript = _InsanityBar.GetComponent<InsanityBar>();
    }

    private void Update()
    {
        if (insanityBarScript.isInHallucination == true)
        {
            if (insanityBarScript.levelOfInsanity == 1 && isPlaying1 == false)
            {
                PlayHallucinationMusic01();
            }
            else if (insanityBarScript.levelOfInsanity == 2 && isPlaying2 == false)
            {
                isPlaying1 = false;
                PlayHallucinationMusic02();
            }
            else if (insanityBarScript.levelOfInsanity == 3 && isPlaying3 == false)
            {
                isPlaying2 = false;
                PlayHallucinationMusic03();

            }
        }
        else
        {
            isPlaying1 = false;
            isPlaying2 = false;
            isPlaying3 = false;
        }
    }

    private void PlayHallucinationMusic01()
    {
        isPlaying1 = true;
        Debug.Log("Here01");
    }
    private void PlayHallucinationMusic02()
    {
        isPlaying2 = true;
        
        Debug.Log("Here02");
    }
    private void PlayHallucinationMusic03()
    {
        isPlaying3 = true;
        Debug.Log("Here03");
    }
}
