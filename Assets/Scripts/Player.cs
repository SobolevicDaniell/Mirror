using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
using Random = UnityEngine.Random;

public class Player : NetworkBehaviour
{

    private SpriteRenderer spriteRenderer;
    
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    private void Update()
    {
        if (isLocalPlayer)
        {
            float horizontal = Input.GetAxis("Horizontal");
            float vertical = Input.GetAxis("Vertical");
            float speed = 6f * Time.deltaTime;
            transform.Translate(new Vector2(horizontal * speed, vertical * speed));

            if (Input.GetKeyDown(KeyCode.Q))
            {
                Color randomColor = new Color(Random.value, Random.value, Random.value);

                spriteRenderer.color = randomColor;
            }
        }
    }
    
    
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
