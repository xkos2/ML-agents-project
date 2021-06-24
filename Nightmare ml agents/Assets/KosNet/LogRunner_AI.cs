using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.MLAgents;
using Unity.MLAgents.Actuators;
using Unity.MLAgents.Sensors;

public class LogRunner_AI : Agent
{
    public Transform Pipe;
    public Transform Finish;
    private Vector2 lastTapPos;
    private Vector3 startRotation;
    private void Start()
    {
        startRotation = transform.localEulerAngles;
    }
    private void Update()
    {
        transform.Translate(0, 0, 0.3f * Time.deltaTime);
    }


    public override void OnEpisodeBegin()
    {
        transform.position = Vector3.zero;
    }
    public override void CollectObservations(VectorSensor sensor)
    {
        sensor.AddObservation(transform.position);
        sensor.AddObservation(Pipe.transform.position);
        sensor.AddObservation(Finish.transform.position);
    }



    public override void OnActionReceived(ActionBuffers actions)
    {
        float RotX = actions.ContinuousActions[0];

        //float moveZ = actions.ContinuousActions[1];
        float RotSpeed = 3f;
        //float MoveSpeed = 3f;
        //transform.position += new Vector3(0, 0, moveZ) * MoveSpeed * Time.deltaTime;
        Pipe.transform.Rotate(0, RotX * RotSpeed * Time.deltaTime, 0);
            
         
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Finish"))
        {
            SetReward(+1f);
            EndEpisode();
        }
        if (other.CompareTag("Walls"))
        {
            SetReward(-1f);
            EndEpisode();
        }
    }



}
