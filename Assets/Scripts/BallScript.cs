using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BallScript : MonoBehaviour
{
    [SerializeField] private int _point;
    [SerializeField] private GameObject _expObject,_loseMenu,_winMenu,_helpMenu;
    [SerializeField] private TMP_Text _text;
    [SerializeField] private AudioClip _hitClip;
    private Rigidbody2D _rBody;
    private AudioSource _audio;
    [SerializeField] private float _moveForce = 2f;
    [SerializeField] private Sprite _destroyBoll;
    private SpriteRenderer _spRenderer;
    
    public bool _isStarted;
    private void Start()
    {
        _rBody = GetComponent<Rigidbody2D>();
        _audio = GetComponent<AudioSource>();
        _spRenderer = GetComponent<SpriteRenderer>();
        _helpMenu.SetActive(true);
        _loseMenu.SetActive(false);
        _winMenu.SetActive(false);
        
    }//Start


    private void Update()
    {
        if(_isStarted == false)
        {
            MoveMent();
        }

        _text.text = "Score = "+ _point.ToString();
        if(_point >= 16)
        {
            Time.timeScale = 0;
            _winMenu.SetActive(true);
        }
        
        
    }//Update
    private void MoveMent()
    {
        Vector2 forceDirection = new Vector2(1f,1f) * _moveForce * 10f;
        if(Input.GetKeyDown(KeyCode.Space))
        {
            _helpMenu.SetActive(false);
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
                _audio.PlayOneShot(_hitClip);
            break;

            case "Base":
                print("GameOver!");
                _spRenderer.sprite = _destroyBoll;
                _loseMenu.SetActive(true);
                Time.timeScale = 0;
            break;
            
            
        }

    }//OnCollisonEnter2D
}//Class
