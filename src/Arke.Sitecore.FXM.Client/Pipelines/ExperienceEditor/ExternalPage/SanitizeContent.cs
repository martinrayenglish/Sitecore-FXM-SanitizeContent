using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Xml;

using Sitecore.Configuration;
using Sitecore.Diagnostics;
using Sitecore.FXM.Client.Pipelines.ExperienceEditor.ExternalPage;
using Sitecore.Xml;

namespace Arke.Sitecore.FXM.Client.Pipelines.ExperienceEditor.ExternalPage
{
    public class SanitizeContent : IExternalPageExperienceEditorProcessor
    {
        private static string _sanitizeNode = "/sitecore/fxmSanitizeExternalContent";
        public void Process(ExternalPageExperienceEditorArgs args)
        {
            Assert.ArgumentNotNull(args, "args");
            Assert.ArgumentNotNull(args.ExternalPageContent, "ExternalPageContent");

            foreach (var regex in GetRegexList())
            {
                var currentReg = new Regex(regex);
                var cleanHtml = currentReg.Replace(args.ExternalPageContent, "");
                args.ExternalPageContent = cleanHtml;
            }
        }
        /// <summary>
        /// Returns list of strings containing regular expressions that have been set in configuration
        /// </summary>
        private static IEnumerable<string> GetRegexList()
        {   
            var configNode = Factory.GetConfigNode(_sanitizeNode);
            var regexList = new List<string>();

            foreach (XmlNode childNode in configNode.ChildNodes)
            {
                regexList.Add(XmlUtil.GetAttribute("value", childNode));
            }

            return regexList;
        }
    }
}
