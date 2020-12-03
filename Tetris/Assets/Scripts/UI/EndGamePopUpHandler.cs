using UnityEngine;
using UnityEngine.UI;

public class EndGamePopUpHandler : MonoBehaviour
{
    [SerializeField] private GameObject panel;
    [SerializeField] private Button replayButton;

    public GameObject Panel => panel;
    public Button ReplayButton => replayButton;
}
