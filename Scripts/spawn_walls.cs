using System.Collections.Generic;
using System.Reflection;
using System.Runtime.InteropServices;
using UnityEngine;

public class spawn_walls : MonoBehaviour
{

    public GameObject[] myObjects;

    public float spawnDelay;
    private float currentTime;
    public float speed;
    public float timeStore;
    public int currentLevel = 0; 
    // Start is called before the first frame update
    void Start()
    {
        currentTime = 0.0f;
        speed = 2;
        spawnDelay = 0;
        timeStore = 5f;
        
    }

    void Update()
    {
        if (spawnDelay > 0)
        {
            spawnDelay -= Time.deltaTime;
        }

        else if (spawnDelay <= 0) 
        {
            SpawnWall();
            spawnDelay = timeStore;
        }
  
        currentTime += Time.deltaTime;

        if (currentTime >= 20 && currentLevel == 0)
        {
            currentTime = 0.0f;
            speed = 3.5f;
            timeStore = 3f;
            currentLevel = 1;

        }
        else if (currentTime >= 20 && currentLevel == 1)
        {
            currentTime = 0.0f;
            speed = 5f;
            timeStore = 2f;
            currentLevel = 2;
        }
    }
    public void SpawnWall() 
    {
        var rnum = Random.Range(0, myObjects.Length);
        GameObject rObject = myObjects[rnum];
        Vector3 spawnPos = new Vector3(0f, 0f, 0f);
        if (rObject.name == "left_wall" || rObject.name == "left_thick") spawnPos = new Vector3(0.39f, 1.31f, -12.07f);
        else if (rObject.name == "right_wall" || rObject.name == "right_thick") spawnPos = new Vector3(-1.1f, 1.31f, -12.07f);
        else if (rObject.name == "up_full") spawnPos = new Vector3(-0.15f, 1.953f, -12.07f);

        var newWall = Instantiate(myObjects[rnum], spawnPos, Quaternion.identity);
        wall_movement script = newWall.GetComponent(typeof(wall_movement)) as wall_movement;
        script.speed = speed;
        //Instantiate(wall, transform.position, transform.rotation);       
    }  
    
}
