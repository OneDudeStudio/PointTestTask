using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class LineManager : MonoBehaviour
{
    public List<Vector3> TargetPoints = new List<Vector3>();
    [SerializeField] private PlayerLocomotion _player;
    [SerializeField] private LineRenderer _lineRenderer;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            CreateNewTargetPoint();
            _player.CanMove = true;
        }
        if (_player.CanMove)
        {
            UpdateLine();
            RemoveTargetPoint();
        }
    }

    void CreateNewTargetPoint()
    {
        Vector3 targetPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 targetPoint = new Vector3(targetPosition.x, targetPosition.y, transform.position.z);
        TargetPoints.Add(targetPoint);
        SetNewLinePoint(targetPoint);
    }

    public void SetNewLinePoint(Vector3 point)
    {
        _lineRenderer.positionCount++;
        _lineRenderer.SetPosition(_lineRenderer.positionCount - 1, point);
    }

    public void RemoveTargetPoint()
    {
        if (_player.transform.position == TargetPoints[0])
        {
            Vector3[] array = TargetPoints.ToArray();
            _lineRenderer.positionCount = array.Length;
            _lineRenderer.SetPositions(TargetPoints.ToArray());
            TargetPoints.RemoveAt(0);
            if (TargetPoints.Count > 0)
            {
                _player.CanMove = true;
            }
            else
            {
                _player.CanMove = false;
            }
        }
    }

    public void EraseLine()
    {
        _lineRenderer.positionCount = 0;
    }

    public void UpdateLine()
    {
        _lineRenderer.SetPosition(0, _player.transform.position);
    }
}
