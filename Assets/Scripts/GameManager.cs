
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fusion; // 追加

public class GameManager : MonoBehaviour
{
    //[SerializeField] UIManager uiManager;
    [SerializeField] FusionLauncher fusionLauncher;

    public void StartHost()
    {
        Debug.Log("GameManager void StartHost()");
        fusionLauncher.LaunchGame(Fusion.GameMode.Host);// FusionLancherで定義したメソッドを呼び出し、Hostモードで起動させる
        //uiManager.OnStartGame();
    }

    public void StartClient()
    {
        fusionLauncher.LaunchGame(Fusion.GameMode.Client); // FusionLancherで定義したメソッドを呼び出し、Clientモードで起動させる
        //uiManager.OnStartGame();
    }

    public void QuitGame()
    {
        fusionLauncher.QuitGame();
    }

}
