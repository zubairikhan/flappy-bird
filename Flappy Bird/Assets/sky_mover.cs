using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class sky_mover : MonoBehaviour
{
    float speed = 1.08f;
    bool dead;
    GameObject player;
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        if (player == null)
        {
            Debug.LogError("Couldn't find GameObject with tag Player");
        }
        dead= player.GetComponent<bird_movement>().dead;
        

    }

    private void FixedUpdate()
    {
        dead = player.GetComponent<bird_movement>().dead;
        if (dead)
        {
            return;
        }
        Vector3 pos = transform.position;
        pos.x += speed * Time.deltaTime;
        transform.position = pos;
    }
}
