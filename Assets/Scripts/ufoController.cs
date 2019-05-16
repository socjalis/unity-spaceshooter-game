using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ufoController : MonoBehaviour
{
    public float xVelocity;
    public float yVelocity;

    public Rigidbody2D rig;

    private SpriteRenderer spr;
    private float ufoWidth;

    // Start is called before the first frame update
    void Start()
    {
        ufoWidth = 0.5f*GetComponent<SpriteRenderer>().bounds.size.x;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector2 newPosistion = rig.position + new Vector2(xVelocity * GameInfo.fixedDeltaTime(), -yVelocity * GameInfo.fixedDeltaTime());
        if (newPosistion.x > GameInfo.screenWidth - ufoWidth)
        {
            rig.MovePosition(new Vector2(2f * (GameInfo.screenWidth - ufoWidth) - newPosistion.x, newPosistion.y));
            xVelocity *= -1;
        }
        else if (newPosistion.x < -GameInfo.screenWidth + ufoWidth)
        {
            rig.MovePosition(new Vector2(-GameInfo.screenWidth + ufoWidth, newPosistion.y));
            xVelocity *= -1;
        }
        else rig.MovePosition(newPosistion);

        if (rig.position.y < -1.2f * GameInfo.screenHeight)
        {
            Object.Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        GameInfo.incrementScore(1);
        Object.Destroy(col.gameObject);
        Object.Destroy(gameObject);
    }
}
