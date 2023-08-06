using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] int _hitPoints;
    public int HitPoints { get { return _hitPoints; } private set { } }
    

    public void Damage(int damage)
    {
        _hitPoints -= damage;
    }
}
