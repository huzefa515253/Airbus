using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace Project
{
    public class CustomJsonResult : ActionResult
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CustomJsonResult"/> class.
        /// </summary>
        public CustomJsonResult() { }

        /// <summary>
        /// Initializes a new instance of the <see cref="CustomJsonResult"/> class.
        /// </summary>
        /// <param name="data">The data.</param>
        /// <param name="jsonRequestBehavior">The json request behavior.</param>
        public CustomJsonResult(object data, JsonRequestBehavior jsonRequestBehavior)
        {
            Data = data;
            JsonRequestBehavior = jsonRequestBehavior;
        }

        public CustomJsonResult(object data, JsonRequestBehavior jsonRequestBehavior, bool negotiateContentType = false)
        {
            Data = data;
            JsonRequestBehavior = jsonRequestBehavior;

            if (negotiateContentType)
            {
                if (HttpContext.Current.Request != null
                    && HttpContext.Current.Request.AcceptTypes != null
                    && HttpContext.Current.Request.AcceptTypes.Contains("application/json") == false)
                    ContentType = "text/html";
                else
                    ContentType = "application/json";
            }
        }

        /// <summary>
        /// Gets or sets the content encoding.
        /// </summary>
        /// <value>
        /// The content encoding.
        /// </value>
        public Encoding ContentEncoding { get; set; }

        /// <summary>
        /// Gets or sets the type of the content.
        /// </summary>
        /// <value>
        /// The type of the content.
        /// </value>
        public string ContentType { get; set; }

        /// <summary>
        /// Gets or sets the data.
        /// </summary>
        /// <value>
        /// The data.
        /// </value>
        public object Data { get; set; }

        /// <summary>
        /// Gets or sets the json request behavior.
        /// </summary>
        /// <value>
        /// The json request behavior.
        /// </value>
        public JsonRequestBehavior JsonRequestBehavior { get; set; }

        /// <summary>
        /// Enables processing of the result of an action method by a custom type that inherits from the <see cref="T:System.Web.Mvc.ActionResult" /> class.
        /// </summary>
        /// <param name="context">The context in which the result is executed. The context information includes the controller, HTTP content, request context, and route data.</param>
        /// <exception cref="System.ArgumentNullException">context</exception>
        /// <exception cref="System.InvalidOperationException">This request has been blocked because sensitive information could be disclosed to third party web sites when this is used in a GET request. To allow GET requests, set JsonRequestBehavior to AllowGet.</exception>
        public override void ExecuteResult(ControllerContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException("context");
            }
            if (JsonRequestBehavior == JsonRequestBehavior.DenyGet
                && String.Equals(context.HttpContext.Request.HttpMethod, "GET", StringComparison.OrdinalIgnoreCase))
            {
                throw new InvalidOperationException("This request has been blocked because sensitive information could be disclosed to third party web sites when this is used in a GET request. To allow GET requests, set JsonRequestBehavior to AllowGet.");
            }

            var response = context.HttpContext.Response;

            response.ContentType = !String.IsNullOrEmpty(ContentType) ? ContentType : "application/json";
            if (ContentEncoding != null)
            {
                response.StatusCode = (int)HttpStatusCode.OK;
                response.ContentEncoding = ContentEncoding;
            }
            if (Data == null)
                return;

            var jsonSerializerSettings = new JsonSerializerSettings
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver()
            };
            response.Write(JsonConvert.SerializeObject(Data, jsonSerializerSettings));
        }
    }

    /// <summary>
    /// Custom Formatted JSON Response
    /// This formats the JSON using conventional CAMEL case and used when custom error result has to be generated for the client
    /// status code will always be 500 
    /// </summary>
    public class CustomJsonErrorResult : CustomJsonResult
    {

        /// <summary>
        /// Initializes a new instance of the <see cref="CustomJsonErrorResult"/> class.
        /// </summary>
        /// <param name="data">The data.</param>
        /// <param name="jsonRequestBehavior">The json request behavior.</param>
        public CustomJsonErrorResult(object data, JsonRequestBehavior jsonRequestBehavior)
        {
            Data = data;
            JsonRequestBehavior = jsonRequestBehavior;
        }

        /// <summary>
        /// Enables processing of the result of an action method by a custom type that inherits from the <see cref="T:System.Web.Mvc.ActionResult" /> class.
        /// </summary>
        /// <param name="context">The context in which the result is executed. The context information includes the controller, HTTP content, request context, and route data.</param>
        /// <exception cref="System.ArgumentNullException">context</exception>
        /// <exception cref="System.InvalidOperationException">This request has been blocked because sensitive information could be disclosed to third party web sites when this is used in a GET request. To allow GET requests, set JsonRequestBehavior to AllowGet.</exception>
        public override void ExecuteResult(ControllerContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException("context");
            }
            if (JsonRequestBehavior == JsonRequestBehavior.DenyGet
                && String.Equals(context.HttpContext.Request.HttpMethod, "GET", StringComparison.OrdinalIgnoreCase))
            {
                throw new InvalidOperationException("This request has been blocked because sensitive information could be disclosed to third party web sites when this is used in a GET request. To allow GET requests, set JsonRequestBehavior to AllowGet.");
            }

            var response = context.HttpContext.Response;

            response.StatusCode = (int)HttpStatusCode.InternalServerError;

            response.ContentType = !String.IsNullOrEmpty(ContentType) ? ContentType : "application/json";
            if (ContentEncoding != null)
            {
                response.ContentEncoding = ContentEncoding;
            }

            if (Data == null)
                return;

            var jsonSerializerSettings = new JsonSerializerSettings
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver()
            };
            response.Write(JsonConvert.SerializeObject(Data, jsonSerializerSettings));
        }
    }
}