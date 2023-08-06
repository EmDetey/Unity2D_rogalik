using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Rigidbody2D _rigitbody;
    [SerializeField] private float _bulletSpeed,
        _lifeTime,
        _distance,
        _damage;
    [SerializeField] private Transform _gunTransform;


    private void BulletFly()
    {
        _rigitbody.AddForce(_gunTransform.up * _bulletSpeed,ForceMode2D.Impulse);
    }
    private void Start()
    {
        _rigitbody = GetComponent<Rigidbody2D>();
        BulletFly();
    }
}
