using System.Web;
using System.Web.Optimization;

namespace Xenon___Allianz
{
    public class BundleConfig
    {
        // Pour plus d'informations sur le regroupement, visitez https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Utilisez la version de développement de Modernizr pour le développement et l'apprentissage. Puis, une fois
            // prêt pour la production, utilisez l'outil de génération à l'adresse https://modernizr.com pour sélectionner uniquement les tests dont vous avez besoin.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            /** JS BUNDLES **/
            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js",
                      "~/Scripts/bootstrap-datepicker.js",
                      "~/Scripts/bootstrap-datepicker.min.js"
                      ));

            bundles.Add(new ScriptBundle("~/bundles/LoginRegister/js").Include(
                      "~/Scripts/LoginRegister.js"
                      ));
            bundles.Add(new ScriptBundle("~/bundles/Contract/js").Include(
                      "~/Scripts/Contract.js"
                      ));
            bundles.Add(new ScriptBundle("~/bundles/ContractPagination/js/").Include(
                      "~/Scripts/ContractPagination.js"
                      ));



            /** CSS BUNDLES **/
            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css",
                      "~/Content/bootstrap-datepicker3.css",
                      "~/Content/bootstrap-datepicker3.min.css",
                      "~/Content/bootstrap-datepicker3.css.map"));
            bundles.Add(new StyleBundle("~/Content/LoginRegister/css").Include(
                      "~/Content/LoginRegister.css"
                      ));
        }
    }
}
