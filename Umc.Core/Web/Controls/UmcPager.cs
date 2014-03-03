using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.Design;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.ComponentModel;
using System.ComponentModel.Design;

namespace Umc.Core.Web.Controls
{
	/// <summary>
	/// 소스제작 : 장현희님
	/// 주소 : http://bullog.net/
	/// 본 Pager 소스는 장현희님의 동의하에 엄준일이 배포하는 블로그 소스에 포함되었습니다.
	/// 본 Pager 소스에 대해 본인은 제작권을 가지고 있지 않음을 알려드립니다.
	/// 
	/// 수정자 : 엄준일
	/// </summary>
	[ToolboxData("<{0}:UmcPager runat=server></{0}:UmcPager>")]
	[Designer(typeof(UmcPagerDesigner), typeof(IDesigner))]
	public class UmcPager : WebControl, INamingContainer, IPostBackEventHandler {

		private bool isDesignTime = false;
		private int currentPage = 0;
		private int recordCount = -1;
		private int pageSize = 10;
		private int pageCount = 0;
		private int pagerBtnCount = 10;
		private int startAt = 0;
		private int endAt = 0;
		private PagerButtonType btnType = PagerButtonType.Numeric;
		private string prevBtnText = "[이전]";
		private string nextBtnText = "[다음]";
		private string prevBtnImgUrl = string.Empty;
		private string nextBtnImgUrl = string.Empty;

		public UmcPager() : base() {
			if (this.Context == null)
				this.isDesignTime = true;
		}

		public void RenderAtDesignTime() {
			if (this.isDesignTime) {
				this.Controls.Clear();

				string prevBtnCaption;
				string nextBtnCaption;

				if (this.prevBtnImgUrl != string.Empty)
					prevBtnCaption = string.Format("<img src=\"{0}\" border=\"0\" align=\"absmiddle\">",
						this.prevBtnImgUrl
						);
				else
					prevBtnCaption = this.prevBtnText;

				if (this.nextBtnImgUrl != string.Empty)
					nextBtnCaption = string.Format("<img src=\"{0}\" border=\"0\" align=\"absmiddle\">",
						this.nextBtnImgUrl
						);
				else
					nextBtnCaption = this.nextBtnText;

				string[] buttons = new string[this.pagerBtnCount + 2];

				if (this.btnType == PagerButtonType.Numeric) {
					for (int i=1;i<=this.pagerBtnCount;i++)
					{
						buttons[i] = string.Format(" {0} ", i);
					}
				}

				buttons[0] = prevBtnCaption;
				buttons[buttons.Length - 1] = nextBtnCaption;
				
				string result = string.Join(" ", buttons, 0, buttons.Length);
				this.Controls.Add(new LiteralControl(result));
			}
		}

		protected override void LoadViewState(object savedState) {
			int[] state = (int[])savedState;

			this.currentPage = state[0];
			this.recordCount = state[1];

			switch (state[2]) {
				case 1:
					this.btnType = PagerButtonType.PrevNext;
					break;
				case 2:
					this.btnType = PagerButtonType.Numeric;
					break;
			}
		}

		protected override object SaveViewState() 
		{
			int[] state = new int[3];

			state[0] = this.currentPage;
			state[1] = this.recordCount;
			state[2] = (int)this.btnType;

			return state;
		}
		

		private void CalculatePageData() {
			int pageCount = this.PageCount;

			if (this.btnType == PagerButtonType.PrevNext) {
				this.startAt = this.currentPage;
				this.endAt = this.currentPage;
			}
			else {
				this.startAt = (this.currentPage / this.pagerBtnCount) * this.pagerBtnCount;
				this.endAt = this.startAt + (this.pagerBtnCount - 1);

				if (this.endAt > pageCount - 1)
					this.endAt = pageCount - 1;
			}
		}

