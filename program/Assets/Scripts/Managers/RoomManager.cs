using Photon.Pun;
using UnityEngine;
using System.Collections.Generic;
using Photon.Realtime;

public class RoomManager : MonoBehaviourPunCallbacks
{ 
    private Dictionary<string, GameObject> Dictionary = new Dictionary<string, GameObject>();

    public override void OnRoomListUpdate(List<RoomInfo> roomList)
    {
        
    }
}
