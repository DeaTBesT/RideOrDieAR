using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    [SerializeField] private float speed;

    private Transform m_player;

    private void Start()
    {
        m_player = GameManager.Instance.GetCar;
    }

    private void FixedUpdate()
    {
        Move();
        Rotate();
    }

    private void Move()
    {
        transform.Translate(transform.forward * speed * Time.deltaTime);
    }

    private void Rotate()
    {
        transform.LookAt(m_player, Vector3.up);
    }
}
