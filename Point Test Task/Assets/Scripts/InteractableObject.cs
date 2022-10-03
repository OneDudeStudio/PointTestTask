using UnityEngine;

public class InteractableObject : MonoBehaviour
{
    protected GameManager _gameManager;

    protected virtual void Awake()
    {
        _gameManager = FindObjectOfType<GameManager>();
    }
    protected virtual void OnTriggerEnter2D(Collider2D collision)
    {
        
    }
}
