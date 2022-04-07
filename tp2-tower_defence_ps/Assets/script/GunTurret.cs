using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunTurret : MonoBehaviour
{
    Collider zombie;
    float radius = 1000f;
    public float speed = 1.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        check_colliders();
        
        
    }
    private void OnTriggerEnter(Collider p_zombie)
    {
        zombie = p_zombie;
    }

    void check_colliders()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, radius);
        foreach (Collider c in colliders)
        {
            Debug.Log("betterhappen");
            IZombie damageable = c.GetComponentInParent<IZombie>();
            if (damageable != null)
            {
                Debug.Log("betterhappen2");
                Vector3 targetDirection = zombie.transform.position - transform.position;
                float singleStep = speed * Time.deltaTime;
                Vector3 newDirection = Vector3.RotateTowards(transform.forward, targetDirection, singleStep, 0.0f);
                Debug.DrawRay(transform.position, newDirection, Color.red);
                transform.rotation = Quaternion.LookRotation(newDirection);
            }
        }
    }
}
