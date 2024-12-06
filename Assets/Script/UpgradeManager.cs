using UnityEngine;
using UnityEngine.UI;

public class UpgradeManager : MonoBehaviour
{
    public ResourceManager resourceManager; // Référence au ResourceManager
    public Button clickUpgradeButton; // Le bouton pour +1 par clic
    public Button autoClickerButton; // Le bouton pour l'Auto Clicker
    public Text clickUpgradeText; // Texte du bouton +1 par clic
    public Text autoClickerText; // Texte du bouton Auto Clicker

    public int clickUpgradeCost = 10; // Coût initial pour le clic
    public int autoClickerCost = 100; // Coût initial pour l'Auto Clicker
    public int clickBonus = 1; // Bonus pour le clic
    public int autoClickBonus = 1; // Bonus pour l'Auto Clicker
    public int branchCost = 1000; // Coût pour ouvrir une branche
    public int branchGoldIncrease = 2; // Or supplémentaire par seconde par branche
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
            // Déduit le coût de l'amélioration
            resourceManager.currentAmount -= clickUpgradeCost;

            // Augmente le bonus de clic
            resourceManager.perClick += clickBonus;

            // Augmente le coût pour la prochaine amélioration
            clickUpgradeCost += 10;

            // Mets à jour l'UI
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
            // Déduit le coût de l'amélioration
            resourceManager.currentAmount -= autoClickerCost;

            // Augmente le gain automatique par seconde
            resourceManager.autoClickAmount += autoClickBonus;

            // Augmente le coût pour la prochaine amélioration
            autoClickerCost += 50;

            // Mets à jour l'UI
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
        // Mets à jour uniquement le texte des boutons
        clickUpgradeText.text = "Amélioration Clic: " + clickUpgradeCost + " Or" + "= +1 gold per click";
        autoClickerText.text = "Auto Clicker: " + autoClickerCost + " Or" + " = +1 gold per second";
        branchUpgradeText.text = "New Shop : " + branchCost + " Or" + " = Open a new shop in town, grants you 1 more gold per second for the autoclicker";
        
    }
    public void BuyBranch()
    {
        if (resourceManager.currentAmount >= branchCost)
        {
            // Déduit le coût de la branche
            resourceManager.currentAmount -= branchCost;

            // Augmente les gains par seconde des branches
            resourceManager.branchGoldPerSecond += branchGoldIncrease;

            // Augmente le coût pour la prochaine branche
            branchCost += 500;

            // Mets à jour l'UI
            resourceManager.UpdateUI();
            UpdateButtonUI();
        }
        else
        {
            Debug.Log("Pas assez de ressources pour ouvrir une nouvelle branche !");
        }
    }
}