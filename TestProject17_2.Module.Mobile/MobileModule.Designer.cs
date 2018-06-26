namespace TestProject17_2.Module.Mobile {
    partial class TestProject17_2MobileModule {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if(disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            // 
            // TestProject17_2MobileModule
            // 
            this.RequiredModuleTypes.Add(typeof(TestProject17_2.Module.TestProject17_2Module));
            this.RequiredModuleTypes.Add(typeof(DevExpress.ExpressApp.Mobile.SystemModule.SystemMobileModule));
			this.RequiredModuleTypes.Add(typeof(DevExpress.ExpressApp.Validation.Mobile.ValidationMobileModule));
        }

        #endregion
    }
}