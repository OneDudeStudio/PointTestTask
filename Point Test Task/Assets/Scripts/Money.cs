using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Money : InteractableObject
{
    protected override void Awake()
    {
        base.Awake();
        _gameManager.AddMoneyToList(this);
    }
    protected override void OnTriggerEnter2D(Collider2D collision)
    {
        gameObject.SetActive(false);
        _gameManager.TakeMoney(this);
        _gameManager.UpdateTakeMoneyText();
    }

}
