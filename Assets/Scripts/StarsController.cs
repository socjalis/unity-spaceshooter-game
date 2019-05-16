using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarsController : MonoBehaviour
{
    public float velocity;
    public float probability;
    public float size;

    private float qVelocity;
    private int start;


    // Start is called before the first frame update
    void Start()
    {
        //probability = 4f;
        //velocity = 1;
        qVelocity = velocity / 3;
        start = 1;


    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (start == 1) {
            startStars();
            start = 0;
        }

        if (Random.value < GameInfo.fixedDeltaTime() * probability)
        {
            newStar();
        }
    }

    public void startStars(){
        for (int i = 0; i < 15; i++){
            float r1 = -GameInfo.screenWidth + Random.value * 2* GameInfo.screenWidth;
            float r2 = -GameInfo.screenHeight + Random.value * 2* GameInfo.screenHeight;

            float distance = 0.2f + Random.value * 0.8f;

            float speed = velocity * distance;
            float scale = size * distance;
            GameObject newStar = ObjectFactory.createStar(new Vector2(r1, r2), speed, scale);
        }
    }

    public void newStar()
    {
        float r1 = -GameInfo.screenWidth + Random.value * 2* GameInfo.screenWidth;
        float r2 = 1.2f * GameInfo.screenHeight;

        float distance = 0.2f + Random.value * 0.8f;

        float speed = velocity * distance;
        float scale = size * distance;
        GameObject newStar = ObjectFactory.createStar(new Vector2(r1, r2), speed, scale);
    }
}
