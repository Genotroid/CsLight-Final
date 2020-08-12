using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enviroment : MonoBehaviour
{
    [SerializeField] private float _speed = 0.2f;

    private void Update()
    {
        transform.Translate(transform.right * _speed * Time.deltaTime * -1, Space.World);
    }
}
