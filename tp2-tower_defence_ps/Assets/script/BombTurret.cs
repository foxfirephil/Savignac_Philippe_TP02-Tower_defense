using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombTurret : MonoBehaviour
{
    //instances private
    private float radius = 10f;
    public float speed = 1.0f;

    //instance public
    public GameObject PrefabBomb;
    public Transform barrel;

    //instance des childs
    AudioSource bombFireFX;
    ParticleSystem smoke;

    private bool timerActive = false;
    private float timerBomb = 5f;
    // Start is called before the first frame update
    void Start()
    {
        barrel = GetComponent<Transform>();
        bombFireFX = GetComponent<AudioSource>();
        smoke = GetComponentInChildren<ParticleSystem>();
        //vérifie les colliders au 0.05 secondes
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
                //régénerre le timer
                timerBomb = 5f;

                //lance la bombe
                Zombie_bomb();

                //lance la fumee
                smoke.Play();
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

    void Zombie_bomb()
    {
        bombFireFX.Play();
        //fait apparaitre la bombe
        Instantiate(PrefabBomb, barrel.position, Quaternion.identity);

        //applique une force sur le rigidbody
        Rigidbody rigidBody = PrefabBomb.GetComponent<Rigidbody>();
        rigidBody.AddForce(transform.forward * 10f, ForceMode.Impulse);
    }
}
