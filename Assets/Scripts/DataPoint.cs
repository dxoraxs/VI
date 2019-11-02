using System;
using UnityEngine;

[Serializable]
public class DataPoint
{
    public Vector3[] _pointMovement;
    public int _isLoop;

    public DataPoint(Vector3[] point)
    {
        _pointMovement = point;
    }

    public DataPoint() { }
}
