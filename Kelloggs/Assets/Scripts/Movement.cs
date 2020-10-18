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
        if (canMove)
            GetComponent<SpriteRenderer>().material.color = Color.white;
        else
            GetComponent<SpriteRenderer>().material.color = Color.grey;
        cam.transform.position = transform.position + Vector3.back * 20;
        if (sliding)
        {
            if (canMove)
            {
                if (Input.GetKey(KeyCode.W))
                {
                    GetComponent<Rigidbody2D>().velocity = Vector2.up * speed * 2f;
                    canMove = false;
                    transform.rotation = Quaternion.Euler(0f, 0f, 0f);
                }
                if (Input.GetKey(KeyCode.S))
                {
                    GetComponent<Rigidbody2D>().velocity = Vector2.down * speed * 2f;
                    canMove = false;
                    transform.rotation = Quaternion.Euler(0f, 0f, 180f);
                }   
                if (Input.GetKey(KeyCode.D))
                {
                    GetComponent<Rigidbody2D>().velocity = Vector2.right * speed * 2f;
                    canMove = false;
                    transform.rotation = Quaternion.Euler(0f, 0f, 90f);
                }   
                if (Input.GetKey(KeyCode.A))
                {
                    GetComponent<Rigidbody2D>().velocity = Vector2.left * speed * 2f;
                    canMove = false;
                    transform.rotation = Quaternion.Euler(0f, 0f, -90f);
                }
            }
        }
        else
        {
            canMove = true;
            float horizontalInput = Input.GetAxis("Horizontal");

            float verticalInput = Input.GetAxis("Vertical");

            Vector3 movement = new Vector3(horizontalInput, verticalInput, 0) * speed;

            transform.rotation = Quaternion.Euler(0f, 0f, movement.x < 0 ? Vector2.Angle(movement, Vector2.up) : -Vector2.Angle(movement, Vector2.up));
            //rotationFix * Quaternion.AngleAxis(movement.x < 0 ? -Vector2.Angle(movement, Vector2.up) : Vector2.Angle(movement, Vector2.up), Vector3.back);

            if (Input.GetKey(KeyCode.Space))
            {
                movement = Vector2.zero;
        cam.transform.position = transform.position + Vector3.back * 50;
            }

            GetComponent<Rigidbody2D>().velocity = movement;
        }
    }

    void OnCollisionStay2D(Collision2D collision)
    {
        canMove = true;

        Vector3 contactNormal = collision.GetContact(0).normal;

        GetComponent<Rigidbody2D>().velocity = Vector3.zero;

        transform.position += contactNormal * 0.05f;
    }
}
