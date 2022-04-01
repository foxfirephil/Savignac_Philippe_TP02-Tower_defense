using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class pauseHandler : MonoBehaviour
{
    public Button BtnPause;
    public Button BtnPlay;
    public GameObject PauseMenu;
    // Start is called before the first frame update
    void Start()
    {
        BtnPause.onClick.AddListener(btn_stop_clik);
        PauseMenu.SetActive(false);
        BtnPlay.onClick.AddListener(btn_play_clik);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void btn_stop_clik()
    { 
        PauseMenu.SetActive(true);
        Time.timeScale=0;
    }

    void btn_play_clik()
    { 
        PauseMenu.SetActive(false);
        Time.timeScale=1;
    }

}
