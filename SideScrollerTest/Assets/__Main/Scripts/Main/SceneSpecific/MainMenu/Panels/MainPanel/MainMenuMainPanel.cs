
using Mvc;
using UnityEngine;
using UnityEngine.UI;
using Utility;
using Zenject;

namespace MainMenu.Panels
{
    public class MainMenuMainPanelModel : BaseModel
    {
    }

    public class MainMenuMainPanelController : BaseController<MainMenuMainPanelModel>
    {
        public void PlayGame(IUtilitySceneLoader sceneLoader)
        {
            sceneLoader.LoadScene(SceneNames.GamePlay, SceneNames.Level1);
        }

        public void ExitGame()
        {
            Application.Quit();
        }
    }


    public class MainMenuMainPanel : BaseView<MainMenuMainPanelModel, MainMenuMainPanelController>
    {
        [Inject] private IUtilitySceneLoader _utilitySceneLoader;

        [SerializeField] private Button _playButton;
        [SerializeField] private Button _exitButton;


        private void Start()
        {
            _playButton.onClick.AddListener(delegate { Controller.PlayGame(_utilitySceneLoader); });
            _exitButton.onClick.AddListener(Controller.ExitGame);
        }
    }
}