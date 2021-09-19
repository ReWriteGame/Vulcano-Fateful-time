using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/SlotsIcon", order = 1)]
public class SlotVariant : ScriptableObject
{
    [SerializeField] private List<Sprite> iconSlot;
    public List<Sprite> IconSlot { get => iconSlot; private set => iconSlot = value; }
}
