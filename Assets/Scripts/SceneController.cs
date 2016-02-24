using UnityEngine;
using UnityEngine.Networking;
using System.Collections;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour {

    public string loadLevel;
    string nextLevel;

	// Use this for initialization
	void Start ()
    {
        DontDestroyOnLoad(gameObject);
	}
	
	// Update is called once per frame
	public void SwitchLevel (string level)
    {
        //TODO: animate fader
        GameObject.Find("Fade").GetComponent<Animator>().SetTrigger("Change");

        nextLevel = level;
        Invoke("Switch", 1f);
	}

    void Switch()
    {
        SceneManager.LoadScene(loadLevel);
        StartCoroutine(LoadLevel());
    }

    IEnumerator LoadLevel()
    {
        yield return new WaitForSeconds(3);
        GameObject.Find("Fade").GetComponent<Animator>().SetTrigger("Change");
        yield return new WaitForSeconds(1.1f);
        SceneManager.LoadScene(nextLevel);
    }
}
