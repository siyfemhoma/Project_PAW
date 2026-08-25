using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CreateRampMesh : MonoBehaviour
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

        _meshCollider = gameObject.AddComponent<MeshCollider>();

        _mesh = new Mesh();
        _mesh.name = _filterName;

        Vector3[] vertices = new Vector3[18]
        {
            // bottom
            new Vector3(0, 0, 0),
            new Vector3(_width, 0, 0),
            new Vector3(0, 0, _depth),
            new Vector3(_width, 0, _depth),

            // ramp
            new Vector3(0, 0, 0),
            new Vector3(_width, 0, 0),
            new Vector3(0, _height, _depth),
            new Vector3(_width, _height, _depth),

            // right(world : +x)
            new Vector3(_width, 0, 0),
            new Vector3(_width, _height, _depth),
            new Vector3(_width, 0, _depth),

            // wall(world : +z)
            new Vector3(_width, 0, _depth),
            new Vector3(0, 0, _depth),
            new Vector3(_width, _height, _depth),
            new Vector3(0, _height, _depth),

            // left(world : -x)
            new Vector3(0, 0, _depth),
            new Vector3(0, _height, _depth),
            new Vector3(0, 0, 0)
        };

        _mesh.vertices = vertices;

        int[] tris = new int[24]
        {
            // bottomL
            1, 3, 0,
            // bottomR
            3, 2, 0,

            // rampL
            4, 6, 5,
            // rampR
            6, 7, 5,

            // R
            8, 9, 10,

            // wL
            11, 13, 12,
            // wR
            13, 14, 12,

            // L
            15, 16, 17
        };

        _mesh.triangles = tris;

        _mesh.RecalculateNormals();

        Vector2[] uv = new Vector2[18]
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
            new Vector2(_width, _height),
            new Vector2(_width, 0),

            new Vector2(0, 0),
            new Vector2(_width, 0),
            new Vector2(0, _height),
            new Vector2(_width, _height),

            new Vector2(0, 0),
            new Vector2(_width, 0),
            new Vector2(0, _height)
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
