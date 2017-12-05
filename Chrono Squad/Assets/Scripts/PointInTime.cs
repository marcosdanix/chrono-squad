using UnityEngine;

public class PointInTime{

    public Vector3 position;
    public Vector3 rotation;
    public bool grounded;
    public bool dead;

    public PointInTime (Vector3 _position, Vector3 _rotation, bool _grounded, bool _dead){

        position = _position;
        rotation = _rotation;
        grounded = _grounded;
        dead = _dead;
    }

}