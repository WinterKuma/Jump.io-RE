using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using Photon.Pun;
using Photon.Realtime;

[RequireComponent(typeof(InputField))]
public class PlayerNameInputField : MonoBehaviour
{
    const string playerNamePrefKey = "PlayerName";

    // Start is called before the first frame update
    void Start()
    {
        string defaultName = string.Empty;
        InputField _inputField = this.GetComponent<InputField>();
        if(_inputField != null)
        {
            if(PlayerPrefs.HasKey(playerNamePrefKey))
            {
                defaultName = PlayerPrefs.GetString(playerNamePrefKey);
                _inputField.text = defaultName;
            }
        }

        PhotonNetwork.NickName = defaultName;
    }

    public void SetPlayerName()
    {
        string value = this.GetComponentInChildren<Text>().text;
        if (string.IsNullOrEmpty(value))
        {
            Debug.LogError("Player Name is null or Empty");
            return;
        }

        PhotonNetwork.NickName = value;
        PlayerPrefs.SetString(playerNamePrefKey, value);
    }
}
