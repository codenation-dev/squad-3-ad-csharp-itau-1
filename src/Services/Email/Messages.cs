namespace TryLog.Services.Email
{
    public static class Messages
    {
        public static string PasswordChangeConfirmation = "<tbody><tr><td><h4>Password Change Confirmation</h4>" +
                "Your password was successfully changed.</td></tr><br><br></tbody>" +
                "<table><tbody><tr><td>Username</td><td>{0}</td></tr>" +
                "<tr><td>Create</td><td>{1}</td></tr>" +
                "<tr><td>New password</td><td>{2}</td></tr></tbody></table>";

        public static string PasswordResetConfirmation = "<tbody><h4> Password Reset Confirmation</h4>" +
            "A password reset event has been triggered.The password reset window is limited to two hours.<br><br>" +
                "If you do not reset your password within two hours, you will need to submit a new request.<br><br>" +
                "To complete the password reset process, click on <a href = {0}>this link</a>.<br><b ></tbody><table><tbody>" +
                "<tr><td>Username</td><td>{1}</td></tr><tr><td>Created</td><td>{2}</td></tr></tbody></table></body>";

        public static string AccountEmailActivation = "Hi {0}.<br>You have been sent this email because you created an account on our website." +
            "<br>Please click on <a href = {1}>this link</a> to confirm your email address is correct.";
    
        public static string AccountReActivation = "Hi {0}.<br>Você solicitou a reativação de sua conta." +
            "<br>Please click on <a href = {1}>this link</a> to confirm.";
    }
}
