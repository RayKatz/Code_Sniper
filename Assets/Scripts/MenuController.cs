using UnityEngine;
using System.Collections;

public class MenuController : MonoBehaviour {

    public GameObject[] canvasi;
    public Animator fadeAnim;
    int index = 0;

    void Start()
    {
        Switch();
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
        Animator[] anims = canvasi[index].GetComponentsInChildren<Animator>();
        foreach (Animator a in anims)
        {
            a.enabled = true;
        }
    }
}
