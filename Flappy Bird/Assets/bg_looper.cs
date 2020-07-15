using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bg_looper : MonoBehaviour
{
    float pipeMax = 1.61f;
    float pipeMin = 0.48f;
    int numOfBgPanels = 6;

    private void Start()
    {
        GameObject[] pipes = GameObject.FindGameObjectsWithTag("Pipe");
        foreach(GameObject pipe in pipes)
        {
            Vector3 pos = pipe.transform.position;
            pos.y = Random.Range(pipeMax, pipeMin);
            pipe.transform.position = pos; 
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        float widthOfBgPanel = ((BoxCollider2D)collision).size.x;
        Vector3 pos = collision.transform.position;
        

        if (collision.tag == "Pipe")
        {
            pos.x = pos.x + (numOfBgPanels * widthOfBgPanel);
            pos.y = Random.Range(pipeMax, pipeMin);
        }
        else
        {
            pos.x = pos.x + (numOfBgPanels * widthOfBgPanel)-widthOfBgPanel/2;
        }
        collision.transform.position = pos;
    }
}
