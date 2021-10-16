using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    private static MenuManager Instance;
    [SerializeField] private Button buttonGame0, buttonGame1, buttonGame2;

    // Start is called before the first frame update
    void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
        }
        else {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

	private void Start()
	{
        buttonGame0.onClick.AddListener(delegate { ChangeScene(0); });
        buttonGame1.onClick.AddListener(delegate { ChangeScene(1); });
        buttonGame2.onClick.AddListener(delegate { ChangeScene(2); });
    }

    void ChangeScene(int index) {
        SceneManager.LoadScene(index);
    }
}
