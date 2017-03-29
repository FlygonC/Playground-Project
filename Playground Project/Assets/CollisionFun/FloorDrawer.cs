using UnityEngine;
using System.Collections;

[RequireComponent(typeof(MeshFilter))][RequireComponent(typeof(Floor2D))]
public class FloorDrawer : MonoBehaviour {

    //public float width = 1;
    //public float height = 1;

    MeshFilter mf;
    Mesh mesh;
    [SerializeField]
    Vector3[] vertices = new Vector3[4];
    [SerializeField]
    int[] tri = new int[6];
    [SerializeField]
    Vector3[] normals = new Vector3[4];
    [SerializeField]
    Vector2[] uv = new Vector2[4];

    Floor2D floorComp;

    void Start()
    {
        floorComp = GetComponent<Floor2D>();

        mf = GetComponent<MeshFilter>();
        mesh = new Mesh();
        mf.mesh = mesh;

        //Vector3[] vertices = new Vector3[4];

        vertices[0] = new Vector3(0, 0, 0);
        vertices[1] = new Vector3(1, 0, 0);
        vertices[2] = new Vector3(0, 1, 0);
        vertices[3] = new Vector3(1, 1, 0);

        mesh.vertices = vertices;

        //int[] tri = new int[6];

        tri[0] = 0;
        tri[1] = 2;
        tri[2] = 1;

        tri[3] = 2;
        tri[4] = 3;
        tri[5] = 1;

        mesh.triangles = tri;

        //Vector3[] normals = new Vector3[4];

        normals[0] = -Vector3.forward;
        normals[1] = -Vector3.forward;
        normals[2] = -Vector3.forward;
        normals[3] = -Vector3.forward;

        mesh.normals = normals;

        //Vector2[] uv = new Vector2[4];

        uv[0] = new Vector2(0, 0);
        uv[1] = new Vector2(1, 0);
        uv[2] = new Vector2(0, 1);
        uv[3] = new Vector2(1, 1);

        mesh.uv = uv;
    }

    void Update()
    {
        //float left = floorComp.left.x;

        vertices[0] = new Vector3(floorComp.left.x, floorComp.left.y - 0.3f, 0);
        vertices[1] = new Vector3(floorComp.right.x, floorComp.right.y - 0.3f, 0);
        vertices[2] = new Vector3(floorComp.left.x, floorComp.left.y, 0);
        vertices[3] = new Vector3(floorComp.right.x, floorComp.right.y, 0);

        mesh.vertices = vertices;
    }
}
