# Sitecore-FXM-SanitizeContent
Custom processor that accepts a series of regular expressions in configuration, and uses them to strip out any problematic content that may be causing issues when loading up the FXM Experience Editor.

## Sample Configuration
You can add as many regular expressions as you need to. In the configuration below, I added a regular expression (thanks Andy Uzick for the help) to strip out any script that contained the words "adobetm".

```
<fxmSanitizeExternalContent>
    <sanitizeRegex value="&lt;script[^&lt;]*(adobedtm)[\s\S]*?&lt;/script&gt;"/>
</fxmSanitizeExternalContent>
```