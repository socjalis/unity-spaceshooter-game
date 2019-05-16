using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpaceshipController : MonoBehaviour
{
    public GameObject panel;
    public Camera cam;
    public Rigidbody2D rig;

    public float velocity;

    private float halfWidth;
    

    // Start is called before the first frame update
    void Start()
    {
        velocity = 4;
        if (cam == null)
        {
            cam = Camera.main;
        }

        rig = GetComponent<Rigidbody2D>();
        
        halfWidth = cam.ScreenToWorldPoint(new Vector3(Screen.width, 0f, 0f)).x;
    }

    // Update is called once per engine update
    void FixedUpdate()
    {
        if (Input.touchCount > 0)
        {
            Vector3 rawPosition = cam.ScreenToWorldPoint(Input.GetTouch(0).position);
            Vector3 newPosition = rig.position;
            if (rawPosition.x > rig.position.x + 0.1) newPosition = rig.position + new Vector2(GameInfo.fixedDeltaTime() * velocity, 0);
            else if (rawPosition.x < rig.position.x - 0.1) newPosition = rig.position + new Vector2(GameInfo.fixedDeltaTime() * -velocity, 0);

            if (newPosition.x > halfWidth) newPosition.x = halfWidth;
            else if (newPosition.x < halfWidth) newPosition.x = -halfWidth;

            rig.MovePosition(newPosition);
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        panel.gameObject.SetActive(true);
        GameObject.Find("FinalScore").GetComponent<Text>().text = GameInfo.score.ToString();
        GameInfo.gameState = 0;

        if (PlayerPrefs.HasKey("highestScore")){
            if(PlayerPrefs.GetInt("highestScore") < GameInfo.score)
            {
                GameObject.Find("ScoreMsg").GetComponent<Text>().text = "New Highscore!";
                PlayerPrefs.SetInt("highestScore", GameInfo.score);
                PlayerPrefs.Save();
            }
        }
        else
        {
            GameObject.Find("ScoreMsg").GetComponent<Text>().text = "New Highscore!";
            PlayerPrefs.SetInt("highestScore", GameInfo.score);
            PlayerPrefs.Save();
        }
        
    }
}
