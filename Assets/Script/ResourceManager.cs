using UnityEngine;
using TMPro;

public class ResourceManager : MonoBehaviour
{
    public int currentAmount = 0; // Or actuel
    public int clickAmount = 1; // Or gagn� par clic
    public int autoClickAmount = 0; // Or gagn� par seconde (via auto clickers)
    public int branchGoldPerSecond = 0; // Or gagn� par seconde (via branches)
    public int investmentGoldPerInterval = 0; // Or g�n�r� toutes les 30 secondes
    public int currentInvestments = 0; // Nombre d'investissements actuels
    public int maxInvestments = 5; // Nombre maximum d'investissements

    public TMP_Text goldText; // Utilise TMP_Text pour afficher l'or

    private void Start()
    {
        InvokeRepeating(nameof(AddAutoClickResources), 1f, 1f); // Auto click toutes les secondes
        InvokeRepeating(nameof(AddBranchGold), 1f, 1f); // Gold des branches toutes les secondes
        InvokeRepeating(nameof(AddInvestmentGold), 30f, 30f); // Investissements toutes les 30 secondes
        UpdateUI();
    }

    // Ajout d'or par un clic
    public void AddGoldPerClick()
    {
        currentAmount += clickAmount; // Ajoute le gold bas� sur la valeur actuelle de clickAmount
        UpdateUI(); // Met � jour l'UI pour afficher la nouvelle quantit� de gold
    }

    // Ajout automatique d'or par seconde (autoclickers)
    public void AddAutoClickResources()
    {
        currentAmount += autoClickAmount;
        UpdateUI();
    }

    // Ajout d'or par les branches
    public void AddBranchGold()
    {
        currentAmount += branchGoldPerSecond;
        UpdateUI();
    }

    // Ajout d'or par les investissements (toutes les 30 secondes)
    public void AddInvestmentGold()
    {
        currentAmount += investmentGoldPerInterval;
        UpdateUI();
    }

    // Mise � jour de l'UI avec le montant actuel d'or
    public void UpdateUI()
    {
        goldText.text = "Gold: " + currentAmount;
    }

    // Mise � jour du montant d'or gagn� par clic
    public void IncreaseClickAmount(int bonus)
    {
        clickAmount += bonus;
    }
}