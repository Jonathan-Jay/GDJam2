using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tilemaptrigger : MonoBehaviour
{
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        player.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        player.GetComponent<Movement>().sliding = false;
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        player.GetComponent<Movement>().sliding = true;
    }
}
