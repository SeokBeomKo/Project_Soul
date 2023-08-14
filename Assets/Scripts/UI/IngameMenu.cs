using UnityEngine;
using UnityEngine.SceneManagement;

public class IngameMenu : MonoBehaviour
{
    [SerializeField]    public GameObject menu;
    public void OnMenu()
    {
        menu.SetActive(true);
        Time.timeScale = 0f;
    }

    public void OffMenu()
    {
        menu.SetActive(false);
        Time.timeScale = 1f;
    }

    public void Retry()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void TimeStop()
    {

    }
}
