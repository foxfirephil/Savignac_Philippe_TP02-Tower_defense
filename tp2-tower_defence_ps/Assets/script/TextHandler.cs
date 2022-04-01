using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextHandler : MonoBehaviour
{
    public Text textCoins;
    public Text textDeath;
    public Text textLife;
    public GameObject[] listEnn;
    
    
    // Start is called before the first frame update
    void Start()
    {
        listEnn= FindObjectsOfType<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        Update_text_coins(coins.nbCoins);
        Update_text_death(listEnn.Length);
        Update_text_life(life.nbLife);
    }

    void Update_text_coins(int p_coins)
    {textCoins.text="Argents : "+p_coins.ToString();}
    void Update_text_death(int p_nbEnn)
    {textDeath.text="Ennemies : "+p_nbEnn.ToString();}
    void Update_text_life(int p_nbVie)
    {textLife.text="Pt. de Vie : "+p_nbVie.ToString();}
}
