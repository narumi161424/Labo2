using UnityEngine;
using UnityEngine.SceneManagement;

public class Clear_back_start : MonoBehaviour
{

    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Return))
        {
            SceneManager.LoadScene("opening");
        }

    }
}