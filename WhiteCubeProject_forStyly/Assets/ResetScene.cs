using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Networking;

public class ResetScene : NetworkBehaviour
{
    [SerializeField]
    private string sceneToTransferTo;

    // Update is called once per frame
    void Update()
    {
        Debug.Log("Entered ResetScene");

        if (Input.GetKeyDown(KeyCode.Space))
        {
            RpcResetScene();
        }
    }

    /**
     * シーン移動する：今回はロビーシーンに戻る
     */
    [ClientRpc]
    private void RpcResetScene()
    {
        Debug.Log("Will reset scene to Lobby");
        NetworkManager.singleton.ServerChangeScene(sceneToTransferTo);      // from https://answers.unity.com/questions/1391780/how-to-use-networkmanagerserverchangescene.html
    }
}