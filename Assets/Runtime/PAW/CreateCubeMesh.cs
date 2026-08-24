using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CreateCubeMesh : MonoBehaviour
{
    #region Inspector
    [Header("Mesh Filter Name")]
    [SerializeField] private string _filterName = "";

    [Header("Material")]
    [SerializeField] private Material _mt;

    [Header("Width, Height Setting")]
    [SerializeField] private float _width = 1f;
    [SerializeField] private float _height = 1f;
    [SerializeField] private float _depth = 1f;

    [Header("Position Setting")]
    [SerializeField] private float _x = 0f;
    [SerializeField] private float _y = 0f;
    [SerializeField] private float _z = 0f;
    #endregion

    #region Variables
    private MeshRenderer _meshRenderer;
    private MeshFilter _meshFilter;
    private BoxCollider _boxCollider;
    private MeshCollider _meshCollider;
    private Mesh _mesh;
    #endregion

    void Start()
    {
        Create();
    }

    [ContextMenu("Create Mesh")]
    public void Create()
    {
        _meshRenderer = gameObject.AddComponent<MeshRenderer>();
        _meshRenderer.sharedMaterial = new Material(Shader.Find("Standard"));

        _meshFilter = gameObject.AddComponent<MeshFilter>();

        _boxCollider = gameObject.AddComponent<BoxCollider>();
        _boxCollider.center = new Vector3(_width, _height, _depth) / 2;
        _boxCollider.size = new Vector3(_width, _height, _depth);

        _meshCollider = gameObject.AddComponent<MeshCollider>();

        _mesh = new Mesh();
        _mesh.name = _filterName;

        Vector3[] vertices = new Vector3[24]
        {
            // bottom
            new Vector3(0, 0, 0),
            new Vector3(_width, 0, 0),
            new Vector3(0, 0, _depth),
            new Vector3(_width, 0, _depth),

            // top
            new Vector3(0, _height, 0),
            new Vector3(_width, _height, 0),
            new Vector3(0, _height, _depth),
            new Vector3(_width, _height, _depth),

            // back(world : -z)
            new Vector3(0, 0, 0),
            new Vector3(_width, 0, 0),
            new Vector3(0, _height, 0),
            new Vector3(_width, _height, 0),

            // right(world : +x)
            new Vector3(_width, 0, 0),
            new Vector3(_width, 0, _depth),
            new Vector3(_width, _height, 0),
            new Vector3(_width, _height, _depth),

            // front(world : +z)
            new Vector3(_width, 0, _depth),
            new Vector3(0, 0, _depth),
            new Vector3(_width, _height, _depth),
            new Vector3(0, _height, _depth),

            // left(world : -x)
            new Vector3(0, 0, _depth),
            new Vector3(0, 0, 0),
            new Vector3(0, _height, _depth),
            new Vector3(0, _height, 0)
        };

        _mesh.vertices = vertices;

        int[] tris = new int[36]
        {
            // bottomL
            1, 3, 0,
            // bottomR
            3, 2, 0,

            // topL
            4, 6, 5,
            // topR
            6, 7, 5,

            // bL
            8, 10, 9,
            // bR
            10, 11, 9,

            // rL
            12, 14, 13,
            // rR
            14, 15, 13,

            // fL
            16, 18, 17,
            // fR
            18, 19, 17,

            // lL
            20, 22, 21,
            // lR
            22, 23, 21
        };

        _mesh.triangles = tris;

        _mesh.RecalculateNormals();

        Vector2[] uv = new Vector2[24]
        {
            new Vector2(0, 0),
            new Vector2(_width, 0),
            new Vector2(0, _depth),
            new Vector2(_width, _depth),

            new Vector2(0, 0),
            new Vector2(_width, 0),
            new Vector2(0, _depth),
            new Vector2(_width, _depth),

            new Vector2(0, 0),
            new Vector2(_width, 0),
            new Vector2(0, _height),
            new Vector2(_width, _height),

            new Vector2(0, 0),
            new Vector2(_width, 0),
            new Vector2(0, _height),
            new Vector2(_width, _height),

            new Vector2(0, 0),
            new Vector2(_width, 0),
            new Vector2(0, _height),
            new Vector2(_width, _height),

            new Vector2(0, 0),
            new Vector2(_width, 0),
            new Vector2(0, _height),
            new Vector2(_width, _height)
        };

        _mesh.uv = uv;

        _meshFilter.mesh = _mesh;
        _meshCollider.sharedMesh = _mesh;

        if (_mt != null)
        {
            _meshRenderer.material = _mt;
        }

        this.transform.position = new Vector3(_x, _y, _z);
    }
}
