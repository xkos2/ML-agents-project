using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EnemyActions : MonoBehaviour
{
     public TextMeshProUGUI enemyscore;
     int penalty;

    private void Update()
    {
        transform.Translate(0, 0, 0.01f);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            transform.position = new Vector3(3.25f, 0, Random.Range(+0.66f, -1.4f));


        }
        if (other.CompareTag("Finish"))
        {
            transform.position = new Vector3(3.25f, 0, Random.Range(+0.66f, -1.4f));
            penalty += 1;
            enemyscore.text = penalty.ToString();
        }
    }
}
