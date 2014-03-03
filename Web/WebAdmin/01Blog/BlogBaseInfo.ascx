<%@ Control Language="C#" AutoEventWireup="true" CodeFile="BlogBaseInfo.ascx.cs" Inherits="WebAdmin_01Blog_BlogBaseInfo" %>
<table width="100%">
	<tr>
		<td colspan="2" class="tb_topline"></td>
	</tr>
	<tr>
		<td class="tb_title" style="width:100px;">블로그 제목</td>
		<td class="tb_content"><asp:TextBox ID="txtTitle" runat="server" CssClass="input_text" Width="250px"></asp:TextBox></td>
	</tr>
	<tr>
		<td colspan="2" class="tb_line"></td>
	</tr>
	<tr>
		<td class="tb_title" style="height: 26px">블로그 주소</td>
		<td class="tb_content" style="height: 26px"><asp:TextBox ID="txtUrl" runat="server" CssClass="input_text" Width="250px"></asp:TextBox></td>
	</tr>
	<tr>
		<td class="tb_line" colspan="2"></td>
	</tr>
		<tr>
			<td class="tb_title">이메일</td>
			<td class="tb_content"><asp:TextBox ID="txtEmail" runat="server" Width="250px" CssClass="input_text"></asp:TextBox></td>
		</tr>
	<tr>
		<td class="tb_line" colspan="2"></td>
	</tr>
	<tr style="height:30px;">
		<td colspan="2"></td>
	</tr>
	<tr>
		<td class="tb_line" colspan="2"></td>
	</tr>
	<tr>
		<td class="tb_title">내 사진</td>
		<td class="tb_content">
			<asp:Label ID="lblMyPicture" runat="server" EnableViewState="false"></asp:Label>
			<a href="javascript:popupMyPicture('<%= CurrentSitemapInfo.ID %>');">
				<img src="/common/images/btn_regist.gif" alt="사진등록" />
			</a>
		</td>
	</tr>
	<tr>
		<td class="tb_line" colspan="2"></td>
	</tr>
	<tr>
		<td class="tb_title">이름</td>
		<td class="tb_content"><asp:TextBox ID="txtName" runat="server" CssClass="input_text" Width="214px"></asp:TextBox></td>
	</tr>
	<tr>
		<td class="tb_line" colspan="2"></td>
	</tr>
	<tr>
		<td class="tb_title">별명</td>
		<td class="tb_content"><asp:TextBox ID="txtNickName" runat="server" CssClass="input_text" Width="214px"></asp:TextBox></td>
	</tr>
	<tr>
		<td class="tb_line" colspan="2"></td>
	</tr>
	<tr>
		<td class="tb_title">소개</td>
		<td class="tb_content"><asp:TextBox ID="txtIntroduction" runat="server" CssClass="input_text" TextMode="MultiLine" Width="100%"></asp:TextBox></td>
	</tr>
	<tr>
		<td class="tb_line" colspan="2"></td>
	</tr>
	<tr>
		<td class="tb_title">주소</td>
		<td class="tb_content">
			<asp:DropDownList ID="ddlAddress" runat="server" CssClass="input_text" Width="110px">
				<asp:ListItem Text="서울시"></asp:ListItem>
				<asp:ListItem Text="부산시"></asp:ListItem>
				<asp:ListItem Text="인천시"></asp:ListItem>
				<asp:ListItem Text="대전시"></asp:ListItem>
				<asp:ListItem Text="대구시"></asp:ListItem>
				<asp:ListItem Text="광주시"></asp:ListItem>
				<asp:ListItem Text="울산시"></asp:ListItem>
				<asp:ListItem Text="경기"></asp:ListItem>
				<asp:ListItem Text="강원"></asp:ListItem>
				<asp:ListItem Text="충북"></asp:ListItem>
				<asp:ListItem Text="충남"></asp:ListItem>
				<asp:ListItem Text="경북"></asp:ListItem>
				<asp:ListItem Text="경남"></asp:ListItem>
				<asp:ListItem Text="전북"></asp:ListItem>
				<asp:ListItem Text="전남"></asp:ListItem>
				<asp:ListItem Text="제주"></asp:ListItem>
				<asp:ListItem Text="해외"></asp:ListItem>
			</asp:DropDownList>
		</td>
	</tr>
	<tr>
		<td class="tb_line" colspan="2"></td>
	</tr>
	<tr>
		<td class="tb_title">취미</td>
		<td class="tb_content"><asp:TextBox ID="txtHobby" runat="server" CssClass="input_text" Width="214px"></asp:TextBox></td>
	</tr>
	<tr>
		<td class="tb_line" colspan="2"></td>
	</tr>
	<tr>
		<td class="tb_title">성별</td>
		<td class="tb_content">
			<asp:DropDownList ID="ddlGender" runat="server" CssClass="input_text" Width="110px">
				<asp:ListItem Text="남자" Value="Man"></asp:ListItem>
				<asp:ListItem Text="여자" Value="Woman"></asp:ListItem>
			</asp:DropDownList>
		</td>
	</tr>
	<tr>
		<td class="tb_line" colspan="2"></td>
	</tr>
	<tr style="height:30px;">
		<td colspan="2"></td>
	</tr>
	<tr>
		<td class="tb_line" colspan="2"></td>
	</tr>
	<tr>
		<td class="tb_title">알림 메일</td>
		<td class="tb_content">
			<asp:RadioButtonList ID="rblAlram" runat="server" RepeatDirection="Horizontal" Width="175px">
				<asp:ListItem Text="예" Value="True"></asp:ListItem>
				<asp:ListItem Text="아니오" Value="False"></asp:ListItem>
			</asp:RadioButtonList>
			※ 덧글 또는 새로운 게시물이 등록되면 이메일로 알려줍니다.</td>
	</tr>
	<tr>
		<td class="tb_line" colspan="2"></td>
	</tr>
	<tr>
		<td class="tb_title">자동 클립 복사</td>
		<td class="tb_content">
			<asp:RadioButtonList ID="rblAutoClip" runat="server" RepeatDirection="Horizontal" Width="175px">
				<asp:ListItem Text="예" Value="True"></asp:ListItem>
				<asp:ListItem Text="아니오" Value="False"></asp:ListItem>
			</asp:RadioButtonList><p class="gray03" style="margin: 6px 0px 0px">
				※ 포스트 입력내용을 자동으로 클립보드에 복사합니다.
			</p>
		</td>
	</tr>
	<tr>
		<td class="tb_line" colspan="2"></td>
	</tr>
	<tr>
		<td class="tb_title">페이지당 포스트</td>
		<td class="tb_content">
			<asp:RadioButtonList ID="rblPostCount" runat="server" RepeatDirection="Horizontal" Width="318px">
				<asp:ListItem Value="1" Text="1개"></asp:ListItem>
				<asp:ListItem Value="3" Text="3개"></asp:ListItem>
				<asp:ListItem Value="5" Text="5개"></asp:ListItem>
				<asp:ListItem Value="10" Text="10개"></asp:ListItem>
			</asp:RadioButtonList>
		</td>
	</tr>
	<tr>
		<td class="tb_line" colspan="2"></td>
	</tr>
	<tr>
		<td class="tb_title">최신 댓글 리스트 갯수</td>
		<td class="tb_content">
			<asp:RadioButtonList ID="rblRecentComment" runat="server" RepeatDirection="Horizontal" Width="318px">
				<asp:ListItem Value="3" Text="3개"></asp:ListItem>
				<asp:ListItem Value="5" Text="5개"></asp:ListItem>
				<asp:ListItem Value="10" Text="10개"></asp:ListItem>
				<asp:ListItem Value="15" Text="15개"></asp:ListItem>
			</asp:RadioButtonList>
		</td>
	</tr>
	<tr>
		<td class="tb_line" colspan="2"></td>
	</tr>
	<tr>
		<td class="tb_title">최신 아티클 리스트 갯수</td>
		<td class="tb_content">
			<asp:RadioButtonList ID="rblRecentArticleCount" runat="server" RepeatDirection="Horizontal" Width="318px">
				<asp:ListItem Value="3" Text="3개"></asp:ListItem>
				<asp:ListItem Value="5" Text="5개"></asp:ListItem>
				<asp:ListItem Value="10" Text="10개"></asp:ListItem>
				<asp:ListItem Value="15" Text="15개"></asp:ListItem>
			</asp:RadioButtonList>
		</td>
	</tr>
	<tr>
		<td class="tb_line" colspan="2"></td>
	</tr>
	<tr>
		<td class="tb_title">이모티콘 사용</td>
		<td class="tb_content">
			<asp:RadioButtonList ID="rblUseEmoticon" runat="server" RepeatDirection="Horizontal" Width="200px">
				<asp:ListItem Value="True" Selected>사용</asp:ListItem>
				<asp:ListItem Value="False">사용 안함</asp:ListItem>
			</asp:RadioButtonList>
		</td>
	</tr>
	<tr>
		<td class="tb_line" colspan="2"></td>
	</tr>
	<tr>
		<td class="tb_title">New Icon 보이는 기간</td>
		<td class="tb_content">
			<asp:DropDownList ID="ddlNewIcon" runat="server">
				<asp:ListItem Value="1">1</asp:ListItem>
				<asp:ListItem Value="2">2</asp:ListItem>
				<asp:ListItem Value="3">3</asp:ListItem>
				<asp:ListItem Value="4">4</asp:ListItem>
				<asp:ListItem Value="5">5</asp:ListItem>
				<asp:ListItem Value="6">6</asp:ListItem>
				<asp:ListItem Value="7">7</asp:ListItem>
			</asp:DropDownList> 일
		</td>
	</tr>
	<tr>
		<td class="tb_line" colspan="2"></td>
	</tr>
</table>
<br />
<table width="100%">
	<tr>
		<td align="right">
					<asp:LinkButton ID="lnkRegister" runat="server" OnClick="lnkRegister_Click" >
						<img src="/Common/Images/btn_regist.gif" alt="등록" />
					</asp:LinkButton>
		</td>
	</tr>
</table>