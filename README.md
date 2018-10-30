# swagger-IncludeXmlComments-bug
Refactoring a bug in Swashbuckle.AspNetCore (v 3.0.), IncludeXmlComments

This bug has been reported here: [https://github.com/domaindrivendev/Swashbuckle.AspNetCore/issues/925](https://github.com/domaindrivendev/Swashbuckle.AspNetCore/issues/925)

----------------------------------

**Type of issue**: Bug
**Swashbuck.AspNetCore Version**: 3.0.0
**ASP.NET Core version**: 2.1

**Issue description**
If any controller inherits a generic class (base controller), Swagger cannot generate the swagger.json while IncludeXmlComments() is activated.

**Code**
I uploaded a sample project so you can easily refactor the bug:
[https://github.com/tohidazizi/swagger-IncludeXmlComments-bug](https://github.com/tohidazizi/swagger-IncludeXmlComments-bug)

**Error**
> **An unhandled exception occurred while processing the request.**
> AmbiguousMatchException: Ambiguous match found.
> System.RuntimeType.GetMethodImplCommon(string name, int genericParameterCount, BindingFlags bindingAttr, Binder binder, CallingConventions callConv, Type[] types, ParameterModifier[] modifiers)

**_Stack_**
> AmbiguousMatchException: Ambiguous match found.
System.RuntimeType.GetMethodImplCommon(string name, int genericParameterCount, BindingFlags bindingAttr, Binder binder, CallingConventions callConv, Type[] types, ParameterModifier[] modifiers)
System.RuntimeType.GetMethodImpl(string name, BindingFlags bindingAttr, Binder binder, CallingConventions callConv, Type[] types, ParameterModifier[] modifiers)
System.Type.GetMethod(string name, BindingFlags bindingAttr)
System.Reflection.TypeExtensions.GetMethod(Type type, string name)
Swashbuckle.AspNetCore.SwaggerGen.XmlCommentsMemberNameHelper.GetMemberNameForMethod(MethodInfo method)
Swashbuckle.AspNetCore.SwaggerGen.XmlCommentsOperationFilter.Apply(Operation operation, OperationFilterContext context)
Swashbuckle.AspNetCore.SwaggerGen.SwaggerGenerator.CreateOperation(ApiDescription apiDescription, ISchemaRegistry schemaRegistry)
Swashbuckle.AspNetCore.SwaggerGen.SwaggerGenerator.CreatePathItem(IEnumerable<ApiDescription> apiDescriptions, ISchemaRegistry schemaRegistry)
System.Linq.Enumerable.ToDictionary<TSource, TKey, TElement>(IEnumerable<TSource> source, Func<TSource, TKey> keySelector, Func<TSource, TElement> elementSelector, IEqualityComparer<TKey> comparer)
Swashbuckle.AspNetCore.SwaggerGen.SwaggerGenerator.CreatePathItems(IEnumerable<ApiDescription> apiDescriptions, ISchemaRegistry schemaRegistry)
Swashbuckle.AspNetCore.SwaggerGen.SwaggerGenerator.GetSwagger(string documentName, string host, string basePath, string[] schemes)
Swashbuckle.AspNetCore.Swagger.SwaggerMiddleware.Invoke(HttpContext httpContext)
Microsoft.AspNetCore.Builder.RouterMiddleware.Invoke(HttpContext httpContext)
Microsoft.AspNetCore.Diagnostics.DeveloperExceptionPageMiddleware.Invoke(HttpContext context)

**Note 1**: In the project, if you remove `EntityOneController`, Swagger starts working fine.

**Note 2**: With or without Swagger, the Web API project (and `EntityOneController`) works fine. Try:

`curl -X GET  http://localhost:58714/api/entityone`

`curl -X GET  http://localhost:58714/api/entityone/123`

`curl -X POST http://localhost:58714/api/entityone \
  -H 'Content-Type: application/json' \
  -d '{"name": "TEST"}'`

`curl -X PUT http://localhost:58714/api/entityone/123 \
  -H 'Content-Type: application/json' \
  -d '{"id": 123, "name": "Entity One with ID 280818165."}'`

`curl -X DELETE http://localhost:58714/api/entityone/123`

