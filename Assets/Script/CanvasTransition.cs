using UnityEngine;

public class CanvasSwitcher : MonoBehaviour
{
    public Canvas canvas1; // Premier Canvas
    public Canvas canvas2; // Deuxi�me Canvas

    private void Start()
    {
        // Initialiser l'�tat des Canvas
        canvas1.gameObject.SetActive(true);
        canvas2.gameObject.SetActive(false);
    }

    public void ShowSecondCanvas()
    {
        canvas1.gameObject.SetActive(false);
        canvas2.gameObject.SetActive(true);
    }

    public void ShowFirstCanvas()
    {
        canvas1.gameObject.SetActive(true);
        canvas2.gameObject.SetActive(false);
    }
}