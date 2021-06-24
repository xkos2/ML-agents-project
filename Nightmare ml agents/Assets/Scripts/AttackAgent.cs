using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.MLAgents;
using Unity.MLAgents.Actuators;
using Unity.MLAgents.Sensors;
using TMPro;

public class AttackAgent : Agent
{
    public Transform Enemy;
    public TextMeshProUGUI playerscore;
   
    int reward;
    

    public override void OnEpisodeBegin()
    {
        transform.position = Vector3.zero;
      
    }
    public override void CollectObservations(VectorSensor sensor)
    {
        sensor.AddObservation(transform.position);
        sensor.AddObservation(Enemy.position);
    }

    public override void OnActionReceived(ActionBuffers actions)
    {
        float moveZ = actions.ContinuousActions[0];
        float speed = 5f;
        transform.position += new Vector3(0, 0, moveZ * speed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            SetReward(+1f);
            reward += 1;
            playerscore.text = reward.ToString();
            EndEpisode();
        }
         if (other.CompareTag("Walls"))
        {
            SetReward(-1f);
           
            EndEpisode();
        }
    }
    private void Update()
    {
        if(Enemy.transform.position == new Vector3(-0.6f,0,0))
        {
            SetReward(-1f);
            EndEpisode();
            Debug.Log("done");
        }
    }
}









