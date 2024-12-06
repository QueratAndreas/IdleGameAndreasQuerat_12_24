using UnityEngine;
using UnityEngine.UI;

public class UpgradeManager : MonoBehaviour
{
    public ResourceManager resourceManager; // R�f�rence au ResourceManager
    public Button clickUpgradeButton; // Le bouton pour +1 par clic
    public Button autoClickerButton; // Le bouton pour l'Auto Clicker
    public Text clickUpgradeText; // Texte du bouton +1 par clic
    public Text autoClickerText; // Texte du bouton Auto Clicker

    public int clickUpgradeCost = 10; // Co�t initial pour le clic
    public int autoClickerCost = 100; // Co�t initial pour l'Auto Clicker
    public int clickBonus = 1; // Bonus pour le clic
    public int autoClickBonus = 1; // Bonus pour l'Auto Clicker
    public int branchCost = 1000; // Co�t pour ouvrir une branche
    public int branchGoldIncrease = 2; // Or suppl�mentaire par seconde par branche
    public Text branchUpgradeText; // Texte du bouton d'achat de branche
    public Button branchUpgradeButton; // Bouton pour acheter une branche

    void Start()
    {
        UpdateButtonUI();
    }

    public void BuyClickUpgrade()
    {
        if (resourceManager.currentAmount >= clickUpgradeCost)
        {
            // D�duit le co�t de l'am�lioration
            resourceManager.currentAmount -= clickUpgradeCost;

            // Augmente le bonus de clic
            resourceManager.perClick += clickBonus;

            // Augmente le co�t pour la prochaine am�lioration
            clickUpgradeCost += 10;

            // Mets � jour l'UI
            resourceManager.UpdateUI();
            UpdateButtonUI();
        }
        else
        {
            Debug.Log("Pas assez de ressources pour le Click Upgrade !");
        }
    }

    public void BuyAutoClicker()
    {
        if (resourceManager.currentAmount >= autoClickerCost)
        {
            // D�duit le co�t de l'am�lioration
            resourceManager.currentAmount -= autoClickerCost;

            // Augmente le gain automatique par seconde
            resourceManager.autoClickAmount += autoClickBonus;

            // Augmente le co�t pour la prochaine am�lioration
            autoClickerCost += 50;

            // Mets � jour l'UI
            resourceManager.UpdateUI();
            UpdateButtonUI();
        }
        else
        {
            Debug.Log("Pas assez de ressources pour l'Auto Clicker !");
        }
    }

    void UpdateButtonUI()
    {
        // Mets � jour uniquement le texte des boutons
        clickUpgradeText.text = "Am�lioration Clic: " + clickUpgradeCost + " Or" + "= +1 gold per click";
        autoClickerText.text = "Auto Clicker: " + autoClickerCost + " Or" + " = +1 gold per second";
        branchUpgradeText.text = "New Shop : " + branchCost + " Or" + " = Open a new shop in town, grants you 1 more gold per second for the autoclicker";
        
    }
    public void BuyBranch()
    {
        if (resourceManager.currentAmount >= branchCost)
        {
            // D�duit le co�t de la branche
            resourceManager.currentAmount -= branchCost;

            // Augmente les gains par seconde des branches
            resourceManager.branchGoldPerSecond += branchGoldIncrease;

            // Augmente le co�t pour la prochaine branche
            branchCost += 500;

            // Mets � jour l'UI
            resourceManager.UpdateUI();
            UpdateButtonUI();
        }
        else
        {
            Debug.Log("Pas assez de ressources pour ouvrir une nouvelle branche !");
        }
    }
}