using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class FirstScript : MonoBehaviour
{
    
    void Start()
    {
      //  Debug.Log("Start, First frame the object exists and is active only if the script is also active");
    }
    void Update()
    {
      //  Debug.Log("Update, every frame...how ever fast your PC is" + Time.deltaTime);
    }
    void FixedUpdate()
    {
       // Debug.Log("Fixed Update" + Time.deltaTime);

    }
    void LateUpdate()
    {
    //    Debug.Log("Late Update");

    }
    void Awake()
    {
      //  Debug.Log("Awake, First frame the object exists and is active regardless if the script is active");
    }

    void OnTriggerEnter(Collider other)
    {
        
    }
    void OnTriggerStay(Collider other)
    {

    }
    void OnTriggerExit(Collider other)
    {

    }
    void OnCollisionEnter(Collision collision)
    {
        
    }
    void OnCollisionStay(Collision collision)
    {

    }
    void OnCollisionExit(Collision collision)
    {

    }
    public void ChangeScene(int sceneId)
    {
        Debug.Log("Button Pressed");
        SceneManager.LoadScene(sceneId);
    }
    public void ExitToDesktop()
    {
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #endif
        Application.Quit();
    }
}
