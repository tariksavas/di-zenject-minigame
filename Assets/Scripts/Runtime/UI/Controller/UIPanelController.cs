using System;
using System.Collections.Generic;
using System.Threading;
using Cysharp.Threading.Tasks;
using Runtime.StructuralDefinitions;
using Runtime.UI.Factory;

namespace Runtime.UI.Controller
{
    public class UIPanelController
    {
        private readonly UIPanelFactory _uiPanelFactory;

        private readonly Dictionary<Type, UIPanel> _cachedPanels = new Dictionary<Type, UIPanel>();
       
        private readonly OptimizedList<Type> _inProgress = new OptimizedList<Type>();

        public UIPanelController(UIPanelFactory uiPanelFactory)
        {
            _uiPanelFactory = uiPanelFactory;
        }

        public async UniTask<T> GetPanelAsync<T>(bool isSinglePanel = true, CancellationToken cancellationToken = default) where T : UIPanel
        {
            Type panelType = typeof(T);
            
            if (isSinglePanel)
            {
                if (_inProgress.Contains(panelType))
                {
                    await UniTask.WaitWhile(() => _inProgress.Contains(panelType), cancellationToken: cancellationToken);
                }
                
                if (_cachedPanels.TryGetValue(panelType, out UIPanel cachedUIPanel))
                {
                    return cachedUIPanel as T;
                }
            }
            
            _inProgress.Add(panelType);
            
            UIPanel uiPanel = await _uiPanelFactory.Create(panelType.Name);

            _cachedPanels.TryAdd(panelType, uiPanel);
            
            _inProgress.Remove(panelType);
                
            return uiPanel as T;
        }
    }
}