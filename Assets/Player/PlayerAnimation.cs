using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    [SerializeField] Vec4Variable aim;

    [Header("Sprite Directional Refrences")]
    [SerializeField] Sprite up;
    [SerializeField] Sprite left;
    [SerializeField] Sprite right;
    [SerializeField] Sprite down;
    private SpriteRenderer spriteRenderer;

    private PlayerSight playerSight;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        playerSight = GetComponentInParent<PlayerSight>();
    }

    public void Update()
    {
        if (Vector2.Angle(Vector2.left, aim.Value) <= 45)
        {
            spriteRenderer.sprite = left;
            spriteRenderer.sortingLayerName = "Background";
        }
        else if (Vector2.Angle(Vector2.right, aim.Value) <= 45)
        {
            spriteRenderer.sprite = right;
            spriteRenderer.sortingLayerName = "Background";
        }
        else if (Vector2.Angle(Vector2.up, aim.Value) <= 45)
        {
            spriteRenderer.sprite = up;
            spriteRenderer.sortingLayerName = "Actors";
        }
        else if (Vector2.Angle(Vector2.down, aim.Value) <= 45)
        {
            spriteRenderer.sprite = down;
            spriteRenderer.sortingLayerName = "Background";
        }
    }
}
