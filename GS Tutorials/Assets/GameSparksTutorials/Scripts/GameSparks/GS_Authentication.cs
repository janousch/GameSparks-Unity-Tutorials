using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// GameSparks
using GameSparks.Api.Requests;
using GameSparks.Core;

namespace GameSparksTutorials
{
    public enum ERegistrationResponse
    {
        EmailIsTaken, UsernameIsTaken, Success, Error
    }

    public class GS_Authentication : GS_Base
    {

        /// <summary>
        /// Log the user in as a guest.
        /// </summary>
        /// <param name="eventName">The event will be called after the device authentication response.</param>
        public static void DeviceAuthentication(string eventName)
        {
            Debug.Log("Device authentication...");

            var deviceAuthenticationRequest = new DeviceAuthenticationRequest();

            deviceAuthenticationRequest.Send(response =>
            {
                if (!response.HasErrors)
                {
                    Debug.Log("Player authenticated!\nName: " + response.DisplayName);

                    EventManager.TriggerEvent(eventName, response.DisplayName);
                } else
                {
                    Debug.Log("Error authenticating player... \n" + response.Errors.JSON.ToString());

                    EventManager.TriggerEvent(eventName, "");
                }
            });
        }
    }
}
