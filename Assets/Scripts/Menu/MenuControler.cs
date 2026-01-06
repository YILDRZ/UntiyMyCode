using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuControler : MonoBehaviour
{
   public Button PlayButton;
   public Button ExitButton;

    void Awake()
    {
        PlayButton.onClick.AddListener(() =>
        {
           SceneManager.LoadScene(1);
        });

        ExitButton.onClick.AddListener(() =>
        {
           Application.Quit();
        });
    }
}
