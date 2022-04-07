using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombTurret : MonoBehaviour
{
    private float radius = 10f;
    public float speed = 1.0f;

    public GameObject PrefabBomb;
    public Transform barrel;

    AudioSource bombFireFX;

    private bool timerActive = false;
    private float timerBomb = 5f;
    // Start is called before the first frame update
    void Start()
    {
        barrel = GetComponent<Transform>();
        bombFireFX = GetComponent<AudioSource>();
        InvokeRepeating("Check_colliders", 0f, 0.05f);
    }


    // Update is called once per frame
    void Update()
    {
        if (timerActive)
        {
            if (timerBomb > 0)
            {
                timerBomb -= Time.deltaTime;
            }
            if (timerBomb < 0)
            {
                timerActive = false;
                timerBomb = 5f;
                Zombie_bomb();
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

    void Zombie_bomb()
    {
        bombFireFX.Play();
        Instantiate(PrefabBomb, barrel.position, Quaternion.identity);
        Rigidbody rigidBody = PrefabBomb.GetComponent<Rigidbody>();
        rigidBody.AddForce(transform.forward * 10f, ForceMode.Impulse);
    }
}
