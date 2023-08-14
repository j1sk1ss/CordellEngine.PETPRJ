using Engine3D.EXMPL.OBJECTS;

namespace Engine3D.EXMPL._3D_OBJECTS.LIGHT_OBJECTS;

public class Light : IObject {
    /// <summary>
    /// Light object
    /// </summary>
    /// <param name="position"> Light position </param>
    /// <param name="name"> Light name </param>
    public Light(Vector3 position, string name) {
        Position = position;
        Name     = name;
    }
    
    private string Name { get; set; }
    private Vector3 Position { get; set; }

    public string GetName() => Name;

    public Vector2 Intersection(Vector3 rayOrigin, Vector3 rayDirection, out Vector3 intersectionNormal) {
        intersectionNormal = new Vector3(0);
        return new Vector2(0);
    }

    public Vector3 GetPosition() => Position;

    public void SetPosition(Vector3 position) => Position = position;
}