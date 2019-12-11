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

    private void Start()
    {
        animator = player.GetComponent<Animator>();
        isPlayerDead = false;
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
        yield return new WaitForSecondsRealtime(deathAnim.length / 2f);
        animator.enabled = false;
        gameOverScreen.SetActive(true);
    }
}
