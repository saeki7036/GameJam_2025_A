using UnityEngine;
using UnityEngine.SceneManagement;
public class StartButtonScript : MonoBehaviour
{
        public void ClickButton()
    {
        SceneManager.LoadScene("SampleScene");
    }
}
