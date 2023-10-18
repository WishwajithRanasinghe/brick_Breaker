using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class BraketScript : MonoBehaviour
{
    [SerializeField] private float _moveSpeed = 3f;
    [SerializeField] private GameObject _ball;
    private void Start()
    {
        //_ball = GameObject.FindGameObjectWithTag("Ball");
        
        _ball.transform.parent = gameObject.transform;

        
       
    }//Start
    private void Update()
    {
        if(_ball.GetComponent<BallScript>()._isStarted == true)
        {
            _ball.transform.parent = null;
        }
        BraketMove();
    }//Update
    private void BraketMove()
    {
        float _horizontalInput = Input.GetAxis("Horizontal");
        float xValue = transform.position.x +1 * _horizontalInput * _moveSpeed * Time.deltaTime;

        transform.position = new Vector3(xValue,transform.position.y);

        Vector3 _position = transform.position;
        _position.x = Mathf.Clamp(_position.x,-2.17f,2.17f);
        transform.position = _position;

    }//BraketMove
}//Class
