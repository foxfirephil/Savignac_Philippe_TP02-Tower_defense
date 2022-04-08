using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Zombie : MonoBehaviour, IZombie
{
    //public instance
    public int lifebar;

    //child instance
    Slider lifebarSld;
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
        lifebarSld = GetComponentInChildren<Slider>();

        //désactiver le ragdoll quand il spawn
        ToggRagdoll(false);
    }

    // Update is called once per frame
    void Update()
    {
        //changer la valeur de la lifebar
        lifebarSld.value = lifebar/100;
    }
    public void TakeDamage()
    {
        //si dégat, enleve 1 pv
        lifebar -= 1;
        //si les pvs on 0 il meurt
        if (lifebar <= 0)
        {
            Die();
            //patcher mon bug quand y meurt
            lifebar = 10000;
        }
    }

    void Die()
    {
        ToggRagdoll(true);
        bodyCol.enabled = false;
        //ajout au compteur global d'ennemies
        GameManager.nbEnn += 1;
        //ajout de l'argent au joueur
        Coins.nbCoins += 20;
        deathsound.Play();
        //détruit apres 2 secondes
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
