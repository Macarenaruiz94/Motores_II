using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnLevels : MonoBehaviour
{
    [SerializeField] private Transform initialLevelPart;
    [SerializeField] private List<Transform> levelParts;
    [SerializeField] private PlayerMovement player;

    private const float playerDistance = 200f;
    private Vector3 lastEndPosition;

    private void Awake()
    {
        lastEndPosition = initialLevelPart.Find("endPosition").position;

        int startingSpawnLevelParts = 5;
        for (int i = 0; i < startingSpawnLevelParts; i++)
        {
            SpawnLevel();
        }
    }

    private void Update()
    {
        if (Vector3.Distance(player.GetPosition(), lastEndPosition) < playerDistance) 
        {
            SpawnLevel();
        }
    }

    private void SpawnLevel()
    {
        Transform chosenLevelPart = levelParts[Random.Range(0, levelParts.Count)];
        Transform lastLevelPartTransform = SpawnLevelPart(chosenLevelPart, lastEndPosition);
        lastEndPosition = lastLevelPartTransform.Find("endPosition").position;
    }

    private Transform SpawnLevelPart(Transform levelParts, Vector3 spawnPosition)
    {
        Transform levelPartsTransform = Instantiate(levelParts, spawnPosition, Quaternion.identity);
        return levelPartsTransform;
    }
}
