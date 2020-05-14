namespace TryLog.Services.Email
{
    public static class Messages
    {
        /// <summary>
        /// Ordem dos paramentros:
        /// Email, newPassword, Created
        /// </summary>
        public static string PasswordChangeConfirmation = 
        "<table cellpadding='0' cellspacing='0' width='100%'>" +
        "<tbody><tr><td colspan='3' height='20'></td></tr><tr><td width='20'></td>" + 
        "<td align='left'><table cellpadding='0' cellspacing='0' width='100%'><tbody><tr>"+
        "<td colspan='3' height='20'></td></tr><tr><td colspan='3'><h4> Password Change Confirmation" +
        "</h4>Your password was successfully changed.<br><br><table><tbody>" +
            "<tr><td>Username </td><td>{0}</td></tr>" +
            "<tr><td>Password </td><td>{1}</td></tr>" +
            "<tr><td>Created </td><td>{2}</td></tr>" +
            "</tbody></table></td></tr><tr><td colspan = '3' height= '20'></td></tr><tr><td colspan= '3' "+
        "style= 'text-align:center;'><span style= 'font-family:Helvetica, Arial,"+
        " sans-serif;font-size:12px;color:#cccccc;'> This message was sent from TriLogy, Inc., "+
        "somewhere, 66th floor, SP, BR.</span></td></tr></tbody></table></td><td width = '20' ></td>"+
        "</tr><tr><td colspan= '3' height= '20'></td></tr></tbody>";  
        
        /// <summary>
        /// Ordem dos paramentros:
        /// FullName, callback, email, token
        /// </summary>
        public static string AccountEmailActivation =
        "<table cellpadding='0' cellspacing='0' width='100%'>" +
        "<tbody><tr><td colspan='3' height='20'></td></tr><tr><td width='20'></td>" + 
        "<td align='left'><table cellpadding='0' cellspacing='0' width='100%'><tbody><tr>"+
        "<td colspan='3' height='20'></td></tr><tr><td colspan='3'><h4> Account activation.</h4>" +
        "<br><table><tbody><tr><td>Hi {0}.</td></tr>" +
        "<tr><tr><td>You have been sent this email because you created an account on our website.</td><tr>" +
        "<tr><td>Please click on this <a 'target='_blank' href= {1}?email={2}&token={3}>link</a> to confirm" +
        " your email address is correct.</td></tr>" +
        "</tbody></table></td></tr><tr><td colspan = '3' height= '20'></td></tr><tr><td colspan= '3' "+
        "style= 'text-align:center;'><span style= 'font-family:Helvetica, Arial,"+
        " sans-serif;font-size:12px;color:#cccccc;'> This message was sent from TriLogy, Inc., "+
        "somewhere, 66th floor, SP, BR.</span></td></tr></tbody></table></td><td width = '20' ></td>"+
        "</tr><tr><td colspan= '3' height= '20'></td></tr></tbody>";

        /// <summary>
        /// Ordem dos paramentros:
        /// FullName, callback, email, token
        /// </summary>
        public static string AccountReActivation =
        "<table cellpadding='0' cellspacing='0' width='100%'>" +
        "<tbody><tr><td colspan='3' height='20'></td></tr><tr><td width='20'></td>" +
        "<td align='left'><table cellpadding='0' cellspacing='0' width='100%'><tbody><tr>" +
        "<td colspan='3' height='20'></td></tr><tr><td colspan='3'><h4> Account activation.</h4>" +
        "<br><table><tbody><tr><td>Hi {0}.</td></tr>" +
        "<tr><tr><td>You have requested to reactivate your account.</td><tr>" +
        "<tr><td>Please click on this <a 'target='_blank' href= {1}?email={2}&token={3}>link</a> " +
        "to proceed with reactivation.</td></tr>" +
        "</tbody></table></td></tr><tr><td colspan = '3' height= '20'></td></tr><tr><td colspan= '3' " +
        "style= 'text-align:center;'><span style= 'font-family:Helvetica, Arial," +
        " sans-serif;font-size:12px;color:#cccccc;'> This message was sent from TriLogy, Inc., " +
        "somewhere, 66th floor, SP, BR.</span></td></tr></tbody></table></td><td width = '20' ></td>" +
        "</tr><tr><td colspan= '3' height= '20'></td></tr></tbody>";  


        /// <summary>
        /// Ordem dos paramentros:
        /// calback, Id, token, createdAt, Email
        /// </summary>
        public static string PasswordResetConfirmation = 
            "<table cellpadding='0' cellspacing='0' width='100%'>" 
            + "<tbody><tr><td colspan='3' height='20'></td></tr><tr><td width='20'>"
            + "</td><td align='left'><table cellpadding='0' cellspacing='0' width='100%'><tbody><tr>"
            + "<td colspan='3' height='20'></td></tr><tr><td colspan='3'><h4> Reset Password</h4>"
            + "A password reset event has been triggered.The password reset window is limited to two hours."
            + "<br><br>If you do not reset your password within two hours, you will need to submit a new "
            + "request.<br><br>To complete the password reset process, " 
            + "click <a href= {0}?id={1}&token={2}>here</a>.<br><br><table><tbody>" 
            + "<tr><td>Username </td><td>{4}</td></tr>" 
            + "<tr><td>Created</td><td>{3}</td></tr>" 
            + "</tbody></table></td></tr><tr><td colspan = '3' height= '20'></td></tr>"
            + "<tr><td colspan= '3' style= 'text-align:center;'><span style= 'font-family:Helvetica, "
            + "Arial, sans-serif;font-size:12px;color:#cccccc;'>This message was sent from TriLogy, "
            + "Inc., somewhere, 66th floor, SP, BR.</span></td></tr></tbody></table></td><td width ='20'>"
            + "</td></tr><tr><td colspan= '3' height='20'></td></tr></tbody>";
    } 
}
