using UnityEngine;
using UnityEngine.UI;

public class CanvasUI : MonoBehaviour
{
    [SerializeField] Image vidasImage;
    [SerializeField] Sprite[] vidasSprite;
    public GameManager GameManager;
    void Start()
    {
        if (GameManager != null)
        {
            vidasImage.sprite = vidasSprite[GameManager.lives - 1];
        }
    }

    public void setActiveSprite(int spriteindex)
    {
        if (spriteindex > 0 && spriteindex <= vidasSprite.Length)
        {
            vidasImage.sprite = vidasSprite[spriteindex - 1];
            vidasImage.color = Color.white; // Mostrar el sprite
        }
        else
        {
            vidasImage.color = Color.clear; // Ocultar el sprite si no hay vidas
        }
    }
}