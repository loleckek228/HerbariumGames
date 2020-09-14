using UnityEngine;

public class LevelGameObjectGenerator : MonoBehaviour
{
    public void CreateGameObject(GameObject gameObjectPrefab, Transform parent, Vector3 position)
    {
        var gameObject = Instantiate(gameObjectPrefab, parent, true);

        gameObject.transform.position = position;
    }
}