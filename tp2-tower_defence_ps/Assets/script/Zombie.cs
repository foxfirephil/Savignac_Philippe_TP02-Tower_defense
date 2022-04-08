using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie : MonoBehaviour, IZombie
{
    public int lifebar;
    Rigidbody[] rbs;
    Animator animator;
    AudioSource deathsound;
    Collider bodyCol;

    // Start is called before the first frame update
    void Start()
    {
        rbs = GetComponentsInChildren<Rigidbody>();
        animator = GetComponent<Animator>();
        deathsound = GetComponent<AudioSource>();
        bodyCol = GetComponent<Collider>();

        ToggRagdoll(false);
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void TakeDamage()
    {
        lifebar -= 1;
        if (lifebar <= 0)
        {
            Die();
            lifebar = 10000;
        }
    }

    void Die()
    {
        ToggRagdoll(true);
        bodyCol.enabled = false;
        GameManager.nbEnn += 1;
        GameManager.nbEnnWave -= 1;
        Coins.nbCoins += 100;
        deathsound.Play();
        Destroy(gameObject, 2f);
    }

    void ToggRagdoll(bool value)
    {
        foreach (var r in rbs)
        {
            r.isKinematic = !value;
        }

        animator.enabled = !value;
    }
}
