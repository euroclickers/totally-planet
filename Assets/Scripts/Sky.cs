using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sky : MonoBehaviour
{
    public int seed;
    public int number = 0;
    public Star star;
    private System.Random rnd;
    // Start is called before the first frame update
    void Start()
    {
        seed = InfoBetweenScenes.seed;
        rnd = new System.Random(seed);
        number = rnd.Next(10, 500);

        for (var i = 0; i < number; i++)
        {
            star = Instantiate(star, new Vector3(0, 0, 200), Quaternion.identity);
            star.rnd = rnd;
            star.transform.parent = transform;
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnStarDestroyed()
    {
        star = Instantiate(star, new Vector3(0, 0, 200), Quaternion.identity);
        star.rnd = rnd;
        star.transform.parent = transform;
    }

}
