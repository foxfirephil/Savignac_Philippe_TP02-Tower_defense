using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ZombiePath : MonoBehaviour, IFreeze
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
        Collider[] colliders = Physics.OverlapSphere(transform.position, 0.4f);

        foreach (var item in colliders)
        {
            // Si l'un des collider est la fin du path, joueur pert 1pv
            if (item.name == "pathend")
            {
                Life.nbLife -= 1;
                Destroy(gameObject);
                break;
            }
        }
    }

    public void slow()
    { agent.speed=-2; }
}
