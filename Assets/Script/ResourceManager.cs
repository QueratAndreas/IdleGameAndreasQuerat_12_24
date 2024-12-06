using UnityEngine;
using TMPro;

public class ResourceManager : MonoBehaviour
{
    public TextMeshProUGUI resourceText; // Texte affichant les ressources
    public int currentAmount = 0; // Montant actuel des ressources
    public int perClick = 1; // Ressources gagnées par clic
    public int autoClickAmount = 0; // Ressources gagnées par seconde via Auto Clicker

    // Méthode appelée à chaque clic
    public void AddResource()
    {
        currentAmount += perClick; // Ajoute les ressources en fonction du bonus
        UpdateUI(); // Met à jour l'affichage
    }

    // Ajout automatique de ressources chaque seconde
    public void AddAutoClickResources()
    {
        currentAmount += autoClickAmount;
        UpdateUI();
    }

    // Met à jour l'interface utilisateur
    public void UpdateUI()
    {
        resourceText.text = currentAmount + " Or";
    }

    private void Start()
    {
        // Combine les gains automatiques des Auto Clickers et des branches
        InvokeRepeating(nameof(AddAutoClickResources), 1f, 1f);
        InvokeRepeating(nameof(AddBranchGold), 1f, 1f);
    }
    public int branchGoldPerSecond = 0; // Or généré par les branches par seconde

    public void AddBranchGold()
    {
        currentAmount += branchGoldPerSecond;
        UpdateUI();
    }
}