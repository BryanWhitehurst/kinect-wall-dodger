using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class wall_deletion : MonoBehaviour
{

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "wall")
        {
            Destroy(other.gameObject);
        }
    }
}
