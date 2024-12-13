using UnityEngine;
using UnityEngine.UI;

public class UpgradeManager : MonoBehaviour
{
    public ResourceManager resourceManager; // Référence au ResourceManager
    public Button clickUpgradeButton; // Le bouton pour +1 par clic
    public Button autoClickerButton; // Le bouton pour l'Auto Clicker
    public Button branchUpgradeButton; // Le bouton pour ouvrir une nouvelle branche
    public Button investmentButton; // Le bouton pour acheter l'investissement

    public Text clickUpgradeText; // Texte du bouton +1 par clic
    public Text autoClickerText; // Texte du bouton Auto Clicker
    public Text branchUpgradeText; // Texte du bouton d'achat de branche
    public Text investmentText; // Texte du bouton d'investissement

    public int clickUpgradeCost = 10; // Coût initial pour le clic
    public int autoClickerCost = 100; // Coût initial pour l'Auto Clicker
    public int branchCost = 1000; // Coût pour ouvrir une branche
    public int investmentCost = 10000; // Coût initial de l'investissement
    public int investmentGoldPerInterval = 200; // Or généré toutes les 30 secondes par investissement
    public int investmentGoldIncrease = 200; // Incrément par investissement
    public int maxInvestments = 5; // Nombre maximum d'investissements
    public int currentInvestments = 0; // Nombre actuel d'investissements

    void Start()
    {
        UpdateButtonUI();
    }

    public void BuyClickUpgrade()
    {
        if (resourceManager.currentAmount >= clickUpgradeCost)
        {
            resourceManager.currentAmount -= clickUpgradeCost;
            resourceManager.clickAmount += 1;
            clickUpgradeCost += 10;
            resourceManager.UpdateUI();
            UpdateButtonUI();
        }
        else
        {
            Debug.Log("Pas assez de ressources pour l'Upgrade !");
        }
    }

    public void BuyAutoClicker()
    {
        if (resourceManager.currentAmount >= autoClickerCost)
        {
            resourceManager.currentAmount -= autoClickerCost;
            resourceManager.autoClickAmount += 1;
            autoClickerCost += 50;
            resourceManager.UpdateUI();
            UpdateButtonUI();
        }
        else
        {
            Debug.Log("Pas assez de ressources pour l'Auto Clicker !");
        }
    }

    public void BuyBranch()
    {
        if (resourceManager.currentAmount >= branchCost)
        {
            resourceManager.currentAmount -= branchCost;
            resourceManager.branchGoldPerSecond += 1;
            branchCost += 500;
            resourceManager.UpdateUI();
            UpdateButtonUI();
        }
        else
        {
            Debug.Log("Pas assez de ressources pour ouvrir une nouvelle branche !");
        }
    }

    public void BuyInvestment()
    {
        if (resourceManager.currentAmount >= investmentCost && currentInvestments < maxInvestments)
        {
            resourceManager.currentAmount -= investmentCost;
            currentInvestments++;
            resourceManager.investmentGoldPerInterval += investmentGoldPerInterval;
            investmentCost += 5000;
            resourceManager.UpdateUI();
            UpdateButtonUI();
        }
        else
        {
            Debug.Log("Pas assez de ressources pour l'investissement !");
        }
    }

    void UpdateButtonUI()
    {
        // Met à jour les textes des boutons
        clickUpgradeText.text = $"{clickUpgradeCost} Gold = +{resourceManager.clickAmount} gold per click";
        autoClickerText.text = $"{autoClickerCost} Gold = +1 gold per second";
        branchUpgradeText.text = $"{branchCost} Gold = grants you 1 more gold per second";
        investmentText.text = currentInvestments < maxInvestments
            ? $"{investmentCost} Gold = You're shop is famous! U get {resourceManager.investmentGoldPerInterval} gold every 30 sec"
            : "Investment: MAX";
    }
}