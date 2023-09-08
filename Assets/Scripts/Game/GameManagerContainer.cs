using UnityEngine;

public class GameManagerContainer : MonoBehaviour
{
    [SerializeField] private GameObject _player;

    public static GameManagerContainer Instance;

    private void Awake()
    {
        Instance = this;
    }
    public GameObject GetPlayer()
    {
        return _player;
    }

}
