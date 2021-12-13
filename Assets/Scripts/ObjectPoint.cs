using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPoint : MonoBehaviour
{
    private OtherObject _object;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void NewObject(ObjectInstanceData data)
    {
        if (_object)
        {
            Destroy(_object.gameObject);

            _object = null;
        }

        if (data == null)
            return;

        Vector3 position = transform.position + data.Position;

        _object = Instantiate(data.Prefab, position, Quaternion.identity, transform);
    }
}
