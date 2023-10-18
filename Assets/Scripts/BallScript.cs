using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class BallScript : MonoBehaviour
{
    [SerializeField] private int _point;
    [SerializeField] private GameObject _expObject;
    private Rigidbody2D _rBody;
    [SerializeField] private float _moveForce = 2f;
    public bool _isStarted;
    private void Start()
    {
        _rBody = GetComponent<Rigidbody2D>();
        
    }//Start


    private void Update()
    {
        if(_isStarted == false)
        {
            MoveMent();
        }
        
        
    }//Update
    private void MoveMent()
    {
        Vector2 forceDirection = new Vector2(1f,1f) * _moveForce * 10f;
        if(Input.GetKeyDown(KeyCode.Space))
        {
            _isStarted = true;
            _rBody.AddForce(forceDirection);
            
        }
     
    }//MoveMent
    private void OnCollisionEnter2D(Collision2D collision)
    {
        switch (collision.transform.tag)
        {
            case "Bried":
                Destroy(collision.gameObject);
                Instantiate(_expObject,collision.transform.position,Quaternion.identity);
                _point ++;
            break;

            case "Base":
                print("GameOver!");
            break;
            
            
        }

    }//OnCollisonEnter2D
}//Class
