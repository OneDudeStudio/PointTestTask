using UnityEngine;

public class PlayerLocomotion : MonoBehaviour
{
    [SerializeField] private LineManager _lineManager;
    [SerializeField] private float _speed;

    public bool CanMove = false;
    public bool isAlive;

    private void Update()
    {
        if (CanMove && isAlive)
        {
            Move();
        }
    }

    private void Move()
    {
        transform.rotation = Quaternion.LookRotation(Vector3.forward, _lineManager.TargetPoints[0] - transform.position);
        transform.position = Vector3.MoveTowards(transform.position, _lineManager.TargetPoints[0], _speed * Time.deltaTime);
    }
}
