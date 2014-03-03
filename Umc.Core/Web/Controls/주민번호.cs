using System;
using System.Collections;
using System.Data;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Web.UI.Design;
using System.ComponentModel;
using System.ComponentModel.Design;

namespace Umc.Core.Web.Controls
{
    [Designer(typeof(JuminDesigner), typeof(IDesigner))]
    [ToolboxData("<{0}:UmcJuminControl runat=server></{0}:UmcJuminControl>")]
    public class UmcJuminControl : WebControl, INamingContainer
    {
        private bool isDesignTime = false;
        private PlaceHolder holder;
        private TextBox tb1;
        private TextBox tb2;
        private string num1="";
        private string num2="";
        public UmcJuminControl()
        {
            if (this.Context == null)
                this.isDesignTime = true;
        }

		/// <summary>
		/// 주민등록번호 앞자리
		/// </summary>
        [Category("Data")]
        public string Ssn1
        {
            get { return this.num1; }
            set { this.num1= value; }
        }
		/// <summary>
		/// 주민등록번호 뒷자리
		/// </summary>
        [Category("Data")]
        public string Ssn2
        {
            get { return this.num2; }
            set { this.num2= value; }
        }
		/// <summary>
		/// 전체주민등록번호
		/// '-' 구분기호 포함하면 리턴된다
		/// ex) 808080-808080
		/// </summary>
        public string FullSsn
        {
            get { return this.Ssn1 + "-" + this.Ssn2; }
            set
            {
                char[] s = "-".ToCharArray();
                string[] temp;
                temp = value.Split(s, 2);
                this.Ssn1 = temp[0];
                this.Ssn2 = temp[1];
            }
        }
        public void RenderAtDesignTime()
        {
            if (this.isDesignTime)
            {
                this.Controls.Clear();
                this.CreateChildControls();
                this.EnsureChildControls();
            }
        }
        protected override void LoadViewState(object savedState)
        {
            string[] state = (string[])savedState;

            this.Ssn1 = state[0];
            this.Ssn2 = state[1];
        }
        protected override object SaveViewState()
        {
            string[] state = new string[2];
            state[0] = this.Ssn1;
            state[1] = this.Ssn2;

            return state;
        }
        protected override void CreateChildControls()
        {
            holder = new PlaceHolder();
            tb1 = new TextBox();
            tb2 = new TextBox();
            tb1.Width = 60;
            tb2.Width = 60;
            tb1.Text = this.Ssn1;
            tb2.Text = this.Ssn2;
            tb1.TextChanged+=new EventHandler(tb1_TextChanged);
            tb2.TextChanged+=new EventHandler(tb2_TextChanged);

            holder.Controls.Add(tb1);
            holder.Controls.Add(new LiteralControl(" - "));
            holder.Controls.Add(tb2);

            this.Controls.Add(holder);
            this.ChildControlsCreated = true;
        }
        private void tb1_TextChanged(object sender, EventArgs e)
        {
            this.Ssn1 = tb1.Text;
        }
        private void tb2_TextChanged(object sender, EventArgs e)
        {
            this.Ssn2 = tb2.Text;
        }

    }
	/// <summary>
	/// 디자인 타임 지원
	/// </summary>
    public class JuminDesigner : ControlDesigner
    {
        public override string GetDesignTimeHtml()
        {
            UmcJuminControl olb = (UmcJuminControl)this.Component;
            olb.RenderAtDesignTime();

            return base.GetDesignTimeHtml();
        }
    }
}
