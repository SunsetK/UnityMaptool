using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Maptool
{
    public class WindowManager : MonoBehaviour
    {
        #region Public Field

        public UILabel    titleLabel  = null;
        public UIButton   hideButton  = null;
        public UIButton   closeButton = null;
        public GameObject contents    = null;
        public GameObject scrollView  = null;

        #endregion Public Field

        #region Public Methods

        public void WindowInit(bool _isWarningObj = false)
        {
            WindowsManager.AddChildren(this.gameObject, _isWarningObj);
        }

        public void SetDepth(int _depth)
        {
            this.gameObject.GetComponent<UIPanel>().depth = _depth;

            if (scrollView != null)
            {
                scrollView.GetComponent<UIPanel>().depth = _depth;
            }
        }

        /// <summary>
        /// Set window title text.
        /// </summary>
        /// <param name="_title">title name.</param>
        public void SetWindowTitle(string _title)
        {
            titleLabel.text = _title;
        }

        /// <summary>
        /// Button close window.
        /// </summary>
        public void CloseButton()
        {
            gameObject.SetActive(false);
        }

        /// <summary>
        /// Button of set hide staatus.
        /// </summary>
        public void HideButton()
        {
            if (contents.activeSelf)
            {
                hideButton.defaultColor = new Color32(55, 72, 161, 255);
                contents.SetActive(false);
            }
            else
            {
                hideButton.defaultColor = new Color32(137, 157, 255, 255);
                contents.SetActive(true);
            }
        }

        public void OnPress(bool _press)
        {
            if (_press)
            {
                WindowsManager.SetDepthTop(this.gameObject);
            }
        }

        #endregion Public Methods
    }
}
