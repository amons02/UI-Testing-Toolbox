using Lombiq.Tests.UI.Extensions;
using Lombiq.Tests.UI.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Lombiq.HelpfulLibraries.OrchardCore.Mvc;

public static class TypedRouteUITestContextExtensions
{
    /// <summary>
    /// Navigates to the relative URL generated by <see cref="TypedRoute"/> for the <paramref name="actionExpression"/>
    /// in the <typeparamref name="TController"/>.
    /// </summary>
    public static Task GoToAsync<TController>(
        this UITestContext context,
        Expression<Action<TController>> actionExpression,
        params (string Key, object Value)[] additionalArguments)
        where TController : ControllerBase =>
        context.GoToRelativeUrlAsync(TypedRoute
            .CreateFromExpression(actionExpression, additionalArguments)
            .ToString(context.TenantName));

    /// <summary>
    /// Navigates to the relative URL generated by <see cref="TypedRoute"/> for the <paramref
    /// name="actionExpressionAsync"/> in the <typeparamref name="TController"/>.
    /// </summary>
    public static Task GoToAsync<TController>(
        this UITestContext context,
        Expression<Func<TController, Task>> actionExpressionAsync,
        params (string Key, object Value)[] additionalArguments)
        where TController : ControllerBase =>
        context.GoToRelativeUrlAsync(TypedRoute
            .CreateFromExpression(actionExpressionAsync.StripResult(), additionalArguments)
            .ToString(context.TenantName));
}
