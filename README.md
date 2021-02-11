# WebApp.Core.MemoryUsage
Prototype to demonstrate the excessive memory usage of Net Core when using endpoints

ISSUE
https://github.com/dotnet/aspnetcore/issues/30092

Using the MapControllerRoute function with various route templates the server memory explodes in the order of GB.
A project with about 1K of Controllers and each with 30/40 Actions, with a dozen MapControllerRoute endpoints can weight up to 3GB.

We are not using the RouteAttribute decorations, but attributing the routes with MapControllerRoute, for a precise choice and for compatibility with NET.

```
app.UseEndpoint(endpoint => {
	endpoint.MapControllerRoute({
		name: "RouteName",
		pattern: "api/{controller}/{action}",
	});
	...
	endpoint.MapControllerRoute({
		name: "RouteName",
		pattern: "api/{controller}/{id}/{action}",
	})
	..
});
```

The memory is almost completely occupied by the Microsoft.AspNetCore.Mvc.ModelBinding.Metadata.DefaultModelMetadata class and the internal routing dictionaries.

If, instead of with the UseEndpoint, the same identical routes are linked with UseMvc, there is not problems, and the application has a normal use of RAM (<500MB in Debug, 150MB in Release)

```
// this works without leak
app.UseMvc(route => {
	route.MapRoute(
                name: name,
                template: routeTemplate,
                defaults: defaults,
                constraints: constraints);
});
```
