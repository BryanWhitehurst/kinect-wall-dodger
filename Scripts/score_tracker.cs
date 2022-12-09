using System.Globalization;
using UnityEngine;
using TMPro;

public class score_tracker : MonoBehaviour
{

    //how long player has been alive for, display at the end of the game
    private float timespent = 0.0f;

    public TextMeshProUGUI curScoreText;
    

    //create reference to UI Manager
    //get isGameOver variable 
    //UI manager, which contains game_over variable, is assiged to this var in Unity
    public GameObject game_over;
    // Update is called once per frame
    void Update()
    {
        //if we haven't reached game over, continue to increase time
        if (!game_over.GetComponent<game_over>().isGameOver) timespent += Time.deltaTime;

        curScoreText.text = "Score: " + (int)timespent;
    }

    public float getScore() {
        return timespent;
    }
}
