using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Sensor : MonoBehaviour
{
    public AnimationCurve transparency;
    public List<GameObject> lostItems;
    public SpriteRenderer itemSensor;
    public float renderDistance;
    private int currentIndex;
    // Start is called before the first frame update
    void Start()
    {
        currentIndex = lostItems.Count - 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (lostItems.Count == 0)
        {
            name = "Winner is you";
        }
        else{
            float currentDistance = (lostItems[currentIndex].transform.position - transform.position).magnitude;

            float percent = 1 - Mathf.Min(currentDistance, renderDistance) / renderDistance;

            itemSensor.color = new Color(Vector3.Lerp(Vector3.zero, Vector3.left), transparency.Evaluate(percent));
            //itemSensor.color.
        }
    }
}
