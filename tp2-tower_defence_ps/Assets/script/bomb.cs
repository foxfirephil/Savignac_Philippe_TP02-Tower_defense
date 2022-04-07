using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bomb : MonoBehaviour
{
    const float radius = 50f;
    // Start is called before the first frame update
    void Start()
    {
        //appeler explose apres 3 secondes
        Invoke("Explode", 3f);
    }

    
    void Explode()
    {
        // reccuperer les objets a proximite
        Collider[] colliders = Physics.OverlapSphere(transform.position,radius);

        //sil a un rigidBody>expulser
        foreach (Collider c in colliders)
        {

            IZombie damageable = c.GetComponentInParent<IZombie>();

            if (damageable != null)
            { damageable.TakeDamage(); }

            if (c.TryGetComponent(out Rigidbody rb))
            {
                //on a trouver un rigiid boddy, donc appliquer la force
                rb.AddExplosionForce(300f,transform.position, radius, 2f);
            }
        }
        //detruire la bombe
        Destroy(gameObject);
    }
}
