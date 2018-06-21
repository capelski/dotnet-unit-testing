namespace Company.Application.WebApi.Controllers
{
    using System;
    using System.Web.Http;
    using Company.Application.Logic.Contracts;

    public class AmazingController : ApiController
    {
        private readonly IAmazingService amazingService;

        public AmazingController(IAmazingService amazingService)
        {
            this.amazingService = amazingService ??
                throw new ArgumentNullException(nameof(amazingService));
        }

        [HttpGet]
        public IHttpActionResult GetById(int id)
        {
            try
            {
                var coolThing = this.amazingService.GetById(id);
                return this.Ok(coolThing);
            }
            catch (Exception ex)
            {
                return this.InternalServerError(ex);
            }
        }
    }
}