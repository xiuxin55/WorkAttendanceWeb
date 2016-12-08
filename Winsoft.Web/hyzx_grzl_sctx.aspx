<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="hyzx_grzl_sctx.aspx.cs" Inherits="Winsoft.Web.hyzx_grzl_sctx" %>

<%@ Register src="~/top.ascx" tagname="top" tagprefix="uc1" %>
<%@ Register src="~/left.ascx" tagname="left" tagprefix="uc1" %>
<%@ Register src="~/foot.ascx" tagname="foot" tagprefix="uc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>逗留网</title>
    <link href="css/style.css"  rel="stylesheet"/>
    <link href="css/body.css"  rel="stylesheet"/>
    <link href="css/page.css"  rel="stylesheet"/>
    <link href="css/main.css" rel="stylesheet" type="text/css" />
    <script src="js/jquery1.3.2.min.js" type="text/javascript"></script>
    <script src="js/jquery.easydrag.js" type="text/javascript"></script>
    <script src="js/CutPic.js" type="text/javascript"></script>
    <script type="text/javascript">
    function Step1() {
        $("#Step2Container").hide();
    }
    function Step2() {
        $("#CurruntPicContainer").hide();
    }
    function Step3() {
        $("#Step2Container").hide();
    }
    </script> 
</head>

<body>
<form id="form1" runat="server">
<uc1:top ID="top1" runat="server" />
<div class="dlp_ttl">
    	<a href="index.aspx">首页</a>&nbsp;>&nbsp;<a href="hyzx.aspx">会员中心</a>
</div>
<div class="dlp_main">
	<uc1:left ID="left1" runat="server" />
    <div class="dlm_fwzx_right">
    	<div class="dfr_ttl"><b>&nbsp;&nbsp;&nbsp;&nbsp;上传头像</b></div>   
        <div class="dfr_con">
        	<div class="dfrc_grzl">
            	<div class="tjyh">
  <div class="xx">
     <div class="left">
         <!--当前照片-->
         <div id="CurruntPicContainer">
            <div class="title"><b>当前照片</b></div>
            <div class="photocontainer">
                <asp:Image ID="imgphoto" runat="server" ImageUrl="~/images/tx.png" />
            </div>
         </div>
         <!--Step 2-->
         <div id="Step2Container">
           <div class="title"><b> 裁切头像照片</b></div>
           <div class="uploadtooltip">您可以拖动照片以裁剪满意的头像</div>   
            <div id="Canvas" class="uploaddiv">
                                        <table id="Crop" cellpadding="0" cellspacing="0" border="0" > 
                                        <tr> 
                                                <td style="height: 73px" colspan="3" class="Overlay"></td> 
                                        </tr> 
                                        <tr> 
                                                <td style="width: 82px" class="Overlay"></td> 
                                                <td style="width: 120px; height: 120px; border-width: 1px; border-style: solid; border-color: white;"></td> 
                                                <td style="width: 82px" class="Overlay"></td> 
                                        </tr> 
                                        <tr> 
                                                <td style="height: 73px" colspan="3" class="Overlay"></td> 
                                        </tr> 
                                        </table> 
                                        <div style="position:relative;top:0px;left:0px;" id="IconContainer"> 
                                            <asp:Image ID="ImageIcon"   runat="server" ImageUrl="~/image/blank.jpg" CssClass="imagePhoto" ToolTip=""/>                                        
                                        </div> 
                   </div>                            
                    <div class="uploaddiv">
                       <table>
                            <tr>
                                <td id="Min">
                                        <img alt="缩小" src="image/_c.gif" onmouseover="this.src='image/_c.gif';" onmouseout="this.src='image/_h.gif';" id="moresmall" class="smallbig" />
                                </td>
                                <td>
                                    <div id="bar">
                                        <div id="barchild" class="child">
                                        </div>
                                    </div>
                                </td>
                                <td id="Max">
                                        <img alt="放大" src="image/c.gif" onmouseover="this.src='image/c.gif';" onmouseout="this.src='image/h.gif';" id="morebig" class="smallbig" />
                                </td>
                            </tr>
                        </table>
                    </div>
                    <div class="uploaddiv">
                        <asp:Button ID="btn_Image" runat="server" Text="保存头像" OnClick="btn_Image_Click" />
                    </div>           
                    <div style=" display:none;">
                    图片实际宽度： <asp:TextBox ID="txt_width" runat="server" Text="1" ></asp:TextBox><br />
                    图片实际高度： <asp:TextBox ID="txt_height" runat="server" Text="1" ></asp:TextBox><br />
                    距离顶部： <asp:TextBox ID="txt_top" runat="server"  Text="82"></asp:TextBox><br />
                    距离左边： <asp:TextBox ID="txt_left" runat="server" Text="73"></asp:TextBox><br />
                    截取框的宽：<asp:TextBox ID="txt_DropWidth" runat="server"  Text="120"></asp:TextBox><br />
                    截取框的高：<asp:TextBox ID="txt_DropHeight" runat="server" Text="120"></asp:TextBox><br />
                    放大倍数： <asp:TextBox ID="txt_Zoom" runat="server" ></asp:TextBox>
                   </div>
         </div>
     </div>
     <div class="right">
         <!--Step 1-->
         <div id="Step1Container">
            <div class="title"><h>更换照片</h></div>
            <div id="uploadcontainer">
                <div class="uploadtooltip">请选择新的照片文件，文件需小于2.5MB</div>
                <div class="uploaddiv"><asp:FileUpload ID="fuPhoto"  runat="server" ToolTip="选择照片"/></div>
                <div class="uploaddiv"><asp:Button ID="btnUpload" runat="server" Text="上 传" onclick="btnUpload_Click" />
                </div>
            </div>         
         </div>
    </div>    
  </div>
  </div>

</div>
        </div>
    </div>
</div>
<div style="width:100%; overflow:hidden; clear:both;"></div>
<uc1:foot ID="foot1" runat="server" />
</form>
</body>
</html>
