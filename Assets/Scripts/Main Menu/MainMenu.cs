using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField]
    private Object scene;

    public void StartGame()
    {
        SceneManager.LoadScene("Main_Scene");
    }
}
