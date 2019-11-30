using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressureController : MonoBehaviour
{
    public GameObject item;
    public bool addOrRemove;

    // Start is called before the first frame update
    void Start()
    {
        if (addOrRemove)
        {
            item.gameObject.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
        
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Male" || collision.gameObject.tag == "Female")
        {
            if (addOrRemove)
            {
                //ADding the item
                item.gameObject.SetActive(true) ;
            }
            else
            {
                item.gameObject.SetActive(false);

            }
        }
    }
}
