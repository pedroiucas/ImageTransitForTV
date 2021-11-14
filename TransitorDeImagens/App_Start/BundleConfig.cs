using System.Web;
using System.Web.Optimization;

namespace TransitorImagens
{
    public class BundleConfig
    {
        // Para obter mais informações sobre o agrupamento, visite https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/Scripts.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/Styles.css"));
        }
    }
}