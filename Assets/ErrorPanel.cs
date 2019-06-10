using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ErrorPanel : MonoBehaviour
{
    [SerializeField] private Text _scoreText;

    public void SetText(string text)
    {
        _scoreText.text = text;
    }

    public void OnClick()
    {
        SceneManager.LoadScene(0);
    }
}
