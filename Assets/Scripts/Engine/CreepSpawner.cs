using System.Collections.Generic;
using UnityEngine;

public class CreepSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject creep;

    public float spawnInterval = 3.5f;
    public int creepCount = 10;

    private readonly List<GameObject> creeps = new();

    private void Start()
    {
        creep.SetActive(false);
    }

    void Update()
    {
        SpawnCreep();
        creeps.RemoveAll(item => item == null);
    }

    private void SpawnCreep()
    {
        if (creeps.Count < creepCount)
        {
            for (int i = 0; i < creepCount - creeps.Count; i++)
            {
                var creep = Instantiate(this.creep, this.creep.transform.position, Quaternion.identity);
                creep.SetActive(true);
                creeps.Add(creep);
            }
        }
    }
}
