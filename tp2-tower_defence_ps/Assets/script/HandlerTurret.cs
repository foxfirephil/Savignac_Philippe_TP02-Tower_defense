using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HandlerTurret : MonoBehaviour
{
    public Button GunBtn;
    public Button BombBtn;
    public Button IceBtn;
    public Button SellBtn;
    public Button exitBtn;
    public GameObject UIBtn;

    private Turret turret;
    // Start is called before the first frame update
    void Start()
    {
        GunBtn.onClick.AddListener(assign_turret_gun);
        BombBtn.onClick.AddListener(assign_turret_bomb);
        IceBtn.onClick.AddListener(assign_turret_ice);
        SellBtn.onClick.AddListener(turret_sell);
        exitBtn.onClick.AddListener(exit_btn);
        SellBtn.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void assign_turret_gun()
    {
        UIBtn.SetActive(false);
        SellBtn.enabled = true;
        GunBtn.enabled = false;
        BombBtn.enabled = false;
        IceBtn.enabled = false;
        // return 1;
        assign_grakata(1);
    }
    void assign_turret_bomb()
    { 
        UIBtn.SetActive(false);
        SellBtn.enabled = true;
        GunBtn.enabled = false;
        BombBtn.enabled = false;
        IceBtn.enabled = false;
        //return 2;
        assign_grakata(2);
    }
    void assign_turret_ice()
    { 
        UIBtn.SetActive(false);
        SellBtn.enabled = true;
        GunBtn.enabled = false;
        BombBtn.enabled = false;
        IceBtn.enabled = false;
        //return 3;
        assign_grakata(3);
    }
    void turret_sell()
    { 
        UIBtn.SetActive(false);
        SellBtn.enabled = false;
        GunBtn.enabled=true;
        BombBtn.enabled = true;
        IceBtn.enabled = true;
        //return 0;
        assign_grakata(4);
    }

    void exit_btn()
    { UIBtn.SetActive(false); }

    void assign_grakata(int p_code)
    {
        turret = gameObject.GetComponentInParent<Turret>();
        switch(p_code)
        {
            case 1: turret.turret_gun(); break;
            case 2: turret.turret_bomb(); break;
            case 3: turret.turret_ice(); break;
            case 4: turret.turret_feet(); break;
        }
    }
}
