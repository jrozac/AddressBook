using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Linq;
using TestAssignment.AddressBook.Dtos;

namespace TestAssignment.AddressBook.Service
{

    /// <summary>
    /// Filter to set response error in case of invalid data
    /// </summary>
    public class ModelsValidationFilter : IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext context)
        {
        }

        /// <summary>
        /// Before execution validation filter
        /// </summary>
        /// <param name="context"></param>
        public void OnActionExecuting(ActionExecutingContext context)
        {
            if (!context.ModelState.IsValid)
            {
      
                // get errors
                var errors = context.ModelState.Where(m => m.Value.Errors.Any())
                    .ToDictionary(m => $"{m.Key.Substring(0,1).ToLower()}{m.Key.Substring(1)}", m => m.Value.Errors.Select(e => e.ErrorMessage).ToArray());

                // define response
                var responseObj = new ModelErrorDto
                {
                    Errors = errors,
                    ModelType = context.ActionArguments?.FirstOrDefault().Value?.GetType().Name
                };

                // set bad request result
                context.Result = new BadRequestObjectResult(responseObj);
            }
        }
    }
}
