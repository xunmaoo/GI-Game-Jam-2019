using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AreaExit : MonoBehaviour
{
    [SerializeField] string areaToLoad;
    public string areaTransitionName;//用来标注是从哪个门出来的 这样让角色初识时站在正确的位置
                                     //1-1-1 means the first door in scene1-1

    

    // Start is called before the first frame update
    void Start()
    {
     
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            PlayerController.instance.areaTransitionName = areaTransitionName;
            Debug.Log("we are trying to load " + areaToLoad);
            SceneManager.LoadScene(areaToLoad);
            
        }
    }
}
