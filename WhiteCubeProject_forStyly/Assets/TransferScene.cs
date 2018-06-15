using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Networking;

public class TransferScene : NetworkBehaviour
{
    [SerializeField]
    private string sceneToTransferTo;

    [SerializeField]
    private int numSecondsAudioClip;

    private void Update()
    {
        Debug.Log("Name of game obj: " + this.gameObject.name);

        //　スペースを押したら一定時間経つとシーンを変える
        if (Input.GetKey(KeyCode.Space) && sceneToTransferTo != null)
        {
            RpcSwitchScene();
        }
    }


    [ClientRpc]
    private void RpcSwitchScene()
    {
        Debug.Log("Coroutine - I am a server: " + isServer);
        Debug.Log("waiting to switch scene to: " + sceneToTransferTo);

        StartCoroutine(SwitchScene());
    }

    /**
     * 音声ファイルが再生し終わるまで、コールーティーンで再生時間だけ待たせる。
     * その後シーンを変える。
     */
    private IEnumerator SwitchScene()
    {
        yield return new WaitForSeconds(numSecondsAudioClip);

        NetworkManager.singleton.ServerChangeScene(sceneToTransferTo);      // from https://answers.unity.com/questions/1391780/how-to-use-networkmanagerserverchangescene.html

    }

}