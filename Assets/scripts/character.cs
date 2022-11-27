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
    bool isFacingRight = true;
    public List<Animator> characters = new List<Animator>();
    public GameObject groundDetector, pink, orange;
    bool canChange1, canChange2;
    public GameObject green,cam,healthbar;
    RuntimeAnimatorController animator;
    public Sprite[] health;
    int hp;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        canChange1 = false;
        canChange2 = false;
        hp = 6;
    }

    bool canDoVelocity = true;
    float timeInAir = 0.2f, timehp = 1f;
    float time = 0, time2 = 0;
    float h;
    float timeRight=0;
    bool stoppedRight = false;
    float h2 = 1;
    
    private void Update()
    {
        animator = GetComponent<Animator>().runtimeAnimatorController;
        Velocity();
        Idle();
        ChangeCharacter();
        CheckHelth();
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.name == "ballpink")
        {            
            col.GetComponent<Animator>().SetBool("ballanim", true);
            canChange1 = true;           
        }
        if (col.name == "ballorange")
        {
            col.GetComponent<Animator>().SetBool("ballanim", true);
            canChange2 = true;
        }

        if (col.name.Contains("heal") && hp < 6)
            hp++;
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
                GetComponent<Animator>().SetBool("jump", false);
            }

            if (hit.collider.CompareTag("lava"))
            {
                rb2d.constraints = RigidbodyConstraints2D.FreezeAll;
            }

            if(hit.collider.name.Contains("greenfloor"))
            {
                if (animator.name == "pink" || animator.name == "orange")
                {
                    time2 += Time.deltaTime;
                    if (hp > 0 && time2 > timehp)
                    {
                        hp--;

                        StartCoroutine(hurt());
                        time2 = 0;
                    }

                    healthbar.GetComponent<SpriteRenderer>().sprite = health[hp];
                }
                else
                    time2 = 0;
            }

            if (hit.collider.name.Contains("pinkfloor"))
            {
                if (animator.name == "green" || animator.name == "orange")
                {
                    time2 += Time.deltaTime;
                    if (hp > 0 && time2 > timehp)
                    {
                        hp--;
                        StartCoroutine(hurt());
                        time2 = 0;
                    }
                    healthbar.GetComponent<SpriteRenderer>().sprite = health[hp];
                }
                else
                    time2 = 0;
            }

            if (hit.collider.name.Contains("orangefloor"))
            {
                if (animator.name == "pink" || animator.name == "green")
                {
                    time2 += Time.deltaTime;
                    if (hp > 0 && time2 > timehp)
                    {
                        hp--;
                        StartCoroutine(hurt());
                        time2 = 0;
                    }
                    healthbar.GetComponent<SpriteRenderer>().sprite = health[hp];
                }
                else
                    time2 = 0;
            }

        }
        else 
        {
            grounded = false;
            canDoVelocity = false;
            canjump = false;
            GetComponent<Animator>().SetBool("jump", true);
        }
    }

    void Velocity()
    {
        CheckGround();
        if (h != 0)
            h2 = h;
        h = Input.GetAxisRaw("Horizontal");
        if(h>0 && !isFacingRight)
        {
            Vector3 scale= transform.localScale;
            scale.x *= -1;
            transform.localScale = scale;
            isFacingRight = true;
        }
        if (h < 0 && isFacingRight)
        {
            Vector3 scale = transform.localScale;
            scale.x *= -1;
            transform.localScale = scale;
            isFacingRight = false;
        }
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
                rb2d.AddForce(new Vector2(h, 0) * (1.5f));
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

    void ChangeCharacter()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
            GetComponent<Animator>().runtimeAnimatorController = characters[0].runtimeAnimatorController;
        if (Input.GetKeyDown(KeyCode.Alpha2) && canChange1)
            GetComponent<Animator>().runtimeAnimatorController = characters[1].runtimeAnimatorController;
        if (Input.GetKeyDown(KeyCode.Alpha3) && canChange2)
            GetComponent<Animator>().runtimeAnimatorController = characters[2].runtimeAnimatorController;
    }

    void Idle()
    {
        if (rb2d.velocity == Vector2.zero)
        {
            GetComponent<Animator>().SetBool("isIdle", true);
        }
        else
        {
            GetComponent<Animator>().SetBool("isIdle", false);
        }
    }

    void CheckHelth()
    {
        if (hp == 0)
            rb2d.constraints = RigidbodyConstraints2D.FreezeAll;
    }



    IEnumerator hurt()
    {
        
        float s = 0;
        while (s < 50)
        {

            s += 2;
            GetComponent<SpriteRenderer>().color = Color.HSVToRGB(0, s / 100f,1 );
        }
        yield return new WaitForSeconds(1);
        while (s> 0)
        {

            s -= 2;
            GetComponent<SpriteRenderer>().color = Color.HSVToRGB(0, s / 100f, 1);
        }

    }
}
