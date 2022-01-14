using UnityEngine;
using UnityEngine.SceneManagement;

public class portal : MonoBehaviour
{


    private void OnCollisionEnter(Collision other) {
        Debug.Log("Going to next level");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
    }

}
