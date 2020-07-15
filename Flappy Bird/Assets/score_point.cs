using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class score_point : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            score.AddPoint();
        }
    }
}
