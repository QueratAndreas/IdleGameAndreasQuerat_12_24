using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI; // Si votre bouton utilise un composant UI

public class ButtonSceneSwitcher : MonoBehaviour
{
    // Méthode pour aller à "SellScene"
    public void SwitchToSellScene()
    {
        SceneManager.LoadScene("SellScene");
    }

    // Méthode pour revenir à "BaseScene"
    public void SwitchToBaseScene()
    {
        SceneManager.LoadScene("SampleScene");
    }
}