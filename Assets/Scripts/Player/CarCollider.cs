using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarCollider : MonoBehaviour
{
    private CarController carController;

    private void Start()
    {
        carController = GetComponent<CarController>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!carController.IsMove) { return; }

        if (other.TryGetComponent(out EnemyStats m_enemyStats))
        {
            m_enemyStats.Kill();
        }
    }
}
