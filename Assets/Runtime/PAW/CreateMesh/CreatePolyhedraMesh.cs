using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CreatePolyhedraMesh : MonoBehaviour
{
    #region Inspector
    [Header("Mesh Filter Name")]
    [SerializeField] private string _filterName = "";

    [Header("Material")]
    [SerializeField] private Material _mt;

    [Header("Bottom Back Width Setting")]
    [SerializeField] private float _startXBB = 0f;
    [SerializeField] private float _widthBB = 1f;

    [Header("Top Back Width Setting")]
    [SerializeField] private float _startXTB = 0f;
    [SerializeField] private float _widthTB = 1f;

    [Header("Bottom Front Width Setting")]
    [SerializeField] private float _startXBF = 0f;
    [SerializeField] private float _widthBF = 1f;

    [Header("Top Front Width Setting")]
    [SerializeField] private float _startXTF = 0f;
    [SerializeField] private float _widthTF = 1f;

    [Header("Back Left Height Setting")]
    [SerializeField] private float _startYBL = 0f;
    [SerializeField] private float _heightBL = 1f;

    [Header("Back Right Height Setting")]
    [SerializeField] private float _startYBR = 0f;
    [SerializeField] private float _heightBR = 1f;

    [Header("Front Left Height Setting")]
    [SerializeField] private float _startYFL = 0f;
    [SerializeField] private float _heightFL = 1f;

    [Header("Front Right Height Setting")]
    [SerializeField] private float _startYFR = 0f;
    [SerializeField] private float _heightFR = 1f;

    [Header("Bottom Left Depth Setting")]
    [SerializeField] private float _startZBL = 0f;
    [SerializeField] private float _depthBL = 1f;

    [Header("Bottom Right Depth Setting")]
    [SerializeField] private float _startZBR = 0f;
    [SerializeField] private float _depthBR = 1f;

    [Header("Top Left Depth Setting")]
    [SerializeField] private float _startZTL = 0f;
    [SerializeField] private float _depthTL = 1f;

    [Header("Top Right Depth Setting")]
    [SerializeField] private float _startZTR = 0f;
    [SerializeField] private float _depthTR = 1f;

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
    private void Create()
    {
        _meshRenderer = gameObject.AddComponent<MeshRenderer>();
        _meshRenderer.sharedMaterial = new Material(Shader.Find("Standard"));

        _meshFilter = gameObject.AddComponent<MeshFilter>();

        _meshCollider = gameObject.AddComponent<MeshCollider>();

        _mesh = new Mesh();
        _mesh.name = _filterName;

        Vector3[] vertices = new Vector3[24]
        {
            // bottom
            new Vector3(_startXBB, _startYBL, _startZBL),
            new Vector3(_widthBB, _startYBR, _startZBR),
            new Vector3(_startXBF, _startYFL, _depthBL),
            new Vector3(_widthBF, _startYFR, _depthBR),

            // top
            new Vector3(_startXTB, _heightBL, _startZTL),
            new Vector3(_widthTB, _heightBR, _startZTR),
            new Vector3(_startXTF, _heightFL, _depthTL),
            new Vector3(_widthTF, _heightFR, _depthTR),

            // back(world : -z)
            new Vector3(_startXBB, _startYBL, _startZBL),
            new Vector3(_widthBB, _startYBR, _startZBR),
            new Vector3(_startXTB, _heightBL, _startZTL),
            new Vector3(_widthTB, _heightBR, _startZTR),

            // right(world : +x)
            new Vector3(_widthBB, _startYBR, _startZBR),
            new Vector3(_widthBF, _startYFR, _depthBR),
            new Vector3(_widthTB, _heightBR, _startZTR),
            new Vector3(_widthTF, _heightFR, _depthTR),

            // front(world : +z)
            new Vector3(_widthBF, _startYFR, _depthBR),
            new Vector3(_startXBF, _startYFL, _depthBL),
            new Vector3(_widthTF, _heightFR, _depthTR),
            new Vector3(_startXTF, _heightFL, _depthTL),

            // left(world : -x)
            new Vector3(_startXBF, _startYFL, _depthBL),
            new Vector3(_startXBB, _startYBL, _startZBL),
            new Vector3(_startXTF, _heightFL, _depthTL),
            new Vector3(_startXTB, _heightBL, _startZTL)
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
            new Vector2(_startXBB, _startZBL),
            new Vector2(_widthBB, _startZBR),
            new Vector2(_startXBF, _depthBL),
            new Vector2(_widthBF, _depthBR),

            new Vector2(_startXTB, _startZTL),
            new Vector2(_widthTB, _startZTR),
            new Vector2(_startXTF, _depthTL),
            new Vector2(_widthTF, _depthTR),

            new Vector2(_startXBB, _startYBL),
            new Vector2(_widthBB, _startYBR),
            new Vector2(_startXTB, _heightBL),
            new Vector2(_widthTB, _heightBR),

            new Vector2(_startYBR, _startZBR),
            new Vector2(_startYFR, _depthBR),
            new Vector2(_heightBR, _startZTR),
            new Vector2(_heightFR, _depthTR),

            new Vector2(_widthBF, _startYFR),
            new Vector2(_startXBF, _startYFL),
            new Vector2(_widthTF, _heightFR),
            new Vector2(_startXTF, _heightFL),

            new Vector2(_startYFL, _depthBL),
            new Vector2(_startYBL, _startZBL),
            new Vector2(_heightFL, _depthTL),
            new Vector2(_heightBL, _startZTL)
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
