using TMPro;
using UnityEngine;

public class ShowResults : MonoBehaviour
{
    [SerializeField] private TMP_Text creditEarnedText;
    [SerializeField] private TMP_Text numberOfCrownsText;

    private void Start()
    {
        Show();
    }

    public void Show()
    {
        GameController gameController = FindObjectOfType<GameController>();

        if (gameController == null) return;

        creditEarnedText.text = gameController.CreditEarned.ToString();
        numberOfCrownsText.text = gameController.NumberOfCrowns.ToString();
    }
}
