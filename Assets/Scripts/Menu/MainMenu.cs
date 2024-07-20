
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] SceneState sceneState;
    //Load Scene
    public void Play()
    {
        sceneState.ResetData();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

    }

    //Quit Game
    public void Quit()
    {
        Application.Quit();
        Debug.Log("Player Has Quit The Game");
    }
}
