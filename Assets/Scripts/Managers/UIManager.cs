namespace redd096
{
    using UnityEngine;
    using UnityEngine.UI;

    [AddComponentMenu("redd096/MonoBehaviours/UI Manager")]
    public class UIManager : MonoBehaviour
    {
        [Header("Menu")]
        [SerializeField] GameObject pauseMenu = default;
        [SerializeField] GameObject endMenu = default;

        void Start()
        {
            //by default, deactive menu
            PauseMenu(false);
            EndMenu(false);
        }

        public void PauseMenu(bool active)
        {
            if (pauseMenu == null)
            {
                Debug.LogWarning("There is no pause menu");
                return;
            }

            //active or deactive pause menu
            pauseMenu.SetActive(active);
        }

        public void EndMenu(bool active)
        {
            if (endMenu == null)
            {
                Debug.LogWarning("There is no end menu");
                return;
            }

            if (active)
            {
                //be sure pause menu is deactive
                PauseMenu(false);
            }

            //active or deactive end menu
            endMenu.SetActive(active);
        }
    }
}