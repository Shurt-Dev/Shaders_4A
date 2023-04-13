using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using System;

public class FollowPlayer : MonoBehaviour
{
    public Transform _Player;
    public bool Detect;
    private int rangeDetect = 5;

    NavMeshAgent _agent;

    void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
    }

    private void OnDetect()
    {
        double Distanceplayer = (double)Math.Sqrt((Math.Pow(_Player.position.x- transform.position.x, 2)) + (Math.Pow(_Player.position.y - transform.position.y, 2)));
        print(Distanceplayer);
        if (Distanceplayer <= rangeDetect)
        {
            Detect= true;
        }
    }
    void Update()
    {
        OnDetect();
        if (Detect == true)
        {
            _agent.SetDestination(_Player.position);
        }
       
    }

}
