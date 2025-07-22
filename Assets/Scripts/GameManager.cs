using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private float LoadGameDelay = 2.5f;
    [SerializeField] private float LoadGameOverDelay = 2f;

    public enum Scenes
    {
        MainMenu,
        Game,
        GameOver
    }




    public void LoadGame()
    {

        StartCoroutine(WaitAndLoad(Scenes.Game, LoadGameDelay));
    }

    public void LoadGameWithoutDelay()
    {
        SceneManager.LoadScene((int)Scenes.Game);
    }

    IEnumerator WaitAndLoad(Scenes scene, float timer)
    {
        yield return new WaitForSeconds(timer);
        SceneManager.LoadScene((int)scene);

    }

    public void LoadGameOver()
    {
        StartCoroutine(WaitAndLoad(Scenes.GameOver, LoadGameOverDelay));
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene((int)Scenes.MainMenu);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
