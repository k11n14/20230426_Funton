using System;
using System.Collections;
using System.Collections.Generic;
using Fusion;
using Fusion.Sockets;
using UnityEngine;
using UnityEngine.SceneManagement; // 追加

public class FusionLauncher : MonoBehaviour, INetworkRunnerCallbacks
{
    private NetworkRunner localRunner;

    // 接続する為の処理、外部から呼び出す想定 
    public async void LaunchGame(GameMode mode)
    {
        localRunner = gameObject.AddComponent<NetworkRunner>();// FusionのコアとなるNetworkRunnerコンポーネントを追加
        localRunner.ProvideInput = true; // 入力を提供する必要があるのでtrueをセット


        var startGameArgs = new StartGameArgs()// NetworkRunnerのStartGameメソッドに渡す設定を定義
        {
            GameMode = mode, // Hostか,Clientかを引数で受け取って設定
            SessionName = "GsRoom", // Room名を設定（今回は固定のRoomを設定）
        };

        await localRunner.StartGame(startGameArgs); // awaitで接続が完了されるまで待つ
        localRunner.SetActiveScene("Main"); // 表示するシーンをセット(現在のMainシーン)
    }

    public void QuitGame()// ゲームを終了する処理、外部から呼び出す
    {
        localRunner.Shutdown();
    }

    //　INetworkRunnerCallbacksのメソッドのうち、使用するメソッドのみ上部に持ってきた
    // =====================
    // ↓ Fusion Events　↓

    public void OnPlayerJoined(NetworkRunner runner, PlayerRef player)// プレイヤーが接続した時に呼ばれるメソッド
    {
        Debug.Log($"{player} が接続"); // playerにはプレイヤーIDが入っている
    }

    public void OnPlayerLeft(NetworkRunner runner, PlayerRef player)// プレイヤーが離脱した時に呼ばれるメソッド
    {
        Debug.Log($"{player} が離脱");
    }

    public void OnShutdown(NetworkRunner runner, ShutdownReason shutdownReason)// サーバーが停止した時に呼ばれるメソッド
    {
        Debug.Log("サーバーシャットダウン");
        SceneManager.LoadScene("Main"); // Main Sceneをリロードする
    }

    public void OnConnectedToServer(NetworkRunner runner) { }
    public void OnConnectFailed(NetworkRunner runner, NetAddress remoteAddress, NetConnectFailedReason reason) { }
    public void OnConnectRequest(NetworkRunner runner, NetworkRunnerCallbackArgs.ConnectRequest request, byte[] token) { }
    public void OnCustomAuthenticationResponse(NetworkRunner runner, Dictionary<string, object> data) { }
    public void OnDisconnectedFromServer(NetworkRunner runner) { }
    public void OnHostMigration(NetworkRunner runner, HostMigrationToken hostMigrationToken) { }
    public void OnInput(NetworkRunner runner, NetworkInput input) { }
    public void OnInputMissing(NetworkRunner runner, PlayerRef player, NetworkInput input) { }
    public void OnReliableDataReceived(NetworkRunner runner, PlayerRef player, ArraySegment<byte> data) { }
    public void OnSceneLoadDone(NetworkRunner runner) { }
    public void OnSceneLoadStart(NetworkRunner runner) { }
    public void OnSessionListUpdated(NetworkRunner runner, List<SessionInfo> sessionList) { }
    public void OnUserSimulationMessage(NetworkRunner runner, SimulationMessagePtr message) { }

}