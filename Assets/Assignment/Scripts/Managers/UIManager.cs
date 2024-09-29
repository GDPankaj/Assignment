using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{ 
    [SerializeField] TextMeshProUGUI scoreText;

    [SerializeField] GameObject endScreen;

    [SerializeField] Score _scoreObject;
    [SerializeField] Button _replayButton;
    [SerializeField] Button _openProjectFileButton;
    [SerializeField] Button _QuitButton;

    [SerializeField] string GithubProjectLink;

    private void OnEnable()
    {
        GameEvents.Instance.ShapeCollected.AddListener(UpdateScore);
        GameEvents.Instance.AllShapesCollected.AddListener(OpenEndScreen);
        _replayButton.onClick.AddListener(GameManager.Instance.ReloadScene);
        _openProjectFileButton.onClick.AddListener(OpenGithubLink);
        _QuitButton.onClick.AddListener(GameManager.Instance.QuitGame);
    }

    private void OnDisable()
    {
        GameEvents.Instance.ShapeCollected.RemoveListener(UpdateScore);
        GameEvents.Instance.AllShapesCollected.RemoveListener(OpenEndScreen);
        _replayButton.onClick.RemoveListener(GameManager.Instance.ReloadScene);
        _openProjectFileButton.onClick.RemoveListener(OpenGithubLink);
        _QuitButton.onClick.RemoveListener(GameManager.Instance.QuitGame);
    }

    private void Start()
    {
        scoreText.text = $"Score: {_scoreObject._Score}";
        endScreen.SetActive(false);
    }
    private void UpdateScore(int points)
    {
        _scoreObject.AddScore(points);

        scoreText.text = $"Score: {_scoreObject._Score}";
    }

    private void OpenEndScreen()
    {
        endScreen.SetActive(true);
    }

    private void OpenGithubLink()
    {
        GameManager.Instance.OpenLink(GithubProjectLink);
    }
}
