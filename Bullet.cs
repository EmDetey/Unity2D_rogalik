using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Rigidbody2D _rigitbody;
    [SerializeField] private float _bulletSpeed;

    private void BulletFly()
    {
        _rigitbody.AddForce(Vector2.zero * _bulletSpeed,ForceMode2D.Impulse);
    }
    private void Start()
    {
        _rigitbody = GetComponent<Rigidbody2D>();
        BulletFly();
    }
}
