using UnityEngine;

public class TowerShooter : MonoBehaviour
{
    [Header("Shooting Settings")]
    [SerializeField] private Arrow _arrow;
    [SerializeField] private float _delayBetweenShoots;
    [SerializeField] private float _damage;
    
    private float _timeAfterShoot;
    public float Damage => _damage;

    public void Shoot(TargetPoint target, ShootPoint shootPoint)
    {
        var point = target.Position;
        shootPoint.transform.LookAt(point);
        
        _timeAfterShoot += Time.deltaTime;
        if (!(_timeAfterShoot > _delayBetweenShoots)) return;
        Instantiate(_arrow, shootPoint.transform.position, Quaternion.identity);
        _timeAfterShoot = 0;
    }
}