using UnityEngine;
using UnityEngine.Rendering;

public class GhostChase : MonoBehaviour
{
    public Transform target;      // assign Boy0 in Inspector
    public float speed = 3f;

    void Update()
    {
        if (target == null)
            return;

        // Move toward the player
        Vector3 toPlayer = target.position - transform.position;
        toPlayer.y = 0f;

        if (toPlayer.sqrMagnitude < 0.001f)
            return;

        Vector3 dir = toPlayer.normalized;

        transform.position += dir * speed * Time.deltaTime;
        transform.rotation = Quaternion.LookRotation(dir);
    }

    void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Ghost collided with: " + collision.gameObject.name);

        if (collision.gameObject.CompareTag("Player"))
        {
            PlayerDeath death = collision.gameObject.GetComponent<PlayerDeath>();
            if (death != null)
            {
                death.Die();
            }

         
            enabled = false;         
        }
    }

}