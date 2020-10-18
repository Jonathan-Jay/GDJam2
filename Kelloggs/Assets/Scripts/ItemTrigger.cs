using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemTrigger : MonoBehaviour
{
    public Sensor player;

    void OnTriggerEnter2D(Collider2D collision)
    {
        player.DeleteCurrentTest(gameObject);
    }
}
