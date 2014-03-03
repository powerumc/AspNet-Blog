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
    [ToolboxData("<{0}:UmcTelePhone runat=server></{0}:UmcTelePhone>")]
    [Designer(typeof(TelePhoneDesigner), typeof(IDesigner))]
    public class UmcTelePhone : WebControl, INamingContainer
    {
        private bool isDesignTime = false;
        DropDownList ctlNum1;
        TextBox ctlNum2;
        TextBox ctlNum3;
        PlaceHolder holder;
        private string num1 = "010";
        private string num2= "";
        private string num3= "";
        private telephoneType TeleType = telephoneType.이동전화;

        public UmcTelePhone()
        {
            if (this.Context == null)
                this.isDesignTime = true;
        }

        public enum telephoneType : short
        {
            이동전화 = 1,
            유선전화 = 2
        }

		/// <summary>
		/// 전화종류 : 이동전화, 유선전화
		/// </summary>
        [Category("Data")]
        public telephoneType TelephoneType
        {
            get { return TeleType; }
            set { this.TeleType = value; }
        }

		/// <summary>
		/// 지역번호 ( 첫번째 자리 )
		/// </summary>
        [Category("Data")]
        public string Num1
        {
            get { return this.num1; }
            set { this.num1 = value; }
        }

		/// <summary>
		/// 국번 ( 두번째 자리 )
		/// </summary>
        [Category("Data")]
        public string Num2
        {
            get { return this.num2; }
            set { this.num2 = value; }
        }

		/// <summary>
		/// 전화번호 ( 세번째 자리 )
		/// </summary>
        [Category("Data")]
        public string Num3
        {
            get { return this.num3; }
            set { this.num3 = value; }
        }

		/// <summary>
		/// 전체 전화번호
		/// '-' 구분기호가 포함된 전체 전화번호
		/// ex) 010-123-1234
		/// </summary>
        public string FullNum
        {
            get { return string.Format("{0}-{1}-{2}", this.Num1,this.Num2,this.Num3); }
            set
            {
                char[] sp = "-".ToCharArray();
                string[] temp;
                temp = value.Split(sp, 3);
                if (temp[0] == "010" || temp[0] == "011" || temp[0] == "016" || temp[0] == "019")
                    TeleType = telephoneType.이동전화;
                else
                    TeleType = telephoneType.유선전화;
                this.Num1 = temp[0];
                this.Num2 = temp[1];
                this.Num3 = temp[2];
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
            this.Num1 = state[0];
            this.Num2 = state[1];
            this.Num3 = state[2];
        }
        protected override object SaveViewState()
        {
            string[] state=new string[3];
            state[0] = this.Num1;
            state[1] = this.Num2;
            state[2] = this.Num3;

            return state;
        }

        protected override void CreateChildControls()
        {
            holder = new PlaceHolder();
            ctlNum1 = new DropDownList();
            ArrayList h = new ArrayList();
            if (TeleType == telephoneType.이동전화)
            {
                Num1 = this.Num1;
                h.Add("010");
                h.Add("011");
                h.Add("016");
                h.Add("019");
            }
            else
            {
                Num1 = this.Num1;
                h.Add("02");
                h.Add("031");
                h.Add("032");
                h.Add("033");
                h.Add("041");
                h.Add("042");
                h.Add("043");
                h.Add("051");
                h.Add("052");
                h.Add("053");
                h.Add("054");
                h.Add("055");
                h.Add("061");
                h.Add("062");
                h.Add("063");
                h.Add("064");
            }
            ctlNum1.DataSource = h;
            ctlNum1.DataBind();
            ctlNum1.SelectedIndexChanged+=new EventHandler(ctlNum1_SelectedIndexChanged);

            ctlNum2 = new TextBox();
            ctlNum2.Width = 40;
            ctlNum2.TextChanged+=new EventHandler(ctlNum2_TextChanged);
            ctlNum3 = new TextBox();
            ctlNum3.Width = 50;
            ctlNum3.TextChanged+=new EventHandler(ctlNum3_TextChanged);

            ctlNum1.SelectedValue = Num1;
            ctlNum2.Text = Num2;
            ctlNum3.Text = Num3;

            holder.Controls.Add(ctlNum1);
            holder.Controls.Add(new LiteralControl(" - "));
            holder.Controls.Add(ctlNum2);
            holder.Controls.Add(new LiteralControl(" - "));
            holder.Controls.Add(ctlNum3);
            this.Controls.Add(holder);
            this.ChildControlsCreated = true;
        }
        private void ctlNum1_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.Num1 = ctlNum1.SelectedItem.Text;
        }
        private void ctlNum2_TextChanged(object sender, EventArgs e)
        {
            this.Num2 = ctlNum2.Text;
        }
        private void ctlNum3_TextChanged(object sender, EventArgs e)
        {            
            this.Num3 = ctlNum3.Text;
        }
    }

	/// <summary>
	/// 디자인 타임 지원
	/// </summary>
    public class TelePhoneDesigner : ControlDesigner
    {
        public override string GetDesignTimeHtml()
        {
            UmcTelePhone olb = (UmcTelePhone)this.Component;
            olb.RenderAtDesignTime();

            return base.GetDesignTimeHtml();
        }
    }
}