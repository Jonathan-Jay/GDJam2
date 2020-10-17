using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lookAt : MonoBehaviour
{
    public Transform player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 pos = transform.position - player.transform.position;
        transform.rotation = Quaternion.AngleAxis( pos.x < 0 ? -Vector2.Angle(pos, Vector2.up) : Vector2.Angle(pos, Vector2.up), Vector3.back);
        
            if (Input.GetKey(KeyCode.UpArrow))
            {
                transform.position += Vector3.up * Time.deltaTime * 5f;
            }
            if (Input.GetKey(KeyCode.DownArrow))
            {
                transform.position += Vector3.down * Time.deltaTime * 5f;
            }
            if (Input.GetKey(KeyCode.RightArrow))
            {
                transform.position += Vector3.right * Time.deltaTime * 5f;
            }
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                transform.position += Vector3.left * Time.deltaTime * 5f;
            }
    }
}
