using UnityEngine;
using UnityEngine.SceneManagement;

public class Startpage2 : MonoBehaviour
{

    void Update()
    {

    
        if (Input.GetKeyDown(KeyCode.Return))
        {
            SceneManager.LoadScene("start");
        }

    }
}