#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

[DefaultExecutionOrder(1000)]
public class MenuUIHandler : MonoBehaviour
{
    private TMP_InputField nameInputField;

    void Start()
    {
        nameInputField = GameObject.Find("Name Input").GetComponent<TMP_InputField>();
    }

    public void StartNew()
    {
        MenuManager.Instance.PlayerName = nameInputField.text == "" ? "Player" : nameInputField.text;

        SceneManager.LoadScene(1);
    }

    public void Exit()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }
}
