using System;
using JetBrains.Annotations;
using UnityEngine;

public class Character : MonoBehaviour {

    public GameObject gfxSide;
    public GameObject gfxForward;
    public GameObject gfxBack;
    public FacingDirection defaultDirection;
    public Vector2 desiredVelocity;

    private Rigidbody2D body;
    private Animator animator;

    private FacingDirection direction;
    public FacingDirection Direction {
        private set {
            if (this.direction != value) {
                this.direction = value;
                this.gfxForward.SetActive(value == FacingDirection.Down);
                this.gfxBack.SetActive(value == FacingDirection.Up);
                this.gfxSide.SetActive(value == FacingDirection.Left || value == FacingDirection.Right);
                this.gfxSide.transform.localScale = new Vector3(value == FacingDirection.Left ? -1 : 1, 1, 1);
            }
        }
        get => this.direction;
    }

    private void Start() {
        this.body = this.GetComponent<Rigidbody2D>();
        this.animator = this.GetComponent<Animator>();
        this.Direction = this.defaultDirection;
    }

    [UsedImplicitly]
    public void FaceCharacter(Character character) {
        this.Direction = DirectionUtil.Opposite(character.Direction);
    }

    private void FixedUpdate() {
        this.body.velocity = this.desiredVelocity;
        var moving = this.desiredVelocity.x != 0 || this.desiredVelocity.y != 0;
        if (moving) {
            var dir = DirectionUtil.FromVelocity(this.desiredVelocity);
            this.Direction = dir;
        }
        this.animator.SetBool("Walking", moving);
    }

}