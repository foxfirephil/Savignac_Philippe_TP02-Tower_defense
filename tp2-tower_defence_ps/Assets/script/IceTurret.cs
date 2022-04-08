using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceTurret : MonoBehaviour
{
    //public instance
    public float speed = 1.0f;

    //child instance
    AudioSource bombFireFX;
    ParticleSystem glace;

    //private instance
    private float radius = 10f;
    private bool timerActive = false;
    private float timerBomb = 5f;

    // Start is called before the first frame update
    void Start()
    {
        bombFireFX = GetComponent<AudioSource>();
        glace = GetComponentInChildren<ParticleSystem>();
        //vérifie a chaque 5 seconde les colliders
        InvokeRepeating("Check_colliders_ice", 0f, 5f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Check_colliders_ice()
    {
        //charche les objet qui ont un collider
        Collider[] colliders = Physics.OverlapSphere(transform.position, radius);
        foreach (Collider c in colliders)
        {
            //vérifier s'il est membre IFreeze
            IFreeze movslow = c.GetComponentInParent<IFreeze>();
            if (movslow != null)
            {
                //rallenti le zombie
                movslow.slow();
                //joue l'effet de neige
                glace.Play();
                break;
            }
        }
    }
}
