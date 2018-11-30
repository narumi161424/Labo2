using UnityEngine;
using UnityEngine.SceneManagement;

public class Startpage: MonoBehaviour
{

    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Return))
        {
            SceneManager.LoadScene("menu");
        }

    }
}