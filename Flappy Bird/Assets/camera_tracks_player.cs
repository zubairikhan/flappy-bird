using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera_tracks_player : MonoBehaviour
{
    Transform player_trans;
    float offset_x;

    // Start is called before the first frame update
    void Start()
    {
        GameObject player_go = GameObject.FindGameObjectWithTag("Player");
        if(player_go == null)
        {
            Debug.LogError("No GameObject with tag Player exists");
            return;
        }
        player_trans = player_go.transform;

        offset_x = transform.position.x - player_trans.position.x;
    }

    // Update is called once per frame
    void Update()
    {
        if (player_trans != null)
        {
            Vector3 pos = transform.position;
            pos.x = player_trans.position.x + offset_x;
            transform.position = pos;
        }
        
    }
}
