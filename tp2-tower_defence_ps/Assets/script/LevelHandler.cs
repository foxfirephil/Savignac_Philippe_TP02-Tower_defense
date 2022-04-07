using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelHandler : MonoBehaviour
{
    public Button StartBtn;
    public GameObject MenuLvl;
    public GameObject MenuUi;
    // Start is called before the first frame update
    void Start()
    {
        StartBtn.onClick.AddListener(btn_start);
        MenuUi.SetActive(false);
        Time.timeScale = 0;
    }

    // Update is called once per frame
    void Update()
    {

    }
    void btn_start()
    {
        FindObjectOfType<GameManager>().IsStart = true;
        MenuLvl.SetActive(false);
        MenuUi.SetActive(true);
        Time.timeScale = 1;
    }
}
