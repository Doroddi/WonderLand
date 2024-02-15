using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine;

public class RandomizeChildren2 : MonoBehaviour
{
    private void Awake()
    {
        // Unity의 transform.childCount 속성 사용
        for (int i = 0; i < transform.childCount; i++)
        {
            // Random 클래스를 사용하여 0 또는 1을 생성하여 각 스위치의 초기 상태를 랜덤으로 설정
            bool isOn = (Random.Range(0, 2) == 1); // 0 또는 1을 랜덤으로 반환하여 true 또는 false 설정
            bool isUp = (Random.Range(0, 2) == 1); // 두 번째 속성도 랜덤으로 설정
            
            // 스위치의 초기 상태 설정
            
            Transform child = transform.GetChild(i);
            child.GetComponent<Switch>().isOn = isOn;
            child.GetComponent<Switch>().isUp = isUp;
            child.GetComponent<Switch>().up.SetActive(isUp);
            child.GetComponent<Switch>().on.SetActive(isOn);
        }
    }
}


