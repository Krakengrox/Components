using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour {

    void ChangeScene()
    {
        SceneManager.LoadScene("Main");
    }
}
