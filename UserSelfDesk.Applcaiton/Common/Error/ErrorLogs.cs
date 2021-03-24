namespace UserSelfDesk.Applcaiton.Common.Error
{
    internal class ErrorLogs
    {
        internal static void PrintError(string className
           , string methodName
           , string msg)
        {
            string layerName = "Helper.Email";
            CoreCommon.LogCapture.Error.PrintError(layerName
                , className
                , methodName
                , msg);
        }
    }
}
