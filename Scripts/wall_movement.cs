using UnityEngine;

public class wall_movement : MonoBehaviour
{

    public float speed;

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * speed);
    }
}
