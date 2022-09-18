using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransformRef 
{
    public Vector3 position, scale = new Vector3();
    public Quaternion rotation;

    static public TransformRef ToTranformRef(GameObject go)
    {
        var tf = go.GetComponent<Transform>();
        var tfref = new TransformRef() { position = tf.position, rotation = tf.rotation, scale = tf.localScale };

        return tfref;
    }
}
