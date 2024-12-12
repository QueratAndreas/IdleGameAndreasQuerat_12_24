using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI; // Si votre bouton utilise un composant UI

public class ButtonSceneSwitcher : MonoBehaviour
{
    // M�thode pour aller � "SellScene"
    public void SwitchToSellScene()
    {
        SceneManager.LoadScene("SellScene");
    }

    // M�thode pour revenir � "BaseScene"
    public void SwitchToBaseScene()
    {
        SceneManager.LoadScene("SampleScene");
    }
}