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

            Vector3 tempCol = Vector3.Lerp(Vector3.forward * 5f, Vector3.right * 5f, percent);

            itemSensor.color = new Color(tempCol.x, tempCol.y, tempCol.z, transparency.Evaluate(percent));
            //itemSensor.color.

            itemSensor.transform.position = transform.position + Vector3.up * 5f;
        }
    }

    public void DeleteCurrentTest(GameObject collision)
    {
        if (collision == lostItems[currentIndex])
        {
            Destroy(lostItems[currentIndex]);
            lostItems.RemoveAt(currentIndex--);
        }
    }
}
