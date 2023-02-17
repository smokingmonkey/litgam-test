using System;
using _LitgTest.Scripts.Models.AnimationModels;

namespace _LitgTest.Scripts.GameLogic.Models.DataModels
{
    public enum DataModels
    {
        PlayerData,
    }
    
    [Serializable]
    public class PlayerData
    {
        public PlayerDances danceAnimation;

        public PlayerData(PlayerDances danceAnimationData)
        {
            danceAnimation = danceAnimationData;
        }
    }
}