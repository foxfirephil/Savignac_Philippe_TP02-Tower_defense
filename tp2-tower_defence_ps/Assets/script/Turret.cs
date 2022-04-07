using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    public GameObject UiTourelle;
    public GameObject Gun_turret;
    public GameObject Bomb_turret;
    public GameObject Ice_turret;
    

    // Start is called before the first frame update
    void Start()
    {
        UiTourelle.SetActive(false);
    }

    void Update()
    {

    }
    public void turret_feet()
    {
        GetComponent<MeshRenderer>().enabled = true;
        Gun_turret.SetActive(false);
        Bomb_turret.SetActive(false);
        Ice_turret.SetActive(false);

    }
    public void turret_gun()
    { Gun_turret.SetActive(true); }

    public void turret_bomb()
    {
        GetComponent<MeshRenderer>().enabled = false;
        Bomb_turret.SetActive(true);
    }
    public void turret_ice()
    {
        GetComponent<MeshRenderer>().enabled = false; 
        Ice_turret.SetActive(true);
    }

    private void OnMouseDown()
    {
        if (FindObjectOfType<GameManager>().IsStart)
        { UiTourelle.SetActive(true); }
    }
}
