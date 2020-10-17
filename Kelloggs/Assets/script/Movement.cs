using System;
using System.Collections;
using System.Collections.Generic;
using System.Media;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public GameObject player;

    float horizontalInput = 0;
    float verticalInput = 0;
    public float moveSpeed = 10;
    // Start is called before the first frame update
    void Start()
    {
        
    }
        
    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");

        verticalInput = Input.GetAxis("Vertical");

        player.transform.Translate(new Vector2(horizontalInput, verticalInput) * moveSpeed * Time.deltaTime);
    }
}
