using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "NewItemPlaceable", menuName = "Items/ItemBox")]
public class ItemBox : ItemPlaceable
{
    public override void PlaceItem()
    {
        var player = GameManager.Instance.Player;
        SpriteRenderer sprite = GameManager.Instance.Player.spritePlayer;
        Vector2 placeDir = sprite.flipX ? Vector2.left : Vector2.right;
        Vector2 placePosition = (Vector2)player.transform.position + placeDir;

        Instantiate(gameObjectPrefab, placePosition, Quaternion.identity);

    }
}
