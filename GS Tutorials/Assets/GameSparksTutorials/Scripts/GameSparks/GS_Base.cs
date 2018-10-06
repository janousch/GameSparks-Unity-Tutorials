
using UnityEngine;

// GameSparks
using GameSparks.Core;

namespace GameSparksTutorials
{
    public abstract class GS_Base : AMonoBehaviourSingleton<GS_Base>
    {
        public bool IsAvaillable { get; private set; }

        public bool IsAuthenticated { get; private set; }

        private void Awake()
        {
            GS.GameSparksAvailable += OnGameSparksAvailable;
            GS.GameSparksAuthenticated += OnGameSparksAuthenticated;
        }

        private void OnGameSparksAvailable(bool available)
        {
            IsAvaillable = available;
        }
        
        private void OnGameSparksAuthenticated(string available)
        {
            IsAuthenticated = true;
        }
    }
}
