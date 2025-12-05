using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerDeath : MonoBehaviour
{
    public PlayerMovementTopDown movement;
    public Animator anim;
    public GameObject gameOverPanel;
    private bool isDead = false;

    void Start()
    {
        if (movement == null)
            movement = GetComponent<PlayerMovementTopDown>();

        if (anim == null)
            anim = GetComponentInChildren<Animator>();
    }

    public void Die()
    {
        if (ScoreManager.Instance.hasWon) return;

        if (isDead) return;
        isDead = true;

        Debug.Log("PlayerDeath.Die was called");

        // stop movement
        if (movement != null)
            movement.enabled = false;

        Rigidbody rb = GetComponent<Rigidbody>();
        if (rb != null)
            rb.linearVelocity = Vector3.zero;

        // play death animation
        if (anim != null)
            anim.SetTrigger("Die");

        if (gameOverPanel != null)
        {
            Debug.Log("turning on gameOverPanel");
            gameOverPanel.SetActive(true);
        }
        else
        {
            Debug.Log("gameOverPanel is NOT assigned");
        }
    }

    private IEnumerator RestartLevel()
    {
        yield return new WaitForSeconds(2f);  // wait for fall anim
        Scene current = SceneManager.GetActiveScene();
        SceneManager.LoadScene(current.buildIndex);
    }
}
