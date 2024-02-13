using System.Collections;
using System.Collections.Generic;
using Mirror;
using UnityEngine;

public class PlayerTeleport : NetworkBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Teleport"))
        {
            if (isLocalPlayer)
            {
                CmdTeleportPlyer();
            }
            
        }
    }

    [Command]
    private void CmdTeleportPlyer()
    {
        RpcMovePlayerToZero();
    }

    [ClientRpc]
    private void RpcMovePlayerToZero()
    {
        transform.position = Vector2.zero;
    }
}
