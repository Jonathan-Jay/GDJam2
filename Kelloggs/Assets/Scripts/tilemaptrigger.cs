using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tilemaptrigger : MonoBehaviour
{
    public GameObject player;
    public AudioSource ice1;
    public AudioSource ice2;
    public AudioSource ambient;


    // Start is called before the first frame update
    void Start()
    {
        ambient.Play(0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        player.GetComponent<Movement>().sliding = false;
        ice2.Play(0);
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        player.GetComponent<Movement>().sliding = true;
        player.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        ice1.Play(0);
    }
}
