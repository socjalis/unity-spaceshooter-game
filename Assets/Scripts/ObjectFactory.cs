using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectFactory : MonoBehaviour
{
    protected static ObjectFactory instance; // Needed
    public GameObject rocket;
    public GameObject star;
    public GameObject ufo;
    public GameObject ufoWave;

    void Start()
    {
        instance = this;
    }

    public static GameObject createMissile(Vector2 position, float velocity)
    {
        GameObject newRocket = GameObject.Instantiate(instance.rocket, new Vector3(position.x, position.y, 0f), Quaternion.identity);
        newRocket.GetComponent<Missile>().velocity = velocity;
        return newRocket;
    }

    public static GameObject createStar(Vector2 position, float velocity, float scale)
    {
        GameObject newStar = GameObject.Instantiate(instance.star, new Vector3(position.x, position.y, 0f), Quaternion.identity);

        newStar.GetComponent<Star>().velocity = velocity;
        newStar.transform.localScale = new Vector3(scale, scale, 1f);

        return newStar;
    }

    public static GameObject createUfo(Vector2 position, float xVelocity, float yVelocity, float scale)
    {
        GameObject newUfo = GameObject.Instantiate(instance.ufo, new Vector3(position.x, position.y, 0f), Quaternion.identity);

        newUfo.GetComponent<ufoController>().xVelocity = xVelocity;
        newUfo.GetComponent<ufoController>().yVelocity = yVelocity;
        newUfo.transform.localScale = new Vector3(scale, scale, 1f);

        return newUfo;
    }

    public static GameObject createUfoWave(float xVelocity, float yVelocity, int quantity, float scale, float spacing, float padding)
    {
        GameObject newUfoWave = GameObject.Instantiate(instance.ufoWave);
        newUfoWave.GetComponent<ufoWave>().initialize(xVelocity, yVelocity, quantity, scale, spacing, padding);

        return newUfoWave;
    }
}
