using System.Collections;
using System.Collections.Generic;
using Mirror;
using UnityEngine;

public class PlayerColour : NetworkBehaviour
{
    private SpriteRenderer spriteRenderer;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            //if (isClient)
            //{
                Color randomColor = new Color(Random.value, Random.value, Random.value);

                spriteRenderer.color = randomColor;
            //}
            
        }
    }
    
}
