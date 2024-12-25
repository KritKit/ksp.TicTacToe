using System.Drawing;
using System.Net.Mime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class tttmode : MonoBehaviour
{
    public int turn;
    public GameObject[] holders = new GameObject[9];
    public GameObject[] winlines = new GameObject[8];
    public GameObject blankPaper,fadePaper;
    public Sprite x;
    public Sprite o;
    public bool[] interractablez = new bool[9];
    public Text turntext;
    public int movez;
    public int[] _holder = new int[9];
    public endstage end;
    public RectTransform textRect;
    public Vector2 startPosition;
    public Vector2 targetPosition;
    public float speedText;


    void Start(){
        blankPaper.SetActive(false);
        for (int i = 0; i < winlines.Length; i++)
        {
            winlines[i].SetActive(false);
        }
        turn = 0;
        for (int i = 0; i < 9; i++){
            _holder[i] = 2;
            interractablez[i] = true;
        }
        turntext.text =  "Turn : X";
        textRect = turntext.GetComponent<RectTransform>();
        startPosition = new Vector2(-6, 185);
        StartCoroutine(animMoveText(-391, 131));
        // textRect.anchoredPosition = new Vector2(-402, 0);

    }
    public void clickSelect(int holder){
        if(interractablez[holder] == true){
            if(turn == 0){
                holders[holder].GetComponent<Image>().sprite = x;
                holders[holder].GetComponent<Image>().color = UnityEngine.Color.red;
                StartCoroutine(RotateToDefault(holders[holder].transform));
                interractablez[holder] = false;
                turn = 1;
                turntext.text = "Turn : O";
                StartCoroutine(animMoveText(379,131));
                // textRect.anchoredPosition = new Vector2(382, 0);
                movez++;
                _holder[holder] = 0;
            }else{
                holders[holder].GetComponent<Image>().sprite = o;
                holders[holder].GetComponent<Image>().color = UnityEngine.Color.black;
                StartCoroutine(RotateToDefault(holders[holder].transform));
                interractablez[holder] = false;
                turn = 0;
                turntext.text = "Turn : X";
                StartCoroutine(animMoveText(-391, 131));
                // textRect.anchoredPosition = new Vector2(-402, 0);
                movez++;
                _holder[holder] = 1;
            }
        }
        end.Check();
    }
    public void Play(){
        SceneManager.LoadScene(1);
    }
    public void Exit(){
        SceneManager.LoadScene(0);
    }
    public IEnumerator RotateToDefault(Transform target){
        Quaternion targetRotation = Quaternion.Euler(0, 0, 0);

        while (Quaternion.Angle(target.rotation, targetRotation) > 0.01f){
            target.rotation = Quaternion.RotateTowards(
                target.rotation, 
                targetRotation, 
                100f * Time.deltaTime
            );
            yield return null;
        }
        // ตั้งค่า rotation ให้ตรงเป๊ะหลังหมุนเสร็จ
        target.rotation = targetRotation;
    }
    public IEnumerator animMoveText(float x, float y){
        blankPaper.SetActive(true);
        Vector2 targetPosition = new Vector2(x, y); // ตำแหน่งเป้าหมาย

        while (Vector2.Distance(textRect.anchoredPosition, targetPosition) > 0.01f){
            // ค่อยๆ เคลื่อนที่จากตำแหน่งปัจจุบันไปยังเป้าหมายตามความเร็ว
            textRect.anchoredPosition = Vector2.Lerp(
                textRect.anchoredPosition,
                targetPosition,
                speedText * Time.deltaTime // คำนวณระยะทางที่ควรเคลื่อนในแต่ละเฟรม
            );

            yield return null; // รอเฟรมถัดไป
        }
        
        // ตั้งค่าตำแหน่งสุดท้ายให้ตรงเป้าหมาย
        textRect.anchoredPosition = targetPosition;
        yield return new WaitForSeconds(0.05f); // รอเฟรมถัดไป
        blankPaper.SetActive(false);
    }


}
