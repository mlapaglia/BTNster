namespace BTNster
{
    using BTNster.IRC;
    using Nancy;
    using Nancy.Conventions;
    using System.Threading;

    public class Bootstrapper : DefaultNancyBootstrapper
    {
        static private Thread botThread;

        protected override void ConfigureConventions(NancyConventions nancyConventions)
        {
            base.ConfigureConventions(nancyConventions);
            nancyConventions.StaticContentsConventions.Clear();
            nancyConventions.StaticContentsConventions.Add
            (StaticContentConventionBuilder.AddDirectory("css", "/Content/CSS"));
            nancyConventions.StaticContentsConventions.Add
            (StaticContentConventionBuilder.AddDirectory("scripts", "/Content/Scripts"));
            nancyConventions.StaticContentsConventions.Add
            (StaticContentConventionBuilder.AddDirectory("images", "/Content/Images"));
            nancyConventions.StaticContentsConventions.Add
            (StaticContentConventionBuilder.AddDirectory("fonts", "/Content/Fonts"));
        }

        protected override void ApplicationStartup(Nancy.TinyIoc.TinyIoCContainer container, Nancy.Bootstrapper.IPipelines pipelines)
        {
            base.ApplicationStartup(container, pipelines);

            container.Register<Bot>().AsSingleton();
        }
    }
}