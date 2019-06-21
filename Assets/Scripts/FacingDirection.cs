using UnityEngine;

public enum FacingDirection {

    Down,
    Up,
    Left,
    Right

}

public static class DirectionUtil {

    public static FacingDirection FromVelocity(Vector2 velocity) {
        if (Mathf.Abs(velocity.y) >= Mathf.Abs(velocity.x)) {
            return velocity.y > 0 ? FacingDirection.Up : FacingDirection.Down;
        } else {
            return velocity.x < 0 ? FacingDirection.Left : FacingDirection.Right;
        }
    }

    public static float GetRotation(FacingDirection direction) {
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

    public static FacingDirection Opposite(FacingDirection direction) {
        switch (direction) {
            case FacingDirection.Up:
                return FacingDirection.Down;
            case FacingDirection.Down:
                return FacingDirection.Up;
            case FacingDirection.Left:
                return FacingDirection.Right;
            default:
                return FacingDirection.Left;
        }
    }

}