using System.Collections.Generic;
using UnityEngine;

public class TargetPointer : MonoBehaviour
{
    [SerializeField] private Transform _patrolPoints;

    private VisionArea _visionArea;
    private Player _targetPlayer = null;
    private List<Vector2> _targetPoints = null;
    private int _currentTargetPointsNumber = 0;

    private void Awake()
    {
        _visionArea = GetComponentInChildren<VisionArea>();
    }


    private void OnEnable()
    {
        _visionArea.Detected += DetectedPlayer;
    }

    private void OnDisable()
    {
        _visionArea.Detected -= DetectedPlayer;
    }

    private void Start()
    {
        if (_patrolPoints != null)
        {
            SetTargetPoints();
        }
    }

    public bool TryDefineTarget(out Vector2 currentTargetPosition)
    {
        if (_targetPlayer != null)
        {
            currentTargetPosition = _targetPlayer.transform.position;
            return true;
        }

        if (_targetPoints == null)
        {
            currentTargetPosition = Vector2.zero;
            return false;
        }

        currentTargetPosition = _targetPoints[_currentTargetPointsNumber];

        bool isTargetPosition = Mathf.Ceil(transform.position.x) == Mathf.Ceil(currentTargetPosition.x);

        if (isTargetPosition)
        {
            _currentTargetPointsNumber = ++_currentTargetPointsNumber % _targetPoints.Count;
            currentTargetPosition = _targetPoints[_currentTargetPointsNumber];
        }

        return true;
    }

    public Player GetTargetPlayer()
    {
        return _targetPlayer;
    }

    private void DetectedPlayer(Collider2D collider)
    {
        if (collider == null)
        {
            _targetPlayer = null;
            return;
        }

        if (_targetPlayer == null)
            collider.TryGetComponent<Player>(out _targetPlayer);
    }

    private void SetTargetPoints()
    {
        _targetPoints = new List<Vector2>();

        for (int i = 0; i < _patrolPoints.childCount; i++)
        {
            Vector2 targetPoint = _patrolPoints.GetChild(i).position;
            _targetPoints.Add(targetPoint);
        }
    }
}
