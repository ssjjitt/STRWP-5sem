﻿using Microsoft.AspNetCore.Mvc.Filters;

namespace ASPCMVC08.Attributes;

public class ControllerActionAttribute : ActionFilterAttribute
{
    public override void OnActionExecuting(ActionExecutingContext context)
    {
        var query = context.HttpContext.Request.Query;
        query.TryGetValue("_action", out var action);
        query.TryGetValue("_controller", out var controller);

        if (action.FirstOrDefault() is null || controller.FirstOrDefault() is null)
        {
            base.OnActionExecuting(context);
            return;
        }

        context.HttpContext.Response.Redirect($"/{controller}/{action}");
    }
}
