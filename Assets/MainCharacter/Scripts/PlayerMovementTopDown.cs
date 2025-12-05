using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovementTopDown : MonoBehaviour
{
    public float speed = 5f;
    public float turnSpeed = 10f;

    private Rigidbody rb;
    private Animator anim;
    private Vector3 input;
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        anim = GetComponentInChildren<Animator>();
    }
    void Update()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        input = new Vector3(h, 0f, v).normalized;

        if (input.sqrMagnitude > 0.001f)
        {
            float targetAngle = Mathf.Atan2(input.x, input.z) * Mathf.Rad2Deg;
            Quaternion targetRot = Quaternion.Euler(0f, targetAngle, 0f);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRot, turnSpeed * Time.deltaTime);
        }

        if (anim !=null)
        {
            anim.SetFloat("Speed", input.magnitude);
        }
    }

    void FixedUpdate()
    {
        rb.linearVelocity = input * speed;
    }
}
