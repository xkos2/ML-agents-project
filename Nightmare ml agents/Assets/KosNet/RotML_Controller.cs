using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.MLAgents;
using Unity.MLAgents.Actuators;
using Unity.MLAgents.Sensors;
using TMPro;


public class RotML_Controller : Agent
{

    [SerializeField] private Transform Reward_1;
    [SerializeField] private Transform Reward_2;
    [SerializeField] private MeshRenderer Platform;

    public TextMeshProUGUI rewardtext;
    float Reward = 0f;


    public override void OnEpisodeBegin()
    {
        transform.position = Vector3.zero;
    }
    public override void CollectObservations(VectorSensor sensor)
    {
        sensor.AddObservation(transform.position);
        sensor.AddObservation(Reward_1.position);
        sensor.AddObservation(Reward_2.position);
    }



    public override void OnActionReceived(ActionBuffers actions)
    {
        float moveX = actions.ContinuousActions[0];
        float moveZ = actions.ContinuousActions[1];
        float moveSpeed = 5f;
        transform.position += new Vector3(moveX, 0, moveZ) * Time.deltaTime * moveSpeed;


    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("1"))
        {
            SetReward(1f);
            Reward += 1;
            EndEpisode();
            Platform.material.color = Color.green;
        }


        if (other.CompareTag("5"))
        {
            SetReward(+5f);
            Reward += 5;
            EndEpisode();
            Platform.material.color = Color.green;
        }

        if (other.CompareTag("Walls"))
        {
            SetReward(Reward * -1f);
            Reward -= 1f;
            EndEpisode();
            Platform.material.color = Color.red;
        }
    }
    private void Update()
    {
        rewardtext.text = Reward.ToString();
    }

}

