using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class CameraController : MonoBehaviour {

    public Transform followingObject;
    public float yOffset;
    public float smoothing;

    private new Camera camera;
    private Tilemap constrainMap;

    private void Start() {
        this.camera = this.GetComponent<Camera>();
        this.constrainMap = GameObject.FindGameObjectWithTag("MapBounds").GetComponent<Tilemap>();
    }

    private void FixedUpdate() {
        var followPos = this.followingObject.transform.position;
        var currPos = this.transform.position;
        var newPos = Vector3.Lerp(currPos, new Vector3(followPos.x, followPos.y + this.yOffset, currPos.z), this.smoothing);

        var halfHeight = this.camera.orthographicSize;
        var halfWidth = this.camera.aspect * halfHeight;
        if (!this.HasTile(new Vector2(newPos.x - halfWidth, currPos.y - halfHeight)) || !this.HasTile(new Vector2(newPos.x + halfWidth, currPos.y + halfHeight)))
            newPos.x = currPos.x;
        if (!this.HasTile(new Vector2(currPos.x - halfWidth, newPos.y - halfHeight)) || !this.HasTile(new Vector2(currPos.x + halfWidth, newPos.y + halfHeight)))
            newPos.y = currPos.y;

        this.transform.position = newPos;
    }

    private bool HasTile(Vector2 pos) {
        return this.constrainMap.GetTile(this.constrainMap.WorldToCell(pos));
    }

}