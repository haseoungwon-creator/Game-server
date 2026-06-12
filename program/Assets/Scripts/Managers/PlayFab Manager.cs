using UnityEngine;
using Photon.Pun;
using PlayFab;
using PlayFab.ClientModels;
using TMPro;
using System.Collections;

public class PlayFapManager : MonoBehaviourPunCallbacks
{
    [SerializeField] string version;

    [SerializeField] TMP_InputField addressInputField;
    [SerializeField] TMP_InputField passwordInputField;

    
    public void Request()
    {
        var requst = new LoginWithEmailAddressRequest { Email = addressInputField.text, Password = passwordInputField.text };

        PlayFabClientAPI.LoginWithEmailAddress(requst,Success,Failed );
    
    }

    public void Success(LoginResult loginResult)
    {

        PlayFabClientAPI.GetAccountInfo(new GetAccountInfoRequest(), Success, Failed);
        PhotonNetwork.AutomaticallySyncScene = false;

        PhotonNetwork.GameVersion = version;

        StartCoroutine(ConnectRoutine());
    }

    public void Success(GetAccountInfoResult getAccountInfoRequest)
    {
        PhotonNetwork.LocalPlayer.NickName = getAccountInfoRequest.AccountInfo?.Username;
    }

    public void Failed(PlayFabError playFabError)
    {
        Debug.Log(playFabError.GenerateErrorReport());
    }

    private IEnumerator ConnectRoutine()
    {
        //Master Server로 연결하는 함수
        PhotonNetwork.ConnectUsingSettings();
        
        //서버 연결이 완료되거나 시간이 초과될 때까지 대기합니다.
        while (!PhotonNetwork.IsConnectedAndReady)
        {
            yield return null;
        }

        //특정로비를 생성하여 집입
        PhotonNetwork.JoinLobby();

    }

    public override void OnJoinedLobby()
    {
        PhotonNetwork.LoadLevel("Lobby");
    }
}

