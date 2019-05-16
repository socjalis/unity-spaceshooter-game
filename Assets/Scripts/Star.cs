using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Star : MonoBehaviour
{
    public float velocity;
    public Rigidbody2D rig;
    private Camera cam;

    // Start is called before the first frame update
    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        cam = Camera.main;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rig.MovePosition(rig.position + new Vector2(0, -velocity * GameInfo.fixedDeltaTime()));
        if (rig.position.y < -1.2*GameInfo.screenHeight)
        {
            Destroy(gameObject);
        }
    }
}
