using System;
using System.Collections;
using System.Collections.Generic;
//using System.Numerics;
using UnityEngine;

public class MovementLeo : MonoBehaviour
{
    public GameObject player;

    float horizontalInput = 0;
    float verticalInput = 0;
    public float moveSpeed = 10;
    // Start is called before the first frame update

        
    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");

        verticalInput = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(horizontalInput, verticalInput, 0) * moveSpeed * Time.deltaTime;

      //  player.transform.LookAt(player.transform.position + movement);

        player.transform.rotation = Quaternion.AngleAxis(movement.x < 0 ? -Vector2.Angle(movement, Vector2.up) : Vector2.Angle(movement, Vector2.up), Vector3.back);
        player.GetComponent<Rigidbody>().velocity  = movement;

        
    }
}
