using System.Net.Mime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
// using UnityEditor.TestTools.TestRunner.Api;

public class endstage : MonoBehaviour
{
    public tttmode tmode;
    public int wincode = 10;
    public bool ended;
    public string result;
    public GameObject endscreen;
    public Text resultText;

    public void Start() {
        ended = false;
        endscreen.SetActive(false);    
    }
    void Update()
    {
        if(ended == true){
            StartCoroutine(waitwinscreen(wincode));
        }
    }
    public void Check(){
        if(tmode._holder[0] == 0 && tmode._holder[1] == 0 && tmode._holder[2] == 0){
            ended = true;
            wincode = 0;
            result = "Winner : X";
            for(int i = 0; i < 9; i++){
                tmode.interractablez[i] = false;
            }
        }else if(tmode._holder[3] == 0 && tmode._holder[4] == 0 && tmode._holder[5] == 0){
            ended = true;
            wincode = 1;
            result = "Winner : X";
            for(int i = 0; i < 9; i++){
                tmode.interractablez[i] = false;
            }
        }else if(tmode._holder[6] == 0 && tmode._holder[7] == 0 && tmode._holder[8] == 0){
            ended = true;
            wincode = 2;
            result = "Winner : X";
            for(int i = 0; i < 9; i++){
                tmode.interractablez[i] = false;
            }
        }else if(tmode._holder[0] == 0 && tmode._holder[3] == 0 && tmode._holder[6] == 0){
            ended = true;
            wincode = 3;
            result = "Winner : X";
            for(int i = 0; i < 9; i++){
                tmode.interractablez[i] = false;
            }
        }else if(tmode._holder[1] == 0 && tmode._holder[4] == 0 && tmode._holder[7] == 0){
            ended = true;
            wincode = 4;
            result = "Winner : X";
            for(int i = 0; i < 9; i++){
                tmode.interractablez[i] = false;
            }
        }else if(tmode._holder[2] == 0 && tmode._holder[5] == 0 && tmode._holder[8] == 0){
            ended = true;
            wincode = 5;
            result = "Winner : X";
            for(int i = 0; i < 9; i++){
                tmode.interractablez[i] = false;
            }
        }else if(tmode._holder[0] == 0 && tmode._holder[4] == 0 && tmode._holder[8] == 0){
            ended = true;
            wincode = 6;
            result = "Winner : X";
            for(int i = 0; i < 9; i++){
                tmode.interractablez[i] = false;
            }
        }else if(tmode._holder[2] == 0 && tmode._holder[4] == 0 && tmode._holder[6] == 0){
            ended = true;
            wincode = 7;
            result = "Winner : X";
            for(int i = 0; i < 9; i++){
                tmode.interractablez[i] = false;
            }
        }else if(tmode._holder[0] == 1 && tmode._holder[1] == 1 && tmode._holder[2] == 1){ //xxxxxxxxxxxxxxxxxxxxxx
            ended = true;
            wincode = 0;
            result = "Winner : O";
            for(int i = 0; i < 9; i++){
                tmode.interractablez[i] = false;
            }
        }else if(tmode._holder[3] == 1 && tmode._holder[4] == 1 && tmode._holder[5] == 1){
            ended = true;
            wincode = 1;
            result = "Winner : O";
            for(int i = 0; i < 9; i++){
                tmode.interractablez[i] = false;
            }
        }else if(tmode._holder[6] == 1 && tmode._holder[7] == 1 && tmode._holder[8] == 1){
            ended = true;
            wincode = 2;
            result = "Winner : O";
            for(int i = 0; i < 9; i++){
                tmode.interractablez[i] = false;
            }
        }else if(tmode._holder[0] == 1 && tmode._holder[3] == 1 && tmode._holder[6] == 1){
            ended = true;
            wincode = 3;
            result = "Winner : O";
            for(int i = 0; i < 9; i++){
                tmode.interractablez[i] = false;
            }
        }else if(tmode._holder[1] == 1 && tmode._holder[4] == 1 && tmode._holder[7] == 1){
            ended = true;
            wincode = 4;
            result = "Winner : O";
            for(int i = 0; i < 9; i++){
                tmode.interractablez[i] = false;
            }
        }else if(tmode._holder[2] == 1 && tmode._holder[5] == 1 && tmode._holder[8] == 1){
            ended = true;
            wincode = 5;
            result = "Winner : O";
            for(int i = 0; i < 9; i++){
                tmode.interractablez[i] = false;
            }
        }else if(tmode._holder[0] == 1 && tmode._holder[4] == 1 && tmode._holder[8] == 1){
            ended = true;
            wincode = 6;
            result = "Winner : O";
            for(int i = 0; i < 9; i++){
                tmode.interractablez[i] = false;
            }
        }else if(tmode._holder[2] == 1 && tmode._holder[4] == 1 && tmode._holder[6] == 1){
            ended = true;
            wincode = 7;
            result = "Winner : O";
            for(int i = 0; i < 9; i++){
                tmode.interractablez[i] = false;
            }
        }else{
            if (tmode.movez == 9){
                wincode = 10;
                result = "Draw";
                ended = true;
                for (int i = 0; i < 9; i++){
                    tmode.interractablez[i] = false;
                }
            }
        }
    }

    public IEnumerator waitwinscreen(int wincodee){
        if(wincodee != 10){
            GameObject[] winlines = tmode.winlines;
            winlines[wincodee].SetActive(true);
        }
        yield return new WaitForSeconds(0.1f);
        resultText.text = result;
        endscreen.SetActive(true);
    }
}
