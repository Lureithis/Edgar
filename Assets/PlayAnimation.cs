using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.UI;

public class PlayAnimation : MonoBehaviour
{
    [SerializeField] VideoClip clipToPlay;
    [SerializeField] RawImage imageToPlayOn;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(this.isActiveAndEnabled == true)
        {
            imageToPlayOn.GetComponent<VideoPlayer>().clip = clipToPlay;
            imageToPlayOn.GetComponent<VideoPlayer>().Play();
        }
    }
}
