using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    List<ICollectible> ShapesPresent = new List<ICollectible>();

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);

        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    { 
    }

    public void RegisterShape(ICollectible collectible)
    {
        ShapesPresent.Add(collectible);
    }

    public void UnregisterShape(ICollectible collectible)
    {
        ShapesPresent.Remove(collectible);

        if(ShapesPresent.Count == 0)
        {
            GameEvents.Instance.AllShapesCollected?.Invoke();
        }
    }

    public void ReloadScene()
    {
        ShapesPresent.Clear();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void OpenLink(string url)
    {
        Application.OpenURL(url);
    }

    public void QuitGame()
    {
        ShapesPresent.Clear();
        Application.Quit();
    }
}
