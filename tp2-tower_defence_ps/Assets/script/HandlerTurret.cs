using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HandlerTurret : MonoBehaviour
{
    //instance des boutons du UI des tourelles
    public Button GunBtn;
    public Button BombBtn;
    public Button IceBtn;
    public Button SellBtn;

    //instance du bouton exit du UI des tourelles
    public Button exitBtn;

    //instance du parent canvas UI des tourelles
    public GameObject UIBtn;

    //désignation des prix
    int GunPrix=100;
    int BombPrix=200;
    int IcePrix=250;
    int grakata;

    //appel du script turret
    private Turret turret;

    // Start is called before the first frame update
    void Start()
    {
        //ajout des Listener
        GunBtn.onClick.AddListener(assign_turret_gun);
        BombBtn.onClick.AddListener(assign_turret_bomb);
        IceBtn.onClick.AddListener(assign_turret_ice);
        SellBtn.onClick.AddListener(turret_sell);
        exitBtn.onClick.AddListener(exit_btn);

        //désactiver la vente quand il n'y a pas de tourelle placé
        SellBtn.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void assign_turret_gun()
    {
        Coins.nbCoins -= GunPrix;
        ui_change_sell();
        // return 1;
        grakata = 1;
        assign_grakata(grakata);

    }
    void assign_turret_bomb()
    {
        Coins.nbCoins -= BombPrix;
        ui_change_sell();
        //return 2;
        grakata = 2;
        assign_grakata(grakata);
    }
    void assign_turret_ice()
    {
        Coins.nbCoins -= IcePrix;
        ui_change_sell();
        //return 3;
        grakata = 3;
        assign_grakata(grakata);
    }
    void turret_sell()
    {
        //vend le prix en fonction de la tourelle
        switch (grakata)
        {
            case 1: Coins.nbCoins += GunPrix/2; break;
            case 2: Coins.nbCoins += BombPrix / 2; break;
            case 3: Coins.nbCoins += IcePrix / 2; break;
        }

        //ferme le UI
        UIBtn.SetActive(false);
        //désactive le bouton vendre
        SellBtn.enabled = false;
        //actives les achats boutons des tourelles
        GunBtn.enabled = true;
        BombBtn.enabled = true;
        IceBtn.enabled = true;
        //return 0;
        assign_grakata(4);
    }

    //ferme le UI sans activé de changements
    void exit_btn()
    { UIBtn.SetActive(false); }

    void ui_change_sell()
    { 
        //ferme le UI
        UIBtn.SetActive(false);
        //assigne le bouton vendre comme seul actif
        SellBtn.enabled = true;
        //désactive les achats boutons des tourelles
        GunBtn.enabled = false;
        BombBtn.enabled = false;
        IceBtn.enabled = false;
    }

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
