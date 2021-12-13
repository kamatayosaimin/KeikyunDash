using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectInstanceData
{
    private Vector3 _position;
    private OtherObject _prefab;

    public Vector3 Position
    {
        get
        {
            return _position;
        }
    }

    public OtherObject Prefab
    {
        get
        {
            return _prefab;
        }
    }

    public ObjectInstanceData(OtherObject prefab, Vector3 position)
    {
        _position = position;
        _prefab = prefab;
    }
}
