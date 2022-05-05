using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour
{
    private BoxCollider2D spawnArea;

    void Start()
    {
        spawnArea = GameObject.Find("/World/SpawnArea").GetComponent<BoxCollider2D>();
        NewPosition();
    }
    public void NewPosition()
    {
        Bounds bounds = this.spawnArea.bounds;
        bool isOcupated = true;
        float x = 0;
        float y = 0;
        while (isOcupated)
        {
            isOcupated = false;
            x = Mathf.Round(Random.Range(bounds.min.x, bounds.max.x));
            y = Mathf.Round(Random.Range(bounds.min.y, bounds.max.y));
            foreach(Transform tail in GameManager.GM.PM.Tails)
                if (tail.position == new Vector3(x, y, 0))
                    isOcupated = true;
        }
        this.transform.position = new Vector3(x, y, 0f);
    }
    void OnTriggerEnter2D(Collider2D snake)
    {
        NewPosition();
    }
}
