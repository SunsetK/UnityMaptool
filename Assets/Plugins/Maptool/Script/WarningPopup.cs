using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Maptool
{
    public class WarningPopup : WindowManager
    {
        #region Public Feild
        public GameObject background = null;
        #endregion Public Feild

        #region Public Property

        public string Message { get; set; }

        #endregion Public Property

        #region Public Methods

        public void Start()
        {
            WindowInit(true);
            gameObject.SetActive(false);
        }

        public void OnEnable()
        {
            WindowsManager.SetDepthTop(this.gameObject);
            background.GetComponent<UIPanel>().depth = gameObject.GetComponent<UIPanel>().depth;
            background.SetActive(true);
        }

        public void OnDisable()
        {
            background.SetActive(false);
        }

        public void SetMessage(string _msg)
        {
            Message = _msg;
        }

        #endregion Public Methods
    }
}

