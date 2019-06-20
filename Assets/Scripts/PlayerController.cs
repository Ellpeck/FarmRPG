using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float speed;
    public Transform rotatingParts;
    public Collider2D interactionArea;
    public LayerMask interactionLayers;

    private Character character;
    private float hor;
    private float vert;

    private void Start() {
        this.character = this.GetComponent<Character>();
    }

    private void Update() {
        this.hor = Input.GetAxisRaw("Horizontal");
        this.vert = Input.GetAxisRaw("Vertical");

        if (Input.GetButtonDown("Interact")) {
            var bounds = this.interactionArea.bounds;
            var objects = Physics2D.OverlapAreaAll(bounds.min, bounds.max, this.interactionLayers);
            foreach (var obj in objects) {
                var interactable = obj.GetComponent<Interactable>();
                if (interactable) {
                    interactable.Interact(this.character);
                    break;
                }
            }
        }
    }

    private void FixedUpdate() {
        this.character.desiredVelocity = new Vector2(this.hor, this.vert) * this.speed;
        this.rotatingParts.rotation = Quaternion.Euler(0, 0, Character.GetRotationFromFacingDirection(this.character.direction));
    }

}