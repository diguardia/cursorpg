using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed;
    private Rigidbody2D _rigidbody2D;
    private PlayerLife playerLife;

    private Vector2 _input;
    public Vector2 _direction;

    public Vector2 Direction => _direction;
    public bool InMovement => _direction.magnitude > 0;

    void Awake() {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        playerLife = GetComponent<PlayerLife>();
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (playerLife.IsDefeated) {
            _direction = Vector2.zero;
        } else {
            _input = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
            _direction = new Vector2();
            
            _direction.x = InputToDirection(_input.x);
            _direction.y = InputToDirection(_input.y);
        }
    }

    private float InputToDirection(float v)
    {
        if (v<0) {return -1;}
        if (v>0) {return 1;}
        return 0;
    }

    void FixedUpdate() {
        _rigidbody2D.MovePosition(_rigidbody2D.position + _direction * speed * Time.fixedDeltaTime);
    }
}
