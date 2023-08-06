using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float _runSpeed,
        _strafeSpeed;
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
        Vector3 mousePosition = Input.mousePosition;
        Vector3 worldMousePosition = Camera.main.ScreenToViewportPoint(new Vector3(mousePosition.x, mousePosition.y, mousePosition.z - Camera.main.transform.position.z));
        Vector3 direction = worldMousePosition - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }
    

    private void Start()
    {
        _rigitbody = GetComponent<Rigidbody2D>();
        _rigitbody.gravityScale = 0f;
    }

    private void Update()
    {
        if(Input.GetMouseButton(0))
        {
            PlayerRotate();
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
