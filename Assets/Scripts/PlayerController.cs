using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float _runSpeed,
        _strafeSpeed;
    [SerializeField] private float _mouseOffset;
    [SerializeField] private GunConstruct _gunConstruct;
    private Rigidbody2D _rigitbody;
    

    private void Run(Vector2 direction)
    {
        _rigitbody.AddForce(direction * _runSpeed, ForceMode2D.Force);
    }
    private void Run(Vector2 direction, float strafeSpeed)
    {
        _rigitbody.AddForce(direction * strafeSpeed, ForceMode2D.Force);
    }

    private void PlayerRotate()
    {
        Vector3 difference = Camera.main.ScreenToViewportPoint(Input.mousePosition) - transform.position;
        float rotateZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f,0f,rotateZ + _mouseOffset);
    }
    

    private void Start()
    {
        _rigitbody = GetComponent<Rigidbody2D>();
       
        _rigitbody.gravityScale = 0f;
    }

    private void Update()
    {
        PlayerRotate();
        if(Input.GetMouseButtonDown(0))
        {
            _gunConstruct.Shoot();
        }
        
    }

   
    private void FixedUpdate()
    {
        if (_rigitbody)
        {
            if (Input.GetKey(KeyCode.W))
            {
                Run(Vector2.up);
            }
            else if (Input.GetKey(KeyCode.S)) 
            {
                Run(Vector2.down);
            }

            if (Input.GetKey(KeyCode.D))
            {
                Run(Vector2.right, _strafeSpeed);
            }
            else if(Input.GetKey(KeyCode.A)) 
            {
                Run(Vector2.left, _strafeSpeed);
            }

        }
    }

}
