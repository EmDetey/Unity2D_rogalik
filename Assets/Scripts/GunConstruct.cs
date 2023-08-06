using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GunConstruct : MonoBehaviour
{
    [SerializeField] private int _maxBullets, _currentBullets;
    public int MaxBullets { get { return _maxBullets; } private set { } }
    public int CurrentBullets { get { return _currentBullets; } private set { } }
    [SerializeField] private int _damage;
    public int Damage { get { return _damage; } private set { } }
    [SerializeField] private Transform _bulletSpawnerTransform;
    [SerializeField] private GameObject _bullet;

    public void Shoot()
    {
        if (_bulletSpawnerTransform)
        {
            if(_currentBullets > 0)
            {
                Instantiate(_bullet, _bulletSpawnerTransform.position, Quaternion.identity);
                Debug.Log("Shoot");
            }
            else
            {
                Debug.Log("none bullets");
            }
        }
    }


}
