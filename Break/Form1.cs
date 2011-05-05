using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Break
{
    public partial class BreakForm : Form
    {
        private Preferences preferencesForm = null;

        public BreakForm() {
            this.components = new System.ComponentModel.Container();
            InitializeComponent();
        }

        private void SetupNotificationIcon() {
            
        }

        void Preferences_Click( object sender, EventArgs e ) {
            if (this.preferencesForm == null) 
                this.preferencesForm = new Preferences();

            if (this.preferencesForm.Visible == false)
                this.preferencesForm.ShowDialog( this );
        }

        void Exit_Application_Click(object sender, EventArgs e) {
            Application.Exit();
        }

        private void BreakForm_Load( object sender, EventArgs e ) {
            this.Visible = false;
            SetupNotificationIcon();

            this.Icon = Break.Properties.Resources.Break_Icon;
        }

        private void timer1_Tick( object sender, EventArgs e ) {

        }
    }
}
