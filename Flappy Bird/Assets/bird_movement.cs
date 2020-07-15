using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bird_movement : MonoBehaviour
{

    Vector3 velocity = Vector3.zero;
    public Vector3 gravity;
    public Vector3 flapVeloctiy;
    public float maxSpeed;
    public float forwardSpeed = 1f;
    Animator animator;
    bool didFlap;
    public bool dead;
    public bool godMode;
    float deathCoolDown;

    // Start is called before the first frame update
    void Start()
    {
        dead = false;
        animator = GetComponentInChildren<Animator>();
    }


    // Update is called once per frame
    void Update()
    {
        if (dead)
        {
            deathCoolDown -= Time.deltaTime;
            if (deathCoolDown <= 0)
            {
                if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
                {
                    Application.LoadLevel(Application.loadedLevel);
                }
            }

        }

        else
        {
            if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
            {
                didFlap = true;
            }
        }
    }

    private void FixedUpdate()
    {
        if (dead)
        {
            return;
        }
        velocity.x = forwardSpeed;
        velocity += gravity * Time.deltaTime;
        if (didFlap)
        {
            animator.SetTrigger("DoFlap");
            didFlap = false;
            if (velocity.y < 0)
            {
                velocity.y = 0;
            }
            velocity += flapVeloctiy;
        }
        velocity = Vector3.ClampMagnitude(velocity, maxSpeed);
        transform.position += velocity * Time.deltaTime;

        float angle = 0;
        if (velocity.y < 0)
        {
            angle = Mathf.Lerp(0, -90, -velocity.y / maxSpeed);
        }
        transform.rotation = Quaternion.Euler(0, 0, angle);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Obstacle")
        {
            if (godMode)
            {
                return;
            }
            animator.SetTrigger("Death");
            dead = true;
            deathCoolDown = 0.5f;
        }
    }
}

