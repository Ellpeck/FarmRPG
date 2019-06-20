using System;
using UnityEngine;

public class Character : MonoBehaviour {

    public GameObject gfxSide;
    public GameObject gfxForward;
    public GameObject gfxBack;
    public Vector2 desiredVelocity;
    public FacingDirection direction;
    
    private Rigidbody2D body;
    private Animator animator;


    private void Start() {
        this.body = this.GetComponent<Rigidbody2D>();
        this.animator = this.GetComponent<Animator>();
    }

    private void FixedUpdate() {
        this.body.velocity = this.desiredVelocity;
        var moving = this.desiredVelocity.x != 0 || this.desiredVelocity.y != 0;
        if (moving) {
            var dir = GetDirectionFromVelocity(this.desiredVelocity);
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

    public static FacingDirection GetDirectionFromVelocity(Vector2 velocity) {
        if (Math.Abs(velocity.y) >= Math.Abs(velocity.x)) {
            return velocity.y > 0 ? FacingDirection.Up : FacingDirection.Down;
        } else {
            return velocity.x < 0 ? FacingDirection.Left : FacingDirection.Right;
        }
    }

    public static float GetRotationFromFacingDirection(FacingDirection direction) {
        switch (direction) {
            case FacingDirection.Up:
                return 180;
            case FacingDirection.Right:
                return 90;
            case FacingDirection.Left:
                return -90;
            default:
                return 0;
        }
    }

}