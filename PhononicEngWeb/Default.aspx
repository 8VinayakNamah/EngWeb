<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="PhononicEngWeb._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">    
            
            <div class="form-row">
               <div class="form-group col-sm-4">
                   <div  style="padding-top:0.75rem">
                        <label for="txtItems">### Enter (Copy/Paste) Items to scrap</label>
                        <textarea class="form-control"  rows="5" cols="20" id="txtItems"></textarea>
                   </div>
                   <div>
                        <%--<label for="exampleFormControlTextarea1">### Example textarea</label>
                        <textarea class="form-control" id="exampleFormControlTextarea1" rows="4" cols="20">
                        </textarea>--%>

                        <label for="txtUser">### User Name</label>
                        <input class="form-text text-left" type="text" value="John Doe" id="txtUser" size="50"/> 
                   </div>
                </div>
                
                <div class="form-group col-sm-8">
                    <div style="padding-top:0.75rem;padding-bottom:0.75rem;">
                        <label for="exampleFormControlSelect2">### Item Detail </label>
                        <div style="height: 150px;overflow:auto;">
                        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CssClass="table table-striped table-bordered table-sm mb-0" >                        
                            <Columns>                            
                                <asp:BoundField DataField="author" HeaderText="Author"/>
                                <asp:BoundField DataField="title" HeaderText="Title"/>
                                <asp:BoundField DataField="genre" HeaderText="Genre"/>
                                <asp:BoundField DataField="price" HeaderText="Price"/>
                            </Columns>
                        </asp:GridView>
                        </div>

                        <div style="height: 150px;overflow:auto;padding-top:0.75rem;">
                            <label for="inputAddress">### Lot ID Summary </label>
                            <asp:GridView ID="GridView2" runat="server" CssClass="table table-striped table-bordered table-sm mb-0"></asp:GridView>
                        </div>
                    </div>                    
                </div>
            </div>   
           
             <div class="form-row h-25">
                <div class="form-group col-sm-4 h-25">
                    <div class="h-25">
                        <input type="submit" class="btn-small" value="Review"/>
                    </div>                                        
                </div>
                <div class="form-group col-sm-8 h-25">
                    <div class="h-25">
                        <input type="submit" class="btn-small" value="Commit" />
                        <input type="submit" class="btn-small" value="Clear" />
                    </div>
                </div>
            </div>
            <div class="form-row">
                <div class="form-group col-sm-4">                    
                    <asp:TextBox CssClass="form-control" ID="txtStatus1"  runat="server" TextMode="MultiLine" ></asp:TextBox>                    
                </div>
                <div class="form-group col-sm-8">
                    <asp:TextBox CssClass="form-control" ID="txtStatus2"  runat="server" TextMode="MultiLine" ></asp:TextBox>
                </div>
            </div>         

</asp:Content>
