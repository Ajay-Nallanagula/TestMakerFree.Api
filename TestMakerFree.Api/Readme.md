https://github.com/PacktPublishing/ASP.NET-Core-2-and-Angular-5


Microsoft.Aspnetcore.spa, configuration files
https://blogs.msdn.microsoft.com/webdev/2017/02/14/building-single-page-applications-on-asp-net-core-with-javascriptservices/

What is HotModuleReplacement ?
HotModuleReplacement : https://webpack.js.org/concepts/hot-module-replacement/

/wwwroot/ folder, which will contain the compiled, ready-to-publish contents of our application: HTML, JS, and CSS files, along with
fonts, images, and everything else we want our users to have access to in terms of static file.

Webhost vs WebServer:
The host is responsible for application startup and lifetime management.The server is responsible for accepting HTTP requests. Part of the host's
responsibility includes ensuring that the application's services and the server are available and properly configured. We could think of the host as
being a wrapper around the server. The host is configured to use a particular server; the server is unaware of its host
http://aspnetcore.readthedocs.io/en/stable/fundamentals/hosting.html

The appsettings.json file is nothing less than the replacement of the good old Web.config file.


tsconfig.json: 	angularCompilerOptions object, which can be used to
configure the behavior of the Angular AoT compiler: the strictMetadataEmit setting which
we added will tell the compiler to report syntax errors immediately rather than produce an
error log file.

Angular AOT: https://angular.io/guide/aot-compiler


Webpack is the most used--and arguably the most powerful nowadays--module
bundler for modern JavaScript applications. Its main job is to recursively build a dependency
graph of all the NPM modules needed by the client-side application before starting it,
package them all into a small number of bundles--often only one--and then feed them (or it)
to the browser.
Dramatically reduces the HTTP requests to load the client-side assets in normal
scenarios, that is, when no package managers, task runners, or concatenation
strategies are being used
Dramatically reduces the chance of variable conflicts when using standard
concatenation strategies such as the .concat().uglify().writeTo() chains
featured by Gulp, Grunt, and the likes
Dramatically increases the control over static files, as it can be configured to
skip all the "dead" JS/CSS and even image (!) assets, reduce/optimize the size of
CSS files even before minifying them, easily switch between CDNs URLs and
locally hosted files, and so on

Wht is Angular Universal ?
The official site states that Universal is “Server-side Rendering for Angular apps”. It’s the middleware that sits between node.js and Angular.
Simply put, it offers best of both worlds: the user experience and high performance and of SPA’s combined with the SEO friendliness of static pages
https://medium.com/burak-tasci/angular-4-with-server-side-rendering-aka-angular-universal-f6c228ded8b0
https://universal.angular.io/

Client app cleanup :82
test

The main reason for building a ViewModel instead of directly passing the Model entities is that it only represents the data that we want to use, and nothing else;
Another advantage is the additional security it gives, since we can protect any field from being serialized and passed through the HTTP channel

  [JsonObject(MemberSerialization.OptOut)]
  //https://www.newtonsoft.com/json/help/html/SerializationAttributes.htm
  //Press F12 on MemberSerialization.OptOut

What is master/detail navigation pattern?
https://docs.microsoft.com/en-us/windows/uwp/design/controls-and-patterns/master-details

Advantages of typescript ?
1. TypeScript interface, as it is the most lightweight way to work with structured JSON data in a strongly-typed fashion
2. We have chosen TypeScript over JavaScript because we want to work with type definitions. Anonymous objects and properties are the exact opposite; they lead to the JavaScript way of doing things, which is something we wanted to avoid in


Enable Swagger :
https://www.c-sharpcorner.com/article/enable-swagger-in-your-net-core-2-0-application-step-by-step-guide/ 

Swashbuckle vs swagger
https://stackoverflow.com/questions/43441683/what-is-swagger-swashbuckle-and-swashbuckle-ui
http://localhost:50744/swagger/index.html

Step1 : Install-Package Swashbuckle.AspNetCore
Step 2 : Inside Startup --> ConfigureServices
services.AddSwaggerGen(swagger =>
            {
                swagger.SwaggerDoc("v1", new Info {
                    Version = "v1",
                    Title = "My API",
                    Description = ".net core api with swagger support",
                    TermsOfService = "None",
                    Contact = new Contact() { Name = "Ajay Nallanagula", Email = "kumarnajay9@gmail.com", Url = "www.google.com" }
                });

Step 3 : Inside Startup --> configure -->below add.mvc
app.UseSwaggerUI(swagUI => {
                swagUI.SwaggerEndpoint("/swagger/v1/swagger.json","TestMakerFree.ApiV1");
            });
