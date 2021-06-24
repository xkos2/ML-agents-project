using UnityEngine;
using Unity.MLAgents;
using Unity.MLAgents.Actuators;
using Unity.MLAgents.Sensors;


public class findthecube : Agent
{
    public Transform finish;
    public override void OnEpisodeBegin()
    {
        transform.position = new Vector3(0,0,0);
        finish.transform.position = new Vector3(Random.Range(-2.6f,2.6f),0,Random.Range(2.22f,-2.91f));

    }
    public override void CollectObservations(VectorSensor sensor)
    {
        sensor.AddObservation(transform.position);
        sensor.AddObservation(finish.position);
    }

    public override void OnActionReceived(ActionBuffers actions)
    {
        float moveX = actions.ContinuousActions[0];
        float moveZ = actions.ContinuousActions[1];
        float speed = 5f;
        transform.position += new Vector3(moveX, 0, moveZ) * speed * Time.deltaTime;
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Finish"))
        {
            SetReward(+1f);
            EndEpisode();
        }
          if(other.CompareTag("Walls"))
        {
            SetReward(-1f);
            EndEpisode();
        }
    }
}
