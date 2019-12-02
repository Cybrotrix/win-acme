﻿using Fclp;
using PKISharp.WACS.Configuration;

namespace PKISharp.WACS.Plugins.TargetPlugins
{
    internal class IISBindingsArgumentsProvider : BaseArgumentsProvider<IISBindingsArguments>
    {
        public override string Name => "IIS plugin";
        public override string Group => "Target";
        public override string Condition => "--target iis";

        public override void Configure(FluentCommandLineParser<IISBindingsArguments> parser)
        {
            parser.Setup(o => o.SiteId)
                .As("siteid")
                .WithDescription("Identifier of a site to include (optional).");
            parser.Setup(o => o.SiteIds)
                .As("siteids")
                .WithDescription("Comma separated list of site identifiers to include (optional).");
            parser.Setup(o => o.Host)
                .As("host")
                .WithDescription("Host name to filter. This parameter may be used to target a single, " +
                "specific binding.");
            parser.Setup(o => o.Host)
                .As("hosts")
                .WithDescription("Comma separated list of host names to filter. This parameter may be used " +
                "to target multiple specific bindings.");
            parser.Setup(o => o.Pattern)
                .As("hosts-pattern")
                .WithDescription("Pattern filter for host names. Can be used to dynamically include bindings " +
                "based on their match with the pattern. You may use a `*` for a range of any characters and a `?` " +
                "for any single character. For example: the pattern `example.*` will match `example.net` and " +
                "`example.com` (but not `my.example.com`) and the pattern `?.example.com` will match " +
                "`a.example.com` and `b.example.com` (but not `www.example.com`).");
            parser.Setup(o => o.Regex)
                .As("hosts-regex")
                .WithDescription("Regex pattern filter for host names. Some people, when confronted with a " +
                "problem, think \"I know, I'll use regular expressions.\" Now they have two problems.");
        }
    }
}