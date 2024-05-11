using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeScene : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
       if( collision.CompareTag(GameConstant.PLAYER_TAG)){
            LoadNextScene();
            SceneChecker.Instance.isFirstTime = true;
        }
    }
    public void LoadNextScene()
    {
        Loader.Load(Loader.GetNextScene());
    }

}
