using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class GAGL1 : MonoBehaviour
{
    List<GameObject> bgList = new List<GameObject>();
    // Start is called before the first frame update
    Button btn_newGame;
    Button btn_loadGame;
    Button btn_setting;
    Button btn_exitGame;
    Button btn_account;
    void Start()
    {
        bgList = new List<GameObject>();
        var bg1 = GameObject.Find("Canvas/bg1");
        var bg2 = GameObject.Find("Canvas/bg2");
        var bg3 = GameObject.Find("Canvas/bg3");
        bgList.Add(bg1);
        bgList.Add(bg2);
        bgList.Add(bg3);
        currentBgIdx = 0;

        btn_newGame = GameObject.Find("Canvas/button grid/New Game Button").GetComponent<Button>();
        btn_loadGame = GameObject.Find("Canvas/button grid/Load Game Button").GetComponent<Button>();
        btn_setting = GameObject.Find("Canvas/button grid/Game Settings Button").GetComponent<Button>();
        btn_exitGame = GameObject.Find("Canvas/button grid/Exit Game Button").GetComponent<Button>();
        btn_account = GameObject.Find("Canvas/Account Login Button").GetComponent<Button>();

        btn_newGame.onClick.AddListener(OnBtnCLick);
        btn_loadGame.onClick.AddListener(OnBtnCLick);
        btn_setting.onClick.AddListener(OnBtnCLick);
        btn_exitGame.onClick.AddListener(OnBtnCLick);
        btn_account.onClick.AddListener(OnBtnCLick);

        SwitchBg();
    }

    // Update is called once per frame
    void Update()
    {

    }
    int currentBgIdx = 0;
    public void SwitchBg()
    {
        currentBgIdx++;
        if (currentBgIdx >= bgList.Count)
            currentBgIdx = 0;
        foreach (var bg in bgList)
        {
            if (bg != null)
                bg.SetActive(false);
        }
        bgList[currentBgIdx].SetActive(true);
    }
    void OnBtnCLick()
    {
        SwitchBg();
    }
}
