﻿// ------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version: 14.0.0.0
//  
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
// ------------------------------------------------------------------------------
namespace TOTD.Mailer.Html
{
    using System.Linq;
    using System.Text;
    using System.Collections.Generic;
    using System;
    
    /// <summary>
    /// Class to produce the template output
    /// </summary>
    
    #line 1 "C:\Users\tdunc\Code\Projects\TOTD-Mailer\TOTD.Mailer.Html\Body.tt"
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.TextTemplating", "14.0.0.0")]
    public partial class Body : BodyBase
    {
#line hidden
        /// <summary>
        /// Create the template output
        /// </summary>
        public virtual string TransformText()
        {
            this.Write("<!DOCTYPE html>\r\n<html>\r\n<head>\r\n    <meta name=\"viewport\" content=\"width=device-" +
                    "width\">\r\n    <meta http-equiv=\"Content-Type\" content=\"text/html; charset=UTF-8\">" +
                    "\r\n    <title></title>\r\n    <style type=\"text/css\">\r\n        @media only screen a" +
                    "nd (max-width: 620px) {\r\n            table[class=body] h1 {\r\n                fon" +
                    "t-size: 28px !important;\r\n                margin-bottom: 10px !important;\r\n     " +
                    "       }\r\n\r\n            table[class=body] p,\r\n            table[class=body] ul,\r" +
                    "\n            table[class=body] ol,\r\n            table[class=body] td,\r\n         " +
                    "   table[class=body] span,\r\n            table[class=body] a {\r\n                f" +
                    "ont-size: 16px !important;\r\n            }\r\n\r\n            table[class=body] .wrap" +
                    "per,\r\n            table[class=body] .article {\r\n                padding: 10px !i" +
                    "mportant;\r\n            }\r\n\r\n            table[class=body] .content {\r\n          " +
                    "      padding: 0 !important;\r\n            }\r\n\r\n            table[class=body] .co" +
                    "ntainer {\r\n                padding: 0 !important;\r\n                width: 100% !" +
                    "important;\r\n            }\r\n\r\n            table[class=body] .main {\r\n            " +
                    "    border-left-width: 0 !important;\r\n                border-radius: 0 !importan" +
                    "t;\r\n                border-right-width: 0 !important;\r\n            }\r\n\r\n        " +
                    "    table[class=body] .btn table {\r\n                width: 100% !important;\r\n   " +
                    "         }\r\n\r\n            table[class=body] .btn a {\r\n                width: 100" +
                    "% !important;\r\n            }\r\n\r\n            table[class=body] .img-responsive {\r" +
                    "\n                height: auto !important;\r\n                max-width: 100% !impo" +
                    "rtant;\r\n                width: auto !important;\r\n            }\r\n        }\r\n     " +
                    "   @media all {\r\n            .ExternalClass {\r\n                width: 100%;\r\n   " +
                    "         }\r\n\r\n                .ExternalClass,\r\n                .ExternalClass p," +
                    "\r\n                .ExternalClass span,\r\n                .ExternalClass font,\r\n  " +
                    "              .ExternalClass td,\r\n                .ExternalClass div {\r\n        " +
                    "            line-height: 100%;\r\n                }\r\n\r\n            .apple-link a {" +
                    "\r\n                color: inherit !important;\r\n                font-family: inher" +
                    "it !important;\r\n                font-size: inherit !important;\r\n                " +
                    "font-weight: inherit !important;\r\n                line-height: inherit !importan" +
                    "t;\r\n                text-decoration: none !important;\r\n            }\r\n\r\n        " +
                    "    .btn-primary table td:hover {\r\n                background-color: #34495e !im" +
                    "portant;\r\n            }\r\n\r\n            .btn-primary a:hover {\r\n                b" +
                    "ackground-color: #34495e !important;\r\n                border-color: #34495e !imp" +
                    "ortant;\r\n            }\r\n        }\r\n    </style>\r\n</head>\r\n<body itemscope=\"items" +
                    "cope\" itemtype=\"http://schema.org/EmailMessage\" class=\"\" style=\"background-color" +
                    ":#f6f6f6;font-family:sans-serif;-webkit-font-smoothing:antialiased;font-size:14p" +
                    "x;line-height:1.4;margin:0;padding:0;-ms-text-size-adjust:100%;-webkit-text-size" +
                    "-adjust:100%;\">\r\n    <table border=\"0\" cellpadding=\"0\" cellspacing=\"0\" class=\"bo" +
                    "dy\" style=\"border-collapse:separate;mso-table-lspace:0pt;mso-table-rspace:0pt;ba" +
                    "ckground-color:#f6f6f6;width:100%;\">\r\n        <tr>\r\n            <td style=\"font-" +
                    "family:sans-serif;font-size:14px;vertical-align:top;\">&nbsp;</td>\r\n            <" +
                    "td class=\"container\" style=\"font-family:sans-serif;font-size:14px;vertical-align" +
                    ":top;display:block;max-width:580px;padding:10px;width:580px;Margin:0 auto !impor" +
                    "tant;\">\r\n                <div class=\"content\" style=\"box-sizing:border-box;displ" +
                    "ay:block;Margin:0 auto;max-width:580px;padding:10px;\">\r\n                    <!--" +
                    " START CENTERED WHITE CONTAINER -->\r\n                    <span class=\"preheader\"" +
                    " style=\"color:transparent;display:none;height:0;max-height:0;max-width:0;opacity" +
                    ":0;overflow:hidden;mso-hide:all;visibility:hidden;width:0;\">This is preheader te" +
                    "xt. Some clients will show this text as a preview.</span>\r\n                    <" +
                    "table class=\"main\" style=\"border-collapse:separate;mso-table-lspace:0pt;mso-tabl" +
                    "e-rspace:0pt;background:#fff;border-radius:3px;width:100%;\">\r\n                  " +
                    "      <!-- START MAIN CONTENT AREA -->\r\n                        <tr>\r\n          " +
                    "                  <td class=\"wrapper\" style=\"font-family:sans-serif;font-size:14" +
                    "px;vertical-align:top;box-sizing:border-box;padding:20px;\">\r\n                   " +
                    "             <table border=\"0\" cellpadding=\"0\" cellspacing=\"0\" style=\"border-col" +
                    "lapse:separate;mso-table-lspace:0pt;mso-table-rspace:0pt;width:100%;\">\r\n        " +
                    "                            <tr>\r\n                                        <td st" +
                    "yle=\"font-family:sans-serif;font-size:14px;vertical-align:top;\">\r\n              " +
                    "                              ");
            
            #line 111 "C:\Users\tdunc\Code\Projects\TOTD-Mailer\TOTD.Mailer.Html\Body.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(Content));
            
            #line default
            #line hidden
            this.Write(@"
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <!-- END MAIN CONTENT AREA -->
                    </table>
                    ");
            
            #line 119 "C:\Users\tdunc\Code\Projects\TOTD-Mailer\TOTD.Mailer.Html\Body.tt"
 if(Footer !=null) {
            
            #line default
            #line hidden
            this.Write(@"                    <!-- START FOOTER -->
                    <div class=""footer"" style=""clear:both;padding-top:10px;text-align:center;width:100%;"">
                        <table border=""0"" cellpadding=""0"" cellspacing=""0"" style=""border-collapse:separate;mso-table-lspace:0pt;mso-table-rspace:0pt;width:100%;"">
                            <tr>
                                <td class=""content-block"" style=""font-family:sans-serif;font-size:14px;vertical-align:top;color:#999999;font-size:12px;text-align:center;"">
                                    ");
            
            #line 125 "C:\Users\tdunc\Code\Projects\TOTD-Mailer\TOTD.Mailer.Html\Body.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(Footer));
            
            #line default
            #line hidden
            this.Write("\r\n                                </td>\r\n                            </tr>\r\n     " +
                    "                   </table>\r\n                    </div>\r\n                    <!-" +
                    "- END FOOTER -->\r\n                    ");
            
            #line 131 "C:\Users\tdunc\Code\Projects\TOTD-Mailer\TOTD.Mailer.Html\Body.tt"
 }
            
            #line default
            #line hidden
            this.Write("                    <!-- END CENTERED WHITE CONTAINER -->\r\n                </div>" +
                    "\r\n            </td>\r\n            <td style=\"font-family:sans-serif;font-size:14p" +
                    "x;vertical-align:top;\">&nbsp;</td>\r\n        </tr>\r\n    </table>\r\n</body>\r\n</html" +
                    ">\r\n");
            return this.GenerationEnvironment.ToString();
        }
    }
    
    #line default
    #line hidden
    #region Base class
    /// <summary>
    /// Base class for this transformation
    /// </summary>
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.TextTemplating", "14.0.0.0")]
    public class BodyBase
    {
        #region Fields
        private global::System.Text.StringBuilder generationEnvironmentField;
        private global::System.CodeDom.Compiler.CompilerErrorCollection errorsField;
        private global::System.Collections.Generic.List<int> indentLengthsField;
        private string currentIndentField = "";
        private bool endsWithNewline;
        private global::System.Collections.Generic.IDictionary<string, object> sessionField;
        #endregion
        #region Properties
        /// <summary>
        /// The string builder that generation-time code is using to assemble generated output
        /// </summary>
        protected System.Text.StringBuilder GenerationEnvironment
        {
            get
            {
                if ((this.generationEnvironmentField == null))
                {
                    this.generationEnvironmentField = new global::System.Text.StringBuilder();
                }
                return this.generationEnvironmentField;
            }
            set
            {
                this.generationEnvironmentField = value;
            }
        }
        /// <summary>
        /// The error collection for the generation process
        /// </summary>
        public System.CodeDom.Compiler.CompilerErrorCollection Errors
        {
            get
            {
                if ((this.errorsField == null))
                {
                    this.errorsField = new global::System.CodeDom.Compiler.CompilerErrorCollection();
                }
                return this.errorsField;
            }
        }
        /// <summary>
        /// A list of the lengths of each indent that was added with PushIndent
        /// </summary>
        private System.Collections.Generic.List<int> indentLengths
        {
            get
            {
                if ((this.indentLengthsField == null))
                {
                    this.indentLengthsField = new global::System.Collections.Generic.List<int>();
                }
                return this.indentLengthsField;
            }
        }
        /// <summary>
        /// Gets the current indent we use when adding lines to the output
        /// </summary>
        public string CurrentIndent
        {
            get
            {
                return this.currentIndentField;
            }
        }
        /// <summary>
        /// Current transformation session
        /// </summary>
        public virtual global::System.Collections.Generic.IDictionary<string, object> Session
        {
            get
            {
                return this.sessionField;
            }
            set
            {
                this.sessionField = value;
            }
        }
        #endregion
        #region Transform-time helpers
        /// <summary>
        /// Write text directly into the generated output
        /// </summary>
        public void Write(string textToAppend)
        {
            if (string.IsNullOrEmpty(textToAppend))
            {
                return;
            }
            // If we're starting off, or if the previous text ended with a newline,
            // we have to append the current indent first.
            if (((this.GenerationEnvironment.Length == 0) 
                        || this.endsWithNewline))
            {
                this.GenerationEnvironment.Append(this.currentIndentField);
                this.endsWithNewline = false;
            }
            // Check if the current text ends with a newline
            if (textToAppend.EndsWith(global::System.Environment.NewLine, global::System.StringComparison.CurrentCulture))
            {
                this.endsWithNewline = true;
            }
            // This is an optimization. If the current indent is "", then we don't have to do any
            // of the more complex stuff further down.
            if ((this.currentIndentField.Length == 0))
            {
                this.GenerationEnvironment.Append(textToAppend);
                return;
            }
            // Everywhere there is a newline in the text, add an indent after it
            textToAppend = textToAppend.Replace(global::System.Environment.NewLine, (global::System.Environment.NewLine + this.currentIndentField));
            // If the text ends with a newline, then we should strip off the indent added at the very end
            // because the appropriate indent will be added when the next time Write() is called
            if (this.endsWithNewline)
            {
                this.GenerationEnvironment.Append(textToAppend, 0, (textToAppend.Length - this.currentIndentField.Length));
            }
            else
            {
                this.GenerationEnvironment.Append(textToAppend);
            }
        }
        /// <summary>
        /// Write text directly into the generated output
        /// </summary>
        public void WriteLine(string textToAppend)
        {
            this.Write(textToAppend);
            this.GenerationEnvironment.AppendLine();
            this.endsWithNewline = true;
        }
        /// <summary>
        /// Write formatted text directly into the generated output
        /// </summary>
        public void Write(string format, params object[] args)
        {
            this.Write(string.Format(global::System.Globalization.CultureInfo.CurrentCulture, format, args));
        }
        /// <summary>
        /// Write formatted text directly into the generated output
        /// </summary>
        public void WriteLine(string format, params object[] args)
        {
            this.WriteLine(string.Format(global::System.Globalization.CultureInfo.CurrentCulture, format, args));
        }
        /// <summary>
        /// Raise an error
        /// </summary>
        public void Error(string message)
        {
            System.CodeDom.Compiler.CompilerError error = new global::System.CodeDom.Compiler.CompilerError();
            error.ErrorText = message;
            this.Errors.Add(error);
        }
        /// <summary>
        /// Raise a warning
        /// </summary>
        public void Warning(string message)
        {
            System.CodeDom.Compiler.CompilerError error = new global::System.CodeDom.Compiler.CompilerError();
            error.ErrorText = message;
            error.IsWarning = true;
            this.Errors.Add(error);
        }
        /// <summary>
        /// Increase the indent
        /// </summary>
        public void PushIndent(string indent)
        {
            if ((indent == null))
            {
                throw new global::System.ArgumentNullException("indent");
            }
            this.currentIndentField = (this.currentIndentField + indent);
            this.indentLengths.Add(indent.Length);
        }
        /// <summary>
        /// Remove the last indent that was added with PushIndent
        /// </summary>
        public string PopIndent()
        {
            string returnValue = "";
            if ((this.indentLengths.Count > 0))
            {
                int indentLength = this.indentLengths[(this.indentLengths.Count - 1)];
                this.indentLengths.RemoveAt((this.indentLengths.Count - 1));
                if ((indentLength > 0))
                {
                    returnValue = this.currentIndentField.Substring((this.currentIndentField.Length - indentLength));
                    this.currentIndentField = this.currentIndentField.Remove((this.currentIndentField.Length - indentLength));
                }
            }
            return returnValue;
        }
        /// <summary>
        /// Remove any indentation
        /// </summary>
        public void ClearIndent()
        {
            this.indentLengths.Clear();
            this.currentIndentField = "";
        }
        #endregion
        #region ToString Helpers
        /// <summary>
        /// Utility class to produce culture-oriented representation of an object as a string.
        /// </summary>
        public class ToStringInstanceHelper
        {
            private System.IFormatProvider formatProviderField  = global::System.Globalization.CultureInfo.InvariantCulture;
            /// <summary>
            /// Gets or sets format provider to be used by ToStringWithCulture method.
            /// </summary>
            public System.IFormatProvider FormatProvider
            {
                get
                {
                    return this.formatProviderField ;
                }
                set
                {
                    if ((value != null))
                    {
                        this.formatProviderField  = value;
                    }
                }
            }
            /// <summary>
            /// This is called from the compile/run appdomain to convert objects within an expression block to a string
            /// </summary>
            public string ToStringWithCulture(object objectToConvert)
            {
                if ((objectToConvert == null))
                {
                    throw new global::System.ArgumentNullException("objectToConvert");
                }
                System.Type t = objectToConvert.GetType();
                System.Reflection.MethodInfo method = t.GetMethod("ToString", new System.Type[] {
                            typeof(System.IFormatProvider)});
                if ((method == null))
                {
                    return objectToConvert.ToString();
                }
                else
                {
                    return ((string)(method.Invoke(objectToConvert, new object[] {
                                this.formatProviderField })));
                }
            }
        }
        private ToStringInstanceHelper toStringHelperField = new ToStringInstanceHelper();
        /// <summary>
        /// Helper to produce culture-oriented representation of an object as a string
        /// </summary>
        public ToStringInstanceHelper ToStringHelper
        {
            get
            {
                return this.toStringHelperField;
            }
        }
        #endregion
    }
    #endregion
}
