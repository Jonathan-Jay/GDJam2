using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Sensor : MonoBehaviour
{
    public AnimationCurve transparency;
    public AnimationCurve shake;
    public List<GameObject> lostItems;
    public SpriteRenderer itemSensor;
    public GameObject timerText;
    public float renderDistance = 100;
    public float timeLimit = 60;
    public float shakeAngle = 30;

    private int currentIndex;
    private float time;
    // Start is called before the first frame update
    void Start()
    {
        currentIndex = lostItems.Count - 1;
        lostItems[currentIndex].GetComponent<MeshRenderer>().materials[0].color = Color.red;
        time = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (lostItems.Count == 0)
        {
            name = "Winner is you";
            Application.Quit();
        }
        else {
            if (time < timeLimit) {
                time += Time.deltaTime;
                if (time >= timeLimit) {
                    time = timeLimit;
                    SceneManager.LoadScene("Prototype");
                }
            }

            float currentDistance = (lostItems[currentIndex].transform.position - transform.position).magnitude;
            float percent = 1 - Mathf.Min(currentDistance, renderDistance) / renderDistance;

            Vector3 tempCol = Vector3.Lerp(Vector3.forward * 5f, Vector3.right * 5f, percent);

            itemSensor.color = new Color(tempCol.x, tempCol.y, tempCol.z, transparency.Evaluate(percent));
            //itemSensor.color.

            itemSensor.transform.position = transform.position + Vector3.up * 3f;
            itemSensor.transform.rotation = Quaternion.Euler(0, 0, Random.Range(-10f, 10f) / 10f * shake.Evaluate(percent) * shakeAngle);
            timerText.GetComponent<Text>().text = "Timer: " + (timeLimit - (int)time);
        }
    }

    public void DeleteCurrentTest(GameObject collision)
    {
        if (collision == lostItems[currentIndex])
        {
            Destroy(lostItems[currentIndex]);
            lostItems.RemoveAt(currentIndex--);
            lostItems[currentIndex].GetComponent<MeshRenderer>().materials[0].color = Color.red;
            time = 0;
        }
    }
}
