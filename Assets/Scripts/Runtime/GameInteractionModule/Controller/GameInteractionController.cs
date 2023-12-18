using Cysharp.Threading.Tasks;
using Runtime.GameInteractionModule.UI;
using Runtime.UI.Controller;

namespace Runtime.GameInteractionModule.Controller
{
    public class GameInteractionController
    {
        private readonly UIPanelController _uiPanelController;
        
        public GameInteractionController(UIPanelController uiPanelController)
        {
            _uiPanelController = uiPanelController;
            
            InitUIPanelAsync().Forget();
        }

        private async UniTaskVoid InitUIPanelAsync()
        {
            GameUIPanel gameUIPanel = await _uiPanelController.GetPanelAsync<GameUIPanel>();
            gameUIPanel.TogglePanel(true);
        }
    }
}