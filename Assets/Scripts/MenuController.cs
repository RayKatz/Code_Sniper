using UnityEngine;
using System.Collections;

public class MenuController : MonoBehaviour {

    public GameObject[] canvasi;
    public Animator fadeAnim;
    int index;

    void Start()
    {
        ChangeScreen(0);
    }

    public void ChangeScreen(int i)
    {
        index = i;

        fadeAnim.SetTrigger("Change");
        //fadeAnim.Play("FadeIn");

        Invoke("Switch",1f);
    }

    void Switch()
    {
        foreach (GameObject c in canvasi)
        {
            c.SetActive(false);
        }

        canvasi[index].SetActive(true);
    }

}
