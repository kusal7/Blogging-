namespace KushalBlogWebApp
{
    /// <summary>
    /// The session data.
    /// </summary>
    public static class SessionData
    {
        /// <summary>
        /// Gets the client office.
        /// </summary>
        public static int BranchCode
        {
            get
            {
                //var context = DI.Instance.Resolve<IHttpContextAccessor>().HttpContext;
                //if (context == null)
                //    return 0;
                //if (context.User == null || context.User.Claims == null || !context.User.Claims.Any() || context.User.Claims.FirstOrDefault(x => x.Type == "OfficeId") == null)
                //    return 0;
                var brannchId = 1;
                return brannchId;
            }
        }

        /// <summary>
        /// Gets the current user.
        /// </summary>
        public static int CurrentUserId
        {
            get
            {

                //var context = DI.Instance.Resolve<IHttpContextAccessor>().HttpContext;

                //var u = string.Empty;
                //if (context == null)
                //    return 0;
                //if (context.User == null || context.User.Claims == null || !context.User.Claims.Any() )
                //    return 0;

                var Userid = 1;
                return Userid;
            }
        }
    }
}
