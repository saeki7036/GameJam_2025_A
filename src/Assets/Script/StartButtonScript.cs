using UnityEngine;
using UnityEngine.SceneManagement;
public class StartButtonScript : MonoBehaviour
{
    public void ClickButton()
    {
        SceneManager.LoadScene("MainGame");
    }

    public void ClickButton2()
    {
        SceneManager.LoadScene("MainGame2");
    }
    public void RestartButton()
    {
        SceneManager.SetActiveScene(SceneManager.GetActiveScene());
    }

    public void GoTitleButton()
    {
        SceneManager.LoadScene("Title");
    }
}
