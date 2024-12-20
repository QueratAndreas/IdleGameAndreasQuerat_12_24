using UnityEngine;
using UnityEngine.UI;

public class ShopManager : MonoBehaviour
{
    public ResourceManager resourceManager; // Référence au ResourceManager pour gérer l'argent
    public Transform shopContent; // Parent des boutons dans la scène
    public GameObject[] buttonInMenu; // Préfab pour les boutons
    public PurchasableItem[] itemsForSale; // Liste des objets disponibles à l'achat

    void Start()
    {
        PopulateShop();
    }

    void PopulateShop()
    {
        for (int i = 0; i < Mathf.Min(itemsForSale.Length, buttonInMenu.Length); i++)
        {
            // Configure le bouton avec les données de l'objet
            buttonInMenu[i].GetComponentInChildren<Text>().text = itemsForSale[i].itemName;
            buttonInMenu[i].GetComponent<Image>().sprite = itemsForSale[i].itemImage;

            // Ajoute la description si le champ existe dans le prefab
            Text descriptionText = buttonInMenu[i].transform.Find("DescriptionText")?.GetComponent<Text>();
            if (descriptionText != null)
            {
                descriptionText.text = itemsForSale[i].itemDescription;
            }

            // Capturer l'index pour le bouton correspondant
            int index = i;

            // Ajoute l'action d'achat au bouton
            Button buttonComponent = buttonInMenu[i].GetComponent<Button>();
            buttonComponent.onClick.AddListener(() => AttemptPurchase(itemsForSale[index], buttonInMenu[index]));
            Debug.Log($"Description de l'objet : {itemsForSale[i].itemDescription}");
        }
    }

    public void AttemptPurchase(PurchasableItem item, GameObject button)
    {
        if (resourceManager.currentAmount >= item.itemPrice)
        {
            // Réduit l'argent
            resourceManager.currentAmount -= item.itemPrice;
            resourceManager.UpdateUI();

            // Désactive le bouton après achat
            button.SetActive(false);

            Debug.Log($"Acheté : {item.itemName}");
        }
        else
        {
            Debug.Log("Pas assez d'argent !");
        }
    }
}