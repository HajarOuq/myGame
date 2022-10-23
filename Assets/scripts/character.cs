using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class character : MonoBehaviour
{
    Rigidbody2D rb2d;
    public float speed;
    public float jumpforce;
    bool grounded;
    bool canjump;
 
    public GameObject groundDetector;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();      
    }

    bool canDoVelocity = true;
    float timeInAir = 0.2f;
    float time = 0;
    float h;
    float timeRight=0;
    bool stoppedRight = false;
    float h2 = 1;
    
    private void Update()
    {
        Velocity();       
    }

    public LayerMask layer;
    void CheckGround()
    {
        // Does the ray intersect any objects excluding the player layer
        RaycastHit2D hit = Physics2D.Raycast(groundDetector.transform.position, -Vector2.up, 0.01f);

        // If it hits something...     
        if (hit.collider != null)
        {
            Debug.DrawRay(groundDetector.transform.position, hit.point, Color.green);
            if (hit.collider.CompareTag("ground") || hit.collider.CompareTag("platform"))
            {
                grounded = true;
                canDoVelocity = true;
                canjump = true;
            }
           
        }
        else 
        {
            grounded = false;
            canDoVelocity = false;
            canjump = false;
        }
    }

    void Velocity()
    {
        CheckGround();
        if (h != 0)
            h2 = h;
        h = Input.GetAxisRaw("Horizontal");
        if (h2 == -h && h2 * h != 0)
        {
            time = 0;
            timeInAir = 0.6f;
        }

        if (grounded)
        {
            time = 0;
            timeInAir = 0.2f;

            if (canDoVelocity)
                rb2d.velocity = Vector2.right * speed * h;

            if (canjump)
            {
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    canjump = false;
                    canDoVelocity = false;
                    rb2d.AddForce(Vector2.up * jumpforce);
                }
            }
        }

        else
        {
            time += Time.deltaTime;
            if (time < timeInAir)
            {
                rb2d.AddForce(new Vector2(h, 0) * 2);
            }
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            if (stoppedRight == true && timeRight < 0.01f)
            {
                h = 0;
                timeRight = 0;
                stoppedRight = false;
            }
            else
                timeRight += Time.deltaTime;
        }
        else
        {
            stoppedRight = true;
        }

    }
}
