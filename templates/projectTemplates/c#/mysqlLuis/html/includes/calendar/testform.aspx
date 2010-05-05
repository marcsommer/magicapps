<%@ Page Language="VB" %>
<script runat="server">

    Sub Button_Action(Sender as object, e as eventargs)
    
    app_message.innerhtml = "Start Date is " & TextBox1.text & "<BR>" & "End Date is " & Textbox2.text
    
    
    End Sub

</script>
<html>
<head>
    <TITLE>Popup Calendar Example</TITLE> <script language="javascript" src="script.js" type="text/javascript"></script>
</head>
<body>
    <form id="testform" runat="server">
        
            Enter Start Date<asp:TextBox id="TextBox1" runat="server"></asp:TextBox>
            <a href="javascript:OpenCalendar('TextBox1', false)"><img height="16" src="icon-calendar.gif"    /></a> 
        
        
            Enter End Date<asp:TextBox id="TextBox2" runat="server"></asp:TextBox>
            <a href="javascript:OpenCalendar('TextBox2', false)"><img height="16" src="icon-calendar.gif"    /></a> 
        
        
            <asp:Button id="Button1" onclick="Button_Action" runat="server" Text="Submit"></asp:Button>
        
        <div id="app_message" runat="server">
        </div>
    </form>
</body>
</html>
