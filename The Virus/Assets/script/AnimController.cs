using System.Collections;
using UnityEngine;
using UnityEngine.UI;

/*
 * 중요: 이 스크립트는 FK.StaticFunc.StaticCoroutine 스크립트에 종속적임. position은 localPosition 기준임.
 * 목적: 스크립트로 애니메이션을 쉽게 만들 수 있도록 하기 위함.
 * 
 * 사용법: 
 * 애니메이션을 한 번 재생(시간 기준) - PlayAnimOneShot( Image컴포넌트, Image[], 프레임 간 시간 )
 * 애니메이션을 한 번 재생(거리 기준) - PlayAnimOneShot( Image컴포넌트, Image[], 오브젝트 위치 컴포넌트, 도착 위치, 거리 측정 기준 )
 * 
 * 애니메이션을 반복 재생(시간 기준) - PlayAnim( Image컴포넌트, Image[], 프레임 간 시간, 사이클 종료 후 대기 시간 )
 * 애니메이션을 한 번 재생(거리 기준) - PlayAnim( Image컴포넌트, Image[], 오브젝트 위치 컴포넌트, 도착 위치, 거리 측정 기준 )
 * 
 * * 거리 측정 기준은 string 값으로 입력하며 "Distance" (대각선 거리, 디폴트 값) , "Horizontal", "Vertical" 셋 중 하나를 인자값으로 전달.
 */

namespace FK.StaticFunc
{
    public class ETCFunc : MonoBehaviour
    {
        public static void ShakeCamera(float ShakeTime, float shakeAmount)
        {
            StaticCoroutine.Do(CameraShake(ShakeTime, shakeAmount));
        }
        static IEnumerator CameraShake(float ShakeTime, float shakeAmount) //화면 흔들리는 효과
        {
            Transform shakeCameraPos = GameObject.Find("Game").transform;
            Vector3 originalPos = shakeCameraPos.localPosition;

            while (ShakeTime > 0.0f)//흔들리는 시간
            {
                shakeCameraPos.localPosition = originalPos + Random.insideUnitSphere * shakeAmount;

                ShakeTime -= Time.deltaTime * 1;
                yield return new WaitForSeconds(0.02f);

            }
            shakeCameraPos.localPosition = originalPos;
        }

        public static void ShakeCamera(GameObject ShakeObject, float ShakeTime, float shakeAmount, float ShakeSpeed)
        {
            StaticCoroutine.Do(CameraShake(ShakeObject, ShakeTime, shakeAmount, ShakeSpeed));
        }
        static IEnumerator CameraShake(GameObject ShakeObject, float ShakeTime, float shakeAmount, float ShakeSpeed) //화면 흔들리는 효과
        {
            Transform shakeCameraPos = ShakeObject.transform;
            Vector3 originalPos = shakeCameraPos.localPosition;

            while (ShakeTime > 0.0f)//흔들리는 시간
            {
                shakeCameraPos.localPosition = originalPos + Random.insideUnitSphere * shakeAmount;

                ShakeTime -= Time.deltaTime * 1;
                yield return new WaitForSeconds(0.02f * ShakeSpeed);

            }
            shakeCameraPos.localPosition = originalPos;
        }
    }

    public class AnimController : MonoBehaviour
    {
        // 애니메이션을 한 번 재생해주는 함수 ( 시간을 기준으로 재생 )
        public static void PlayAnimOneShot(Image _img, Sprite[] _imgs, float _time_per_frame = 0.02f)
        {
            StaticCoroutine.Do(PlayAnimOneShotCoroutine(_img, _imgs, _time_per_frame));            
        }
        static IEnumerator PlayAnimOneShotCoroutine(Image _img, Sprite[] _imgs, float _time_per_frame)
        {
            int index = 0;

            while (index < _imgs.Length)
            {
                _img.sprite = _imgs[index];

                index++;
                yield return new WaitForSeconds(_time_per_frame);                
            }
        }

