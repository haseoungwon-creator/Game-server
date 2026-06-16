using UnityEngine;

public class PanelManager :Singleton<PanelManager>
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void Open(string message)
    {
        Debug.Log(message);
    }

 
}
