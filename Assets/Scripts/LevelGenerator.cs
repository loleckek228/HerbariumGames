using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

[RequireComponent(typeof(LevelGameObjectGenerator))]
public class LevelGenerator : MonoBehaviour
{
    [SerializeField] private Vector3 _distanceBetweenFloorBlocks;
    [SerializeField] private Floor _floorPrefab;
    [SerializeField] private Player _playerPrefab;
    [SerializeField] private List<Trap> _trapPrefabs;
    [SerializeField] private Chest _chestPrefab;

    private LevelGameObjectGenerator gameObjectGenerator;
    private Player player;
    private Vector3 startPoint = new Vector3(0, 0, 0);

    private void Awake()
    {
        Generate();
    }

    private void Generate()
    {
        CreatePlayer();
        GenerateFloorAndTraps();
    }

    private void CreatePlayer()
    {
        player = Instantiate(_playerPrefab);

        Vector3 playerPosition = new Vector3(0, 1, 0);
        Vector3 playerRotation = new Vector3(0, 180, 0);

        player.transform.position = playerPosition;
        player.transform.rotation = Quaternion.Euler(playerRotation);
    }

    private void GenerateFloorAndTraps()
    {
        gameObjectGenerator = GetComponent<LevelGameObjectGenerator>();

        GameObject floorBlocks = new GameObject("FloorBlocks");
        GameObject trapsGameObject = new GameObject("Traps");
        GameObject chest = new GameObject("Chest");

        int floorCount = _trapPrefabs.Count * 2 + 1;

        for (int i = 0; i <= floorCount; i++)
        {
            CreateGameObject(_floorPrefab.gameObject, floorBlocks.transform, startPoint);

            if (i != 0 && i != floorCount && i % 2 == 0)
            {
                CreateTrap(trapsGameObject.transform);
            }

            if (i == floorCount)
            {
                Vector3 offset = new Vector3(1, 1.5f, 0);

                CreateGameObject(_chestPrefab.gameObject, chest.transform, startPoint + offset);
            }

            startPoint += _distanceBetweenFloorBlocks;
        }
    }

    private void CreateGameObject(GameObject gameObject, Transform parent, Vector3 position)
    {
        gameObjectGenerator.CreateGameObject(gameObject, parent, position);
    }

    private void CreateTrap(Transform parent)
    {
        if (_trapPrefabs.Count > 0)
        {
            Trap trap = GetRandomTrapFromList();

            CreateGameObject(trap.gameObject, parent, startPoint);

            _trapPrefabs.Remove(trap);
        }
    }

    private Trap GetRandomTrapFromList()
    {
        int randomIndex = Random.Range(0, _trapPrefabs.Count - 1);

        return _trapPrefabs[randomIndex];
    }

    public Player GetPlayer()
    {
        return player;
    }
}