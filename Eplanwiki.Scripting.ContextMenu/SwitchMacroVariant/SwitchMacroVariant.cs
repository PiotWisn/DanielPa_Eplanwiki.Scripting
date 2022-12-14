/* This Source Code Form is subject to the terms of the Mozilla Public
 * License, v. 2.0. If a copy of the MPL was not distributed with this
 * file, You can obtain one at http://mozilla.org/MPL/2.0/. */

using Eplan.EplApi.ApplicationFramework;
using Eplan.EplApi.Base;
using Eplan.EplApi.Scripting;
using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;
using System.Xml;

namespace Eplanwiki.Scripting.ContextMenu
{
    partial class VarinatSelectionForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.comboBoxVariant = new System.Windows.Forms.ComboBox();
            this.labelVariant = new System.Windows.Forms.Label();
            this.buttonOk = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // comboBoxVariant
            // 
            this.comboBoxVariant.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxVariant.FormattingEnabled = true;
            this.comboBoxVariant.Location = new System.Drawing.Point(121, 10);
            this.comboBoxVariant.Margin = new System.Windows.Forms.Padding(2);
            this.comboBoxVariant.Name = "comboBoxVariant";
            this.comboBoxVariant.Size = new System.Drawing.Size(102, 24);
            this.comboBoxVariant.TabIndex = 0;
            this.comboBoxVariant.SelectedIndexChanged += new System.EventHandler(this.comboBoxVariant_SelectedIndexChanged);
            // 
            // labelVariant
            // 
            this.labelVariant.AutoSize = true;
            this.labelVariant.Location = new System.Drawing.Point(11, 15);
            this.labelVariant.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelVariant.Name = "labelVariant";
            this.labelVariant.Size = new System.Drawing.Size(53, 17);
            this.labelVariant.TabIndex = 1;
            this.labelVariant.Text = "Variant";
            // 
            // buttonOk
            // 
            this.buttonOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonOk.Location = new System.Drawing.Point(14, 76);
            this.buttonOk.Margin = new System.Windows.Forms.Padding(2);
            this.buttonOk.Name = "buttonOk";
            this.buttonOk.Size = new System.Drawing.Size(101, 31);
            this.buttonOk.TabIndex = 2;
            this.buttonOk.Text = "OK";
            this.buttonOk.UseVisualStyleBackColor = true;
            // 
            // buttonCancel
            // 
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Location = new System.Drawing.Point(121, 76);
            this.buttonCancel.Margin = new System.Windows.Forms.Padding(2);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(101, 31);
            this.buttonCancel.TabIndex = 3;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // VarinatSelectionForm
            // 
            this.AcceptButton = this.buttonOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoSize = true;
            this.CancelButton = this.buttonCancel;
            this.ClientSize = new System.Drawing.Size(231, 121);
            this.ControlBox = false;
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonOk);
            this.Controls.Add(this.labelVariant);
            this.Controls.Add(this.comboBoxVariant);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "VarinatSelectionForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Variant";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBoxVariant;
        private Button buttonOk;
        private Button buttonCancel;
        private System.Windows.Forms.Label labelVariant;
    }

    /// <summary>
    /// Contains static text for usercontrolls
    /// Uncoment/comment the section you want/don't want before loading the script
    /// </summary>
    public static class TextHelper
    {
        #region English
        public static string MESSAGE_BOX_TEXT_PROJECT_SETTING = "The project setting 'Insert macrobox' is not set to true.\n" +
                    "The macrobox would get lost this way. If your Electric P8 version is 2.3 or higher, the setting could be done automatically.\n\n" +
                    "Should the project setting 'Insert macrobox' set to true?";
        public static string MESSAGE_BOX_TITEL_PROJECT_SETTING = "Project setting 'Insert macrobox'";
        public static string CONTEXT_MENU_ITEM_TEXT = "Switch Variant...";
        public static string VARIANT = "Variant";
        #endregion

        #region German
        //public static string MESSAGE_BOX_TEXT_PROJECT_SETTING = "Die Projekteinstellung 'Makrokästen mit einfügen' ist nicht gesetzt.\n" +
        //            "Auf diese Weise würde der Makrokasten verloren gehen. Ist Ihre Electric P8 Version 2.3 oder höher, kann die Einstellung automatisch gesetzt werden.\n\n" +
        //            "Soll die Projekteinstellung 'Makrokästen mit einfügen' gesetzt werden?";
        //public static string MESSAGE_BOX_TITEL_PROJECT_SETTING = "Projekteinstellung 'Makrokästen mit einfügen'";
        //public static string CONTEXT_MENU_ITEM_TEXT = "Variante umschalten...";
        //public static string VARIANT = "Variante";
        #endregion
    }

    /// <summary>
    /// Main class with menu entry and action
    /// </summary>
    public class SwitchMacroVariant
    {   
        /// <summary>
        /// The on register script.
        /// </summary>
        [DeclareRegister]
        public void OnRegisterScript()
        {
            AddVarinatSelectionMenuItem();
        }

        /// <summary>
        /// The on un register script.
        /// </summary>
        [DeclareUnregister]
        public void OnUnRegisterScript()
        {
            RemoveVarinatSelectionMenuItem();
        } 
   
        /// <summary>
        /// Action gets started from contextmenu in GED
        /// </summary>
        [DeclareAction("VarinatSelectionAction")]
        public void VarinatSelectionAction()
        {
            if (CheckPlaceMacroBoxSetting())        //else: ask to set the parameter 
            {
                Process oCurrent = Process.GetCurrentProcess();
                var ww = new WindowWrapper(oCurrent.MainWindowHandle); //wrap the form to eplan process

                VarinatSelectionForm selectionForm = new VarinatSelectionForm();
                DialogResult result = selectionForm.ShowDialog(ww);

                if (result == DialogResult.OK)
                {
                    SetMacroboxVariant(selectionForm.SelectedVariant);

                    UpdateMacro();
                }
            }
            
            else
            {
               DialogResult dResult = MessageBox.Show(TextHelper.MESSAGE_BOX_TEXT_PROJECT_SETTING, TextHelper.MESSAGE_BOX_TITEL_PROJECT_SETTING, MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
               switch (dResult)
               {                                    
                   case DialogResult.No:                       
                       break;                   
                   case DialogResult.Yes:
                       SetProjectSetting("MacrosGui.InsertMacrobox", "1");
                       VarinatSelectionAction();
                       break;
                   default:
                       break;
               }
            }
        }

        /// <summary>
        /// Adds the menueitem to contextmenu in GED
        /// </summary>        
        private void AddVarinatSelectionMenuItem()
        {
            Eplan.EplApi.Gui.ContextMenu oMenu = new Eplan.EplApi.Gui.ContextMenu();
            Eplan.EplApi.Gui.ContextMenuLocation oLocation = new Eplan.EplApi.Gui.ContextMenuLocation("Editor", "Ged");
            oMenu.AddMenuItem(oLocation, TextHelper.CONTEXT_MENU_ITEM_TEXT, "VarinatSelectionAction", true, false);            
        }

        /// <summary>
        /// Adds the menueitem to contextmenu in GED
        /// </summary>        
        private void RemoveVarinatSelectionMenuItem()
        {
            Eplan.EplApi.Gui.ContextMenu oMenu = new Eplan.EplApi.Gui.ContextMenu();
            Eplan.EplApi.Gui.ContextMenuLocation oLocation = new Eplan.EplApi.Gui.ContextMenuLocation("Editor", "Ged");
            oMenu.RemoveMenuItem(oLocation, TextHelper.CONTEXT_MENU_ITEM_TEXT, "VarinatSelectionAction", true, false);
        }

        /// <summary>
        /// Should check if the "/Settings/CAT/MOD/Setting:InsertMacrobox" has Val = 1
        /// Is there a way to read project settings without API? Maybe with export
        /// YES THERE IS A WAY!!! THANKS TO FrankS
        /// </summary>
        /// <returns></returns>
        private bool CheckPlaceMacroBoxSetting()
        {
            string node = "MacrosGui";
            string setting = "/Settings/CAT/MOD/Setting[@name='InsertMacrobox']/Val";
            string settingTemp = GetProjectSetting(node, setting);
            if (settingTemp.Equals("1"))
            {
                return true;
            }
            else
            {
                return false;
            }
            
        }
        
        /// <summary>
        /// Exports a node from projectsettings to a temp file and reads the setting value
        /// </summary>
        /// <param name="node">´'name'-attribute value of the MOD element to export</param>
        /// <param name="setting">XPath of the setting to read</param>
        /// <returns>value of the setting as string</returns>
        private string GetProjectSetting(string node, string setting)
        {
            try
            {
                string projectPath = PathMap.SubstitutePath("$(PROJECTPATH)");
                string settingsTempFile = Path.Combine(System.Environment.GetEnvironmentVariable("TEMP"), "GetProjectSetting_temp.xml");
                new CommandLineInterpreter().Execute("XSettingsExport /XmlFile:\"" + settingsTempFile + "\" /prj:\"" + projectPath + "\" /Node:" + node);
                var xmlDocument = new XmlDocument();
                xmlDocument.Load(settingsTempFile);
                var settingNode = xmlDocument.DocumentElement.SelectSingleNode(setting);
                var projectSetting = settingNode.InnerText;
                File.Delete(settingsTempFile);
                return projectSetting;
            }
            catch (BaseException exc)
            {
                String strMessage = exc.Message;
                System.Windows.Forms.MessageBox.Show("Exception: " + strMessage);
                return string.Empty;
            }
        }
        
        /// <summary>
        /// The action XAfActionSettingProject is only available in version 2.3 and higher
        /// </summary>
        /// <param name="setting"></param>
        /// <param name="value"></param>
        private void SetProjectSetting(string setting, string value)
        {
            CommandLineInterpreter interpreter = new CommandLineInterpreter();
            ActionCallingContext XAfActionSettingProjectContext = new ActionCallingContext();
            XAfActionSettingProjectContext.AddParameter("set", setting);
            XAfActionSettingProjectContext.AddParameter("value", value);
            interpreter.Execute("XAfActionSettingProject", XAfActionSettingProjectContext);
        }               

        /// <summary>
        /// Sets the variant of the selected macrobox
        /// </summary>
        /// <param name="variant">0-15 = A-P</param>
        private void SetMacroboxVariant(int variant)
        {
            CommandLineInterpreter interpreter = new CommandLineInterpreter();
            ActionCallingContext XEsSetPropertyActionContext = new ActionCallingContext();
            XEsSetPropertyActionContext.AddParameter("PropertyId", "23008");
            XEsSetPropertyActionContext.AddParameter("PropertyIndex", "0");
            XEsSetPropertyActionContext.AddParameter("PropertyValue", variant.ToString());
            interpreter.Execute("XEsSetPropertyAction", XEsSetPropertyActionContext);
        }

        /// <summary>
        /// Macrobox has to be selected in graphical editor
        /// </summary>
        private void UpdateMacro()
        {
            CommandLineInterpreter interpreter = new CommandLineInterpreter();
            interpreter.Execute("XGedUpdateMacroAction");
            interpreter.Execute("XMSelectObjectsInsideMacroBoxAction");
        }
    }

    /// <summary>
    /// Part of VarinatSelectionForm-class not generated by form designer
    /// </summary>
    public partial class VarinatSelectionForm : Form
    {
        /// <summary>
        /// Property to access the selection of the combobox
        /// </summary>
        public int SelectedVariant { get; set; }

        /// <summary>
        /// Default constructor.
        /// </summary>
        public VarinatSelectionForm()
        {
            InitializeComponent();
            this.labelVariant.Text = TextHelper.VARIANT;
            this.Text = TextHelper.VARIANT;
            this.comboBoxVariant.Items.AddRange(VariantItems());
            this.comboBoxVariant.SelectedIndex = 0;
        }

        /// <summary>
        /// Keeps the SelectedVariant property up to date
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void comboBoxVariant_SelectedIndexChanged(object sender, EventArgs e)
        {
            SelectedVariant = comboBoxVariant.SelectedIndex;
        }

        /// <summary>
        /// Close form with no further actions
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Would be better to determine the variants available in the selected macro. 
        /// Have no idea how to determine the Variants. Getting the filename of the macro 
        /// would be enough to count the variants in xml
        /// </summary>
        /// <returns></returns>
        private string[] VariantItems()
        {
            string[] items = new string[]{
                "A",
                "B",
                "C",
                "D",
                "E",
                "F",
                "G",
                "H",
                "I",
                "J",
                "K",
                "L",
                "M",
                "N",
                "O",
                "P"};
            return items;
        }
    }

    /// <summary>
    /// For handling the owner of a form. Copied from Eplan API "User Guide" example
    /// </summary>
    public class WindowWrapper : System.Windows.Forms.IWin32Window
    {
        public WindowWrapper(IntPtr handle)
        {
            _hwnd = handle;
        }

        public IntPtr Handle
        {
            get { return _hwnd; }
        }
        private IntPtr _hwnd;
    }

}
