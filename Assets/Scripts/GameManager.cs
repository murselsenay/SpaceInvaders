using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    public GameObject enemyPrefab;
    float distance = 0;
    int enemyCount;
    public int lineCount;
    float startPosition;
    internal int score;

    public Text scoreText;
    public GameObject startGameButtonPrefab;
    GameObject startGameButton;
    public static bool startGame;
    

    public static GameManager instance;
    void Start()
    {

        instance = this;

        startPosition = transform.position.x;
        startGameButton = Instantiate(startGameButtonPrefab, new Vector3(0, 0, 0), Quaternion.identity) as GameObject;
        startGameButton.transform.SetParent(GameObject.Find("Canvas").transform, false);



        enemyCount = lineCount * 17;

       


        

        
    }

    
    void Update()
    {
        if (startGame)
        {
            for (int i = 0; i < enemyCount; i++)
            {
                if (i % 17 == 0)
                {
                    transform.position = new Vector2(startPosition, transform.position.y - 1f);
                    distance = 0;
                }
                Instantiate(enemyPrefab, new Vector2(transform.position.x + distance, transform.position.y), Quaternion.identity);
                distance += 1f;
            }
            startGame = false;
        }
        
    }


    public void RestartGame()
    {
        SceneManager.LoadScene(0);
    }
    public void StartGame()
    {
        startGame = true;
        Destroy(GameObject.FindGameObjectWithTag("StartButton"));
    }
}
