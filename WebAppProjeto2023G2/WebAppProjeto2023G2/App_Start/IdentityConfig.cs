using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebAppProjeto2023G2.DAL;
using WebAppProjeto2023G2.Infraestrutura;

namespace WebAppProjeto2023G2
{
    public class IdentityConfig
    {
        public void Configuration(IAppBuilder app)
        {
            app.CreatePerOwinContext<IdentityDbContextAplicacao>
            (IdentityDbContextAplicacao.Create);
            app.CreatePerOwinContext<GerenciadorUsuario>(GerenciadorUsuario.Create);
            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = Microsoft.AspNet.Identity.DefaultAuthenticationTypes.ApplicationCookie,
                LoginPath = new PathString("/Seguranca/Account/Login"),
            });
        }
    }
}