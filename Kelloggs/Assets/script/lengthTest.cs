using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lengthTest : MonoBehaviour
{
    public GameObject player;
    public GameObject objectToFind;
    public GameObject length; // empty game object
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        length.transform.position = player.transform.position - objectToFind.transform.position;
    }
}
