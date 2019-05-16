using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ufoWave : MonoBehaviour
{
    public GameObject ufo;

    public float xVelocity;
    public float yVelocity;
    public int quantity;
    public float scale;
    public float spacing;
    public float padding;

    public void initialize(float xVelocity, float yVelocity, int quantity, float scale, float spacing, float padding)
    {
        this.xVelocity = xVelocity;
        this.yVelocity = yVelocity;
        this.quantity = quantity;
        this.scale = scale;
        this.spacing = spacing;
        this.padding = padding;
    }

    public void createWave() {
        float ufoWidth = 0.5f * this.ufo.GetComponent<SpriteRenderer>().bounds.size.x;
        ufoWidth *= scale;

        float start = -GameInfo.screenWidth +
            ufoWidth +
            Random.value * (GameInfo.screenWidth - ufoWidth);
        int direction = 1;
        float startY = GameInfo.screenHeight * 1.2f;
        for (int i = 0; i < quantity; i++)
        {
            Debug.Log("i: " + i + "x: " + start);

            GameObject newUfo = ObjectFactory.createUfo(new Vector2(start, padding * i + startY), xVelocity, yVelocity, scale);
            start += spacing * direction;
            if (start > GameInfo.screenWidth)
            {
                direction = -1;
                xVelocity *= -1;
                start = 2 * (GameInfo.screenWidth - ufoWidth) - start;
            }
            else if (start < -GameInfo.screenWidth + ufoWidth)
            {
                direction = 1;
                xVelocity *= -1;
                start = 2*(-GameInfo.screenWidth + ufoWidth) + start;
            }
        }
    }
    public void destroySelf()
    {
        Destroy(gameObject);
    }
}
