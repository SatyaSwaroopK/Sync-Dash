using System.Collections.Generic;
using UnityEngine;

public class GhostController : MonoBehaviour
{
    public PlayerController player; 
    public float syncDelay = 0.2f;  
    private Queue<float> actionQueue = new Queue<float>();
    private Rigidbody rb;
    private bool isGrounded = true;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        
        transform.position = new Vector3(player.transform.position.x * -1, transform.position.y, player.transform.position.z);

        
        if (player.actionQueue.Count > 0)
        {
            float eventTime = player.actionQueue.Peek(); 
            if (Time.time >= eventTime + syncDelay)
            {
                player.actionQueue.Dequeue(); 
                Jump();
            }
        }
    }

    void Jump()
    {
        if (isGrounded)
        {
            rb.AddForce(Vector3.up * player.jumpForce, ForceMode.Impulse);
            isGrounded = false;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }
}
