using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class webPost : MonoBehaviour
{
    int autoTriggers;
    int motionTriggers;
    public string postUrl;
  
    // Start is called before the first frame update
    void Start(){
        StartCoroutine( sendReport() );
    } // end Start

    // Update is called once per frame
    void Update(){
  
    } // end update

    IEnumerator sendReport(){
        print( "in sendReport" );
        WWWForm dataToPost = new WWWForm();
        dataToPost.AddField("autoTriggers", 2 );
        dataToPost.AddField("motionTrigger", 3 );
        UnityWebRequest www = UnityWebRequest.Post( postUrl, dataToPost );
        yield return www.SendWebRequest();
        if( www.isNetworkError || www.isHttpError ){
            print(www.error);
        } // end error
        else{
            print( "back from POST with: " + www.downloadHandler.text );
            // clear for next report
            autoTriggers = 0;
            motionTriggers = 0;
        } // end POST
    } //end post

    void autoTrigger(){
        autoTriggers++;
    }
    
    void motionTrigger(){
        motionTriggers++;
    }
}
