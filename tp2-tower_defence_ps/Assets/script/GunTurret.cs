using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GunTurret : MonoBehaviour
{
    //instance private
    private float radius = 10f;
    private bool timerActive = false;
    private float timerGun = 1f;

    //instance public
    public float speed = 1.0f;

    //instance child
    AudioSource gunFireFX;
    ParticleSystem bullet;

    // Start is called before the first frame update
    void Start()
    {
        gunFireFX = GetComponent<AudioSource>();
        bullet = GetComponentInChildren<ParticleSystem>();
        //vérifie les colliders au 0.05 secondes
        InvokeRepeating("Check_colliders", 0f,0.05f);

    }

    // Update is called once per frame
    void Update()
    {
        if (timerActive)
        {
            if (timerGun > 0)
            {
                timerGun -= Time.deltaTime;
            }
            if (timerGun < 0)
            {
                timerActive = false;
                //régénerre le timer
                timerGun = 1f;

                //tire
                Zombie_damage();

                //effet de balles
                bullet.Play();
            }
        }
    }

    void Check_colliders()
    {
        //charche les objet qui ont un collider
        Collider[] colliders = Physics.OverlapSphere(transform.position, radius);
        foreach (Collider c in colliders)
        {
            //vérifier s'il est membre IZombie
            IZombie damageable = c.GetComponentInParent<IZombie>();
            if (damageable != null)
            {
                //on cherche son parametre Transfom
                if (c.TryGetComponent(out Transform target))
                {
                    //place la direction
                    Vector3 targetDirection = target.position - transform.position;

                    //dicte la valeur a laquelle la tourelle tourne
                    float singleStep = speed * Time.deltaTime;

                    //redirige vers la direction placé
                    Vector3 newDirection = Vector3.RotateTowards(transform.forward, targetDirection, singleStep, 0.0f);
                    Debug.DrawRay(transform.position, newDirection, Color.red);

                    //tourne la tourelle vers la direction voulu en gelant ses rotations sauf l'axe Z
                    transform.rotation = Quaternion.LookRotation(newDirection);
                    transform.localEulerAngles = new Vector3(0, 0, transform.localEulerAngles.z);

                    //redémarre le compteur
                    timerActive = true;
                    break;
                }
            }
        }
    }

    void Zombie_damage() 
    {
        gunFireFX.Play();
        //cherche leur colliders
        Collider[] colliders = Physics.OverlapSphere(transform.position, radius);
        foreach (Collider c in colliders)
        {
            //vérifier s'il est membre IZombie
            IZombie damageable = c.GetComponentInParent<IZombie>();
            if (damageable != null)
            {
                //infliger du dégat
                damageable.TakeDamage();
                break;
            }
        }
            
    }
}
