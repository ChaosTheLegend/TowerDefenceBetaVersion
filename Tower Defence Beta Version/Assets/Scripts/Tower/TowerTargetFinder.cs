using UnityEngine;

public class TowerTargetFinder : MonoBehaviour
{
    [SerializeField, Range(10f, 20f)]
    private float _targetingRange = 10f;
    public TargetPoint Target { get; private set; }

    private const int ENEMY_LAYER_MASK = 1 << 9;
    private bool _isTargetNull;

    private TargetPoint _previousPoint;
    
    private void Start() => _isTargetNull = Target == null;

    // ReSharper disable Unity.PerformanceAnalysis
    public bool IsAcquireTarget()
    {
        // ReSharper disable once Unity.PreferNonAllocApi
        var targets = Physics.OverlapSphere(transform.localPosition, _targetingRange, ENEMY_LAYER_MASK);

        if (targets.Length > 0)
        {
            Target = targets[0].GetComponent<TargetPoint>();
            return true;
        }

        Target = null;
        return false;
    }

    public bool IsTargetTracked()
    {
        if (_isTargetNull)
            return false;

        var myPos = transform.localPosition;
        var targetPos = Target.Position;

        if (!(Vector3.Distance(myPos, targetPos) > _targetingRange)) return true;
        Target = null;
        return false;
    }

    private void OnDrawGizmosSelected()
    {
        var target = Target;
        var position = transform.position;
        position.y += 0.01f;

        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(position, _targetingRange);

        if (target == null) return;
        Gizmos.color = Color.red;
        Gizmos.DrawLine(position, target.Position);
    }
}