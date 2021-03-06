﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddMisModel.aspx.cs" Inherits="ZoomLaCMS.Manage.WorkFlow.AddMisModel"  MasterPageFile="~/Manage/I/Default.master" ValidateRequest="false" %>
<asp:Content runat="server" ContentPlaceHolderID="head">
    <title>套红管理</title>
    <script type="text/javascript" charset="utf-8" src="/Plugins/Ueditor/ueditor.config.js"></script>
    <script type="text/javascript" charset="utf-8" src="/Plugins/Ueditor/ueditor.all.min.js"></script>
</asp:Content>
<asp:Content runat="server" ContentPlaceHolderID="Content">
    <div>
        <table class="table table-striped table-bordered table-hover">
            <tr>
                <td class="td_m">模板名称:</td>
                <td>
                    <asp:TextBox ID="ModelName" CssClass=" form-control text_300" runat="server"></asp:TextBox>
                    <span style="color: #f00">*</span>
                    <asp:RequiredFieldValidator ID="r1" ControlToValidate="ModelName" runat="server" ErrorMessage="名称不能为空" ForeColor="Red"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr class="tdbg">
                <td>模板类型:</td>
                <td>
                    <asp:DropDownList runat="server" ID="DocType_DP" CssClass="form-control text_300">
                        <asp:ListItem Value="0">公文</asp:ListItem>
                        <asp:ListItem Value="1">事务</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>绑定节点:</td>
                <td>
                    <asp:TextBox runat="server" ID="bindNodeT" CssClass="form-control text_300" /><span><span class="rd_green">(选填)</span></span>
                </td>
            </tr>
            <tr>
                <td>Word套红:</td>
                <td>
                    <asp:TextBox runat="server" ID="WordUP_T" CssClass="form-control text_300" placeholder="上传或直接填入模板"></asp:TextBox>
                    <span class="rd_green">请上传doc或docx文件</span>
                    <div class="margin_t5">
                        <ZL:FileUpload runat="server" ID="Word_UP" AllowExt="doc,docx" CssClass="form-control text_300" Style="display: inline-block;" />
                        <asp:Button runat="server" ID="WordUP_Btn" OnClick="WordUP_Btn_Click" Text="上传" CssClass="btn btn-info" />
                    </div>
                </td>
            </tr>
            <tr runat="server" visible="false">
                <td colspan="2" style="height: auto;">
                    <asp:TextBox ID="ModelContent" Style="min-height: 500px;" TextMode="MultiLine" runat="server" Width="815"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td></td>
                <td>
                    <asp:Button ID="BtnSav" runat="server" CssClass="btn btn-primary" OnClick="BtnSav_Click" Text="保存信息" />
                    <button type="button" class="btn btn-primary" onclick="location='MisModelManage.aspx'">返回列表</button>
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
