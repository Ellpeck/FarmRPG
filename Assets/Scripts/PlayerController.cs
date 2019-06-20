using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float speed;
    private Character character;

    private float hor;
    private float vert;

    private void Start() {
        this.character = this.GetComponent<Character>();
    }

    private void Update() {
        this.hor = Input.GetAxisRaw("Horizontal");
        this.vert = Input.GetAxisRaw("Vertical");
    }

    private void FixedUpdate() {
        this.character.desiredVelocity = new Vector2(this.hor, this.vert) * this.speed;
    }

}