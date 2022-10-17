using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace CMS.Api.Models
{
    public class ValidationFilter : IAsyncActionFilter
    {
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            if (!context.ModelState.IsValid)
            {
                List<string> messages = new();

                var returnModel = new ReturnModel<string>
                {
                    StatusCode = (int)Shared.Utilities.Results.ComplexTypes.ResultStatus.Warning,
                    Messages = (from state in context.ModelState.Values
                                from err in state.Errors
                                select err.ErrorMessage).ToList()
                };
                context.Result = new ContentResult
                {
                    Content = JsonSerializer.Serialize(returnModel),
                    ContentType = "application/json",
                    StatusCode = returnModel.StatusCode
                };
                return;

            }
            await next();
        }
    }
}
