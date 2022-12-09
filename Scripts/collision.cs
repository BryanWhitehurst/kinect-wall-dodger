using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Threading;
using UnityEngine;
using UnityEngine.SceneManagement;

public class collision : MonoBehaviour
{

    //create reference to
    public GameObject game_over;

    // This function is called when a collision happens between a moving wall and a player
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "wall") 
        {
            Debug.Log("Contact made between object and player, triggering game over");
            Debug.Log("Name of collider " + other.gameObject.name);
            Time.timeScale = 0;
            game_over.GetComponent<game_over>().triggerGameOver();
        }
    }  
}
