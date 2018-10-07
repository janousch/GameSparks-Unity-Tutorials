
using UnityEngine;

namespace GameSparksTutorials
{
    public class Login : MonoBehaviour
    {
        public void GuestLogin()
        {
            EventManager.StartListening<string>("OnLoginResponse", OnLoginResponse);

            GS_Authentication.DeviceAuthentication("OnLoginResponse");
        }

        private void OnLoginResponse(string displayName)
        {
            if (displayName.Length > 0)
            {
                DataController.SaveValue("displayName", displayName);

                UIController.SetActivePanel(UI_Element.MainMenu);
            } else
            {
                Debug.Log("Error OnLoginResponse");
            }

            EventManager.StopListening<string>("OnLoginResponse", OnLoginResponse);
        }
    }
}