﻿using Engine3D.EXMPL._3D_OBJECTS.MATERIALS;
using Engine3D.EXMPL.OBJECTS;

namespace Engine3D.EXMPL._3D_OBJECTS.GEOMETRY.LIGHT_OBJECTS;

public class Light : Object {
    /// <summary>
    /// Light object
    /// </summary>
    /// <param name="position"> Light position </param>
    /// <param name="strength"> Strength of light </param>
    /// <param name="name"> Light name </param>
    public Light(Vector3 position, double strength, string name = "light1")  
        : base(position, new Vector3(0), Material.DefaultMaterial, name) {
        Position = position;
        Strength = strength;
        Name     = name;
    }
    
    private double Strength { get; }

    public override (Vector2, Material) Intersection(Vector3 rayOrigin, Vector3 rayDirection, out Vector3 intersectionNormal) {
        intersectionNormal = new Vector3(0);
        return (new Vector2(0), Material);
    }

    public double GetStrength() => Strength;

    public override void Rotate(Vector3 angle) {
        Position.Rotate(angle);
    }
}