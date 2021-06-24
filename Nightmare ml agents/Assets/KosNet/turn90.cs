using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class turn90 : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Respawn"))
        {
            transform.Rotate(0,90,0);
        }
    }
}
