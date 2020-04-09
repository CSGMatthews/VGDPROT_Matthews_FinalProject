using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class MonsterController : MonoBehaviour
{
    public Transform m_target;
    public float m_moveSpeed = 8.0f;

   
    private Text m_deadLabel;

    private NavMeshAgent m_agent;

    // Start is called before the first frame update
    private void Start()
    {
        m_deadLabel = FindObjectOfType<Text>();
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
            m_deadLabel.enabled = true;
            other.GetComponent<PlayerController>().GotCaught();
        }

    }
}