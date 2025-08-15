using Microsoft.AspNetCore.Mvc.ApplicationModels;

namespace Fitness.Api.Common.Convention
{
    internal sealed class RouteConvention : IApplicationModelConvention
    {
        private readonly AttributeRouteModel _prefix;

        public RouteConvention(string prefix)
        {
            _prefix = new AttributeRouteModel(new Microsoft.AspNetCore.Mvc.RouteAttribute(prefix));
        }

        public void Apply(ApplicationModel application)
        {
            foreach (var controller in application.Controllers)
            {
                foreach (var selector in controller.Selectors)
                {
                    if (selector.AttributeRouteModel == null) continue;

                    selector.AttributeRouteModel = AttributeRouteModel.CombineAttributeRouteModel(
                        _prefix, selector.AttributeRouteModel);
                }

                foreach (var action in controller.Actions)
                {
                    foreach (var selector in action.Selectors)
                    {
                        if (selector.AttributeRouteModel == null) continue;

                        selector.AttributeRouteModel = AttributeRouteModel.CombineAttributeRouteModel(
                            _prefix, selector.AttributeRouteModel);
                    }
                }
            }
        }
    }
}
