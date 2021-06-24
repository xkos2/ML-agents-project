using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.MLAgents;
using Unity.MLAgents.Actuators;
using Unity.MLAgents.Sensors;



public class brain : Agent
{
    
    [SerializeField] private Transform R1;
    [SerializeField] private Transform R2;

    
    [SerializeField] private MeshRenderer floorMeshRenderer;

    public override void OnEpisodeBegin()
    {
       transform.position = Vector3.zero;
    }
    public override void CollectObservations(VectorSensor sensor)
    {
        sensor.AddObservation(transform.position);
        sensor.AddObservation(R1.position);
        sensor.AddObservation(R2.position);
    }
    public override void OnActionReceived(ActionBuffers actions)
    {
        float moveX = actions.ContinuousActions[0];
        float moveZ = actions.ContinuousActions[1];
        float moveSpeed = 5.55f;
        transform.position += new Vector3(moveX, 0, moveZ) * Time.deltaTime * moveSpeed;

    }

    private void OnTriggerEnter(Collider other)
    {
      if(other.CompareTag("Finish"))
      {
         SetReward(+1f);
         EndEpisode();
         floorMeshRenderer.material.color = Color.green;
      }
      if(other.CompareTag("Respawn"))
      {
         SetReward(+5f);
         EndEpisode();
         floorMeshRenderer.material.color = Color.green;
      }
      if(other.CompareTag("Walls"))
      {
         SetReward(-2f);
         EndEpisode();
        floorMeshRenderer.material.color = Color.red;
      }
    }

}
