using UnityEngine;

public class ItemAsset : MonoBehaviour
{
    public static ItemAsset Instance { get; private set; }

    private void Start()
    {
        Instance = this;
    }

    public Sprite FoodSprite;
}
