using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class ItemPlaceable : ScriptableObject
{
    public string itemId;
    public GameObject gameObjectPrefab;
    public virtual void PlaceItem() { }
}
