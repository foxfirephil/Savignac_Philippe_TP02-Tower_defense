using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Levitate : MonoBehaviour
{
    NavMeshAgent agent;
    Animator animLev;
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animLev = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        var navArea = new NavMeshHit();

        agent.SamplePathPosition(-1, 0.0f, out navArea);

        if (navArea.mask != 1)
        { animLev.SetBool("levitate", true); } // = true;
        else
        { animLev.SetBool("levitate", false); }// = false;
    }
}
