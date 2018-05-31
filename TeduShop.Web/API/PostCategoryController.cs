using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TeduShop.Model.Models;
using TeduShop.Service;
using TeduShop.Web.Infratructure.Core;

namespace TeduShop.Web.API
{
    public class PostCategoryController : ApiControllerBase
    {
        IPostCategoryService _postCategoryService;
        public PostCategoryController(IErrorService errorService, IPostCategoryService postCategoryService):base(errorService)
        {
            this._postCategoryService = postCategoryService;
        }
        public HttpResponseMessage Creat(HttpRequestMessage request,PostCategory postcategory)
        {
            return CreateHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;
                if (ModelState.IsValid)
                {
                    request.CreateErrorResponse(HttpStatusCode.BadRequest,modelState)
                }
                else
                {

                }
                return response; 
            });
        }
       
    }
}