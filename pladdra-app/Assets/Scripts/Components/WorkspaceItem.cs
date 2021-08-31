using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using TMPro;


using Pladdra.MVC.Models;
using Pladdra.MVC.Controllers;

namespace Pladdra.Components
{
    public class WorkspaceItem : MonoBehaviour
    {
        public TMP_Text titleText;
        public TMP_Text updatedDateText;
        public Button loadButton;
        public Button deleteButton;
    }
}
