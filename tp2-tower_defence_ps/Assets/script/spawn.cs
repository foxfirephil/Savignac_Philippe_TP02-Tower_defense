using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawn : MonoBehaviour
{

    public GameObject zombprefab;
    public GameObject warokprefab;
    public GameObject nshdprefab;
    public int level;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < level; i++)
        {
            Instantiate(zombprefab, transform.position,Quaternion.identity);
            Instantiate(warokprefab, transform.position,Quaternion.identity);
            Instantiate(nshdprefab, transform.position,Quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
        
    }
}
