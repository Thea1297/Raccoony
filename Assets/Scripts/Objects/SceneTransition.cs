using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour
{
    [Header("New Scene Variables")]
    public string sceneToLoad; //which scene are we loading
    public Vector2 playerPosition; 
    public VectorValue playerMemory;
    public Vector2 cameraNewMax;
    public Vector2 cameraNewMin;
    public VectorValue cameraMin;
    public VectorValue cameraMax;

    [Header("Fading - Transition Variables")]
    public GameObject fadeInPanel;
    public GameObject fadeOutPanel;
    public float waitTime;

    private void Awake()
    {
        if(fadeInPanel != null)
        {
            GameObject panel = Instantiate(fadeInPanel, Vector3.zero, Quaternion.identity) as GameObject;
            Destroy(panel, 1);
        }
    }
    public void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player") && !other.isTrigger)
        {
            playerMemory.initialValue = playerPosition;
            //SceneManager.LoadScene(sceneToLoad);
            StartCoroutine(FadeControl());


        }
    }

    public IEnumerator FadeControl()
    {
        if (fadeOutPanel != null)
        {
            Instantiate(fadeOutPanel, Vector3.zero, Quaternion.identity);

        }
        yield return new WaitForSeconds(waitTime);
        //reset camera to cameramin and cameramax
        ResetCameraBounds();

        //async load the scene while the other scene is still active
        AsyncOperation asyncOp = SceneManager.LoadSceneAsync(sceneToLoad);
        while(!asyncOp.isDone)
        {
            yield return null; //when its done load the scene
        }
    }
    public void ResetCameraBounds()
    {
        cameraMax.initialValue = cameraNewMax;
        cameraMin.initialValue = cameraNewMin;
    }
}
