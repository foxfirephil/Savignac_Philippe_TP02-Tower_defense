using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public GameObject zombprefab;
    public GameObject warokprefab;
    public GameObject nshdprefab;
    public int level;

    private float timer = 5f;
    // Start is called before the first frame update
    void Start()
    {
        level = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (timer > 0)
        {
            timer -= Time.deltaTime;
        }
        if (timer < 0)
        {
            timer = 5f;
            zombie_inst();
            nightshd_inst();
            warrok_inst();
        }

        

    }

    void zombie_inst()
    {
        Instantiate(zombprefab, transform.position,Quaternion.identity);
    }
    void nightshd_inst()
    {
        Instantiate(nshdprefab, transform.position, Quaternion.identity);
    }
    void warrok_inst()
    {
        Instantiate(warokprefab, transform.position, Quaternion.identity);
    }
}
