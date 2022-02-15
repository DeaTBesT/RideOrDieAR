using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : MonoBehaviour
{
    public void Kill()
    {
        GameManager.Instance.KillEnemy();

        Destroy(gameObject);
    }
}
