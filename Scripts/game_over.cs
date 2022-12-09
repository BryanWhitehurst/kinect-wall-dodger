using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class game_over : MonoBehaviour
{
    [SerializeField] private GameObject gameOverPanel;
    [SerializeField] private GameObject curScorePanel;
    [SerializeField] TextMeshProUGUI m_Object;
    [HideInInspector] public bool isGameOver = false;
    public GameObject otherGameObject; 

    // Start is called before the first frame update
    void Start()
    {
        
        gameOverPanel.SetActive(false);

    }

    public void triggerGameOver()
    {
        isGameOver = true;
    }
    // Update is called once per frame
    void Update()
    {
        //Trigger game over manually and check with bool so it isn't called multiple times
        if (Input.GetKeyDown(KeyCode.G) && !isGameOver)
        {
            isGameOver = true;

            gameOverPanel.SetActive(true);
            curScorePanel.SetActive(false);

        }

        if (isGameOver)
        {
            gameOverPanel.SetActive(true);
            curScorePanel.SetActive(false);
            m_Object.text = "Score: " + (int)otherGameObject.GetComponent<score_tracker>().getScore();
            //If R is hit, restart the current scene
            if (Input.GetKeyDown(KeyCode.R))
            {
                Time.timeScale = 1;
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }

            //If Q is hit, quit the game
            if (Input.GetKeyDown(KeyCode.Q))
            {
                print("Application Quit");
                Application.Quit();
            }
        }
    }
}
