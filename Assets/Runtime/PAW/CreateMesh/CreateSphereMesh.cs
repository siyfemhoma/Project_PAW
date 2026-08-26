using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CreateSphereMesh : MonoBehaviour
{
    #region Inspector
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

        GameObject sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        _meshFilter.mesh = sphere.GetComponent<MeshFilter>().sharedMesh;

        _meshCollider = gameObject.AddComponent<MeshCollider>();

        if (_mt != null)
        {
            _meshRenderer.material = _mt;
        }

        Destroy(sphere);

        this.transform.position = new Vector3(_x, _y, _z);
        this.transform.localScale = new Vector3(_width, _height, _depth);
    }
}
