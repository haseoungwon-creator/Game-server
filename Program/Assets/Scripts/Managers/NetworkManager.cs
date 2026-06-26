using Photon.Pun;
using System.Security.Principal;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UIElements;

public class NetworkManager : MonoBehaviourPunCallbacks
{

    [SerializeField] Transform createPosition;
    private void Start()
    {
        Create();
    }

    public void Create()
    {
        PhotonNetwork.Instantiate("Character", createPosition.position, Quaternion.identity);
    }
}
