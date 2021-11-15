using System.Web;
using System.Web.Optimization;

namespace foxcon
{
    public class BundleConfig
    {
        // Para obter mais informações sobre o agrupamento, visite https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/Content/js").Include(
                       "~/Content/lte/plugins/jquery/jquery.min.js",
                       "~/Content/lte/plugins/bootstrap/js/bootstrap.bundle.min.js",
                       
                       "~/Content/lte/dist/js/adminlte.min.js",
                       "~/Content/lte/dist/js/adminlte.min.js"));

            bundles.Add(new ScriptBundle("~/Content/charts").Include(
                "~/Content/lte/plugins/chart.js/Chart.min.js"));

            bundles.Add(new ScriptBundle("~/Content/datatable").Include(
                       "~/Content/lte/plugins/datatables/jquery.dataTables.min.js",
                       "~/Content/lte/plugins/datatables-bs4/js/dataTables.bootstrap4.min.js",
                       "~/Content/lte/plugins/datatables-responsive/js/dataTables.responsive.min.js",
                       "~/Content/lte/plugins/datatables-responsive/js/responsive.bootstrap4.min.js",
                       "~/Content/lte/plugins/datatables-buttons/js/dataTables.buttons.min.js",
                       "~/Content/lte/plugins/datatables-buttons/js/buttons.bootstrap4.min.js",
                       "~/Content/lte/plugins/datatables-buttons/js/buttons.html5.min.js",
                       "~/Content/lte/plugins/datatables-buttons/js/buttons.print.min.js",
                       "~/Content/lte/plugins/datatables-buttons/js/buttons.colVis.min.js"));

           
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use a versão em desenvolvimento do Modernizr para desenvolver e aprender. Em seguida, quando estiver
            // pronto para a produção, utilize a ferramenta de build em https://modernizr.com para escolher somente os testes que precisa.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/lte/plugins/fontawesome-free/css/all.min.css",
                      "~/Content/lte/dist/css/adminlte.min.css"));

            bundles.Add(new StyleBundle("~/Content/css/datatable").Include(
                      "~/Content/lte/plugins/datatables-bs4/css/dataTables.bootstrap4.min.css",
                      "~/Content/lte/plugins/datatables-responsive/css/responsive.bootstrap4.min.css",
                      "~/Content/lte/plugins/datatables-buttons/css/buttons.bootstrap4.min.css"));
        }
    }
}