        // 애니메이션을 한 번 재생해주는 함수 ( 거리를 기준으로 재생 )
        public static void PlayAnimOneShot(Image _img, Sprite[] _imgs, 
            GameObject _object, Vector3 _end_point, string _criteria = "Distance")
        {
            StaticCoroutine.Do(PlayAnimOneShotCoroutine(_img, _imgs, _object, _end_point, _criteria));
        }
        static IEnumerator PlayAnimOneShotCoroutine(Image _img, Sprite[] _imgs, 
            GameObject _object, Vector3 _end_point, string _criteria)
        {
            int index = 0;
            float _change_distance = 0;
            Vector3 _start_point = _object.transform.localPosition;

            if("Distance" == _criteria)
            {
                _change_distance = Vector3.Distance(_start_point, _end_point) / _imgs.Length;
            }
            else if("Vertical" == _criteria)
            {
                _change_distance = Mathf.Abs(_end_point.y - _start_point.y) / _imgs.Length;
            }
            else if("Horizontal" == _criteria)
            {
                _change_distance = Mathf.Abs(_end_point.x - _end_point.x)  / _imgs.Length;
            }
            
            while(index < _imgs.Length)
            {
                float _current_distance = 0;                

                if ("Distance" == _criteria)
                {
                    _current_distance = Vector3.Distance(_object.transform.localPosition, _start_point);
                }
                else if ("Vertical" == _criteria)
                {
                    _current_distance = Mathf.Abs(_object.transform.localPosition.y - _start_point.y);
                }
                else if ("Horizontal" == _criteria)
                {
                    _current_distance = Mathf.Abs(_object.transform.localPosition.x - _start_point.x);
                }

                index = (int)(_current_distance / _change_distance);
                if (index < _imgs.Length) _img.sprite = _imgs[index];

                yield return new WaitForSeconds(0.02f);
            }                        
        }

        // 애니메이션을 반복 재생해주는 함수 ( 시간을 기준으로 재생 )
        public static void PlayAnim(Image _img, Sprite[] _imgs, float _time_per_frame = 0.1f, float _time_interval = 0.02f)
        {
            StaticCoroutine.Do(PlayAnimCoroutine(_img, _imgs, _time_per_frame, _time_interval));
        }
        static IEnumerator PlayAnimCoroutine(Image _img, Sprite[] _imgs, float _time_per_frame, float _time_interval)
        {
            int index = 0;

            while (true)
            {
                _img.sprite = _imgs[index];
                index++;

                if(index < _imgs.Length) // 애니메이션 사이클이 아직 안끝났으면
                {
                    yield return new WaitForSeconds(_time_per_frame);
                }
                else // 애니메이션 사이클이 끝났으면
                {
                    index = 0;
                    yield return new WaitForSeconds(_time_interval);
                }                
            }
        }

        // 애니메이션을 반복 재생해주는 함수 ( 거리를 기준으로 재생 )
        public static void PlayAnim(Image _img, Sprite[] _imgs, 
            GameObject _object, Vector3 _end_point, string _criteria = "Distance")
        {
            StaticCoroutine.Do(PlayAnimCoroutine(_img, _imgs, _object, _end_point, _criteria));
        }
        static IEnumerator PlayAnimCoroutine(Image _img, Sprite[] _imgs, 
            GameObject _object, Vector3 _end_point, string _criteria)
        {
            int index = 0;
            float _change_distance = 0;
            Vector3 _start_point = _object.transform.localPosition;

            if ("Distance" == _criteria)
            {
                _change_distance = Vector3.Distance(_start_point, _end_point) / _imgs.Length;
            }
            else if ("Vertical" == _criteria)
            {
                _change_distance = Mathf.Abs(_end_point.y - _start_point.y) / _imgs.Length;
            }
            else if ("Horizontal" == _criteria)
            {
                _change_distance = Mathf.Abs(_end_point.x - _end_point.x) / _imgs.Length;
            }

            while (true)
            {
                float _current_distance = 0;

                if ("Distance" == _criteria)
                {
                    _current_distance = Vector3.Distance(_object.transform.localPosition, _start_point);
                }
                else if ("Vertical" == _criteria)
                {
                    _current_distance = Mathf.Abs(_object.transform.localPosition.y - _start_point.y);
                }
                else if ("Horizontal" == _criteria)
                {
                    _current_distance = Mathf.Abs(_object.transform.localPosition.x - _start_point.x);
                }

                index = (int)(_current_distance / _change_distance);
                if (index < _imgs.Length) _img.sprite = _imgs[index];

                yield return new WaitForSeconds(0.02f);
            }
        }

    }

}