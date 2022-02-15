using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    private void Start()
    {
        GameManager.Instance.AddSpawnPoint(this);
    }
}
