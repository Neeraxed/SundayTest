using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private float speed;

    private Transform camera;

    private Vector3 offset;

    private void Awake()
    {
        camera = this.transform;
        offset = camera.position - player.position;
    }

    private void Update()
    {
        Follow();
    }

    private void Follow()
    {
        camera.DOMoveX(player.position.x + offset.x, speed * Time.deltaTime);
        camera.DOMoveZ(player.position.z + offset.z, speed * Time.deltaTime);
    }

}
