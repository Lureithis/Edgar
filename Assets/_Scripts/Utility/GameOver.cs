using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameOver : MonoBehaviour
{
    public bool isPlayerDead;

    [SerializeField] GameObject player;
    [SerializeField] GameObject gameOverScreen;
    [SerializeField] AnimationClip deathAnim;
    private Animator animator;

    public bool playAnim;

    private void Start()
    {
        gameOverScreen.SetActive( false);
        animator = player.GetComponent<Animator>();
        isPlayerDead = false;
        playAnim = false;
    }

    public void EndGame()
    {
        isPlayerDead = true;
        StartCoroutine(playDeathAnim());
        player.GetComponent<PlayerMovement>().enabled = false;
    }

    private IEnumerator playDeathAnim()
    {
        deathAnim.wrapMode = WrapMode.Once;
        animator.Play(deathAnim.name);
        if(playAnim == false)
        {
            yield return new WaitForSecondsRealtime(deathAnim.length / 2f);
        }
        else
        {
            yield return new WaitForSecondsRealtime(0.5f);
        }
        animator.Play("Idle");
        animator.enabled = false;
        gameOverScreen.SetActive(true);
    }
}
