using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; //　追加

public class UIManager : MonoBehaviour
{
    [SerializeField] GameObject menuUI;
    [SerializeField] GameObject inGameUI;

    private void Start()
    {
        // InGameUIは非表示にしておく
        inGameUI.SetActive(false);
    }

    // ゲームが始まったらMenuUIを非表示にしてInGameUIを表示
    public void OnStartGame()
    {
        menuUI.SetActive(false);
        inGameUI.SetActive(true);
    }

}