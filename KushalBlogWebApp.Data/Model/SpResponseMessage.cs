
namespace KushalBlogWebApp.Data.Model

{
    /// <summary>
    /// The sp response message.
    /// </summary>
    public class SpResponseMessage
    {
        /// <summary>
        /// Gets or sets the msg.
        /// </summary>
        public string Msg { get; set; } = string.Empty;
        /// <summary>
        /// Gets or sets the status code.
        /// </summary>
        public int StatusCode { get; set; }
        /// <summary>
        /// Gets or sets the return id.
        /// </summary>
        public int ReturnId { get; set; }
        /// <summary>
        /// Gets or sets the msg type.
        /// </summary>
        public string MsgType { get; set; } = string.Empty;



    }
}
