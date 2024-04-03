using acc_hotlab_private_run_compare.DBClasses;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace acc_hotlab_private_run_compare
{
    public partial class FormSingleRun : Form
    {
        RunInformation providedRun;
        StoredRunContext storedRunContext;

        public FormSingleRun(RunInformation providedRun, StoredRunContext storedRunContext)
        {
            InitializeComponent();
            this.providedRun = providedRun;
            this.storedRunContext = storedRunContext;
        }

        private void ButtonSaveRunInfoText_Click(object sender, EventArgs e)
        {
            providedRun.RunDescription = TextBoxRunDescription.Text;
            storedRunContext.RunInformationSet.Update
        }
    }
}
