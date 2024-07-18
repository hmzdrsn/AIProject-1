using AIProject.Application.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

//GERİ KALAN EXCEPTİONLAR YAZILACAK

namespace AIProject.WebApi.Attributes
{
    public class ApiExceptionFilterAttribute : ExceptionFilterAttribute
    {
        private readonly IDictionary<Type, Action<ExceptionContext>> _exceptionHandlers;
        private readonly IConfiguration _configuration;

        public ApiExceptionFilterAttribute(IConfiguration configuration)
        {
            _configuration = configuration;

            _exceptionHandlers = new Dictionary<Type, Action<ExceptionContext>>()
            {
                {typeof (NotFoundException), HandleNotFoundException },
                {typeof(ValidationException),HandleInvalidModelException }
            };

        }

        public override void OnException(ExceptionContext context)
        {
            HandleException(context);

            base.OnException(context);
        }
        private void HandleException(ExceptionContext context)
        {
            Type type = context.Exception.GetType();

            var ignoreListForSendMail = new List<Type>
            {
                //typeof()
            };
            if (!ignoreListForSendMail.Contains(type))
            {

                //SendMailException(context);

            }


            if (!_exceptionHandlers.ContainsKey(type))
            {
                _exceptionHandlers[type].Invoke(context);
                return;
            }

            if (!context.ModelState.IsValid)
            {
                HandleInvalidModelException(context);
                return;
            }

            HandleUnknownException(context);
        }


        public void HandleInvalidModelException(ExceptionContext context)
        {
            ValidationProblemDetails? details = new(context.ModelState)
            {
                
                Type = "Allahın dediğin olur",
            };

            context.Result = new BadRequestObjectResult(details);

            context.ExceptionHandled = true;
        }


        public void HandleNotFoundException(ExceptionContext context)
        {
            NotFoundException? exception = (NotFoundException)context.Exception;
            ProblemDetails? details = new()
            {
                Type = "Selamunaleykümmmm... :))))",
                Title = "Aleykümselaaaam title",
                Detail = exception.Message
            };
            context.Result = new NotFoundObjectResult(details);

            context.ExceptionHandled = true;
        }
        public void HandleUnknownException(ExceptionContext context)
        {
            //NotFoundException? exception = (NotFoundException)context.Exception;
            //ProblemDetails? details = new()
            //{
            //    Type = "Selamunaleykümmmm... :))))",
            //    Title = "Aleykümselaaaam title",
            //    Detail = exception.Message
            //};
            //context.Result = new NotFoundObjectResult(details);

            context.ExceptionHandled = true;
        }
    }
}
