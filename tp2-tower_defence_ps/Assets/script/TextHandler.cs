using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextHandler : MonoBehaviour
{
    public Text textCoins;
    public Text textDeath;
    public Text textLife;
    public Text textTimer;
    public Text textLevel;

    float montre = 0f;
    int c;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        montre += Time.deltaTime;
        double b = System.Math.Round(montre, 2);

        if (montre > 60)
        { 
            c += 1;
            montre = 0;
        }


        Update_text_coins(Coins.nbCoins);
        Update_text_death(GameManager.nbEnn);
        Update_text_life(Life.nbLife);
        Update_text_timer(b,c);
        Update_text_level(GameManager.level);
        
    }

    void Update_text_coins(int p_coins)
    {textCoins.text="Argents : "+p_coins.ToString();}
    void Update_text_death(int p_nbEnn)
    {textDeath.text="Ennemies : "+p_nbEnn.ToString();}
    void Update_text_life(int p_nbVie)
    {textLife.text="Pt. de Vie : "+p_nbVie.ToString();}
    void Update_text_timer(double p_nbsec,int p_nbmin)
    { textTimer.text = p_nbmin.ToString()+":"+p_nbsec.ToString(); }
    void Update_text_level(int p_nblevel)
    { textLevel.text = "Niveau : "+p_nblevel.ToString(); }
}
