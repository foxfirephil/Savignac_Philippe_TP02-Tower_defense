using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public GameObject zombprefab;
    public GameObject warokprefab;
    public GameObject nshdprefab;

    float timer = 5f;
    // Start is called before the first frame update
    void Start()
    {

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
            zombie_inst();

            if (GameManager.level >= 4)
            { 
                nightshd_inst();
                zombie_inst();
            }
            if (GameManager.level >= 9)
            { 
                warrok_inst();
                zombie_inst();
            }
            if (GameManager.level >= 12)
            {
                nightshd_inst();
            }
            if (GameManager.level >=14)
            {
                warrok_inst();
            }
            if (GameManager.level >=16)
            {
                zombie_inst();
                zombie_inst();
                
            }
        }

        

    }

    void zombie_inst()
    {
        Instantiate(zombprefab, transform.position,Quaternion.identity);
        GameManager.nbEnnWave --;
    }
    void nightshd_inst()
    {
        Instantiate(nshdprefab, transform.position, Quaternion.identity);
        GameManager.nbEnnWave--;
    }
    void warrok_inst()
    {
        Instantiate(warokprefab, transform.position, Quaternion.identity);
        GameManager.nbEnnWave--;
    }
}
