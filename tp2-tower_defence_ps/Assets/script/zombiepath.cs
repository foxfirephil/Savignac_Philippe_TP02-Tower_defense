using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class zombiepath : MonoBehaviour
{
    NavMeshAgent agent;
    private float X = 15.24f;
    private float Z = -52.86f;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 destination = new Vector3(X,0.9f,Z);
        agent.SetDestination(destination);
    }
}
