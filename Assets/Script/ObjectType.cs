using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectType
{
    public enum Aux { GameObject, Cube, Capsule, Sphere, Cylinder, Plane, Quad};
    
    public Aux get;
    public GameObject go;

    static public ObjectType WTypeOb(Aux aux)
    {
        switch (aux)
        {
            case Aux.GameObject:
                var gmObjct = new ObjectType() { go = new GameObject(), get = Aux.GameObject };
                return gmObjct;
            case Aux.Cube:
                var cube = new ObjectType() { go = GameObject.CreatePrimitive(PrimitiveType.Cube), get = Aux.Cube };
                return cube;
            case Aux.Capsule:
                var capsule = new ObjectType() { go = GameObject.CreatePrimitive(PrimitiveType.Capsule), get = Aux.Capsule };
                return capsule;
            case Aux.Sphere:
                var sphere = new ObjectType() { go = GameObject.CreatePrimitive(PrimitiveType.Sphere), get = Aux.Sphere };
                return sphere;
            case Aux.Cylinder:
                var cylinder = new ObjectType() { go = GameObject.CreatePrimitive(PrimitiveType.Cylinder), get = Aux.Cylinder };
                return cylinder;
            case Aux.Plane:
                var plane = new ObjectType() { go = GameObject.CreatePrimitive(PrimitiveType.Plane), get = Aux.Plane };
                return plane;
            case Aux.Quad:
                var quad = new ObjectType() { go = GameObject.CreatePrimitive(PrimitiveType.Quad), get = Aux.Quad };
                return quad;
            default:
                Debug.Log("TIPO DE OBJETO NÃO EXISTE!!!. Opções: GameObject, Cube, Capsule, Sphere, Cylinder, Plane, Quad");
                break;
        }
        return new ObjectType() { };
    }

    static public ObjectType WTypeOb(string aux)
    {
        switch (aux)
        {
            case "GameObject":
                var gmObjct = new ObjectType() { go = new GameObject(), get = Aux.GameObject };
                return gmObjct;
            case "Cube":
                var cube = new ObjectType() { go = GameObject.CreatePrimitive(PrimitiveType.Cube), get = Aux.Cube };
                return cube;
            case "Capsule":
                var capsule = new ObjectType() { go = GameObject.CreatePrimitive(PrimitiveType.Capsule), get = Aux.Capsule };
                return capsule;
            case "Sphere":
                var sphere = new ObjectType() { go = GameObject.CreatePrimitive(PrimitiveType.Sphere), get = Aux.Sphere };
                return sphere;
            case "Cylinder":
                var cylinder = new ObjectType() { go = GameObject.CreatePrimitive(PrimitiveType.Cylinder), get = Aux.Cylinder };
                return cylinder;
            case "Plane":
                var plane = new ObjectType() { go = GameObject.CreatePrimitive(PrimitiveType.Plane), get = Aux.Plane };
                return plane;
            case "Quad":
                var quad = new ObjectType() { go = GameObject.CreatePrimitive(PrimitiveType.Quad), get = Aux.Quad };
                return quad;
            default:
                Debug.Log("TIPO DE OBJETO NÃO EXISTE!!!. Opções:GameObject, Cube, Capsule, Sphere, Cylinder, Plane, Quad");
                break;
        }
        return new ObjectType() { };
    }
}
