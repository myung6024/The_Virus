using System.Collections;
using UnityEngine;

/*
 * 목적: static 함수 안에서도 Coroutine 함수를 사용할 수 있도록 하기 위함.
 * static 함수 안에서는 non-static 함수인 StartCoroutine 함수를 호출할 수 없으므로,
 * static instance를 만들어 instance안에서 StartCoroutine을 대신 실행해주는 클래스다.
 * 
 * 사용법: 
 * StartCoroutine 대신 StaticCoroutine.Do() 를 호출하면 된다. (instance에 접근할 필요X)
 */

namespace FK.StaticFunc
{

    public class StaticCoroutine : MonoBehaviour
    {
        // variable
        
        // get을 계속 호출하면서 생기는 overflow를 방지하기 위하여 2중 instance 설계
        private static StaticCoroutine instance = null; // 실제 instance
        private static StaticCoroutine instance_call // 호출용 instance
        {
            // Scene에 이 스크립트가 없어도 호출 가능하도록, 없으면 오브젝트 생성
            get
            {
                if(instance == null)
                {
                    instance = GameObject.FindObjectOfType(typeof(StaticCoroutine)) as StaticCoroutine;

                    if(instance == null)
                    {
                        instance = new GameObject("FK StaticCoroutine").AddComponent<StaticCoroutine>();
                    }
                }
                return instance;
            }
        }
        

        // initialize
        void Awake()
        {
            if (instance == null)
            {
                instance = this;
            }
        }

        // static coroutine
        public static void Do(IEnumerator _coroutine)
        {
            instance_call.StartCoroutine(_coroutine);            
        }
    }

}