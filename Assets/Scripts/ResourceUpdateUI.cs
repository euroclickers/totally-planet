using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceUpdateUI : MonoBehaviour
{
    public Sprite arrow_up;
    public Sprite arrow_down;

    private float timeAlive = 2f;
    private float startedTime = 0; 

    void Start()
    {
        
    }


    // Update is called once per frame
    void Update()
    {
        if(startedTime == 0)
        {
            startedTime = Time.time;
        }

        if((Time.time - startedTime) > timeAlive )
        {
            GameObject.Find("Parent").BroadcastMessage("OnResourceUpdateUIDestroyed", this, SendMessageOptions.DontRequireReceiver);
            Destroy(this.gameObject);
        }

    }

    public void setIncreasing(bool isIncreasing)
    {
        transform.GetComponent<SpriteRenderer>().sprite = isIncreasing ? arrow_up : arrow_down;
    }
}
