using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GunTurret : MonoBehaviour
{
    float radius = 10f;
    public float speed = 1.0f;
    AudioSource gunFireFX;

    // Start is called before the first frame update
    void Start()
    {
        gunFireFX = GetComponent<AudioSource>();
        InvokeRepeating("Check_colliders", 0f,0.05f);
        //InvokeRepeating("Zombie_damage",0f,1f);
    }

    private bool timerActive = false;
    private float timerGun = 1f;
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
                timerGun =1f;
                Zombie_damage();
            }
        }
    }

    void Check_colliders()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, radius);
        foreach (Collider c in colliders)
        {
            IZombie damageable = c.GetComponentInParent<IZombie>();
            if (damageable != null)
            {
                if (c.TryGetComponent(out Transform target))
                {
                    Vector3 targetDirection = target.position - transform.position;
                    float singleStep = speed * Time.deltaTime;
                    Vector3 newDirection = Vector3.RotateTowards(transform.forward, targetDirection, singleStep, 0.0f);
                    Debug.DrawRay(transform.position, newDirection, Color.red);
                    transform.rotation = Quaternion.LookRotation(newDirection);
                    transform.localEulerAngles = new Vector3(0, 0, transform.localEulerAngles.z);
                    timerActive = true;
                    break;
                }
            }
        }
    }

    void Zombie_damage() 
    {
        gunFireFX.Play();
        Collider[] colliders = Physics.OverlapSphere(transform.position, radius);
        foreach (Collider c in colliders)
        {
            IZombie damageable = c.GetComponentInParent<IZombie>();
            if (damageable != null)
            {
                damageable.TakeDamage();
                break;
            }
        }
            
    }
}