		protected override void Render(HtmlTextWriter writer) {
			if (this.isDesignTime) {
				base.Render(writer);
				return;
			}

			CalculatePageData();

			string prevBtnCaption;
			string nextBtnCaption;

			prevBtnCaption = (this.prevBtnImgUrl != string.Empty) ?
				string.Format("<img src=\"{0}\" border=\"0\" align=\"absmiddle\">", this.prevBtnImgUrl) :
				this.prevBtnText;

			nextBtnCaption = (this.nextBtnImgUrl != string.Empty) ?
				string.Format("<img src=\"{0}\" border=\"0\" align=\"absmiddle\">", this.nextBtnImgUrl) :
				this.nextBtnText;

			int prevIndex = 0;
			int nextIndex = 0;

			switch (this.btnType) {
				case PagerButtonType.PrevNext:
					if (this.currentPage > 0)
						prevIndex = this.currentPage - 1;

					if (this.currentPage < this.pageCount - 1)
						nextIndex = this.currentPage + 1;
					break;
				case PagerButtonType.Numeric:
					prevIndex = (this.startAt >= this.pagerBtnCount) ?
						this.startAt - this.pagerBtnCount :
						-1;
					nextIndex = (this.endAt < this.pageCount - 1) ?
						this.endAt + 1 :
						this.endAt;
					break;
			}

			if (this.startAt > 0)
				prevBtnCaption = string.Format("<a id=\"{0}\" href=\"javascript:{1}\">{2}</a>&nbsp;",
					this.UniqueID, Page.GetPostBackEventReference(this, prevIndex.ToString()),
					prevBtnCaption);
			else
				prevBtnCaption = "";
				//prevBtnCaption = string.Format("{0}&nbsp;", prevBtnCaption);

			writer.Write(prevBtnCaption);

			if (this.btnType == PagerButtonType.Numeric) {
				for (int i=this.startAt;i<=this.endAt;i++) {
					string btn = string.Empty;

					//if( i != this.startAt )
						btn = " | ";

					if (i != this.currentPage)
						btn += string.Format("<a id=\"{0}\" href=\"javascript:{1}\"> {2} </a>",
							this.UniqueID, Page.GetPostBackEventReference(this, i.ToString()), i + 1);
					else
						btn += string.Format("<b> {0} </b>", i + 1);
					writer.Write(btn);
				}
				writer.Write(" | ");
			}

			// 마지막 페이지가 아니라면  페이지 네비게이트 바에 보이도록...
			if( CurrentPageIndex < (PageCount-1)/10*10 )
			{
				int lastPage	= ( RecordCount / PageSize );
				writer.Write( string.Format("..<a id=\"{0}\" href=\"javascript:{1}\">[{2}]</a>", 
					this.UniqueID, 
					Page.GetPostBackEventReference( this, (lastPage-1).ToString()), 
					lastPage.ToString() ));
			}
			

			if (this.endAt < this.pageCount - 1)
				nextBtnCaption = string.Format("&nbsp;<a id=\"{0}\" href=\"javascript:{1}\">{2}</a>",
					this.UniqueID, Page.GetPostBackEventReference(this, (nextIndex).ToString()),
					nextBtnCaption);
			else
				nextBtnCaption = "";
			//	nextBtnCaption = string.Format("&nbsp;{0}", nextBtnCaption);
			writer.Write(nextBtnCaption);
		}

		#region IPostBackEventHandler 멤버

		public void RaisePostBackEvent(string eventArgument) {
			this.OnPageIndexChanged(new PageIndexChangedEventArgs(Convert.ToInt32(eventArgument)));
		}

		#endregion

		public event PageIndexChangedEventHandler PageIndexChanged;

		protected virtual void OnPageIndexChanged(PageIndexChangedEventArgs e) {
			if (this.PageIndexChanged != null) {
				this.currentPage = e.NewPageIndex;
				this.PageIndexChanged(this, e);
			}
		}

		[Category("Data")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
		[PersistenceMode(PersistenceMode.Attribute)]
		public int CurrentPageIndex {
			get {return this.currentPage;}
			set {this.currentPage = value;}
		}

		[Category("Data")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
		[PersistenceMode(PersistenceMode.Attribute)]
		public int RecordCount {
			get {return this.recordCount;}
			set {this.recordCount = value;}
		}

		[Category("Data")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
		[PersistenceMode(PersistenceMode.Attribute)]
		public int PageCount {
			get {
				this.pageCount = this.RecordCount / this.PageSize;

				if ((this.RecordCount % this.PageSize) > 0)
					this.pageCount++;
					
				return this.pageCount;
			}
		}

		[Category("Appearance")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
		[PersistenceMode(PersistenceMode.Attribute)]
		public int PageSize {
			get {return this.pageSize;}
			set {this.pageSize = value;}
		}

		[Category("Appearance")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
		[PersistenceMode(PersistenceMode.Attribute)]
		public int PagerButtonCount {
			get {return this.pagerBtnCount;}
			set {
				if ((value <= 0) ||
					(value > 30))
					this.pagerBtnCount = 10;
				else
					this.pagerBtnCount = value;
			}
		}

		[Category("Appearance")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
		[PersistenceMode(PersistenceMode.Attribute)]
		public PagerButtonType ButtonType {
			get {return this.btnType;}
			set {this.btnType = value;}
		}

		[Category("Appearance")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
		[PersistenceMode(PersistenceMode.Attribute)]
		public string PreviousButtonText {
			get {return this.prevBtnText;}
			set {
				if (value.ToString() != string.Empty)
					this.prevBtnText = value;
			}
		}

		[Category("Appearance")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
		[PersistenceMode(PersistenceMode.Attribute)]
		public string NextButtonText {
			get {return this.nextBtnText;}
			set {
				if (value.ToString() != string.Empty)
					this.nextBtnText = value;
			}
		}

		[Category("Appearance")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
		[PersistenceMode(PersistenceMode.Attribute)]
		public string PreviousButtomImageUrl {
			get {return this.prevBtnImgUrl;}
			set {this.prevBtnImgUrl = value;}
		}

		[Category("Appearance")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
		[PersistenceMode(PersistenceMode.Attribute)]
		public string NextButtonImageUrl {
			get {return this.nextBtnImgUrl;}
			set {this.nextBtnImgUrl = value;}
		}
	}

	public enum PagerButtonType : short {
		PrevNext = 1,
		Numeric = 2
	}


	public delegate void PageIndexChangedEventHandler(object sender, PageIndexChangedEventArgs e);

	public class PageIndexChangedEventArgs : EventArgs {
		private int newPageIndex = 0;

		public PageIndexChangedEventArgs(int newPage) {
			this.newPageIndex = newPage;
		}

		public int NewPageIndex {
			get {return this.newPageIndex;}
		}
	}
}