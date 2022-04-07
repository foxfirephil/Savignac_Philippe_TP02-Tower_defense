using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie : MonoBehaviour, IZombie
{
    public int lifebar;
    Rigidbody[] rbs;
    Animator animator;
    AudioSource deathsound;

    // Start is called before the first frame update
    void Start()
    {
        rbs = GetComponentsInChildren<Rigidbody>();
        animator = GetComponent<Animator>();
        deathsound = GetComponent<AudioSource>();

        ToggRagdoll(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void TakeDamage()
    {
        if (lifebar <= 0)
        {
            deathsound.Play();
            Die();
        }
    }

    void Die()
    {
        ToggRagdoll(true);
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
