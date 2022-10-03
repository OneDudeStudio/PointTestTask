using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spikes : InteractableObject
{
    
    protected override void OnTriggerEnter2D(Collider2D collision)
    {
        _gameManager.TakeSpikes();
        gameObject.SetActive(false);
    }
}
    

