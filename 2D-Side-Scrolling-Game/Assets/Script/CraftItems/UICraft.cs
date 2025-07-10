using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;
using UnityEngine;

public class UICraft : MonoBehaviour
{
    public string craftRecipeID;
    public Image image;
    public TextMeshProUGUI textName;
    public void SetUICraft(Sprite sprite, string nameItem)
    {
        image.sprite = sprite;
        textName.text = nameItem;    
    }
}
