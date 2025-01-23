using UnityEngine;
using UnityEngine.UI;

public class CanvasUI : MonoBehaviour
{
    [SerializeField] Image vidasImage;
    [SerializeField] Sprite[] vidasSprite;

    void Start()
    {
        //vidasImage.sprite = vidasSprite[2];
    }

    public void setActiveSprite(int spriteindex)
    {
        if (vidasSprite.Length >= spriteindex && spriteindex > 0)
        {
            vidasImage.sprite = vidasSprite[spriteindex -1];

            //CREAR EL COLOR BLANCO ES LO MISMO QUE DECIR QUE SÍ QUE VEMOS
            vidasImage.color = Color.white;
        }
        else
        {
            //OCULTA EL SPRITE
            vidasImage.color= Color.clear;
        }
    }
}
