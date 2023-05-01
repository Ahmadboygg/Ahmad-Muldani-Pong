using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ISpeedable 
{
   void BallSpeedUp();
   void ResetBallSpeedUp();
   void PaddleSpeedUp();
   void ResetPaddleSpeedUp();
}
