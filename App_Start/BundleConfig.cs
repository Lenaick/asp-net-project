﻿using System.Web;
using System.Web.Optimization;

namespace Projet3
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

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/bootstrap-toggle.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/fontawesome").Include(
                      "~/Scripts/fontawesome.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/dataTables").Include(
                      "~/Scripts/dataTables.min.js",
                      "~/Scripts/dom-checkbox.js"));

            bundles.Add(new ScriptBundle("~/bundles/froala_editor").Include(
                      "~/Scripts/froala_editor/*.js"));

            bundles.Add(new StyleBundle("~/Content/froala_editor").Include(
                      "~/Content/froala_editor/*.css"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/bootstrap-toggle.min.css",
                      "~/Content/fontawesome.min.css",
                      "~/Content/dataTables.min.css",
                      "~/Content/site.css"));
        }
    }
}
