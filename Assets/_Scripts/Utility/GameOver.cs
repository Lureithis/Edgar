using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameOver : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] GameObject gameOverScreen;
    [SerializeField] AnimationClip deathAnim;
    private Animator animator;

    private void Start()
    {
        animator = player.GetComponent<Animator>();
    }

    public void EndGame()
    {
        StartCoroutine(playDeathAnim());
        player.GetComponent<PlayerMovement>().enabled = false;
    }

    private IEnumerator playDeathAnim()
    {
        deathAnim.wrapMode = WrapMode.Once;
        animator.Play(deathAnim.name);
        yield return new WaitForSecondsRealtime(deathAnim.length-0.5f);
        animator.enabled = false;
        gameOverScreen.SetActive(true);
    }
}
