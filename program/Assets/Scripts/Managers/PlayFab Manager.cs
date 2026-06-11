using UnityEngine;
using Photon.Pun;
using PlayFab.ClientModels;
using TMPro;

public class PlayFapManager : MonoBehaviourPunCallbacks
{
    [SerializeField] string verison;

    [SerializeField] TMP_InputField addressInputField;
    [SerializeField] TMP_InputField passwordInputField;
}

