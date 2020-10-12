using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Star : MonoBehaviour
{
    public Sprite[] sprites;
    public System.Random rnd;
    private float speedX;
    private float speedY;
    public float opacity = 0f;

    void Start()
    {
        var maxXValue = 10;
        var maxYValue = 5;
        var randomX = rnd.Next(-maxXValue, maxXValue) + rnd.Next(0, 10) / 10f;
        var randomY = rnd.Next(-maxYValue, maxYValue) + rnd.Next(0, 10) / 10f;
        transform.position = new Vector3(randomX, randomY, 100);


        speedX = rnd.Next(1, 10) / 100f;
        speedY = rnd.Next(1, 10) / 100f;

        var spriteIndex = rnd.Next(0, sprites.Length - 1);
        transform.GetComponent<SpriteRenderer>().sprite = sprites[spriteIndex];

    }

    // Update is called once per frame
    void Update()
    {
        if(opacity < 1f)
        {
            opacity += 0.01f * Time.deltaTime;
            this.GetComponent<SpriteRenderer>().material.color = new Color(1f, 1f, 1f, opacity);
        }
        
        transform.Translate(
            new Vector3(
                speedX * Time.deltaTime,
                speedY * Time.deltaTime,
                0
            ));
    }

    public void OnBecameInvisible()
    {
        transform.parent.BroadcastMessage("OnStarDestroyed", SendMessageOptions.DontRequireReceiver);
        Destroy(gameObject);
    }

}
