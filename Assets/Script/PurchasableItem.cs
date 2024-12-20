using UnityEngine;

[CreateAssetMenu(fileName = "New Purchasable Item", menuName = "Shop/Purchasable Item")]
public class PurchasableItem : ScriptableObject
{
    public string itemName; // Nom de l'objet
    public Sprite itemImage; // Image de l'objet
    public string itemDescription; // Description de l'objet
    public int itemPrice; // Prix de l'objet
}