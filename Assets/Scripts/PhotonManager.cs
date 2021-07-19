using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

using Photon.Pun;
using Photon.Realtime;

public class PhotonManager : MonoBehaviourPunCallbacks
{
    private static PhotonManager _instance = null;
    public static PhotonManager instance
    {
        get
        {
            if(!_instance)
            {
                _instance = new PhotonManager();
            }
            return _instance;
        }
    }

    [SerializeField]
    private Text rankList;

    public override void OnLeftRoom()
    {
        SceneManager.LoadScene(0);
    }

    public void LeaveRoom()
    {
        PhotonNetwork.LeaveRoom();
    }

    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        
    }

    public override void OnPlayerLeftRoom(Player otherPlayer)
    {
        PhotonNetwork.LeaveRoom();
    }

    void LoadArea()
    {
        if(!PhotonNetwork.IsMasterClient)
        {
            //마스터 클라가 아님;
        }
        Debug.LogFormat("PhotonNetwork : Loading Level : {0}", PhotonNetwork.CurrentRoom.PlayerCount);
        PhotonNetwork.LoadLevel("InGameScene");
    }
}
