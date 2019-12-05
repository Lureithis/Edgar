using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameOver : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] GameObject gameOverScreen;
    [SerializeField] AnimationClip deathAnim;

    public void EndGame()
    {
        StartCoroutine(PlayDeathAnim());
        
        player.GetComponent<PlayerMovement>().enabled = false;
    }

    /*private IEnumerator PlayDeathAnim()
    {
        deathAnim.wrapMode = WrapMode.Once;
        Animation.Play(deathAnim.);
        player.GetComponent<PlayerMovement>().PlayerDeath();
        yield return new WaitForSecondsRealtime(deathAnim.length+5f);
        gameOverScreen.SetActive(true);*/
    //}
}
