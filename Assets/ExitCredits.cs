using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitCredits : MonoBehaviour
{
    void Update()
    {
        if (Input.GetButtonUp("Submit"))
        {
            SceneManager.LoadScene("MainMenu");
        }
    }
}
