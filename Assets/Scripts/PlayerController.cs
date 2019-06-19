using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float movementSpeed;
    public GameObject gfxSide;
    public GameObject gfxForward;
    public GameObject gfxBack;

    private Rigidbody2D body;
    private Animator animator;

    private FacingDirection direction = FacingDirection.Down;
    private float horMovement;
    private float vertMovement;

    private void Start() {
        this.body = this.GetComponent<Rigidbody2D>();
        this.animator = this.GetComponent<Animator>();
    }

    private void Update() {
        this.horMovement = Input.GetAxisRaw("Horizontal");
        this.vertMovement = Input.GetAxisRaw("Vertical");
    }

    private void FixedUpdate() {
        var vel = new Vector2(this.horMovement, this.vertMovement) * this.movementSpeed;
        this.body.velocity = vel;

        var moving = vel.x != 0 || vel.y != 0;
        if (moving) {
            var dir = GetDirectionFromVelocity(vel);
            if (this.direction != dir) {
                this.direction = dir;
                this.gfxForward.SetActive(dir == FacingDirection.Down);
                this.gfxBack.SetActive(dir == FacingDirection.Up);
                this.gfxSide.SetActive(dir == FacingDirection.Left || dir == FacingDirection.Right);
                this.gfxSide.transform.localScale = new Vector3(dir == FacingDirection.Left ? -1 : 1, 1, 1);
            }
        }
        this.animator.SetBool("Walking", moving);
    }

    private static FacingDirection GetDirectionFromVelocity(Vector2 velocity) {
        if (Math.Abs(velocity.y) >= Math.Abs(velocity.x)) {
            return velocity.y > 0 ? FacingDirection.Up : FacingDirection.Down;
        } else {
            return velocity.x < 0 ? FacingDirection.Left : FacingDirection.Right;
        }
    }

}