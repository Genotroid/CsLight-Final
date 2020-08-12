using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
{
    [SerializeField] private float _speed;

    private Vector2 _offset = Vector2.zero;
    private Material _material;

    private void Start()
    {
        _material = GetComponent<Renderer>().material;
        _offset = _material.GetTextureOffset("_MainTex");
        
    }

    private void Update()
    {
        _offset.x += _speed * Time.deltaTime;
        _material.SetTextureOffset("_MainTex", _offset);
    }
}
