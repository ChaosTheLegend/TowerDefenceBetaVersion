using UnityEngine;

public abstract class Tower : MonoBehaviour
{
    public TowerTargetFinder Finder { get; private set; }
    public TowerShooter Shooter { get; private set; }

    private ShootPoint _shootPoint;

    private void FixedUpdate()
    {
        if (Finder.IsAcquireTarget() || Finder.IsTargetTracked()) 
            Shooter.Shoot(Finder.Target, _shootPoint);
    }

    protected void InitRequiredComponents()
    {
        Finder = GetComponent<TowerTargetFinder>();
        Shooter = GetComponent<TowerShooter>();
        _shootPoint = GetComponentInChildren<ShootPoint>();
    }
}