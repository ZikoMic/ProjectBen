using System    .Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCBehaviour : MonoBehaviour
{
    public int direction;
    public float speed;
    public float timeout = 5.0f;
    public float initTimout;
    public GameObject briefcasePrefab;
    public GameObject leftPoint, rightPoint;
    // Start is called before the first frame update
    void Start()
    {
        initTimout = timeout;
    }

    // Update is called once per frame
    void Update()
    {
        if (timeout <= 0)
        {
            Debug.Log("Im the BADDDD GUYyy");
            GameObject briefcase;
            if(direction > 0)
            {
                briefcase = Instantiate(briefcasePrefab, rightPoint.transform.position, Quaternion.identity);
                briefcase.gameObject.GetComponent<BriefCase>().direction = 1;

            }else if(direction < 0)
            {
                briefcase = Instantiate(briefcasePrefab, leftPoint.transform.position, Quaternion.identity);
                briefcase.gameObject.GetComponent<BriefCase>().direction = -1;

            }

            //

            timeout = initTimout;
        }
        else
        {
            timeout -= Time.deltaTime;
        }

    }
}
