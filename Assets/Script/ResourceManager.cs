using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class ResourceManager : MonoBehaviour
{
    public int currentAmount = 0; 
    public int clickAmount = 1; 
    public int autoClickAmount = 0; 
    public int branchGoldPerSecond = 0; 
    public int investmentGoldPerInterval = 0; 
    public int currentInvestments = 0; 
    public int maxInvestments = 5; 

    public Text goldText; 

    private void Start()
    {
        InvokeRepeating(nameof(AddAutoClickResources), 1f, 1f); 
        InvokeRepeating(nameof(AddBranchGold), 1f, 1f); 
        InvokeRepeating(nameof(AddInvestmentGold), 30f, 30f); 
        UpdateUI();
    }

   
    public void AddGoldPerClick()
    {
        currentAmount += clickAmount; 
        UpdateUI(); 
    }

    
    public void AddAutoClickResources()
    {
        currentAmount += autoClickAmount;
        UpdateUI();
    }

    
    public void AddBranchGold()
    {
        currentAmount += branchGoldPerSecond;
        UpdateUI();
    }

    
    public void AddInvestmentGold()
    {
        currentAmount += investmentGoldPerInterval;
        UpdateUI();
    }

    
    public void UpdateUI()
    {
        goldText.text = "" + currentAmount;
    }

    
    public void IncreaseClickAmount(int bonus)
    {
        clickAmount += bonus;
    }
}