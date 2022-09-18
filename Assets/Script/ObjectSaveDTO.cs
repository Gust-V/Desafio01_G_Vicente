using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ObjectSaveDTO
{
    public string obTypeString;
    public Collider clld;
    public Color color;
    public Vector3 position;
    public Quaternion rotation;
    public Vector3 scale;
    public System.Type[] components;

}
