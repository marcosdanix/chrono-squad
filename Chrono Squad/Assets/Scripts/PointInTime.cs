using UnityEngine;

public class PointInTime{

    public Vector3 position;
    public Vector3 rotation;
    public bool grounded;

    public PointInTime (Vector3 _position, Vector3 _rotation, bool _grounded){

        position = _position;
        rotation = _rotation;
        grounded = _grounded;
    }

}