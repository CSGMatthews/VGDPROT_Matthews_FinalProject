using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class MonsterController : MonoBehaviour
{
    public Transform m_target;
    public float m_moveSpeed = 8.0f;

    private NavMeshAgent m_agent;

    // Start is called before the first frame update
    void Start()
    {
        m_agent = GetComponent<NavMeshAgent>();
        m_agent.speed = m_moveSpeed;
    }

    private void Update()
    {
        m_agent.SetDestination(m_target.position);
    }

    private void OnTriggerEnter(Collider other)

    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player Died!");
            other.GetComponent<PlayerController>().GotCaught();
        }

    }
}