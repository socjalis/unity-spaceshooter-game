using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameInfo : MonoBehaviour
{
    public static int score;
    public static float currentLevel;

    public static float screenWidth;
    public static float screenHeight;

    public static int gameState;

    public static Text text;
    // Start is called before the first frame update
    void Start()
    {
        text = GameObject.Find("Score").GetComponent<Text>();
        score = 0;
        currentLevel = 0f;
        gameState = 1;
        
        screenWidth = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, 0f, 0f)).x;
        screenHeight = Camera.main.ScreenToWorldPoint(new Vector3(0f, Screen.height, 0f)).y;
    }

    // Update is called once per frame
    void Update()
    {
        NextLevel();
    }

    private void NextLevel()
    {
        if (score > (currentLevel + 1) * 20f)
        {
            currentLevel++;
            Debug.Log("NEW LEVEL");
        }
    }
    public static void incrementScore(int plus)
    {
        score += plus;
        text.text = "Score\n" + score;
    }
    public static float fixedDeltaTime()
    {
        if (gameState == 0) return 0f;
        else return Time.fixedDeltaTime;
    }
}
