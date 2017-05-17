#define USE_PARSER2
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Diagnostics;
using RichTextParser;

internal struct ParserValue
{
    internal IRichText TextValue;
    internal List<IRichText> TextValues;
    internal HyperTextAttr AttrValue;
    internal List<HyperTextAttr> AttrValues;
    internal string StringValue;

    #region test string
    internal const string c_TestText = @"<!DOCTYPE html>
<html dir='ltr' xmlns='http://www.w3.org/1999/xhtml' lang='en'>
<head>
    <link rel='canonical' href='https://msdn.microsoft.com/en-us/library/az24scfc(v=vs.110).aspx' />
</head>
<body class='library Chrome'>
    <div>
        <h2 class='LW_CollapsibleArea_TitleDiv'>
            <div>
                <a class='LW_CollapsibleArea_TitleAhref' title='Collapse' role='heading'><span class='cl_CollapsibleArea_expanding LW_CollapsibleArea_Img'></span><span class='LW_CollapsibleArea_Title'>Quantifiers</span></a><div id='Anchor_4' class='LW_CollapsibleArea_Anchor_Div'><a href='/en-us/library/az24scfc#Anchor_4' class='LW_CollapsibleArea_Anchor_Img' title='Right-click to copy and share the link for this section'></a></div>
                <div class='LW_CollapsibleArea_HrDiv'>
                    <hr class='LW_CollapsibleArea_Hr' />
                </div>
            </div>
        </h2>
        <div class='sectionblock'><a id='Quantifiers'></a></div>
    </div>
    <p>A quantifier specifies how many instances of the previous element (which can be a character, a group, or a character class) must be present in the input string for a match to occur. Quantifiers include the language elements listed in the following table. For more information, see <a href='https://msdn.microsoft.com/en-us/library/3206d374'>Quantifiers</a>.</p>
    <table responsive='true' summary='table'>
        <thead>
            <tr responsive='true'>
                <th scope='col'>Quantifier</th>
                <th scope='col'>Description</th>
                <th scope='col'>Pattern</th>
                <th scope='col'>Matches</th>
            </tr>
        </thead>
        <tbody>
            <tr>
                <td data-th='Quantifier'><code>*</code></td>
                <td data-th='Description'>Matches the previous element zero or more times.</td>
                <td data-th='Pattern'><code>\d*\.\d</code></td>
                <td data-th='Matches'>'.0', '19.9', '219.9'</td>
            </tr>
            <tr>
                <td data-th='Quantifier'><code>+</code></td>
                <td data-th='Description'>Matches the previous element one or more times.</td>
                <td data-th='Pattern'><code>'be+'</code></td>
                <td data-th='Matches'>'bee' in 'been', 'be' in 'bent'</td>
            </tr>
            <tr>
                <td data-th='Quantifier'><code>?</code></td>
                <td data-th='Description'>Matches the previous element zero or one time.</td>
                <td data-th='Pattern'><code>'rai?n'</code></td>
                <td data-th='Matches'>'ran', 'rain'</td>
            </tr>
            <tr>
                <td data-th='Quantifier'><code>{</code> <em>n</em> <code>}</code></td>
                <td data-th='Description'>Matches the previous element exactly <em>n</em> times.</td>
                <td data-th='Pattern'><code>',\d{3}'</code></td>
                <td data-th='Matches'>',043' in '1,043.6', ',876', ',543', and ',210' in '9,876,543,210'</td>
            </tr>
            <tr>
                <td data-th='Quantifier'><code>{</code> <em>n</em> <code>,}</code></td>
                <td data-th='Description'>Matches the previous element at least <em>n</em> times.</td>
                <td data-th='Pattern'><code>'\d{2,}'</code></td>
                <td data-th='Matches'>'166', '29', '1930'</td>
            </tr>
            <tr>
                <td data-th='Quantifier'><code>{</code> <em>n</em> <code>,</code> <em>m</em> <code>}</code></td>
                <td data-th='Description'>Matches the previous element at least <em>n</em> times, but no more than <em>m</em> times.</td>
                <td data-th='Pattern'><code>'\d{3,5}'</code></td>
                <td data-th='Matches'>'166', '17668'<br />
                    <br />
                    '19302' in '193024'</td>
            </tr>
            <tr>
                <td data-th='Quantifier'><code>*?</code></td>
                <td data-th='Description'>Matches the previous element zero or more times, but as few times as possible.</td>
                <td data-th='Pattern'><code>\d*?\.\d</code></td>
                <td data-th='Matches'>'.0', '19.9', '219.9'</td>
            </tr>
            <tr>
                <td data-th='Quantifier'><code>+?</code></td>
                <td data-th='Description'>Matches the previous element one or more times, but as few times as possible.</td>
                <td data-th='Pattern'><code>'be+?'</code></td>
                <td data-th='Matches'>'be' in 'been', 'be' in 'bent'</td>
            </tr>
            <tr>
                <td data-th='Quantifier'><code>??</code></td>
                <td data-th='Description'>Matches the previous element zero or one time, but as few times as possible.</td>
                <td data-th='Pattern'><code>'rai??n'</code></td>
                <td data-th='Matches'>'ran', 'rain'</td>
            </tr>
            <tr>
                <td data-th='Quantifier'><code>{</code> <em>n</em> <code>}?</code></td>
                <td data-th='Description'>Matches the preceding element exactly <em>n</em> times.</td>
                <td data-th='Pattern'><code>',\d{3}?'</code></td>
                <td data-th='Matches'>',043' in '1,043.6', ',876', ',543', and ',210' in '9,876,543,210'</td>
            </tr>
            <tr>
                <td data-th='Quantifier'><code>{</code> <em>n</em> <code>,}?</code></td>
                <td data-th='Description'>Matches the previous element at least <em>n</em> times, but as few times as possible.</td>
                <td data-th='Pattern'><code>'\d{2,}?'</code></td>
                <td data-th='Matches'>'166', '29', '1930'</td>
            </tr>
            <tr>
                <td data-th='Quantifier'><code>{</code> <em>n</em> <code>,</code> <em>m</em> <code>}?</code></td>
                <td data-th='Description'>Matches the previous element between <em>n</em> and <em>m</em> times, but as few times as possible.</td>
                <td data-th='Pattern'><code>'\d{3,5}?'</code></td>
                <td data-th='Matches'>'166', '17668'<br />
                    <br />
                    '193', '024' in '193024'</td>
            </tr>
        </tbody>
    </table>
    <p><a href='#top'>Back to top</a></p>
    <p><a id='backreference_constructs'></a></p>
    <div>
        <h2 class='LW_CollapsibleArea_TitleDiv'>
            <div>
                <a class='LW_CollapsibleArea_TitleAhref' title='Collapse' role='heading'><span class='cl_CollapsibleArea_expanding LW_CollapsibleArea_Img'></span><span class='LW_CollapsibleArea_Title'>Backreference Constructs</span></a><div id='Anchor_5' class='LW_CollapsibleArea_Anchor_Div'><a href='/en-us/library/az24scfc#Anchor_5' class='LW_CollapsibleArea_Anchor_Img' title='Right-click to copy and share the link for this section'></a></div>
                <div class='LW_CollapsibleArea_HrDiv'>
                    <hr class='LW_CollapsibleArea_Hr' />
                </div>
            </div>
        </h2>
        <div class='sectionblock'><a id='Backreference-Constructs'></a></div>
    </div>
    <p>A backreference allows a previously matched subexpression to be identified subsequently in the same regular expression. The following table lists the backreference constructs supported by regular expressions in the .NET Framework. For more information, see <a href='https://msdn.microsoft.com/en-us/library/thwdfzxy'>Backreference Constructs</a>.</p>
    <p>
        <a href='https://msdn.microsoft.com/en-us/library/system.text.regularexpressions'>System.Text.RegularExpressions</a><br />
        <a href='https://msdn.microsoft.com/en-us/library/system.text.regularexpressions.regex'>Regex</a><br />
        <a href='https://msdn.microsoft.com/en-us/library/hs600312'>.NET Framework Regular Expressions</a><br />
        <a href='https://msdn.microsoft.com/en-us/library/30wbz966'>Regular Expression Classes</a><br />
        <a href='https://msdn.microsoft.com/en-us/library/kweb790z'>Regular Expression Examples</a><br />
        <a href='http://download.microsoft.com/download/D/2/4/D240EBF6-A9BA-4E4F-A63F-AEB6DA0B921C/Regular%20expressions%20quick%20reference.docx'>Regular Expressions - Quick Reference (download in Word format)</a><br />
        <a href='http://download.microsoft.com/download/D/2/4/D240EBF6-A9BA-4E4F-A63F-AEB6DA0B921C/Regular%20expressions%20quick%20reference.pdf'>Regular Expressions - Quick Reference (download in PDF format)</a>
    </p>
</body>
</html>";
    #endregion
}
#if !USE_PARSER2
internal partial class Parser
{
    static void Main(string[] args)
    {
        int count = 100;
        Console.WriteLine("[usage]RichTextParser textfile count");
        Console.WriteLine();
        Console.WriteLine("Now run {0} parses with preset text ...", count);
        string text = ParserValue.c_TestText;
        if (args.Length > 0) {
            string file = args[0];
            if (File.Exists(file)) {
                text = File.ReadAllText(file);
            } else {
                Console.WriteLine("Can't read file '{0}'", file);
                return;
            }
            if (args.Length > 1) {
                try {
                    count = int.Parse(args[1]);
                } catch {
                    Console.WriteLine("arg '{0}' error", args[1]);
                    return;
                }
            }
        }
        var parser = new Parser();
        Stopwatch w = new Stopwatch();
        w.Start();        
        for (int i = 0; i < count; ++i) {
            var result = parser.Parse(text);
        }
        double t = w.ElapsedTicks * 1000.0 / Stopwatch.Frequency;
        Console.WriteLine("elapsed {0}ms for {1} parses, {2}ms/parse", t, count, t / count);
    }
}
#else
internal partial class Parser2
{
    static void Main(string[] args)
    {
        int count = 100;
        Console.WriteLine("[usage]RichTextParser textfile count");
        Console.WriteLine();
        Console.WriteLine("Now run {0} parses with preset text ...", count);
        string text = ParserValue.c_TestText;
        if (args.Length > 0) {
            string file = args[0];
            if (File.Exists(file)) {
                text = File.ReadAllText(file);
            } else {
                Console.WriteLine("Can't read file '{0}'", file);
                return;
            }
            if (args.Length > 1) {
                try {
                    count = int.Parse(args[1]);
                } catch {
                    Console.WriteLine("arg '{0}' error", args[1]);
                    return;
                }
            }
        }
        var parser = new Parser2();
        Stopwatch w = new Stopwatch();
        w.Start();
        for (int i = 0; i < count; ++i) {
            var result = parser.Parse(text);
        }
        double t = w.ElapsedTicks * 1000.0 / Stopwatch.Frequency;
        Console.WriteLine("elapsed {0}ms for {1} parses, {2}ms/parse", t, count, t / count);
    }
}
#endif