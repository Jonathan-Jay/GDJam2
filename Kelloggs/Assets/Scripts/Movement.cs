using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Movement : MonoBehaviour
{
    public Camera cam;
    public float speed = 10;
    public bool sliding = true;
    public bool canMove = true;
    // Start is called before the first frame update
    void Start()
    {
        canMove = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (sliding)
        {
            if (canMove)
            {
                if (Input.GetKeyDown(KeyCode.W))
                {
                    GetComponent<Rigidbody2D>().velocity = Vector2.up * speed;
                    canMove = false;
                }
                if (Input.GetKeyDown(KeyCode.S))
                {
                    GetComponent<Rigidbody2D>().velocity = Vector2.down * speed;
                    canMove = false;
                }   
                if (Input.GetKeyDown(KeyCode.D))
                {
                    GetComponent<Rigidbody2D>().velocity = Vector2.right * speed;
                    canMove = false;
                }   
                if (Input.GetKeyDown(KeyCode.A))
                {
                    GetComponent<Rigidbody2D>().velocity = Vector2.left * speed;
                    canMove = false;
                }
            }
        }
        else
        {
            canMove = true;
            Vector2 movement = Vector2.zero;
            if (Input.GetKey(KeyCode.W))
            {
                movement += Vector2.up * speed;
            }
            if (Input.GetKey(KeyCode.S))
            {
                movement += Vector2.down * speed;
            }   
            if (Input.GetKey(KeyCode.D))
            {
                movement += Vector2.right * speed;
            }   
            if (Input.GetKey(KeyCode.A))
            {
                movement += Vector2.left * speed;
            }
            GetComponent<Rigidbody2D>().velocity = movement;
        }

        if (canMove)
            GetComponent<MeshRenderer>().material.color = Color.green;
        else
            GetComponent<MeshRenderer>().material.color = Color.red;
        cam.transform.position = transform.position + Vector3.back * 20;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        canMove = true;

        Vector3 contactNormal = collision.GetContact(0).normal;

        if (contactNormal.x == 0)
        {
            if (contactNormal.y > 0)
            {
                transform.position += Vector3.up * 0.05f;
            }
            else
            {
                transform.position += Vector3.down * 0.05f;
            }
        }
        else
        {
            if (contactNormal.x > 0)
            {
                transform.position += Vector3.right * 0.05f;
            }
            else
            {
                transform.position += Vector3.left * 0.05f;
            }

        }

    }
}
