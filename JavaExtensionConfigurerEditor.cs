﻿using System.Web.UI.WebControls;
using Inedo.BuildMaster.Extensibility.Configurers.Extension;
using Inedo.BuildMaster.Web.Controls;
using Inedo.BuildMaster.Web.Controls.Extensions;
using Inedo.Web.Controls;

namespace Inedo.BuildMasterExtensions.Java
{
    public class JavaExtensionConfigurerEditor : ExtensionConfigurerEditorBase
    {
        private ValidatingTextBox txtJdkPath;
        private TextBox txtAntPath;

        protected override void CreateChildControls()
        {
            txtJdkPath = new ValidatingTextBox()
            {
                Width = Unit.Pixel(300)
            };

            txtAntPath = new TextBox()
            {
                Width = Unit.Pixel(300)
            };

            this.Controls.Add(
                new FormFieldGroup(
                    "JDK Path",
                    "The path to the Java Development Kit.",
                    false,
                    new StandardFormField(
                        "JDK Path:",
                        txtJdkPath
                    )
                ),
                new FormFieldGroup(
                    "Ant Path",
                    "The path to the Ant executable.",
                    true,
                    new StandardFormField(
                        "Ant Path:",
                        txtAntPath
                    )
                )
            );
        }

        public override void BindToForm(ExtensionConfigurerBase extension)
        {
            this.EnsureChildControls();

            var configurer = (JavaExtensionConfigurer)extension;
            txtJdkPath.Text = configurer.JdkPath ?? string.Empty;
            txtAntPath.Text = configurer.AntPath ?? string.Empty;
        }

        public override ExtensionConfigurerBase CreateFromForm()
        {
            this.EnsureChildControls();

            return new JavaExtensionConfigurer()
            {
                JdkPath = txtJdkPath.Text,
                AntPath = txtAntPath.Text
            };
        }

        public override void InitializeDefaultValues()
        {
            this.BindToForm(new JavaExtensionConfigurer());
        }
    }
}
