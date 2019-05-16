using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waves : MonoBehaviour
{
    private float time;
    private float level;
    private float interval;

    // Start is called before the first frame update
    void Start()
    {
        time = 0f;
        interval = 5f;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        level = GameInfo.currentLevel;
        interval -= GameInfo.fixedDeltaTime();
        if(interval < 0)
        {
            GameObject wave = ObjectFactory.createUfoWave(2f, 2f, 30, 1f, 0.6f, 0.5f);
            wave.GetComponent<ufoWave>().createWave();
            wave.GetComponent<ufoWave>().destroySelf();
            interval = 30f;
        }
    }
}
