using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingController : MonoBehaviour
{
    public float interval;
    public float nextShot;
    public float velocity;

    // Start is called before the first frame update
    void Start()
    {
        velocity = 3f;
        interval = 0.5f;
        nextShot = interval;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        nextShot -= GameInfo.fixedDeltaTime();
        if(nextShot < 0)
        {
            GameObject rocket = ObjectFactory.createMissile(GetComponent<Rigidbody2D>().position +
                new Vector2(0, 0.5f*GetComponent<SpriteRenderer>().bounds.size.y), velocity);
            nextShot = interval;
        }
    }
}
