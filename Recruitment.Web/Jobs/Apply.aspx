<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Apply.aspx.cs" Inherits="Recruitment.Web.Apply" %>

<%@ Register Assembly="DevExpress.Web.v16.2, Version=16.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Xpo.v16.2, Version=16.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Xpo" TagPrefix="dx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder_Header" runat="server">
    <script type="text/javascript">
        var uploadInProgress = false,
            submitInitiated = false,
            uploadErrorOccurred = false;
            uploadedFiles = [];
        function onFileUploadComplete(s, e) {
            var callbackData = e.callbackData.split("|"),
                uploadedFileName = callbackData[0],
                isSubmissionExpired = callbackData[1] === "True";
            uploadedFiles.push(uploadedFileName);
            if(e.errorText.length > 0 || !e.isValid)
                uploadErrorOccurred = true;
            if(isSubmissionExpired && UploadedFilesTokenBox.GetText().length > 0) {
                var removedAfterTimeoutFiles = UploadedFilesTokenBox.GetTokenCollection().join("\n");
                alert("The following files have been removed from the server due to the defined 5 minute timeout: \n\n" + removedAfterTimeoutFiles);
                UploadedFilesTokenBox.ClearTokenCollection();
            }
        }
        function onFileUploadStart(s, e) {
            uploadInProgress = true;
            uploadErrorOccurred = false;
            UploadedFilesTokenBox.SetIsValid(true);
        }
        function onFilesUploadComplete(s, e) {
            uploadInProgress = false;
            for(var i = 0; i < uploadedFiles.length; i++)
                UploadedFilesTokenBox.AddToken(uploadedFiles[i]);
            updateTokenBoxVisibility();
            uploadedFiles = [];
            if(submitInitiated) {
                SubmitButton.SetEnabled(true);
                SubmitButton.DoClick();
            }
        }
        function onSubmitButtonInit(s, e) {
            s.SetEnabled(true);
        }
        function onSubmitButtonClick(s, e) {
            ASPxClientEdit.ValidateGroup();
            if(!formIsValid())
                e.processOnServer = false;
            else if(uploadInProgress) {
                s.SetEnabled(false);
                submitInitiated = true;
                e.processOnServer = false;
            }
        }
        function onTokenBoxValidation(s, e) {
            var isValid = DocumentsUploadControl.GetText().length > 0 || UploadedFilesTokenBox.GetText().length > 0;
            e.isValid = isValid;
            if(!isValid) {
                e.errorText = "No files have been uploaded. Upload at least one file.";
            }
        }
        function onTokenBoxValueChanged(s, e) {
            updateTokenBoxVisibility();
        }
        function updateTokenBoxVisibility() {
            var isTokenBoxVisible = UploadedFilesTokenBox.GetTokenCollection().length > 0;
            UploadedFilesTokenBox.SetVisible(isTokenBoxVisible);
        }
        function formIsValid() {
            return !ValidationSummary.IsVisible() && DescriptionTextBox.GetIsValid() && UploadedFilesTokenBox.GetIsValid() && !uploadErrorOccurred;
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder_Body" runat="server">
    <br />
    <br />
    <br />

    <div class="container container-fluid">
        <div class="row">
            <div class="col-md-12">
                <table>
                    <tr class="thumbnail">
                        <td class="col-sm-1 col-lg-1 col-md-1">
                            <dx:ASPxBinaryImage ID="jp_image" runat="server" />
                        </td>
                        <td class="col-sm-2 col-lg-2 col-md-2 caption">
                            <h4><a id="title" href="#"></a></h4>
                            <p>
                                <span class="fa fa-calendar"></span>
                                <label runat="server" id="jp_date_start"></label>
                                <span class="fa fa-industry"></span>
                                <label runat="server" id="industry_name"></label>
                                <span class="fa fa-users"></span>
                                <label runat="server" id="jp_view_count"></label>
                            </p>
                            <p runat="server" id="jp_content" />
                            <br />
                        </td>

                    </tr>

                </table>
            </div>
        </div>
        <h1><i class="fa fa-address-card" aria-hidden="true"></i> Apply Information</h1>
        <br />
        <div class="input-group">
            <span class="input-group-addon" id="basic-addon1"><span class="fa fa-user"></span></span>
            <input type="text" class="form-control" placeholder="Your name" aria-describedby="basic-addon1">
        </div>
        <br />
        <div class="input-group">
            <span class="input-group-addon" id="basic-addon1"><span class="fa fa-male"></span><span class="fa fa-female"></span></span>
            <dx:ASPxComboBox runat="server" ID="ASPxComboBoxGender" ClientInstanceName="ASPxComboBoxGender"
                DataSourceID="XpoDSGender" TextField="rec_gender_name" ValueField="rec_gender_id" ValueType="System.Int32"
                Height="100%" NullText="Your gender" CssClass="form-control" Theme="Moderno">
            </dx:ASPxComboBox>
        </div>
        <br />
         <div class="input-group">
            <span class="input-group-addon" id="basic-addon1"><span class="fa fa-globe"></span></span>
            <dx:ASPxComboBox runat="server" ID="ASPxComboBoxNationality" ClientInstanceName="ASPxComboBoxNationality"
                DataSourceID="XpoDSNationality" TextField="nationality_name" ValueField="nationality_id" ValueType="System.Int32"
                Height="100%" NullText="Your nationality" CssClass="form-control" Theme="Moderno">
            </dx:ASPxComboBox>
        </div>
        <br />
        <div class="input-group">
            <span class="input-group-addon" id="basic-addon1"><span class="fa fa-mobile"></span></span>
            <input type="text" class="form-control" placeholder="Your mobile" aria-describedby="basic-addon1">
        </div>
        <br />
        <div class="input-group">
            <span class="input-group-addon" id="basic-addon1"><span class="fa fa-file-word-o"></span></span>
            <dx:ASPxUploadControl ID="ASPxUploadControlCV" runat="server" CssClass="form-control" BrowseButtonStyle-CssClass="input-group-addon" Height="100%" Width="100%" ClientInstanceName="DocumentsUploadControl" 
                AdvancedModeSettings-EnableMultiSelect="True" ShowProgressPanel="True" Theme="Moderno" AutoStartUpload="True" UploadMode="Auto" NullText="Your CV File" ToolTip="Please select your CV document to send it."
                FileUploadMode="OnPageLoad" OnFileUploadComplete="DocumentsUploadControl_FileUploadComplete">
                <ValidationSettings AllowedFileExtensions=".doc, .docm, .docx, .docx, .pdf, .zip, .rar, .7z" MaxFileCount="1" MaxFileSize="4194304">
                </ValidationSettings>
                <BrowseButton Text="Browse CV...">
                </BrowseButton>
                <AdvancedModeSettings DropZoneText="Drop file here">
                </AdvancedModeSettings>
                <BrowseButtonStyle CssClass="input-group-addon">
                </BrowseButtonStyle>
                 <ClientSideEvents FileUploadComplete="onFileUploadComplete" FilesUploadComplete="onFilesUploadComplete" FilesUploadStart="onFileUploadStart" />
            </dx:ASPxUploadControl>
             <dx:ASPxTokenBox runat="server" Width="100%" ID="UploadedFilesTokenBox" ClientInstanceName="UploadedFilesTokenBox"
                                                NullText="Select the documents to submit" AllowCustomTokens="false" ClientVisible="false">
                                                <ClientSideEvents Init="updateTokenBoxVisibility" ValueChanged="onTokenBoxValueChanged" Validation="onTokenBoxValidation" />
                                                <ValidationSettings EnableCustomValidation="true"></ValidationSettings>
                                            </dx:ASPxTokenBox>
        </div>
<dx:ASPxValidationSummary runat="server" ID="ValidationSummary" ClientInstanceName="ValidationSummary"
                                                RenderMode="Table" Width="250px" ShowErrorAsLink="false">
                                            </dx:ASPxValidationSummary>
        <br/>
        <button type="submit" class="btn label-success btn-default btn-lg">Apply <span class="glyphicon glyphicon-ok"></span>   </button>
         <dx:ASPxButton runat="server" ID="SubmitButton" ClientInstanceName="SubmitButton" CssClass="btn label-success btn-default btn-lg" Text="Apply" AutoPostBack="False"
                                    OnClick="SubmitButton_Click" ValidateInvisibleEditors="true" ClientEnabled="false" Theme="Moderno">
                                    <ClientSideEvents
                                        Init="onSubmitButtonInit" Click="onSubmitButtonClick" />
                                </dx:ASPxButton>
    </div>
    <dx:XpoDataSource ID="XpoDSGender" runat="server"
        TypeName="Recruitment.Module.BusinessObjects.Recruitment.rec_Gender">
    </dx:XpoDataSource>
    <dx:XpoDataSource ID="XpoDSNationality" runat="server"
        TypeName="Recruitment.Module.BusinessObjects.Recruitment.rec_Nationality">
    </dx:XpoDataSource>
</asp:Content>
