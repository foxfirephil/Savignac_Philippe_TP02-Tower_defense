using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceTurret : MonoBehaviour
{
    private float radius = 10f;
    public float speed = 1.0f;

    AudioSource bombFireFX;

    private bool timerActive = false;
    private float timerBomb = 5f;
    // Start is called before the first frame update
    void Start()
    {
        bombFireFX = GetComponent<AudioSource>();
        InvokeRepeating("Check_colliders_ice", 0f, 10f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Check_colliders_ice()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, radius);
        foreach (Collider c in colliders)
        {
            IFreeze movslow = c.GetComponentInParent<IFreeze>();
            if (movslow != null)
            {
                movslow.slow();
                break;
            }
        }
    }
}
