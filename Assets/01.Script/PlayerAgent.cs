using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.MLAgents;
using Unity.MLAgents.Sensors;
using Unity.MLAgents.Actuators;

public class PlayerAgent : Agent
{
    public MapManager m;
    public UIManager u;
    public override void Initialize()
    {

    }
    public override void OnEpisodeBegin()
    {
        //포지션초기화해주고 배열값 변경
        m.x = 2;
        m.y = 1;
        m.a.transform.position = new Vector3(-3.05f, -3.57f, 0);
        m.moveCnt = 0;
    }
    public override void CollectObservations(VectorSensor sensor)
    {
        sensor.AddObservation(transform.position);
        //base.CollectObservations(sensor);
    }
    public override void OnActionReceived(ActionBuffers actions)
    {
        if (actions.DiscreteActions[0] == 0)
        {
            m.plusValue = 1;
            m.moveCnt++;
            u.SetText();
            Minus();

            if (m.mapArrays[m.y].array[m.x + m.plusValue] == 1)
            {
               // m.a.transform.position += new Vector3(0.2f, 0f, 0f);// Translate(Vector3.right);
               m.a.transform.Translate(Vector3.right);
                m.x++;
                m.plusValue = 0;
            }
            else if (m.mapArrays[m.y].array[m.x + m.plusValue] == 2)
            {
                m.a.transform.Translate(Vector3.right);
                m.x++;

                if (m.Clear())
                {
                    AddReward(200f);
                    u.SetMinText();

                    Debug.Log("잘 끝남");
                }
                else
                {
                    AddReward(100f);
                    Debug.Log("멍청하게끝남");
                    Debug.Log(m.moveCnt);
                }
                EndEpisode();
            }
            else
            {
                AddReward(-1f);
                Debug.Log("못가요 바보");
            }
        }
        if (actions.DiscreteActions[0] == 1)
        {
            m.plusValue = -1;
            m.moveCnt++;
            u.SetText();
            Minus();

            if (m.mapArrays[m.y].array[m.x + m.plusValue] == 1)
            {
                m.a.transform.Translate(Vector3.left);
                m.x--;
                m.plusValue = 0;
            }
            else if (m.mapArrays[m.y].array[m.x + m.plusValue] == 2)
            {
                m.a.transform.Translate(Vector3.left);
                m.x--;

                if (m.Clear())
                {
                    AddReward(200f);
                    u.SetMinText();

                    Debug.Log("잘 끝남");
                }
                else
                {
                    AddReward(100f);
                    Debug.Log("멍청하게끝남");
                    Debug.Log(m.moveCnt);

                }
                EndEpisode();
            }
            else
            {
                AddReward(-1f);
                Debug.Log("못가요 바보");
            }
        }
        if (actions.DiscreteActions[0] == 2)
        {
            m.plusValue = 1;
            m.moveCnt++;
            u.SetText();
            Minus();

            if (m.mapArrays[m.y + m.plusValue].array[m.x] == 1)
            {
                m.a.transform.Translate(Vector3.up);
                m.y++;
                m.plusValue = 0;
            }
            else if (m.mapArrays[m.y + m.plusValue].array[m.x + m.plusValue] == 2)
            {
                m.a.transform.Translate(Vector3.up);
                m.y++;

                if (m.Clear())
                {
                    AddReward(200f);
                    u.SetMinText();

                    Debug.Log("잘 끝남");
                }
                else
                {
                    AddReward(100f);

                    Debug.Log("멍청하게끝남");
                }
                EndEpisode();
            }
            else
            {
                AddReward(-1f);
                Debug.Log("못가요 바보");
            }
        }
        if (actions.DiscreteActions[0] == 3)
        {
            m.plusValue = -1;
            m.moveCnt++;
            u.SetText();

            Minus();

            if (m.mapArrays[m.y + m.plusValue].array[m.x] == 1)
            {
                m.a.transform.Translate(Vector3.down);
                m.y--;
                m.plusValue = 0;
            }
            else if (m.mapArrays[m.y + m.plusValue].array[m.x + m.plusValue] == 2)
            {
                m.a.transform.Translate(Vector3.down);
                m.y--;

                if (m.Clear())
                {
                    AddReward(200f);
                    u.SetMinText();
                    Debug.Log("잘 끝남");
                }
                else
                {
                    AddReward(100f);
                    Debug.Log("멍청하게끝남");
                }
                EndEpisode();
            }
            else
            {
                AddReward(-1f);
                Debug.Log("못가요 바보");
            }
        }
    }
    public void Minus()
    {
        if (m.moveCnt % 5 == 0)
        {
            AddReward(-0.5f);
        }
    }
    public override void Heuristic(in ActionBuffers actionsOut)
    {
        //var DiscreteActionOut = actionsOut.DiscreteActions;
        //if (Input.GetKey(KeyCode.D))
        //{
        //    DiscreteActionOut[0] = 1;
        //}
        //if (Input.GetKey(KeyCode.A))
        //{
        //    DiscreteActionOut[0] = 2;
        //}
        //if (Input.GetKey(KeyCode.W))
        //{
        //    DiscreteActionOut[0] = 3;
        //}
        //if (Input.GetKey(KeyCode.S))
        //{
        //    DiscreteActionOut[0] = 4;
        //}
    }
}
