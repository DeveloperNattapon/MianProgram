<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="UserProject.aspx.vb" Inherits="MainProgram.UserProject" MasterPageFile="~/Site1.Master" EnableEventValidation="false" EnableViewState="true"%>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

 <form id="form1" runat="server">
   <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
     <section class="content-header">
        <h1>
            User Profile
        </h1>
        <ol class="breadcrumb">
           <li><a href="UserProject.aspx"><i class="fa fa-home"></i>Home</a></li>  
            <li class="active">Proflie</li>
        </ol>
    </section>
    
          <!-- Main content -->
    <section class="content">

        <div class="row">
             <div class="col-md-3">

          <!-- Profile Image -->
          <div class="box box-primary">
            <div class="box-body box-profile">
              <img class="profile-user-img img-responsive img-circle" src="Images/textus.png" alt="User profile picture"/>

              <h3 class="profile-username text-center" id="txtprofilename" runat="server" ></h3>
                <%--<input class="form-control" id="Text1" runat="server" placeholder="User ID" disabled="disabled"/>--%>
              <p class="text-muted text-center" id="txtdeptname" runat="server"></p>           

              <%--<ul class="list-group list-group-unbordered">
                <li class="list-group-item">
                  <b>Followers</b> <a class="pull-right">1,322</a>
                </li>
                <li class="list-group-item">
                  <b>Following</b> <a class="pull-right">543</a>
                </li>
                <li class="list-group-item">
                  <b>Friends</b> <a class="pull-right">13,287</a>
                </li>
              </ul>

              <a href="#" class="btn btn-primary btn-block"><b>Follow</b></a>--%>
              
            </div>
            <!-- /.box-body -->
          </div>
          <!-- /.box -->

        
        </div>
        <!-- /.col -->
            <!-- left column -->
            <div class="col-lg-9 col-md-9 ">
                
                <!-- general form elements -->
                <div class="box box-primary">
                    <div class="box-header with-border">
                        <h3 class="box-title">Personal Profile</h3>
                        <div class="text-right">
                             <button type="submit" runat="server" class="btn btn-primary" id="btnEdit" title="btnEdit" onserverclick="btnEdit_ServerClick"><i class="fa fa-edit"></i> Edit</button>
                        </div>
                       
                    </div>
                    <!-- /.box-header -->
                    <div class="row">

                        <form class="form-horizontal">
                            <div class="col-lg-8 col-md-8 col-md-offset-2">
                                 <div class="box-body">   
                                            
                               <div class="form-group">
                    <div class="col-xs-12">
                        <label class="control-label " for="txtUserId">UserId</label>
                        <div class="controls ">
                            <input class="form-control" id="txtUser" runat="server" required="required" type="text" disabled="disabled"/>
                        </div>
                       
                    </div>



                    <div class="col-xs-3">
                        <label class="control-label" for="txtPrefix_thai">คำนำหน้า</label>
                        <div class="controls ">
                            <input class="form-control" runat="server" id="txtPrefix" type="text" />
                          
                        </div>

                        <label class="control-label" for="ddlPrefix_Eng">Name Title</label>
                        <div class="controls ">
                            <input class="form-control" id="txtPrefix_Eng" runat="server" type="text" />
                     
                        </div>
                    </div>



                    <div class="col-xs-5">

                        <label class="control-label" for="txtName_thai">ชื่อ-ไทย</label>
                        <div class="controls ">
                            <input class="form-control" id="txtNameThai" required="required" runat="server" type="text" />
                        </div>

                        <label class="control-label" for="txtName_eng">First name</label>
                        <div class="controls ">
                            <input class="form-control" id="txtNameEng" runat="server" type="text" />
                        </div>

                    </div>
                    <div class="col-xs-4">

                        <label class="control-label" for="txtSurname_thai">นามสกุล</label>
                        <div class="controls ">
                            <input class="form-control" id="txtSurnameThai" required="required" runat="server" type="text" />
                        </div>

                        <label class="control-label" for="txtSurname_eng">Surname</label>
                        <div class="controls">
                            <input class="form-control" id="txtSurnameEng"  runat="server" type="text" />
                        </div>

                    </div>
                    <div class="col-xs-12">
                        <label class="control-label" for="txtEmail">อีเมล</label>
                        <div class="controls ">
                            <input class="form-control" id="txtEmaile" runat="server" type="text" />
                        </div>

                        <label class="control-label" for="ddlBranch">สาขา</label>
                        <div class="controls">
                            <input class="form-control" id="txtBranch" runat="server" type="text" />
                          </div>
                        <label class="control-label" for="txtDept">ฝ่าย</label>
                        <div class="controls ">
                              <input class="form-control" id="txtSection" runat="server" type="text" />
                        </div>

                        <label class="control-label" for="txtDept">แผนก</label>
                        <div class="controls ">
                             <input class="form-control" id="txtDept" runat="server" type="text" />
                  
                        </div>

                        <label class="control-label" for="txtPosition">ตำแหน่ง</label>
                        <div class="controls ">
                            <input class="form-control" id="txtPosition" runat="server" type="text" />
                  
                         </div>
                        <%--<div class="col-xs-12">--%>
                        <label class="control-label" for="lbApprove1">ผู้อนุมัติ 1</label>
                        <div class="controls ">
                            <input class="form-control" id="lbApprove1" required="required" runat="server" type="text" disabled="disabled" />
                        </div>
                    <%--    </div>--%>

                        <%--<div class="col-xs-6">--%>
                        <label class="control-label" for="lbApprove2">ผู้อนุมัติ 2</label>
                        <div class="controls ">
                            <input class="form-control" id="lbApprove2" required="required" runat="server" type="text" disabled="disabled" />
                        </div>
                   <%--     </div>--%>

                        <label class="control-label" for="txtPosition">สถานะ</label>
                        <div class="controls ">
                             <input class="form-control" id="txtStatus" required="required" runat="server" type="text" disabled="disabled" />
                            
                        </div>

                    </div>
                </div>

                   
                </div>
                            </div>
                       </form>

                            <!--/.row-->
                        </div>


                        <!--/.row-->
                    </div>

                    <!--/.box box-primary-->
                </div>
                <!--/.col-lg-12 -->
            </div>

            <!--/.col (right) -->

            <!-- /.row -->
        </section>
        <!-- /.content -->
</form>
 </asp:Content>