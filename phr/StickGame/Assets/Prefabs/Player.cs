using FishNet.Object;
using FishNet.Object.Synchronizing;
using UnityEngine;
using UnityEngine.UIElements;
public class Player : NetworkBehaviour
{
    [SyncVar]
    public string username;

    [SyncVar]
    public bool isReady;

    public override void OnStartServer()
    {
        base.OnStartServer();

        GameManager.Instance.players.Add(this);
    }

    public override void OnStopServer()
    {
        base.OnStopServer();

        GameManager.Instance.players.Remove(this);
    }

    [ServerRpc]
    private void ServerSetIsReady(bool value)
    {
        isReady = value;
    }
}
