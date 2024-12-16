using UnityEngine;
using UnityEngine.UI;

public class UpgradeManager : MonoBehaviour
{
    public ResourceManager resourceManager; // Référence au ResourceManager
    public Button clickUpgradeButton;
    public Button autoClickerButton;
    public Button branchUpgradeButton;
    public Button investmentButton;

    public Text clickUpgradeText;
    public Text autoClickerText;
    public Text branchUpgradeText;
    public Text investmentText;

    public int clickUpgradeCost = 10;
    public int autoClickerCost = 100;
    public int branchCost = 1000;
    public int investmentCost = 10000;
    public int investmentGoldPerInterval = 200;
    public int investmentGoldIncrease = 200;
    public int maxInvestments = 5;
    public int currentInvestments = 0;

    private bool investmentActive = false; // Contrôle si l'upgrade d'investissement est active

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
            resourceManager.branchGoldPerSecond += 1; // Correction : ajout d'un bonus effectif
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
            investmentCost += 5000;
            UpdateButtonUI();  // Actualise l'UI après l'achat

            // Vérifie si l'investissement n'est pas déjà actif
            if (!investmentActive)
            {
                // Activation de l'investissement et du processus répétitif
                investmentActive = true;
                InvokeRepeating(nameof(AddInvestmentGold), 30f, 30f); // Ajout d'or toutes les 30 secondes
            }
        }
        else
        {
            Debug.Log("Pas assez de ressources ou investissement MAX atteint !");
        }
    }

    private void AddInvestmentGold()
    {
        // Ajout d'or pour chaque investissement actif
        if (currentInvestments > 0)
        {
            resourceManager.currentAmount += currentInvestments * investmentGoldPerInterval;
            resourceManager.UpdateUI();
        }
    }

    void UpdateButtonUI()
    {
        clickUpgradeText.text = $"{clickUpgradeCost} Gold = +{resourceManager.clickAmount} gold per click";
        autoClickerText.text = $"{autoClickerCost} Gold = +1 gold per second";
        branchUpgradeText.text = $"{branchCost} Gold = grants you 1 more gold per second";

        investmentText.text = currentInvestments < maxInvestments
            ? $"{investmentCost} Gold = You're shop is famous! U get {investmentGoldPerInterval} gold every 30 sec"
            : "Investment: MAX";
    }
}