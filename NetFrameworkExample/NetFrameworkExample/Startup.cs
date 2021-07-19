using System;
using System.IO;
using System.Threading.Tasks;
using System.Web;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(NetFrameworkExample.Startup))]

namespace NetFrameworkExample
{
    public class Startup
    {
	public void Configuration(IAppBuilder app)
	{
	    //New code:
	 //   app.Use((context, next) =>
	 //   {
		//PrintCurrentIntegratedPipelineStage(context, "Middleware 1");
		//return next.Invoke();
	 //   });
	    //   app.Run(context =>
	    //   {
	    //context.Response.ContentType = "text/plain";
	    //return context.Response.WriteAsync("Hello, world.");
	    //   });
	}

	private void PrintCurrentIntegratedPipelineStage(IOwinContext context, string msg)
	{
	    var currentIntegratedpipelineStage = HttpContext.Current.CurrentNotification;
	    context.Get<TextWriter>("host.TraceOutput").WriteLine(
		"Current IIS event: " + currentIntegratedpipelineStage
		+ " Msg: " + msg);
	}
    }
}
