using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class Cam : MonoBehaviour
{


  Transform target;
  Vector3 velocity = Vector3.zero;
    
  [Range(0,1)]
  public float smoothTime;

  public Vector3 positionOffset;

  [Header("Axis Limitation")]
  public Vector2 xLimit; // o X até onde a câmera pode ir
  public Vector2 yLimit; // o Y até onde a câmera pode ir
  private void Awake()
  {
    target = GameObject.FindGameObjectWithTag("Player").transform;
  }

  private void LateUpdate()
  {
    Vector3 targetPosition = target.position+positionOffset;
    targetPosition= new Vector3(Mathf.Clamp(targetPosition.x,xLimit.x,xLimit.y), Mathf.Clamp(targetPosition.y,yLimit.x,yLimit.y), -10);
    transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);
  }
}
